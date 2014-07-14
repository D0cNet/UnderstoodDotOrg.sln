using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountFriendConnections : System.Web.UI.UserControl
    {
        public Member ProfileMember;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ProfileMember == null)
            {
                return;
            }

        }
    }
}