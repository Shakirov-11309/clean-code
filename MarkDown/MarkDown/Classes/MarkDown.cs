using MarkDown.Interfaces;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using System.Text;

namespace MarkDown.Classes
{
    public class MarkDown : IMarkDown
    {
        public string Render(string markDownText)
        {
            StringBuilder stringBuilder = new StringBuilder();

            var lines = StringParser.SplitTextOnLines(markDownText);

            foreach (var line in lines ) 
            {
               var convertLine = new Converter();
               stringBuilder.Append(convertLine.ConvertToHTML(markDownText));
            }
            return stringBuilder.ToString();
        }
    }
}
