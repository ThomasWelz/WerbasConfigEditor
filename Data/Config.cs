using System.Xml.Serialization;

namespace Data.Entity
{
    /// <summary>
    /// Servers and Clients for Serialization
    /// </summary>
    [Serializable(), XmlRoot("Config")]
    public class Config
    {
        [XmlArray("Servers")]
        [XmlArrayItem("Server")]
        public List<Server> Servers;

        [XmlArray("Clients")]
        [XmlArrayItem("Client")]
        public List<Client> Clients;
    }
}
