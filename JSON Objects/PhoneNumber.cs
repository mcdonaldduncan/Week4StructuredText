
namespace Week4StructuredText.Objects
{
    internal sealed class PhoneNumber : Printable
    {
        public string Type { get; set; }

        public string Number { get; set; }

        public bool CanContact { get; set; }

        public override string ReturnString()
        {
            return $"{Number} | {Type} | Can Contact: {(CanContact ? "Yes" : "No")}\n";
        }
    }
}
