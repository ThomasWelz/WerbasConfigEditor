using System.Xml.Serialization;

namespace Data.Entity
{
    /// <summary>
    /// All the ConnectionStrings of the Servers for Serialization
    /// </summary>
    [Serializable(), XmlRoot("Connections")]
    public class Connections
    {
        [XmlArray("ConnectionStrings")]
        [XmlArrayItem("ConnectionString")]
        public List<string> ConnectionStrings { get; set; }
    }
}
