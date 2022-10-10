using System.Text;

namespace Week4StructuredText.Printing
{
    public abstract class Printable
    {
        public StringBuilder sb = new StringBuilder();

        /// <summary>
        /// Organize data into a readable string for writing via a streamwriter
        /// </summary>
        /// <returns string></returns>
        public abstract string ReturnString();
    }
}
