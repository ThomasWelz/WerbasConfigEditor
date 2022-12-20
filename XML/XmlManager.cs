using Data.Entity;
using System.Xml.Serialization;
using XML.Contract;

namespace XML
{
    /// <summary>
    /// Manager for all the XML Operations
    /// </summary>
    public class XmlManager : IXmlManager
    {
        #region Private Members

        private const string WERBAS_DIRECTORY_PATH = @"C:\Werbas";
        private const string PROD_XML_FILE_PATH = @"C:\Werbas\ConfigEditor.xml";
        private const string TEST_XML_FILE_PATH = @"C:\Werbas\Test.xml";

        private const string PROD_CON_XML_FILE_PATH = @"C:\Werbas\ConnectionStrings.xml";
        private const string TEST_CON_XML_FILE_PATH = @"C:\Werbas\ConnectionStringsTest.xml";

        private string _xmlFilePath = string.Empty;
        private string _conXmlFilePath = string.Empty;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public XmlManager()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Check if the needed XML File is avaiable -> if not create it
        /// </summary>
        /// <param name="isTestMode"></param>
        public void CheckAndInitializeXml(bool isTestMode = false)
        {
            if (isTestMode)
            {
                _xmlFilePath = TEST_XML_FILE_PATH;
                _conXmlFilePath = TEST_CON_XML_FILE_PATH;
                //Start with fresh Data
                File.Delete(_xmlFilePath);
                File.Delete(_conXmlFilePath);
            }
            else
            {
                _xmlFilePath = PROD_XML_FILE_PATH;
                _conXmlFilePath = PROD_CON_XML_FILE_PATH;
            }

            var xmlExist = File.Exists(_xmlFilePath);

            if (!xmlExist)
            {
                Directory.CreateDirectory(WERBAS_DIRECTORY_PATH);
                this.SaveToXml(new Config());
            }
        }

        #region Get

        /// <summary>
        /// Reads XML File and serialize it to an model structur
        /// </summary>
        /// <returns></returns>
        public Config GetAll()
        {
            FileInfo fileInfo = new FileInfo(_xmlFilePath);
            var result = new Config();

            if (fileInfo.Exists)
            {
                StreamReader reader = new StreamReader(_xmlFilePath);
                XmlSerializer serializer = new XmlSerializer(result.GetType());
                result = serializer.Deserialize(reader) as Config;
                reader.Close();
            }

            return result;
        }

        /// <summary>
        /// Get the first Server which is matching the given Path
        /// </summary>
        /// <param name="serverPath"></param>
        /// <returns></returns>
        public Server? GetServerByPathOrDefault(string serverPath)
        {
            var actualConfig = this.GetAll();

            return actualConfig.Servers.FirstOrDefault(s => s.Path == serverPath.TrimEnd());
        }

        /// <summary>
        /// Get the first Client which is matching the given Path
        /// </summary>
        /// <param name="clientPath"></param>
        /// <returns></returns>
        public Client? GetClientByPathOrDefault(string clientPath)
        {
            var actualConfig = this.GetAll();

            return actualConfig.Clients.FirstOrDefault(s => s.Path == clientPath.TrimEnd());
        }

        #endregion

        #region Add / Update

        /// <summary>
        /// Add a new Server by the given Parameters or update an already existing one by given Serverpath
        /// </summary>
        /// <param name="path"></param>
        /// <param name="connectionString"></param>
        /// <param name="selectedServerPath"></param>
        public void AddOrUpdateServer(string path, string connectionString, string selectedServerPath)
        {
            var actualConfig = this.GetAll();

            var serverToAdd = actualConfig.Servers.FirstOrDefault(s => s.Path == path && s.ConnectionString == connectionString);

            //Is Server a new one or an update of a previous selected
            if (!String.IsNullOrEmpty(selectedServerPath))
            {
                var serverToUpdate = actualConfig.Servers.FirstOrDefault(s => s.Path == selectedServerPath);

                if (serverToUpdate != null)
                {
                    serverToUpdate.Path = path;
                    serverToUpdate.ConnectionString = connectionString;
                }
            }
            else
            {
                actualConfig.Servers.Add(new Server() { Path = path, ConnectionString = connectionString });
            }

            this.SaveToXml(actualConfig);
        }

        /// <summary>
        /// Add a new Client by the given Parameters or update an already existing one by given ClientPath
        /// </summary>
        /// <param name="path"></param>
        /// <param name="isTsClient"></param>
        /// <param name="selectedServerPath"></param>
        public void AddOrUpdateClient(string path, bool isTsClient, string selectedClientPath)
        {
            var actualConfig = this.GetAll();

            var clientToAdd = actualConfig.Clients.FirstOrDefault(c => c.Path == path && c.IsTsClient == isTsClient);

            //Is Client a new one or an update of a previous selected
            if (!String.IsNullOrEmpty(selectedClientPath))
            {
                var clientToUpdate = actualConfig.Clients.FirstOrDefault(s => s.Path == selectedClientPath);

                if (clientToUpdate != null)
                {
                    clientToUpdate.Path = path;
                    clientToUpdate.IsTsClient = isTsClient;
                }
            }
            else
            {
                actualConfig.Clients.Add(new Client() { Path = path, IsTsClient = isTsClient });
            }

            this.SaveToXml(actualConfig);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Delete an existing Server by its path
        /// </summary>
        /// <param name="serverPath"></param>
        /// <param name="serverConnectionString"></param>
        public void DeleteServer(string serverPath, string serverConnectionString)
        {
            var actualConfig = this.GetAll();

            var serverToDelete = actualConfig.Servers.FirstOrDefault(s => s.Path == serverPath.TrimEnd() && s.ConnectionString == serverConnectionString.TrimEnd());

            if (serverToDelete != null)
            {
                actualConfig.Servers.Remove(serverToDelete);
                this.SaveToXml(actualConfig);
            }
        }

        /// <summary>
        /// Delete an existing Client by its Path and TS Client Value
        /// </summary>
        /// <param name="clientPath"></param>
        /// <param name="isTsClient"></param>
        public void DeleteClient(string clientPath, bool isTsClient)
        {
            var actualConfig = this.GetAll();

            var clientToDelete = actualConfig.Clients.FirstOrDefault(c => c.Path == clientPath.TrimEnd() && c.IsTsClient == isTsClient);

            if (clientToDelete != null)
            {
                actualConfig.Clients.Remove(clientToDelete);
                this.SaveToXml(actualConfig);
            }
        }

        #endregion

        #endregion

        #region Saving XML Files

        /// <summary>
        /// Save all Server Connection String in a separat XML File
        /// </summary>
        public void SaveConnectionStrings()
        {
            StreamWriter writer = new StreamWriter(_conXmlFilePath);

            var connections = new Connections();
            connections.ConnectionStrings = new List<string>();

            var actualConfig = this.GetAll();

            foreach (var server in actualConfig.Servers.Where(s => !String.IsNullOrEmpty(s.ConnectionString)).ToList())
            {
                connections.ConnectionStrings.Add(server.ConnectionString);
            }

            XmlSerializer serializer = new XmlSerializer(connections.GetType());
            serializer.Serialize(writer, connections);

            writer.Close();
            serializer = null;
        }

        /// <summary>
        /// Write current Config Data to a local XML File
        /// </summary>
        /// <param name="config"></param>
        /// <param name="isTestMode"></param>
        private void SaveToXml(Config config)
        {
            StreamWriter writer = new StreamWriter(_xmlFilePath);
            XmlSerializer serializer = new XmlSerializer(config.GetType());
            serializer.Serialize(writer, config);

            writer.Close();
            serializer = null;
        }

        #endregion
    }
}