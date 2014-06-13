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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Comments : BaseSublayout
    {
        private int _blogId = 0;
        private int _blogPostId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            SubmitButton.Text = DictionaryConstants.SubmitButtonText;

            // TODO: convert to dictionary
            CommentEntryTextField.Attributes.Add("placeholder", "Add your comment...");

            Item currentItem = Sitecore.Context.Item;

            // Check to make sure the sitecore item has telligent fields populated
            // If not, populate them
            if (currentItem["BlogId"] == string.Empty || currentItem["ContentId"] == string.Empty
                || currentItem["ContentTypeId"] == string.Empty || currentItem["TelligentUrl"] == string.Empty)
            {
                if ((currentItem.InheritsFromType(DefaultArticlePageItem.TemplateId)
                    || currentItem.InheritsTemplate(BehaviorAdvicePageItem.TemplateId))
                    && currentItem.Name != "__StandardValues")
                {
                    if (currentItem["BlogId"] == string.Empty)
                    {
                        PopulateTelligentFields(currentItem, 4, currentItem.Name); //blog id should be 4
                    }
                }
                else if (currentItem.InheritsFromType(BlogsPostPageItem.TemplateId) && currentItem.Name != "__StandardValues")
                {
                    if (currentItem["BlogId"] == string.Empty)
                    {
                        switch (currentItem.Parent.ID.ToString())
                        {
                            case "{37478172-CCDF-454E-BABA-D56096EBE8F9}":
                                PopulateTelligentFields(currentItem, 1, currentItem.Name); //blog id should be 1
                                break;
                            case "{23DC4EBA-B296-46A7-AC68-D813C9931AF0}":
                                PopulateTelligentFields(currentItem, 2, currentItem.Name); //blog id should be 2
                                break;
                            case "{A720AAA9-8AC8-4851-A873-0E0F158C61BD}":
                                PopulateTelligentFields(currentItem, 3, currentItem.Name); //blog id should be 3
                                break;
                            default:
                                return;
                        }
                    }
                }
            }

            // TODO: refactor so pages all inherit a shared template item type
            var fieldBlogId = currentItem.Fields[Constants.TelligentFieldNames.BlogId];
            var fieldBlogPostId = currentItem.Fields[Constants.TelligentFieldNames.BlogPostId];
            valComment.ErrorMessage = DictionaryConstants.CommentErrorMessage;

            if (fieldBlogId == null || fieldBlogPostId == null)
            {
                this.Visible = false;
                return;
            }

            string blogId = fieldBlogId.Value ?? String.Empty;
            string blogPostId = fieldBlogPostId.Value ?? String.Empty;

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
            List<Comment> dataSource = CommunityHelper.ReadComments(_blogId.ToString(), _blogPostId.ToString());
            CommentRepeater.DataSource = dataSource;
            CommentRepeater.DataBind();

            // TODO: If paging is added, revise this to use TotalCount attribute in XML response
            // TODO: use dictionary
            CommentCountDisplay.Text = String.Format("Comments ({0})", dataSource.Count);
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
            CommunityHelper.PostComment(_blogId, _blogPostId, body, user);

            PopulateComments();

            // Clear postback value
            CommentEntryTextField.Value = String.Empty;
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
                        var contentUrl = node["Url"].InnerText;
                        var blogPostId = node["Id"].InnerText;
                        var telligentUrl = node["Url"].InnerText;

                        string PublishedDate = CommunityHelper.FormatDate(node["PublishedDate"].InnerText);

                    item.Editing.BeginEdit();
                    try
                    {
                        item["BlogPostId"] = blogPostId;
                        item["BlogId"] = blogId.ToString();
                        item["ContentId"] = contentId;
                        item["TelligentUrl"] = telligentUrl;
                        item["ContentTypeId"] = contentTypeId;
                    }
                    catch
                    {
                    }
                    item.Editing.EndEdit();

                }
                catch { } // TODO: Add logging
            }
        }
    }
}