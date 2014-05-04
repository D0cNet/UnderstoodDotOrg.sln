using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                case 1:
                    id = "{2A9B3FBC-208F-4DA0-8BC5-9024CA8D6F4E}";
                    break;
                case 2:
                    id = "{417F1D9E-E74E-4CE2-879F-CA7D38D0E43F}";
                    break;
                case 3:
                    id = "{95B73EB6-323A-46F8-BA21-C4F57712BE86}";
                    break;
                case 4:
                    id = "{907EAD93-A2AB-48ED-886C-2DF985375803}";
                    break;
                case 5:
                    id = "{FE5442E8-CC81-4D9C-926B-2745DF398829}";
                    break;
                default:
                    ret = "/";
                    break;
            }

            if (id != string.Empty)
            {
                var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(id);
                ret = Sitecore.Links.LinkManager.GetItemUrl(item);
            }

            return ret;
        }
    }
}
