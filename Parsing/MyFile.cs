using System;
using System.Collections.Generic;
using System.Linq;
using Week4StructuredText.Constant;

namespace Week4StructuredText.Parsing
{
    internal sealed class MyFile : IDeliminated
    {
        public string Delimiter { get; set; }
        public string FilePath { get; set; }
        public string Extension { get; set; }
        public bool LoadError { get; set; }

        
        
    }
}
