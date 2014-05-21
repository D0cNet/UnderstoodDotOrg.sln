namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
    using System;
    using System.Collections.Generic;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.QandA;
    using UnderstoodDotOrg.Domain.TelligentCommunity;

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

    }
}