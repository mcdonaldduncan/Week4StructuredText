using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week4StructuredText.XML_Objects
{
    [XmlRoot("item")]
    public class Item
    {
        [XmlElement("name")]
        public string Name;

        [XmlElement("price")]
        public string Price;

        [XmlElement("uom")]
        public string UnitOfMeasurement;
    }
}
