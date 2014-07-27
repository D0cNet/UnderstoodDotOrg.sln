using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class WhatsHappening : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            bool isUser = false;
            try
            {
                if (IsUserLoggedIn)
                {
                    isUser = true;
                }
            }
            catch
            {
                isUser = false;
            }

            if (isUser)
            {
                sbEvents.Visible = true;
                sbQuestions.Visible = true;
                sbCommunityMembers.Visible = false;
                sbMyFriends.Visible = true;

                if (TelligentService.UserFollowsBlogs(this.CurrentMember.ScreenName))
                {
                    sbBlogsIFollow.Visible = true;
                    sbRecentBlogPosts.Visible = false;
                }
                else
                {
                    sbRecentBlogPosts.Visible = true;
                    sbBlogsIFollow.Visible = false;
                }
            }
            else
            {

            }
        }
    }
}