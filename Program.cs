namespace Week4StructuredText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Process Started!");
            List<string> newFiles = new List<string>() { Constants.File1, Constants.File2 };
            Parser parser = new Parser(newFiles);
        }
    }
}