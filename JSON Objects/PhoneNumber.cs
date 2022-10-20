
namespace Week4StructuredText.Objects
{
    internal sealed class PhoneNumber
    {
        public string? Type { get; set; }

        public string? Number { get; set; }

        public bool CanContact { get; set; }

        public override string ToString()
        {
            return $"{Number ?? @"N/A"} | {Type ?? @"N/A"} | Can Contact: {(CanContact ? "Yes" : "No")}\n";
        }
    }
}
