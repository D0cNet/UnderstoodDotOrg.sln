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
        public static Guid GetGrade(string grade)
        {
            Guid ret = new Guid();

            //replace with live lookup
            switch (grade)
            {
                case "1":
                    ret = Guid.Parse("{E26222FB-07CD-413B-9127-9050B6D2D037}");
                    break;
                case "2":
                    ret = Guid.Parse("{0CDA88F1-5F69-485C-AE6B-50E8D5C265EB}");
                    break;
                case "3":
                    ret = Guid.Parse("{67AA2A29-E6FF-49B2-9F9E-D29F07C19C23}");
                    break;
                case "4":
                    ret = Guid.Parse("{32702CD8-0625-498F-9D8F-17691E81BC69}");
                    break;
                case "5":
                    ret = Guid.Parse("{79AB134B-CC1F-4BB6-94F8-12FE9E181F9E}");
                    break;
                case "6":
                    ret = Guid.Parse("{E82EB59B-2A3C-4910-96C9-E276C92B712E}");
                    break;
                case "7":
                    ret = Guid.Parse("{79B1ACCE-CD06-4F0C-84B2-15A6C01020B9}");
                    break;
                case "8":
                    ret = Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}");
                    break;
                case "9":
                    ret = Guid.Parse("{5EEF6AE2-1CBE-4532-883F-C6C0859581A1}");
                    break;
                case "10":
                    ret = Guid.Parse("{E0B459C0-548A-4E6C-854A-E8F475416F12}");
                    break;
                case "11":
                    ret = Guid.Parse("{9FFF9854-5951-4A7F-94A5-4F8507800916}");
                    break;
                case "12":
                    ret = Guid.Parse("{0762C21C-2B35-439C-A45F-A4FCEF5C87B7}");
                    break;
                default:
                    break;
            }

            return ret;
        }

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
