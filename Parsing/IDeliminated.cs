
namespace Week4StructuredText
{
    internal interface IDeliminated
    {
        public string Delimiter { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
    }
}
