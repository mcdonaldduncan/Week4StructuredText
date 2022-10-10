
using Week4StructuredText.Printing;

namespace Week4StructuredText.Objects
{
    internal sealed class Address : Printable
    {
        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public override string ReturnString()
        {
            return $"{StreetAddress}, {City}, {State}, {PostalCode}";
        }
    }
}
