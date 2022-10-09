using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Week4StructuredText.XML_Objects
{
    [XmlRoot("menu")]
    public class Market
    {
        [XmlElement("item")]
        public List<Item> Items;
    }
}
