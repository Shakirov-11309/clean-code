using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MarkDown.Classes
{
    public class Converter
    {
        public string ConvertToHTML(string line)
        {
            line = RenderHeaders(line);
            line = RenderTags(line);

            return line;
        }

        private string RenderHeaders(string line) 
        {
            int headerLevel = GetHeaderLevel(line);
            if (headerLevel > 0)
            {
                string headerContent = line.Substring(headerLevel).Trim();
                return String.Format("<h{0}>{1}</h{0}>", headerLevel, headerContent);
            }
            return line;
        }

        private string HandleEscaping(ref int index, string text) 
        {
            if(index + 1 < text.Length) 
            {
                char escapedChar = text[index + 1];
                index += 2;
                return escapedChar.ToString();
            }
            return "\\";
        }

        private int GetHeaderLevel(string text)
        {
            int level = 0;
            while (level < text.Length && level < 7 && text[level] == '#')
            {
                level++;
            }
            return level > 0 && level < text.Length && text[level] == ' ' ? level : 0;
        }

        private string HandleTag(ref int index, string text, string delimiter, string openTag, string closTag)
        {
            int start = index + delimiter.Length;
            int end = text.IndexOf(delimiter, start);

            if (end == -1)
            {
                index += delimiter.Length;
                return delimiter;
            }
            string innerText = RenderTags(text.Substring(start, end - start));
            index = end + delimiter.Length;
            return $"{openTag}{innerText}{closTag}";
        }

        private bool StartWithDelimiter(string text, int index, string delimiter) 
        {
            return index + delimiter.Length <= text.Length && text.Substring(index, delimiter.Length) == delimiter;
        }

        private bool IsValidDelimiter(string text, int index, string delimiter)
        {
            int before = index - 1;
            int after = index + delimiter.Length;

            bool validBefore = before < 0 || !char.IsWhiteSpace(text[before]) && !char.IsDigit(text[before]);
            bool validAfter = after >= delimiter.Length || !char.IsWhiteSpace(text[after]) && !char.IsDigit(text[after]);

            return validBefore && validAfter;
        }

        private string RenderTags(string text)
        {
            var result = new StringBuilder();
            int i = 0;
            while (i < text.Length) 
            {
                if (text[i] == '\\')
                {
                    result.Append(HandleEscaping(ref i, text));
                }
                else if (StartWithDelimiter(text, i, "__") && IsValidDelimiter(text, i, "__")) 
                {
                    result.Append(HandleTag(ref i, text, "__", "<strong>", "</strong>"));
                }
                else if (StartWithDelimiter(text, i, "_") && IsValidDelimiter(text, i, "_"))
                {
                    result.Append(HandleTag(ref i, text, "_", "<em>", "</em>"));
                }
                else
                {
                    result.Append(text[i]);
                    i++;
                }
            }
            return result.ToString();
        }
    }
}
