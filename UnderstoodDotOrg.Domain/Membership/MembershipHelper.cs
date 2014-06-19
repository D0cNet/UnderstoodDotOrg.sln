using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
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
    }
}
