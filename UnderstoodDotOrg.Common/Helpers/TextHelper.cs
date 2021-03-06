﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace UnderstoodDotOrg.Common.Helpers
{
    public static class TextHelper
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
            // strip quotes
            terms = terms.Replace("\"", "");

            string[] reserved = new [] { ".", "^", "$", "*", "+", "?", "(", ")", "[", "{", "|", "\\", "}", ":", "-" };
            reserved = reserved.Select(x => @"\" + x).ToArray();

            string reservedPattern = String.Format("({0})", String.Join("|", reserved));

            IEnumerable<string> words = terms.Trim().Split(' ').Select(x => x.Trim()).Distinct();
            foreach (string word in words)
            {
                string regexWord = Regex.Replace(word, reservedPattern, @"\$1");
                
                // TODO: refactor
                // Cannot use word boundaries \b to match 
                title = Regex.Replace(title,
                            String.Format("^({0})$", regexWord),
                            String.Format("<span>$1</span>", word),
                            RegexOptions.IgnoreCase);

                title = Regex.Replace(title,
                            String.Format(@"(\s)({0})$", regexWord),
                            String.Format("$1<span>$2</span>", word),
                            RegexOptions.IgnoreCase);

                title = Regex.Replace(title,
                            String.Format(@"^({0})(\s|[^a-z0-9])", regexWord),
                            String.Format("<span>$1</span>$2", word),
                            RegexOptions.IgnoreCase);

                title = Regex.Replace(title,
                            String.Format(@"(\s)({0})(\s|[^a-z0-9])", regexWord), 
                            String.Format("$1<span>$2</span>$3", word), 
                            RegexOptions.IgnoreCase);
            }

            return title;
        }

        /// <summary>
        /// Removes HTML and whitespace from a string
        /// </summary>
        /// <param name="Source"></param>
        /// <returns></returns>
        public static string RemoveHTML(this string Source)
        {
            if (!string.IsNullOrEmpty(Source)) 
            {
                return WebUtility.HtmlDecode(Sitecore.StringUtil.RemoveTags(Source)).Trim();
            }

            return string.Empty;
        }
    }
}
