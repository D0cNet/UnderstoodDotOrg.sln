using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.QandA;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using System.Net;
using Sitecore.Configuration;
using System.Text;
using System.Collections.Specialized;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;
using System.Web.UI.HtmlControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Services.CommunityServices;
using System.Web;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
 

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

            var dataSource = TelligentService.GetAnswers(wikiId, wikiPageId, contentId);
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
            if (e.IsItem())
            {
                var item = (Answer)e.Item.DataItem;
                Item currItem = Sitecore.Context.Item;
                var q = Questions.QuestionFactory(currItem);
                HyperLink hypUserProfileLink = (HyperLink)e.Item.FindControl("hypUserProfileLink");
                if (hypUserProfileLink != null)
                {
                    hypUserProfileLink.NavigateUrl = MembershipHelper.GetPublicProfileUrl(item.Author);
                }
                LikeButton btnLikeCtrl = e.FindControlAs<LikeButton>("LikeButton");
                if (btnLikeCtrl != null)
                {
                    btnLikeCtrl.LoadState(item.ContentId, item.ContentTypeId);
                }
                HtmlButton btnLikeThumbsUp = e.FindControlAs<HtmlButton>("btnLike");
                if(btnLikeThumbsUp!=null)
                {
                    btnLikeThumbsUp.Attributes.Add("commentContentId", item.ContentId);
                }
                //Literal litGroup = e.FindControlAs<Literal>("lbGroup");
                //if (litGroup !=null)
                //{
                    
                //    if(q!=null){
                //        litGroup.Text = q.Group;
                //    }
                //}
                //HtmlAnchor hrefAnchor = e.FindControlAs<HtmlAnchor>("hrefTopic");
                //if (hrefAnchor != null)
                //{
                //    hrefAnchor.HRef = currItem.Parent.GetUrl() + "?topic=" + HttpUtility.UrlEncode(q.Group);
                //}
            }
        }

        protected void LikeButton_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                string contentTypeId = Constants.Settings.TelligentCommentContentTypeId;
                string contentId = ((HtmlButton)sender).Attributes["commentContentId"];
                TelligentService.LikeContent(CurrentMember.ScreenName, contentId, contentTypeId);
            }
            //using (var webClient = new WebClient())
            //{
            //    try
            //    {
            //        // replace the "admin" and "Admin's API key" with your valid user and apikey!
            //        var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            //        var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            //        webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            //        webClient.Headers.Add("Rest-Impersonate-User", this.CurrentMember.ScreenName.Trim());
            //        var requestUrl = String.Format("{0}api.ashx/v2/likes.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

            //        var values = new NameValueCollection();
            //        values.Add("ContentId", contentId);
            //        values.Add("ContentTypeId", contentTypeId);

            //        var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            //        Console.WriteLine(xml);
            //    }
            //    catch { } //TODO: Add logging
            //}
            Response.Redirect(Request.RawUrl);
        }
    }
}