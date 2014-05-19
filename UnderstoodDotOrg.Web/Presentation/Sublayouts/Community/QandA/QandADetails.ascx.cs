namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A
{
    using System;
    using UnderstoodDotOrg.Domain.TelligentCommunity;

    public partial class QandADetails : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            string wikiId = Request.QueryString["wikiId"];
            string wikiPageId = Request.QueryString["wikiPageId"];
            string contentId = Request.QueryString["contentId"];

            Question question = CommunityHelper.GetQuestion(wikiId, wikiPageId, contentId);
            QuestionTitleLabel.Text = question.Title;
            QuestionBodyLabel.Text = question.Body;
            GroupLabel.Text = question.Group;
            AuthorLabel.Text = question.Author;
            DateLabel.Text = question.PublishedDate;
        }
    }
}