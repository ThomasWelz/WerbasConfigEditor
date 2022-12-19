using Data;
using System.Xml.Serialization;
using XML.Contract;

namespace XML
{
    public class XmlManager : IXmlManager
    {
        #region Private Members

        private const string WERBAS_DIRECTORY_PATH = @"C:\Werbas";
        private const string XML_FILE_PATH = @"C:\Werbas\ConfigEditor.xml";

        #endregion

        #region Constructor

        public XmlManager()
        {

        }

        #endregion

        #region Public Methods

        public void CheckAndInitializeXml()
        {
            var xmlExist = File.Exists(XML_FILE_PATH);

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
        public Data.Config GetAll()
        {
            FileInfo FI = new FileInfo(XML_FILE_PATH);
            var result = new Data.Config();

            if (FI.Exists)
            {
                StreamReader reader = new StreamReader(XML_FILE_PATH);
                XmlSerializer serializer = new XmlSerializer(result.GetType());
                result = serializer.Deserialize(reader) as Data.Config;
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

            return actualConfig.Servers.FirstOrDefault(s => s.Path == serverPath);
        }

        #endregion

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
        /// Delete an existing Server by its path
        /// </summary>
        /// <param name="serverPath"></param>
        /// <param name="serverConnectionString"></param>
        public void DeleteServer(string serverPath, string serverConnectionString)
        {
            var actualConfig = this.GetAll();

            var serverToDelete = actualConfig.Servers.FirstOrDefault(s => s.Path == serverPath && s.ConnectionString == serverConnectionString);

            if (serverToDelete != null) 
            { 
                actualConfig.Servers.Remove(serverToDelete);
                this.SaveToXml(actualConfig);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Write current Config Data to a local XML File
        /// </summary>
        /// <param name="config"></param>
        public void SaveToXml(Config config)
        {
            StreamWriter writer = new StreamWriter(XML_FILE_PATH);
            XmlSerializer serializer = new XmlSerializer(config.GetType());
            serializer.Serialize(writer, config);
            writer.Close();
            serializer = null;
        }

        #endregion
    }
}