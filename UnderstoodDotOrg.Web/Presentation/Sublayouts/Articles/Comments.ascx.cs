using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Web.UI.WebControls;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Framework.UI;
using System.Web.UI.HtmlControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Comments : BaseSublayout
    {
        protected string BlogId
        {
            get { return _blogId.ToString(); }
        }
        protected string BlogPostId
        {
            get { return _blogPostId.ToString(); }
        }
        protected string AjaxPath
        {
            get { return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.CommentsListEndpoint); }
        }

        private int _blogId = 0;
        private int _blogPostId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = DictionaryConstants.SubmitButtonText;

            // TODO: convert to dictionary
            txtComment.Attributes.Add("placeholder", "Add your comment...");

            Item currentItem = Sitecore.Context.Item;

            // TODO: refactor so pages all inherit a shared template item type
            var fieldBlogId = currentItem.Fields[Constants.TelligentFieldNames.BlogId];
            var fieldBlogPostId = currentItem.Fields[Constants.TelligentFieldNames.BlogPostId];
            rfvComment.ErrorMessage = DictionaryConstants.CommentErrorMessage;

            if (fieldBlogId == null || fieldBlogPostId == null)
            {
                LogMissingCommentFields();
                this.Visible = false;
                return;
            }

            string blogId = fieldBlogId.Value ?? String.Empty;
            string blogPostId = fieldBlogPostId.Value ?? String.Empty;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId))
            {
                LogMissingCommentFields();
                this.Visible = false;
                return;
            }

            if (Int32.TryParse(blogId, out _blogId) && Int32.TryParse(blogPostId, out _blogPostId))
            {
                if (!IsPostBack)
                {
                    PopulateComments();
                }
            }
        }

        private void LogMissingCommentFields()
        {
            Sitecore.Diagnostics.Log.Info(
                    String.Format("Item missing blog/blogpost values for comments, {0}", Sitecore.Context.Item.ID), this);
        }

        private void PopulateComments()
        {
            bool hasMoreResults;
            int totalComments;

            List<Comment> dataSource = CommunityHelper.ReadComments(
                _blogId.ToString(), _blogPostId.ToString(), 1, Constants.ARTICLE_COMMENTS_PER_PAGE, "CreatedUtcDate", true, out totalComments, out hasMoreResults);
            commentsControl.Comments = dataSource;

            pnlShowMore.Visible = hasMoreResults;

            litCommentCount.Text = totalComments.ToString();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn)
            {
                // TODO: redirect to sign in page
                return;
            }


            if (CurrentMember.ScreenName.IsNullOrEmpty())
            {
                Sitecore.Diagnostics.Log.Error(
                    String.Format("Member has empty screen name, member id: {0}", CurrentMember.MemberId), this);
            }

            CommunityHelper.PostComment(_blogId, _blogPostId, txtComment.Text.Trim(), CurrentMember.ScreenName);

            Response.Redirect(Request.RawUrl);
        }

        protected void FlagButton_Click(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn)
            {
                // TODO: redirect
                return;
            }

            LinkButton btn = (LinkButton)sender;
            string id = btn.CommandArgument;

            using (var webClient = new WebClient())
            {
                try
                {
                    var adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    webClient.Headers.Add("Rest-Method", "PUT");
                    var requestUrl = String.Format("{0}api.ashx/v2/comments/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), id);

                    var values = new NameValueCollection();
                    values.Add("CommentId", id);
                    values.Add("IsApproved", "false");

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                    Response.Redirect(Request.RawUrl);
                }
                catch { } // TODO: add logging
            }
        }

        protected void LikeButton_Click(object sender, EventArgs e)
        {
            if (!IsUserLoggedIn)
            {
                // TODO: redirect
                return;
            }

            LinkButton btn = (LinkButton)(sender);
            string ids = btn.CommandArgument;
            string[] s = ids.Split('&');

            string contentId = s[0];
            string contentTypeId = s[1];

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", CommunityHelper.TelligentAuth());
                    webClient.Headers.Add("Rest-Impersonate-User", this.CurrentMember.ScreenName.Trim());
                    var requestUrl = String.Format("{0}api.ashx/v2/likes.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

                    var values = new NameValueCollection();
                    values.Add("ContentId", contentId);
                    values.Add("ContentTypeId", contentTypeId);

                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                    Response.Redirect(Request.RawUrl);
                }
                catch { } // TODO: add loggin
            }
        }
        private void PopulateTelligentFields(Item item, int blogId, string title)
        {
            BlogPost blogPost = new BlogPost();

            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", CommunityHelper.TelligentAuth());
                    var requestUrl = CommunityHelper.GetApiEndPoint(String.Format("blogs/{0}/posts/{1}.xml", blogId, title));

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/BlogPost");

                    var contentId = node["ContentId"].InnerText;
                    var contentTypeId = node["ContentTypeId"].InnerText;
                    var blogPostId = node["Id"].InnerText;
                    var telligentUrl = node["Url"].InnerText;

                    // TODO: revisit, this probably shouldn't be on page load
                    using (new Sitecore.Data.Items.EditContext(item, updateStatistics: false, silent: true))
                    {
                        item["BlogPostId"] = blogPostId;
                        item["BlogId"] = blogId.ToString();
                        item["ContentId"] = contentId;
                        item["TelligentUrl"] = telligentUrl;
                        item["ContentTypeId"] = contentTypeId;
                    }
                }
                catch { } // TODO: Add logging
            }
        }
    }
}