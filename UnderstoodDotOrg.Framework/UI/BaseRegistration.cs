using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Framework.UI
{
    public class BaseRegistration : BaseSublayout
    {
        private string sessionKey = "understood_org_registering_user";

        public static string YesButton { get { return DictionaryConstants.YesButtonText; } }
        public static string NoButton { get { return DictionaryConstants.NoButtonText; } }
        public static string GirlButton { get { return DictionaryConstants.GirlButtonText; } }
        public static string BoyButton { get { return DictionaryConstants.BoyButtonText; } }
        public static string NextButtonText { get { return DictionaryConstants.NextButtonText; } }
        public static string InProgressText { get { return DictionaryConstants.InProgressButtonText; } }

        public Member registeringUser 
        {
            get { return (Member)(Session[sessionKey]); }
            set { Session[sessionKey] = value; }
        }
    }
}
