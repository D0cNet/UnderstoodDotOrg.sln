using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Importer;

namespace UnderstoodDotOrg.Domain.Membership
{
    public class MembershipHelper
    {
        public static string GetNextStepURL(int nextStep)
        {
            string ret = string.Empty;
            string id = string.Empty;

            switch (nextStep)
            {
                case 0: //sign up page
                    id = Constants.Pages.SignUp.ToString();
                    break;
                case 1: //page 1 - kids, gender, grades
                    id = Constants.Pages.Registration1.ToString();
                    break;
                case 2: //page 2 - repeats, nicknames, issues, nicknames
                    id = Constants.Pages.Registration2.ToString();
                    break;
                case 3: //page 3 - repeats and conditional, diagnosis, IEP/504 status
                    id = Constants.Pages.Registration3.ToString();
                    break;
                case 4: //page 4 - parent issues, community registration
                    id = Constants.Pages.Registration4.ToString();
                    break;
                case 5: //page 5 - confirmation
                    id = Constants.Pages.Registration5.ToString();
                    break;
                default:
                    ret = "/";
                    break;
            }

            if (id != string.Empty)
            {
                var item = Sitecore.Context.Database.GetItem(id);
                ret = Sitecore.Links.LinkManager.GetItemUrl(item);
            }

            return ret;
        }

        public static string GetLocalizedGender(string genderKey)
        {
            // TODO: use constants
            if (genderKey == "boy")
            {
                return Common.DictionaryConstants.BoyButtonText;
            }
            else if (genderKey == "girl")
            {
                return Common.DictionaryConstants.GirlButtonText;
            }
            return string.Empty;
        }

        public static string GetPublicProfileUrl(string screenName)
        {
            if (!string.IsNullOrEmpty(screenName))
            {
                Item item = Sitecore.Context.Database.GetItem(Constants.Pages.ViewPublicProfilePage);
                if (item != null)
                {
                    string wildcard = Sitecore.Configuration.Settings.GetSetting(Constants.Settings.WildcardUrlPlaceholder);
                    return item.GetUrl().Replace(wildcard, screenName);
                }
            }

            return string.Empty;
        }

        public static string GetPublicProfileUrl(Domain.TelligentCommunity.User user)
        {
            return GetPublicProfileUrl(user.Username);
        }

        public static string GetPublicProfileUrl(Member member)
        {
            return GetPublicProfileUrl(member.ScreenName);
        }

        public static string GetPublicProfileActivityUrl(string screenName)
        {
            string url = GetPublicProfileUrl(screenName);
            if (!string.IsNullOrEmpty(url))
            {
                url = String.Format("{0}?{1}={2}", 
                    url, 
                    Constants.QueryStrings.PublicProfile.View, 
                    Constants.QueryStrings.PublicProfile.ViewComments);
            }

            return url;
        }
    }
}
