using Sitecore.Data.Items;
using System;
using System.Web;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.CommunityServices;
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
            Item currItem = Sitecore.Context.Item;
           // UnderstoodDotOrg.Services.Models.Telligent.Question question = TelligentService.GetQuestion(wikiId, wikiPageId, contentId);
            UnderstoodDotOrg.Services.Models.Telligent.Question question = Questions.GetQuestion(wikiId, wikiPageId, contentId);
            QuestionTitleLabel.Text = question.Title;
            QuestionBodyLabel.Text = question.Body;
            GroupLabel.Text = question.Group;
            AuthorLabel.Text = question.Author;
            hypAuthorLink.NavigateUrl = MembershipHelper.GetPublicProfileUrl(question.Author);
            DateLabel.Text = question.PublishedDate;
            //HtmlAnchor hrefTopicUrl = e.FindControlAs<HtmlAnchor>("hrefTopicUrl");
            if (hrefTopicUrl != null)
            {
                Item parentItem = Sitecore.Context.Item.Parent;
                hrefTopicUrl.HRef = parentItem.GetUrl() + "?topic=" + HttpUtility.UrlEncode(question.Group);
            }
            SubmitButton.Text = UnderstoodDotOrg.Common.DictionaryConstants.SubmitAnswerLabel;
            FollowButton.LoadState(question.ContentId, Constants.TelligentContentType.Weblog, question.ContentTypeId);
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