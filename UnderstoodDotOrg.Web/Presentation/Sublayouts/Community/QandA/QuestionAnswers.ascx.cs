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
    using UnderstoodDotOrg.Framework.UI;

    public partial class QuestionAnswers : BaseSublayout
    {
        string wikiId;
        string wikiPageId;
        string contentId;
        private void Page_Load(object sender, EventArgs e)
        {
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

            var dataSource = CommunityHelper.GetAnswers(wikiId, wikiPageId, contentId);
            AnswerRepeater.DataSource = dataSource;
            AnswerRepeater.DataBind();
            try
            {
                lbAnswerCount.Text = dataSource[0].Count;
                divSortAnswers.Visible = true;

                if (dataSource[0].Count.AsInt() < 7)
                {
                    divShowMore.Visible = false;
                }
            }
            catch
            {
                lbAnswerCount.Text = "0";
                divShowMore.Visible = false;
                divSortAnswers.Visible = false;
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