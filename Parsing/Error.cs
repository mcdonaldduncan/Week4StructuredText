
namespace Week4StructuredText
{
    internal sealed class Error
    {
        public string ErrorMessage { get; set; }
        public string Source { get; set; }

        public Error(string message, string source)
        {
            ErrorMessage = message;
            Source = source;
        }
    }
}
