using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Data;
using XML.Contract;

namespace WerbasConfigEditor
{
    public partial class frmConfigEditor : Form
    {
        #region Private Members

        private readonly IXmlManager _xmlManager;

        private string _selectedServerPath = string.Empty;
        private string _selectedClientPath = string.Empty;

        private Config _config = new Config();

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

        private void frmConfigEditor_Load(object sender, EventArgs e)
        {
            _xmlManager.CheckAndInitializeXml();
            this.ReadXmlDocument();
        }


        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtServerPath.Text) && !String.IsNullOrEmpty(this.txtServerConnectionString.Text))
            {
                this.btnSaveServer.Enabled = true;
            }
        }

        //Add a new Server
        private void btnAddServer_Click(object sender, EventArgs e)
        {
            this.txtServerPath.Text = String.Empty;
            this.txtServerConnectionString.Text = String.Empty;
            _selectedServerPath = string.Empty;

            this.btnSaveServer.Enabled = false;
            this.btnDeleteServer.Enabled = false;

            this.txtServerPath.Focus();
        }

        //Add a new Client
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            this.txtClientPath.Text = String.Empty;
            this.optTSClientYes.Checked = false;
            this.optTSClientNo.Checked = false;
            _selectedClientPath = string.Empty;

            this.btnSaveClient.Enabled = false;
            this.btnDeleteClient.Enabled = false;
        }

        //Save the actual Server
        private void btnSaveServer_Click(object sender, EventArgs e)
        {
            //Check if Path already Exist
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

                //Is Server a new one or an update of a previous selected
                _xmlManager.AddOrUpdateServer(serverPath, serverConnectionString, _selectedServerPath);

                this.ReadXmlDocument();
            }
        }

        //Delete the selected Server
        private void btnDeleteServer_Click(object sender, EventArgs e)
        {
            var serverPath = this.txtServerPath.Text.TrimEnd();
            var serverConnectionString = this.txtServerConnectionString.Text.TrimEnd();

            if (!String.IsNullOrEmpty(serverPath) && !String.IsNullOrEmpty(serverConnectionString))
            {
                _xmlManager.DeleteServer(serverPath, _selectedServerPath);
                
                this.ReadXmlDocument();
            }
        }

        //Load the actual selected Server from the local DataSet
        private void lstServerList_Click(object sender, EventArgs e)
        {
            var serverPath = this.lstServerList.SelectedItem.ToString();

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

            //Fill Server and Client Lists with the loaded Data
            foreach (var server in _config.Servers)
            {
                this.lstServerList.Items.Add(server.Path);
            }
            foreach (var client in _config.Clients)
            {
                this.lstClientList.Items.Add(client.Path);
            }

            this.InitializeUI();
        }

        //Initialize UI to Default
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
        }

        #endregion


    }
}