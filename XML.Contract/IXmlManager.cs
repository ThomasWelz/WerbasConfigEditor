using Data.Entity;

namespace XML.Contract
{
    /// <summary>
    /// Interface for XML Manager
    /// </summary>
    public interface IXmlManager
    {
        void CheckAndInitializeXml(bool isTestMode = false);

        #region Get
        
        Config GetAll();
        Server? GetServerByPathOrDefault(string serverPath);
        Client? GetClientByPathOrDefault(string clientPath);

        #endregion

        #region Add / Update

        void AddOrUpdateServer(string path, string connectionString, string selectedServerPath);
        void AddOrUpdateClient(string path, bool isTsClient, string selectedClientPath);

        #endregion

        #region Delete

        void DeleteServer(string serverPath, string serverConnectionString);
        void DeleteClient(string clientPath, bool isTsClient);

        #endregion

        #region Saving XML Files

        void SaveConnectionStrings();

        #endregion
    }
}