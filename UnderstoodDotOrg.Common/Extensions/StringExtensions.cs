﻿using Sitecore.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Extensions {
    public static class StringExtensions {
        /// <summary>
        /// Indicates whether the specified string is null or an empty string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value) {
            return string.IsNullOrWhiteSpace(value);
        }

        /// Like linq take - takes the first x characters
        public static string Truncate(this string s, int length, bool atWord, bool addEllipsis) {
            // Return if the string is less than or equal to the truncation length     
            if (s == null || s.Length <= length)
                return s;
            // Do a simple tuncation at the desired length     
            string s2 = s.Substring(0, length);
            // Truncate the string at the word     
            if (atWord) {
                // List of characters that denote the start or a new word (add to or remove more as necessary)          
                List<char> alternativeCutOffs = new List<char>() { ' ', ',', '.', '?', '/', ':', ';', '\'', '\"', '\'', '-' };
                // Get the index of the last space in the truncated string          
                int lastSpace = s2.LastIndexOf(' ');
                // If the last space index isn't -1 and also the next character in the original          
                // string isn't contained in the alternativeCutOffs List (which means the previous          
                // truncation actually truncated at the end of a word),then shorten string to the last space          
                if (lastSpace != -1 && (s.Length >= length + 1 && !alternativeCutOffs.Contains(s.ToCharArray()[length]))) s2 = s2.Remove(lastSpace);
            }      // Add Ellipsis if desired     
            if (addEllipsis)
                s2 += "...";
            return s2;
        }

        /// <summary>
        ///  update sitecore item links in string
        /// </summary>
        /// <returns></returns>
        public static string UpdateSitecoreLinks(this string s) {
            // get all anchore
            var matches = Regex.Matches(s, "<a href=\"(.+?)\">(.+?)</a>");
            string oldString = String.Empty;
            string newString = String.Empty;
            // update sitecore item links
            foreach (Match m in matches) {
                if (!m.ToString().Contains("http://") && !m.ToString().Contains("mailto:")) {
                    oldString = m.ToString();
                    newString = m.ToString().Replace("<a href=\"", "<a href=\"" + WebUtil.GetServerUrl());
                    s = s.Replace(oldString, newString);
                }
            }

            return s;
        }

        /// <summary>
        ///  strip html
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StripHTML(this string s) {
            return s.StripHTML(string.Empty);
        }
        public static string StripHTML(this string s, string fillString) {
            string input = Regex.Replace(s, "<blockquote?>", fillString);
            return Regex.Replace(input, "</blockquote?>", fillString);
        }
        public static string StripHTML(this string s, string tag, bool selfClosing) {
            string result;
            if (s.Contains("<")) {
                int startIndex = s.IndexOf("<" + tag);
                string text = s.Substring(startIndex);
                string oldValue = text.Substring(0, text.IndexOf(">") + 1);
                result = s.Replace(oldValue, "").Replace("</" + tag + ">", "");
            }
            else {
                result = s;
            }
            return result;
        }

        /// <summary>
        ///  escape character for sitecore x path query
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static string EscapeCharacterForXPath(this string xpath) {
            string word;
            string newPath = string.Empty;
            string[] bufferpath = xpath.Split('[');
            string[] tab = bufferpath[0].Split(new char[] { '/' });
            bool isExcaped;
            bool first = true;

            foreach (string part in tab) {
                isExcaped = false;
                word = part;

                if (part.Contains(" ")) {
                    word = "#" + part + "#";
                    isExcaped = true;
                }

                if (word.Contains('-')) {
                    if (isExcaped)
                        word = word.Replace("-", "##-##");
                    else
                        word = "#" + word.Replace("-", "##-##") + "#";
                }
                if (first) {
                    first = false;
                    newPath = word;
                }
                else
                    newPath += "/" + word;
            }
            bufferpath[0] = newPath;
            newPath = "";
            foreach (string s in bufferpath) {
                newPath += string.IsNullOrEmpty(newPath) ? s : "[" + s;
            }


            return newPath;
        }

        /// <summary>
        ///  escape character for sitecore x path query
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static string EscapeCharacterForTabID(this string tabID) {

            tabID = tabID.Replace("<br />", "").Replace("<br/>", "").Replace("/", "").Replace(" ", "");
            return tabID;
        }

        public static bool IsNumeric(this string s) {
            int result = 0;

            return !string.IsNullOrEmpty(s) && int.TryParse(s, out result);
        }


    }
}
