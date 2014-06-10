namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Domain.SitecoreCIG;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.QandA;
    using UnderstoodDotOrg.Domain.TelligentCommunity;
    using UnderstoodDotOrg.Common.Extensions;

    public partial class QuestionAnswers : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            string wikiId;
            string wikiPageId;
            string contentId;
            try
            {
                wikiId = Request.QueryString["wikiId"];
                wikiPageId = Request.QueryString["wikiPageId"];
                contentId = Request.QueryString["contentId"];

            }
            catch
            {
                wikiId = "1";
                wikiPageId = "1";
            }

            var dataSource = CommunityHelper.GetAnswers(wikiId, wikiPageId);
            AnswerRepeater.DataSource = dataSource;
            AnswerRepeater.DataBind();
            try
            {
                lbAnswerCount.Text = dataSource[0].Count;
            }
            catch
            {
                lbAnswerCount.Text = "0";
            }
        }

        protected void AnswerRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            var item = (Answer)e.Item.DataItem;
            HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");

            var membershipManager = new MembershipManager();

            hypUserProfileLink.NavigateUrl = string.Format(MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage().GetUrl()
                + "?{0}={1}",
                Constants.ACCOUNT_EMAIL,
                CommunityHelper.ReadUserEmail(item.Author));
        }

    }
}