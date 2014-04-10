using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Framework.UI
{
    class BaseRegistration : BaseSublayout
    {
        private string sessionKey = "understood_org_registering_user";

        public Member registeringUser 
        {
            get { return (Member)(Session[sessionKey]); }
            set { Session[sessionKey] = value; }
        }
    }
}
