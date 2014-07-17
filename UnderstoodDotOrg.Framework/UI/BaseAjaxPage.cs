using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Framework.UI
{
    public class BaseAjaxPage : System.Web.UI.Page
    {
        // TODO: refactor so base sublayout and this can re-use functions
        private System.Web.Security.MembershipUser _currentUser;
        private Member _currentMember;
        
        public System.Web.Security.MembershipUser CurrentUser
        {
            get
            {
                return (_currentUser = _currentUser ?? (System.Web.Security.MembershipUser)Session[Constants.currentUserKey]);
            }
            set
            {
                Session[Constants.currentUserKey] =
                    _currentUser = value;
            }
        }

        public Member CurrentMember
        {
            get
            {
                return (_currentMember = _currentMember ?? (Member)Session[Constants.currentMemberKey]);
            }
            set
            {
                Session[Constants.currentMemberKey] =
                    _currentMember = value;
            }
        }

        public bool IsUserLoggedIn
        {
            get
            {
                return CurrentMember != null && CurrentUser != null;
            }
        }
    }
}
