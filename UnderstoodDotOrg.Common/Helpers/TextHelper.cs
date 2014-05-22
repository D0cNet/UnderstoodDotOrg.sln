using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Helpers
{
    public class TextHelper
    {
        public static string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        public static string TruncateText(string input, int numberOfChars)
        {
            string output = Sitecore.StringUtil.RemoveTags(input).Trim();

            return (output.Length <= numberOfChars) 
                ? output 
                : String.Concat(output.Substring(0, numberOfChars).Trim(), "...");
        }

        public static string HighlightSearchTitle(string terms, string title)
        {
            IEnumerable<string> words = terms.Trim().Split(' ').Select(x => x.Trim()).Distinct();
            foreach (string word in words)
            {
                title = Regex.Replace(title, 
                            String.Format(@"\b({0})\b", word), 
                            String.Format("<span>$1</span>", word), 
                            RegexOptions.IgnoreCase);
            }

            return title;
        }
    }
}
