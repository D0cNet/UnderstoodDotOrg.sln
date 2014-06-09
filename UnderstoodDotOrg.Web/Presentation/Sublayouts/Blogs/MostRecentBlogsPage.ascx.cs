using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class MostRecentBlogsPage : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = Request.QueryString["BlogId"];
            List<BlogPost> dataSource = CommunityHelper.ListBlogPosts(blogId, "6");
            rptBlogInfo.DataSource = dataSource;
            rptBlogInfo.DataBind();

            lbBlogName.Text = dataSource[0].BlogName;
        }

        protected void rptBlogInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (Question)e.Item.DataItem;
            HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");

            var membershipManager = new MembershipManager();

            hypUserProfileLink.NavigateUrl = string.Format(MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetUrl() + "?{0}={1}", Constants.ACCOUNT_EMAIL, CommunityHelper.ReadUserEmail(item.Author));
        }
    }
}