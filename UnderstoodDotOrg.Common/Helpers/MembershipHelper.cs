using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Common.Helpers
{
    public static class MembershipHelper
    {
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

        public static string AddOrdinalIndicator(int Value)
        {
            return AddOrdinalIndicator(Value.ToString());
        }
    }
}
