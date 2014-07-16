using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Helpers
{
     public class DataFormatHelper
    {
        public static string FormatDate(DateTime dateTime)
        {
            // TODO: localize fragments
            DateTime now = DateTime.Now;
            TimeSpan s = now.Subtract(dateTime.Date);
            int span = (int)s.TotalDays;
            string timeSince = span.ToString();
            string publishedDate = timeSince + " days ago";
            if (timeSince.Equals("1"))
            {
                publishedDate = "yesterday";
            }

            if (timeSince.Equals("0"))
            {
                s = now.TimeOfDay.Subtract(dateTime.TimeOfDay);
                span = (int)s.TotalSeconds;
                if (span < 60)
                {
                    return "just now";
                }

                if (span < 120)
                {
                    return "1 minute ago";
                }

                if (span < 3600)
                {
                    return string.Format("{0} minutes ago", Math.Floor((double)span / 60));
                }

                if (span < 7200)
                {
                    return "1 hour ago";
                }

                if (span < 86400)
                {
                    return string.Format("{0} hours ago", Math.Floor((double)span / 3600));
                }
            }
            return publishedDate;
        }

        public static string FormatDate(string dateTime)
        {
            return FormatDate(DateTime.Parse(dateTime));
        }

         public static string FormatString100(string inputString)
         {
             if (inputString.Length >= 100)
             {
                 string myString = inputString.Substring(0, 100);

                 int index = myString.LastIndexOf(' ');
                 //Have to check the value for index
                 if (index > -1)
                     myString = myString.Substring(0, index);

                 return myString;
             }
             else
             {
                 return inputString;
             }
         }
         public static string AddOrdinal(int num)
         {
             if (num <= 0) return num.ToString();

             switch (num % 100)
             {
                 case 11:
                 case 12:
                 case 13:
                     return num + "th";
             }

             switch (num % 10)
             {
                 case 1:
                     return num + "st";
                 case 2:
                     return num + "nd";
                 case 3:
                     return num + "rd";
                 default:
                     return num + "th";
             }

         }
         
         /// <summary>
         /// 
         /// </summary>
         /// <param name="index"></param>
         /// <returns></returns>
         public static string getLetter(int index)
         {
             if (Enum.IsDefined(typeof(Letters), index))
             {
                 return ((Letters)index).ToString();
             }

             return string.Empty;
         }

         enum Letters
         {
             a = 0,
             b = 1,
             c = 2,
             d = 3,
             e = 4,
             f = 5
         }
    }
}
