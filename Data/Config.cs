using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
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
