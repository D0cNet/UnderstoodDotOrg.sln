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
    using System.Net;
    using Sitecore.Configuration;
    using System.Text;
    using System.Collections.Specialized;
    using UnderstoodDotOrg.Services.TelligentService;

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

            hypUserProfileLink.NavigateUrl = MembershipHelper.GetPublicProfileUrl(item.Author);
        }

        protected void LikeButton_Click(object sender, EventArgs e)
        {
            string contentTypeId = Constants.Settings.TelligentCommentContentTypeId;
            using (var webClient = new WebClient())
            {
                try
                {
                    // replace the "admin" and "Admin's API key" with your valid user and apikey!
                    var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
                    var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    webClient.Headers.Add("Rest-Impersonate-User", this.CurrentMember.ScreenName.Trim());
                    var requestUrl = String.Format("{0}api.ashx/v2/likes.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

                    var values = new NameValueCollection();
                    values.Add("ContentId", contentId);
                    values.Add("ContentTypeId", contentTypeId);

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                    Console.WriteLine(xml);
                }
                catch { } //TODO: Add logging
            }
            Response.Redirect(Request.RawUrl);
        }
    }
}