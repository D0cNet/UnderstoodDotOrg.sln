using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Services.Models.Telligent;
namespace UnderstoodDotOrg.Services.CommunityServices
{
    static public class Blogs
    {
        public static string GetBlogUrlFromID(string id)
        {
            string BlogUrl = String.Empty;
            BlogUrl = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{37FB73FC-F1B3-4C04-B15D-CAFAA7B7C87F}")) +
                          "/" + Constants.BlogNames[id], ".aspx", "");
            return BlogUrl;
        }

       
    }
}
