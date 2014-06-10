namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Domain.SitecoreCIG;
    using UnderstoodDotOrg.Domain.TelligentCommunity;

    public partial class FeaturedQuestions : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            List<Question> dataSource = CommunityHelper.GetQuestionsList("2");
            questionsRepeater.DataSource = dataSource;
            questionsRepeater.DataBind();
        }

        protected void questionsRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            var item = (Question)e.Item.DataItem;
            HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");

            var membershipManager = new MembershipManager();

            hypUserProfileLink.NavigateUrl = string.Format(MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetUrl()
                + "?{0}={1}",
                Constants.ACCOUNT_EMAIL,
                CommunityHelper.ReadUserEmail(item.Author));
        }
    }
}