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
            var wikiId = "";
            var wikiPageId = "";
            try
            {
                var blogCig = new QandADetailsItem(Sitecore.Context.Item);
                wikiId = blogCig.WikiId.Raw;
                wikiPageId = blogCig.WikiPageId.Raw;
            }
            catch
            {
                wikiId = "1";
                wikiPageId = "1";
            }

            List<Answer> dataSource = CommunityHelper.GetAnswers(wikiId, wikiPageId);
            AnswerRepeater.DataSource = dataSource;
            AnswerRepeater.DataBind();
        }

    }
}