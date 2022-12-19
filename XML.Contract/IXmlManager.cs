using Data;

namespace XML.Contract
{
    public interface IXmlManager
    {
        void CheckAndInitializeXml();
        Data.Config GetAll();
        Server? GetServerByPathOrDefault(string serverPath);

        void AddOrUpdateServer(string path, string connectionString, string selectedServerPath);
        void DeleteServer(string serverPath, string serverConnectionString);
    }
}