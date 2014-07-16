namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    using System;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Domain.SitecoreCIG;
    using UnderstoodDotOrg.Domain.TelligentCommunity;
    using UnderstoodDotOrg.Framework.UI;

    public partial class MyFriends : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var user = string.Empty;
            try
            {
                user = this.CurrentMember.ScreenName;
            }
            catch { }

            var dataSource = CommunityHelper.GetFriends(user);
            if (dataSource.Count < 4)
            {
                divFriends.Visible = false;
            }
            else
            {
                if (dataSource.Count == 4)
                {
                    arrowLeft.Visible = arrowRight.Visible = false;
                }
                rptFriends.DataSource = dataSource;
                rptFriends.DataBind();
            }
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