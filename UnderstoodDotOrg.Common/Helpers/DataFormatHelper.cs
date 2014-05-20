using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Helpers
{
     public class DataFormatHelper
    {
         public static string FormatDate(string dateTime)
         {
             string[] d = dateTime.Split('T');
             DateTime date = DateTime.Parse(d[0]);
             DateTime now = DateTime.Now;
             TimeSpan s = now.Subtract(date);
             int span = (int)s.TotalDays;
             string timeSince = span.ToString();
             string publishedDate = timeSince + " days ago";
             if (timeSince.Equals("1"))
             {
                 publishedDate = "yesterday";
             }

             if (timeSince.Equals("0"))
             {
                 date = DateTime.Parse(d[1]);
                 s = now.TimeOfDay.Subtract(date.TimeOfDay);
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
    }
}
