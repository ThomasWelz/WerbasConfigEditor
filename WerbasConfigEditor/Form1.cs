using System.Xml;
using WerbasConfigEditor.Entity;

namespace WerbasConfigEditor
{
    public partial class frmConfigEditor : Form
    {
        #region Private Members

        private const string WERBAS_DIRECTORY_PATH = @"C:\Werbas";
        private const string XML_FILE_PATH = @"C:\Werbas\ConfigEditor.xml";

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public frmConfigEditor()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void frmConfigEditor_Load(object sender, EventArgs e)
        {
            //Check if XML File is available -> if not - create it
            var xmlExist = File.Exists(XML_FILE_PATH);

            if (!xmlExist)
            {
                this.InitializeXmlDocument();
            }
            else
            {
                this.Servers = new List<Server>();
                this.ReadXmlDocument();
            }
        }

        //Save the actual Server
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveXmlDocument();
        }

        //Delete the selected Server
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var xmlDoc = this.LoadXmlDocument();

            XmlNodeList? serverNodeList = xmlDoc.SelectSingleNode("Servers")?.ChildNodes;
            var serverPath = this.lstServerList.SelectedItem.ToString();
            bool serverDeleted = false;

            if (serverNodeList != null)
            {
                for (int i = 0; i < serverNodeList.Count; i++)
                {
                    if (this.IsServerNodeValid(serverNodeList[i]))
                    {
                        var server = xmlDoc.ImportNode(serverNodeList[i], true);

                        foreach (XmlAttribute attribute in serverNodeList[i].Attributes)
                        {
                            if (attribute.Value == serverPath)
                            {
                                server.RemoveAll();
                                serverDeleted = true;
                                break;
                            }
                        }

                        if (serverDeleted)
                        {
                            break;
                        }
                    }
                }

                if (serverDeleted)
                {
                    xmlDoc.Save(XML_FILE_PATH);
                }
            }
        }

        //Refresh the selected Server Attributes
        private void lstServerList_Click(object sender, EventArgs e)
        {
            var xmlDoc = this.LoadXmlDocument();

            XmlNodeList? serverNodeList = xmlDoc.SelectSingleNode("Servers")?.ChildNodes;
            var serverPath = this.lstServerList.SelectedItem.ToString();

            if (serverNodeList != null)
            {
                for (int i = 0; i < serverNodeList.Count; i++)
                {
                    if (this.IsServerNodeValid(serverNodeList[i]))
                    {
                        if (serverNodeList[i].Attributes[0].Value == serverPath)
                        {
                            this.txtServerPath.Text = serverNodeList[i].Attributes[0].Value;
                            this.txtServerConnectionString.Text = serverNodeList[i].Attributes[1].Value;
                        }
                    }
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of all Servers inside of the XML File
        /// </summary>
        private List<Server> Servers { get; set; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Save a new Server to the XML File
        /// </summary>
        private void SaveXmlDocument()
        {
            var xmlDoc = this.LoadXmlDocument();

            var newServer = new Server()
            {
                ConnectionString = this.txtServerConnectionString.Text,
                Path = this.txtServerPath.Text
            };

            var serversNode = xmlDoc.SelectSingleNode("Servers");
            XmlElement server = xmlDoc.CreateElement("Server");
            serversNode.AppendChild(server);

            XmlAttribute path = xmlDoc.CreateAttribute("Path");
            path.Value = newServer.Path;
            server.Attributes.Append(path);

            XmlAttribute conString = xmlDoc.CreateAttribute("ConnectionString");
            conString.Value = newServer.ConnectionString;
            server.Attributes.Append(conString);

            xmlDoc.Save(XML_FILE_PATH);

            this.ReadXmlDocument();
        }

        /// <summary>
        /// Read the XML Document, list all the Servers
        /// </summary>
        private void ReadXmlDocument()
        {
            this.Servers.Clear();
            this.lstServerList.Items.Clear();

            var xmlDoc = this.LoadXmlDocument();
            XmlNodeList? serverNodeList = xmlDoc.SelectSingleNode("Servers")?.ChildNodes;

            if (serverNodeList != null)
            {
                for (int i = 0; i < serverNodeList.Count; i++)
                {
                    var serverElement = serverNodeList[i];

                    if (this.IsServerNodeValid(serverElement))
                    {
                        var loadedServer = new Server()
                        {
                            Path = serverElement.Attributes[0].Value,
                            ConnectionString = serverElement.Attributes[1].Value
                        };

                        //Add loaded Server to Server List and Server Listbox for further operations
                        this.Servers.Add(loadedServer);
                        this.lstServerList.Items.Add(loadedServer.Path);

                    }
                }
            }
        }

        /// <summary>
        /// Create and Initialize the Werbas Folder and the Config Editor XML File
        /// </summary>
        private void InitializeXmlDocument()
        {
            Directory.CreateDirectory(WERBAS_DIRECTORY_PATH);

            using (XmlWriter xmlWriter = XmlWriter.Create(XML_FILE_PATH))
            {
                xmlWriter.WriteStartDocument();

                xmlWriter.WriteStartElement("Servers");
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
            }
        }

        /// <summary>
        /// Checks if a given serverNode is valid and has all the attributes
        /// </summary>
        /// <param name="serverNode"></param>
        /// <returns>bool</returns>
        private bool IsServerNodeValid(XmlNode? serverNode)
        {
            var result = false;

            if (serverNode != null && serverNode.Attributes != null && serverNode.Attributes.Count == 2)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Loads the XML Document by the given Path
        /// </summary>
        /// <returns>XmlDocumentreturns>
        private XmlDocument LoadXmlDocument()
        {
            XmlDocument result = new XmlDocument();
            result.Load(XML_FILE_PATH);

            return result;
        }

        #endregion
    }
}