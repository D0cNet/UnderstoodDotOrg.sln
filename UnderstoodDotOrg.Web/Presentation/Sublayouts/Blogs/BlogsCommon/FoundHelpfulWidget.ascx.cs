using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class FoundHelpfulWidget : BaseSublayout
    {
        public BlogsPostPageItem blogCig = new BlogsPostPageItem(Sitecore.Context.Item);

        protected void Page_Load(object sender, EventArgs e)
        {
            var contentId = blogCig.ContentId.Raw;

            LikeCount.Text = CommunityHelper.GetTotalLikes(contentId).ToString();

            var blogId = blogCig.BlogId.Raw;
            var blogPostId = blogCig.BlogPostId.Raw;
            CommentCount.Text = CommunityHelper.ReadComments(blogId, blogPostId).Count.ToString();
            var blogPostInfo = CommunityHelper.ReadBlogBody(Int32.Parse(blogId), Int32.Parse(blogPostId));
            btnLike.CommandArgument = btnUnlike.CommandArgument = blogPostInfo.ContentId + "&" + blogPostInfo.ContentTypeId;
        }
        protected void btnThisHelped_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ids = btn.CommandArgument;
            string[] s = ids.Split('&');

            string contentId = s[0];
            string contentTypeId = s[1];

            var webClient = new WebClient();

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
        protected void btnDidntHelp_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string ids = btn.CommandArgument;
            string[] s = ids.Split('&');

            string contentId = s[0];
            string contentTypeId = s[1];

            var username = this.CurrentMember.ScreenName.Trim();
            var like = new LikeModel();
            if (!string.IsNullOrEmpty(username))
            {
                like = CommunityHelper.GetLike(this.CurrentMember.ScreenName.Trim(), contentId, contentTypeId);
            }
            using (var webClient = new WebClient())
            {
                try
                {
                    // replace the "admin" and "Admin's API key" with your valid user and apikey!
                    var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
                    var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    webClient.Headers.Add("Rest-Method", "DELETE");

                    var requestUrl = String.Format("{0}api.ashx/v2/likes.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

                    var values = new NameValueCollection();
                    values.Add("ContentUrl", like.ContentUrl);

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                    Console.WriteLine(xml);
                }
                catch { } //TODO: Add logging
            }
        }
    }
}