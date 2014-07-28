using System;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A
{


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

            UnderstoodDotOrg.Services.Models.Telligent.Question question = TelligentService.GetQuestion(wikiId, wikiPageId, contentId);
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
            if (!IsUserLoggedIn)
            {
                this.ProfileRedirect(Constants.UserPermission.RegisteredUser);
            }
            else if (CurrentMember.ScreenName == null)
            {
                this.ProfileRedirect(Constants.UserPermission.CommunityUser);
            }
            else
            {
                TelligentService.PostAnswer(wikiId, wikiPageId, body, user);
                Response.Redirect(Request.RawUrl);
            }
            
        }
    }
}