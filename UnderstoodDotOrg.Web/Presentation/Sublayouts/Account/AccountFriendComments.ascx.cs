using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountFriendComments : System.Web.UI.UserControl
    {
        protected string AjaxPath
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.UserCommentsEndpoint);
            }
        }

        public Member ProfileMember;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ProfileMember == null)
            {
                return;
            }

            ucCommentList.DisplayAuthorInfo = true;
            ucCommentList.ProfileMember = ProfileMember;

            int totalComments;
            var comments = TelligentService.GetUserCommentsByScreenName(ProfileMember.ScreenName, 1, Constants.PUBLIC_PROFILE_COMMENTS_PER_PAGE, out totalComments);
            if (comments.Any())
            {
                ucCommentList.Comments = comments;
            }

            pnlShowMore.Visible = comments.Count() < totalComments;
        }
    }
}