using Moq;
using System.Diagnostics.CodeAnalysis;
using XML;
using XML.Contract;

namespace UnitTest
{
    /// <summary>
    /// Tests for all the XML Manager Methods
    /// </summary>
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class XmlManagerTest
    {
        #region Private Members

        private IXmlManager _xmlManager = Mock.Of<XmlManager>();

        private const string SERVER_PATH = "SERVER_PATH";
        private const string SERVER_CONNECTION_STRING = "SERVER_CONNECTION_STRING";
        private const string CLIENT_PATH = "CLIENT_PATH";
        private const string SERVER_PATH_UPDATE = "SERVER_PATH_UPDATE";
        private const string SERVER_CONNECTION_STRING_UPDATE = "SERVER_CONNECTION_STRING_UPDATE";
        private const string CLIENT_PATH_UPDATE = "CLIENT_PATH_UPDATE";
        private const bool CLIENT_TS = true;

        #endregion

        [TestInitialize]
        public void Initialize()
        {
            _xmlManager.CheckAndInitializeXml(true);

            _xmlManager.AddOrUpdateServer(SERVER_PATH, SERVER_CONNECTION_STRING, String.Empty);
            _xmlManager.AddOrUpdateClient(CLIENT_PATH, CLIENT_TS, String.Empty);
        }

        [TestMethod]
        public void GetAll_Valid()
        {
            var actual = _xmlManager.GetAll();

            var expected = 1;

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected, actual.Servers.Count);
            Assert.AreEqual(expected, actual.Clients.Count);
        }

        [TestMethod]
        public void GetServerByPathOrDefault_Valid()
        {
            var actual = _xmlManager.GetServerByPathOrDefault(SERVER_PATH);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetClientByPathOrDefault_Valid()
        {
            var actual = _xmlManager.GetClientByPathOrDefault(CLIENT_PATH);

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void AddOrUpdateServer_Valid()
        {
            _xmlManager.AddOrUpdateServer(SERVER_PATH_UPDATE, SERVER_CONNECTION_STRING_UPDATE, SERVER_PATH);

            var actual = _xmlManager.GetAll();
            var expectedCounter = 1;

            Assert.AreEqual(expectedCounter, actual.Servers.Count);
            Assert.AreEqual(SERVER_PATH_UPDATE, actual.Servers[0].Path);
            Assert.AreEqual(SERVER_CONNECTION_STRING_UPDATE, actual.Servers[0].ConnectionString);
        }

        [TestMethod]
        public void AddOrUpdateClient_Valid()
        {
            _xmlManager.AddOrUpdateClient(CLIENT_PATH_UPDATE, false, CLIENT_PATH);

            var actual = _xmlManager.GetAll();
            var expectedCounter = 1;

            Assert.AreEqual(expectedCounter, actual.Clients.Count);
            Assert.AreEqual(CLIENT_PATH_UPDATE, actual.Clients[0].Path);
            Assert.AreEqual(false, actual.Clients[0].IsTsClient);
        }

        [TestMethod]
        public void DeleteServer_Valid()
        {
            _xmlManager.DeleteServer(SERVER_PATH, SERVER_CONNECTION_STRING);

            var actual = _xmlManager.GetAll();
            var expected = 0;

            Assert.AreEqual(expected, actual.Servers.Count);
        }

        [TestMethod]
        public void DeleteClient_Valid()
        {
            _xmlManager.DeleteClient(CLIENT_PATH, CLIENT_TS);

            var actual = _xmlManager.GetAll();
            var expected = 0;

            Assert.AreEqual(expected, actual.Clients.Count);
        }
    }
}