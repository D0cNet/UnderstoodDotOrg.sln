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
    public class ArticlesAndBlogsHandler
    {
        protected void OnItemSaved(object sender, EventArgs args)
        {
            Sitecore.Data.Items.Item item = Sitecore.Events.Event.ExtractParameter(args, 0) as Item;
            Sitecore.Diagnostics.Assert.IsNotNull(item, "item");

            if ((item.Database != null && item.Database.Name != "master")
                || item.Name.ToLower() == "__standardvalues")
            {
                return;
            }

            if (item.InheritsFromType(DefaultArticlePageItem.TemplateId)
                || item.InheritsTemplate(BehaviorAdvicePageItem.TemplateId))
            {
                var t = item["BlogId"];
                if (item["BlogId"] == string.Empty)
                {
                    CreateTelligentPost(item, 4); //blog id should be 4
                }
            }
            else if (item.InheritsFromType(BlogsPostPageItem.TemplateId))
            {
                if (item["BlogId"] == string.Empty)
                {
                    switch (item.Parent.ID.ToString())
                    {
                        case "{37478172-CCDF-454E-BABA-D56096EBE8F9}":
                            CreateTelligentPost(item, 1); //blog id should be 1
                            break;
                        case "{23DC4EBA-B296-46A7-AC68-D813C9931AF0}":
                            CreateTelligentPost(item, 2); //blog id should be 2
                            break;
                        case "{A720AAA9-8AC8-4851-A873-0E0F158C61BD}":
                            CreateTelligentPost(item, 3); //blog id should be 3
                            break;
                        case "{CEE7D06D-F14F-4A34-BA72-95381FFFCC75}":
                            CreateTelligentPost(item, 7); //blog id should be 3
                            break;
                        case "{A6B58A59-A00B-4F6D-BBA2-8ECB82CB0BBA}":
                            CreateTelligentPost(item, 8); //blog id should be 3
                            break;
                        case "{D882ED4F-4E03-4351-A764-36DA8EE82EF2}":
                            CreateTelligentPost(item, 9); //blog id should be 3
                            break;
                        default:
                            return;
                    }
                }
            }
        }

        private void CreateTelligentPost(Item item, int blogId)
        {
            var requestUrl = string.Format(
                    "{0}api.ashx/v2/blogs/{1}/posts.xml",
                    Settings.GetSetting(Constants.Settings.TelligentConfig),
                    blogId);

            var values = new NameValueCollection
            {
                { "Title", item.Name },
                { "Body", item.Paths.Path }
            };

            try
            {
                using (var webClient = new WebClient())
                {
                    var adminKeyBase64 = CommunityHelper.TelligentAuth();

                    webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                    
                    var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xml);

                    var node = xmlDoc.SelectSingleNode("Response/BlogPost");
                    var blogPostId = node["Id"].InnerText;
                    var contentId = node["ContentId"].InnerText;
                    
                    using (new Sitecore.Data.Items.EditContext(item, updateStatistics: false, silent: true))
                    {
                        item["BlogPostId"] = blogPostId;
                        item["BlogId"] = blogId.ToString();
                        item["ContentId"] = contentId;
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(
                    String.Format("Telling post handler failed: {0}", requestUrl), ex, this);
            }
        }
    }
}