using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class BlogsPostPage : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //i read this page. now record it.
            //MembershipManager mgr = new MembershipManager();

            //mgr.LogMemberActivity(new Guid(), new Guid(), Constants.UserActivity_Values.WasRead, Constants.UserActivity_Types.Type_Blog);

            Item currentItem = Sitecore.Context.Item;
            var fieldBlogId = currentItem.Fields[Constants.TelligentFieldNames.BlogId];
            var fieldBlogPostId = currentItem.Fields[Constants.TelligentFieldNames.BlogPostId];
            var fieldTelligentUrl = currentItem.Fields[Constants.TelligentFieldNames.TelligentUrl];
            var fieldContentTypeId = currentItem.Fields[Constants.TelligentFieldNames.ContentTypeId];

            if (string.IsNullOrEmpty(fieldTelligentUrl.ToString()))
            {
                AddTelligentUrl(currentItem, fieldBlogId.ToString(), fieldBlogPostId.ToString());
            }
            if (string.IsNullOrEmpty(fieldContentTypeId.ToString()))
            {
                AddTelligentUrl(currentItem, fieldBlogId.ToString(), fieldBlogPostId.ToString());
            }
        }
        private void AddTelligentUrl(Item item, string blogId, string blogPostId)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", CommunityHelper.TelligentAuth());
                    var requestUrl = CommunityHelper.GetApiEndPoint(String.Format("blogs/{0}/posts/{1}.xml", blogId, blogPostId));

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/BlogPost");

                    XmlNode auth = xmlDoc.SelectSingleNode("Response/BlogPost/Author");

                    var telligentUrl = node["Url"].InnerText;

                    item.Editing.BeginEdit();
                    try
                    {
                        item["TelligentUrl"] = telligentUrl;
                    }
                    catch
                    {
                    }
                    item.Editing.EndEdit();

                }
                catch { } // TODO: Add logging
            }
        }

        private void AddContentTypeId(Item item, string blogId, string blogPostId)
        {
            using (var webClient = new WebClient())
            {
                try
                {
                    webClient.Headers.Add("Rest-User-Token", CommunityHelper.TelligentAuth());
                    var requestUrl = CommunityHelper.GetApiEndPoint(String.Format("blogs/{0}/posts/{1}.xml", blogId, blogPostId));

                    var xml = webClient.DownloadString(requestUrl);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    XmlNode node = xmlDoc.SelectSingleNode("Response/BlogPost");

                    XmlNode auth = xmlDoc.SelectSingleNode("Response/BlogPost/Author");

                    var contentTypeId = node["ContentTypeId"].InnerText;

                    item.Editing.BeginEdit();
                    try
                    {
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