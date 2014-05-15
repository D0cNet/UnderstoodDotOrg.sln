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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Comments : System.Web.UI.UserControl
    {
        private int _blogId = 0;
        private int _blogPostId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            SubmitButton.Text = DictionaryConstants.SubmitButtonText;

            // TODO: convert to dictionary
            CommentEntryTextField.Attributes.Add("placeholder", "Add your comment...");

            Item currentItem = Sitecore.Context.Item;
            string blogId = currentItem.Fields[Constants.TelligentFieldNames.BlogId].Value ?? String.Empty;
            string blogPostId = currentItem.Fields[Constants.TelligentFieldNames.BlogPostId].Value ?? String.Empty;

            if (String.IsNullOrEmpty(blogId) || String.IsNullOrEmpty(blogPostId))
            {
                // TODO: hide entire control or elements 
                this.Visible = false;
                return;
            }

            if (Int32.TryParse(blogId, out _blogId) && Int32.TryParse(blogPostId, out _blogPostId))
            {
                PopulateComments();
            }
        }

        private void PopulateComments()
        {
            List<Comment> dataSource = CommunityHelper.ReadComments(_blogId, _blogPostId);
            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();

            // TODO: use dictionary
            CommentCountDisplay.Text = String.Format("Comments ({0})", dataSource.Count);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string body = CommentEntryTextField.Text;
            CommunityHelper.PostComment(_blogId, _blogPostId, body);

            PopulateComments();

            // Clear postback value
            CommentEntryTextField.Text = String.Empty;
        }

        protected void FlagButton_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            string id = btn.CommandArgument;

            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
           // var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = CommunityHelper.TelligentAuth();//Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Rest-Method", "PUT");
            var requestUrl = String.Format("{0}api.ashx/v2/comments/{1}.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), id);

            var values = new NameValueCollection();
            values.Add("CommentId", id);
            values.Add("IsApproved", "false");

            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            Console.WriteLine(xml);
        }

        protected void ReplyButton_Click(object sender, EventArgs e)
        {
            CommentEntryTextField.Focus();
        }

        protected void LikeButton_Click(object sender, EventArgs e)
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
            var requestUrl = String.Format("{0}api.ashx/v2/likes.xml", Settings.GetSetting(Constants.Settings.TelligentConfig));

            var values = new NameValueCollection();
            values.Add("ContentId", contentId);
            values.Add("ContentTypeId", contentTypeId);

            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            Console.WriteLine(xml);

            PopulateComments();
        }       
    }
}