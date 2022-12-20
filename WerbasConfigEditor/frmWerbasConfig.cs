using Data.Entity;
using XML.Contract;

namespace WerbasConfigEditor
{
    /// <summary>
    /// Form to Configure multiple Servers and Clients 
    /// </summary>
    public partial class frmConfigEditor : Form
    {
        #region Private Members

        private readonly IXmlManager _xmlManager;

        private string _selectedServerPath = string.Empty;
        private string _selectedClientPath = string.Empty;

        private Config _config = new Config();
        private const int COLUMN_WIDTH = 60;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="xmlManager"></param>
        public frmConfigEditor(IXmlManager xmlManager)
        {
            InitializeComponent();

            _xmlManager = xmlManager;
        }

        #endregion

        #region Events

        /// <summary>
        /// Initialize Form while Loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConfigEditor_Load(object sender, EventArgs e)
        {
            _xmlManager.CheckAndInitializeXml();
            this.ReadXmlDocument();
        }

        /// <summary>
        /// Create a local XML File with all ConnectionStrings which can be used as a Template
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConnectionStrings_Click(object sender, EventArgs e)
        {
            _xmlManager.SaveConnectionStrings();
        }

        /// <summary>
        /// Validation if Saving the Server is allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtServerPath.Text) && !String.IsNullOrEmpty(this.txtServerConnectionString.Text))
            {
                this.btnSaveServer.Enabled = true;
            }
        }

        /// <summary>
        /// Validation if Saving the Client is allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClientPath_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtClientPath.Text) && (this.optTSClientYes.Checked || this.optTSClientNo.Checked))
            {
                this.btnSaveClient.Enabled = true;
            }
        }

        /// <summary>
        /// Add a new Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddServer_Click(object sender, EventArgs e)
        {
            this.txtServerPath.Text = String.Empty;
            this.txtServerConnectionString.Text = String.Empty;
            _selectedServerPath = string.Empty;

            this.btnSaveServer.Enabled = false;
            this.btnDeleteServer.Enabled = false;

            this.txtServerPath.Focus();
        }

        /// <summary>
        /// Add a new Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            this.txtClientPath.Text = String.Empty;
            this.optTSClientYes.Checked = false;
            this.optTSClientNo.Checked = false;
            _selectedClientPath = string.Empty;

            this.btnSaveClient.Enabled = false;
            this.btnDeleteClient.Enabled = false;

            this.txtClientPath.Focus();
        }

        /// <summary>
        /// Save the currently added or updated Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveServer_Click(object sender, EventArgs e)
        {
            var serverPath = this.txtServerPath.Text.TrimEnd();
            var serverConnectionString = this.txtServerConnectionString.Text.TrimEnd();

            if (!String.IsNullOrEmpty(serverPath) && !String.IsNullOrEmpty(serverConnectionString))
            {
                var serverToAdd = _config.Servers.FirstOrDefault(s => s.Path == serverPath && s.ConnectionString == serverConnectionString);

                if (serverToAdd != null)
                {
                    MessageBox.Show("Es gibt bereits einen Server mit diesen Werten", "Speichern", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _xmlManager.AddOrUpdateServer(serverPath, serverConnectionString, _selectedServerPath);

                this.ReadXmlDocument();
            }
        }

        /// <summary>
        /// Save the currently added or updated Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            var clientPath = this.txtClientPath.Text.TrimEnd();
            var isTsClient = this.optTSClientYes.Checked;

            if (!String.IsNullOrEmpty(clientPath))
            {
                var clientToAdd = _config.Clients.FirstOrDefault(s => s.Path == clientPath && s.IsTsClient == isTsClient);

                if (clientToAdd != null)
                {
                    MessageBox.Show("Es gibt bereits einen Client mit diesen Werten", "Speichern", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _xmlManager.AddOrUpdateClient(clientPath, isTsClient, _selectedClientPath);

                this.ReadXmlDocument();
            }
        }

        /// <summary>
        /// Delete the current selected Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            var serverPath = this.txtServerPath.Text.TrimEnd();
            var serverConnectionString = this.txtServerConnectionString.Text.TrimEnd();

            if (!String.IsNullOrEmpty(serverPath) && !String.IsNullOrEmpty(serverConnectionString))
            {
                _xmlManager.DeleteServer(serverPath, serverConnectionString);

                this.ReadXmlDocument();
            }
        }

        /// <summary>
        /// Delete the current selected Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            var clientPath = this.txtClientPath.Text.TrimEnd();
            var isTsClient = this.optTSClientYes.Checked;

            if (!String.IsNullOrEmpty(clientPath))
            {
                _xmlManager.DeleteClient(clientPath, isTsClient);

                this.ReadXmlDocument();
            }
        }

        /// <summary>
        /// Load the actual selected Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstServerList_Click(object sender, EventArgs e)
        {
            if (this.lstServerList.SelectedIndex < 1 || this.lstServerList.Items.Count == 0)
            {
                return;
            }

            var serverPathArray = this.lstServerList.SelectedItem.ToString().Split('|');
            var serverPath = serverPathArray[0];

            if (String.IsNullOrEmpty(serverPath))
            {
                return;
            }

            var selectedServer = _xmlManager.GetServerByPathOrDefault(serverPath);

            if (selectedServer != null)
            {
                this.txtServerPath.Text = selectedServer.Path;
                this.txtServerConnectionString.Text = selectedServer.ConnectionString;

                _selectedServerPath = selectedServer.Path;

                this.btnDeleteServer.Enabled = true;
                this.btnSaveServer.Enabled = true;
            }
        }

        /// <summary>
        /// Load the actual selected Client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstClientList_Click(object sender, EventArgs e)
        {
            if (this.lstClientList.SelectedIndex < 1 || this.lstClientList.Items.Count == 0)
            {
                return;
            }

            var clientPathArray = this.lstClientList.SelectedItem.ToString().Split('|');
            var clientPath = clientPathArray[0];

            if (String.IsNullOrEmpty(clientPath))
            {
                return;
            }

            var selectedClient = _xmlManager.GetClientByPathOrDefault(clientPath);

            if (selectedClient != null)
            {
                this.txtClientPath.Text = selectedClient.Path;
                this.optTSClientYes.Checked = selectedClient.IsTsClient;
                this.optTSClientNo.Checked = !selectedClient.IsTsClient;

                _selectedClientPath = selectedClient.Path;

                this.btnDeleteClient.Enabled = true;
                this.btnSaveClient.Enabled = true;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Read the XML Document and add its data to the local DataSet
        /// </summary>
        private void ReadXmlDocument()
        {
            this.lstServerList.Items.Clear();
            this.lstClientList.Items.Clear();

            _config = _xmlManager.GetAll();

            //Listbox Headers
            this.lstServerList.Items.Add("Path".PadRight(COLUMN_WIDTH) + " | " + "ConnectionString");
            this.lstClientList.Items.Add("Path".PadRight(COLUMN_WIDTH) + " | " + "IsTsClient");

            //Fill Server and Client Lists with the loaded Data
            foreach (var server in _config.Servers)
            {
                this.lstServerList.Items.Add(server.Path.PadRight(COLUMN_WIDTH) + " | " + server.ConnectionString);
            }

            foreach (var client in _config.Clients)
            {
                this.lstClientList.Items.Add(client.Path.PadRight(COLUMN_WIDTH) + " | " + client.IsTsClient.ToString());
            }

            this.InitializeUI();
        }

        /// <summary>
        /// Initialize UI to Default
        /// </summary>
        private void InitializeUI()
        {
            this.txtServerPath.Text = String.Empty;
            this.txtServerConnectionString.Text = String.Empty;
            this.txtClientPath.Text = String.Empty;
            this.optTSClientNo.Checked = false;
            this.optTSClientYes.Checked = false;

            this.btnSaveServer.Enabled = false;
            this.btnDeleteServer.Enabled = false;
            this.btnSaveClient.Enabled = false;
            this.btnDeleteClient.Enabled = false;

            this.btnSaveConnectionStrings.Enabled = this.lstServerList.Items.Count > 0;

            if (this.lstServerList.Items.Count > 1)
            {
                this.lstServerList.SelectedIndex = 1;
                this.lstServerList_Click(this, new EventArgs());
            }
            if (this.lstClientList.Items.Count > 1)
            {
                this.lstClientList.SelectedIndex = 1;
                this.lstClientList_Click(this, new EventArgs());
            }
        }

        #endregion

    }
}