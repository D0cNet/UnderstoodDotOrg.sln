using Sitecore.Data;
using Sitecore.Web.UI.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Common.Helpers
{
    public static class MembershipHelper
    {

        static public string SignUpLink()
        {
            return Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(new ID(Constants.Pages.SignUp)));
        }

        static public string SignInLink()
        {
            return Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(new ID(Constants.Pages.SignIn)));
        }


        
        /// <summary>
        /// Adds ordinal indicator (st, nd, rd, th) to provided string value
        /// </summary>
        /// <param name="Value">String representing current position</param>
        /// <returns>Value with appropriate ordinal indicator appended</returns>
        public static string AddOrdinalIndicator(string Value)
        {
            switch (Value)
            {
                case "1":
                    Value += "st";
                    break;
                case "2":
                    Value += "nd";
                    break;
                case "3":
                    Value += "rd";
                    break;
                default:
                    Value += "th";
                    break;
            }

            return Value;
        }

        /// <summary>
        /// Adds ordinal indicator (st, nd, rd, th) to provided integer value
        /// </summary>
        /// <param name="Value">Integer representing current position</param>
        /// <returns>String of value with appropriate ordinal indicator appended</returns>
        public static string AddOrdinalIndicator(int Value)
        {
            return AddOrdinalIndicator(Value.ToString());
        }
    }
}
