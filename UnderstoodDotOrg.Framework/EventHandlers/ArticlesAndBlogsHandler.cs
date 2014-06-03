using Sitecore.Configuration;
using Sitecore.Data.Items;
using Sitecore.Events;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Framework.EventHandlers
{
    class ArticlesAndBlogsHandler
    {
        protected void OnItemSaved(object sender, EventArgs args)
        {
            var itm = Sitecore.Events.Event.ExtractParameter(args, 0) as Item;

            //if (itm.InheritsFromType(DefaultArticlePageItem.TemplateId)
            //    || itm.InheritsTemplate(BehaviorAdvicePageItem.TemplateId))
            //{
            //    if (itm["BlogId"] == string.Empty)
            //    {
            //        CreateTelligentPost(itm, 4); //blog id should be 4
            //    }
            //}
            //else if (itm.InheritsFromType(BlogsPostPageItem.TemplateId))
            //{
            //    if (itm["BlogId"] == string.Empty)
            //    {
            //        switch (itm.Parent.ID.ToString())
            //        {
            //            case "{37478172-CCDF-454E-BABA-D56096EBE8F9}":
            //                CreateTelligentPost(itm, 1); //blog id should be 1
            //                break;
            //            case "{23DC4EBA-B296-46A7-AC68-D813C9931AF0}":
            //                CreateTelligentPost(itm, 2); //blog id should be 2
            //                break;
            //            case "{A720AAA9-8AC8-4851-A873-0E0F158C61BD}":
            //                CreateTelligentPost(itm, 3); //blog id should be 3
            //                break;
            //            default:
            //                return;
            //        }
            //    }
            //}
            if (itm["TelligentUrl"] == string.Empty)
            {
                AddTelligentUrl(itm, itm["BlogId"], itm["BlogPostId"]);
            }
        }

        private void CreateTelligentPost(Item item, int blogId)
        {
            try
            {
                var webClient = new WebClient();

                var adminKeyBase64 = CommunityHelper.TelligentAuth();

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                var requestUrl = string.Format(
                    "{0}api.ashx/v2/blogs/{1}/posts.xml",
                    Settings.GetSetting(Constants.Settings.TelligentConfig),
                    blogId);

                var values = new NameValueCollection();
                values["Title"] = item.Name;
                values["Body"] = item.Paths.Path;

                var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                var node = xmlDoc.SelectSingleNode("Response/BlogPost");
                var blogPostId = node["Id"].InnerText;
                var contentId = node["ContentId"].InnerText;
                var telligentUrl = node["Url"].InnerText;

                item.Editing.BeginEdit();
                try
                {
                    item["BlogPostId"] = blogPostId;
                    item["BlogId"] = blogId.ToString();
                    item["ContentId"] = contentId;
                    item["TelligentUrl"] = telligentUrl;
                }
                catch
                {
                }
                item.Editing.EndEdit();
            }
            catch
            {
                var e = new Exception(@"Item Creation Failed:
The title of the item you created matches the title of an item that already exists. Please rename the article that you've just created.");
                throw e;
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