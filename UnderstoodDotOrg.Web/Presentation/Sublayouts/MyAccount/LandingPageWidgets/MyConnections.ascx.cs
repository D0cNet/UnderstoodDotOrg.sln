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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyConnections : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccountConnections);
            hypConnectionsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            var dataSource = CommunityHelper.GetFriends(this.CurrentMember.ScreenName);
            rptFriends.DataSource = dataSource;
            rptFriends.DataBind();
            ltFriendCount.Text = dataSource.Count().ToString();
        }

        protected void rptFriends_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            var item = (User)e.Item.DataItem;
            HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");

            var membershipManager = new MembershipManager();

            hypUserProfileLink.NavigateUrl = string.Format(MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetUrl()
                + "?{0}={1}",
                Constants.ACCOUNT_EMAIL,
                CommunityHelper.ReadUserEmail(item.Username));
        }
    }
}