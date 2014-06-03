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
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class BlogsPostPage : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item currentItem = Sitecore.Context.Item;
            var fieldBlogId = currentItem.Fields[Constants.TelligentFieldNames.BlogId];
            var fieldBlogPostId = currentItem.Fields[Constants.TelligentFieldNames.BlogPostId];
            var fieldTelligentUrl = currentItem.Fields[Constants.TelligentFieldNames.TelligentUrl];

            if (string.IsNullOrEmpty(fieldTelligentUrl.ToString()))
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
    }
}