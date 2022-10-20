using System.Text;
using System.Xml.Serialization;

namespace Week4StructuredText.XML_Objects
{
    [XmlRoot("menu")]
    public sealed class Market
    {
        [XmlElement("item")]
        public List<Item>? Items { get; set; }

        private StringBuilder sb = new StringBuilder();

        public override string ToString()
        {
            for (int i = 0; i < Items?.Count; i++)
            {
                sb.Append($"Item#{i + 1}: {Items[i].Name} ==> {Items[i].Price}/{Items[i].UnitOfMeasurement}\n");
            }
            return sb.ToString();
        }
    }
}
