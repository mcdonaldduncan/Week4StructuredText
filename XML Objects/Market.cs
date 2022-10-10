using System.Xml.Serialization;

namespace Week4StructuredText.XML_Objects
{
    [XmlRoot("menu")]
    public sealed class Market : Printable
    {
        [XmlElement("item")]
        public List<Item> Items { get; set; }

        public override string ReturnString()
        {
            for (int i = 0; i < Items.Count; i++)
            {
                sb.Append($"Item#{i + 1}: {Items[i].Name} ==> {Items[i].Price}/{Items[i].UnitOfMeasurement}\n");
            }
            return sb.ToString();
        }
    }
}
