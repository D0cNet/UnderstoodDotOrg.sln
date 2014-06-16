namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A
{
    using System;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.TelligentCommunity;
    using UnderstoodDotOrg.Framework.UI;

    public partial class QandADetails : BaseSublayout
    {
        string wikiId;
        string wikiPageId;
        string contentId;
        private void Page_Load(object sender, EventArgs e)
        {
            wikiId = Request.QueryString["wikiId"];
            wikiPageId = Request.QueryString["wikiPageId"];
            contentId = Request.QueryString["contentId"];

            Question question = CommunityHelper.GetQuestion(wikiId, wikiPageId, contentId);
            QuestionTitleLabel.Text = question.Title;
            QuestionBodyLabel.Text = question.Body;
            GroupLabel.Text = question.Group;
            AuthorLabel.Text = question.Author;
            DateLabel.Text = question.PublishedDate;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string body = CommentEntryTextField.Value;
            string user = "";
            try
            {
                if (!this.CurrentMember.ScreenName.IsNullOrEmpty())
                {
                    user = this.CurrentMember.ScreenName;
                }
            }
            catch
            {
                user = "admin";
            }
            CommunityHelper.PostAnswer(wikiId, wikiPageId, body, user);

            // Clear postback value
            CommentEntryTextField.Value = String.Empty;
        }
    }
}