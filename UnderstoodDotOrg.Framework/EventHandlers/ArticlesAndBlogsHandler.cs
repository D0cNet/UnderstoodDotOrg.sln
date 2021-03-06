﻿using Sitecore.Configuration;
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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
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
                || item.Name.ToLower() == "__standard values")
            {
                return;
            }

            // Behavior Tools
            if (item.TemplateID == Sitecore.Data.ID.Parse(BehaviorToolsAdvicePageItem.TemplateId)
                || item.TemplateID == Sitecore.Data.ID.Parse(BehaviorToolsAdviceVideoPageItem.TemplateId))
            {
                if (item["BlogId"] == string.Empty)
                {
                    CreateTelligentPost(item, 11);
                }
            }
                // Articles
            else if (item.InheritsFromType(DefaultArticlePageItem.TemplateId))
            {
                if (item["BlogId"] == string.Empty)
                {
                    CreateTelligentPost(item, 4);
                }
            }
            // Blog Posts
            else if (item.TemplateID == Sitecore.Data.ID.Parse(BlogsPostPageItem.TemplateId))
            {
                if (item["BlogId"] == string.Empty)
                {
                    switch (item.Parent.ID.ToString())
                    {
                        case "{401A4297-3D08-4BB5-8F19-EC32A38C82C6}":
                            CreateTelligentPost(item, 1);
                            break;
                        case "{E77C456C-3B33-40B0-8828-C6AA53906045}":
                            CreateTelligentPost(item, 2);
                            break;
                        case "{62017F9B-2DF5-490A-95A7-5C1ACF3573D1}":
                            CreateTelligentPost(item, 3);
                            break;
                        default:
                            return;
                    }
                }
            }
            // Assistive Tech
            else if (item.TemplateID == Sitecore.Data.ID.Parse("{C9DFC576-7750-4A84-9A79-61F16585E64E}"))
            {
                if (item["BlogId"] == string.Empty)
                {
                    CreateTelligentPost(item, Int32.Parse(Settings.GetSetting(Common.Constants.Settings.TelligentAssistiveTechBlogId)));
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
                // Append ID to keep title unique
                { "Title", String.Format("{0} {1}", item.Name, item.ID.ToString()) },
                { "Body", item.ID.ToString() }
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
                    var contentTypeId = node["ContentTypeId"].InnerText;
                    var telligentUrl = node["Url"].InnerText;
                    
                    using (new Sitecore.Data.Items.EditContext(item, updateStatistics: false, silent: true))
                    {
                        item["BlogPostId"] = blogPostId;
                        item["BlogId"] = blogId.ToString();
                        item["ContentId"] = contentId;
                        item["ContentTypeId"] = contentTypeId;
                        item["TelligentUrl"] = telligentUrl;
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