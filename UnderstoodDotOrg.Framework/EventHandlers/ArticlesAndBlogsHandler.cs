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
            // item.path.paths
            var itm = Sitecore.Events.Event.ExtractParameter(args, 0) as Item;
            int blogId = 0;

            if (itm.InheritsFromType(DefaultArticlePageItem.TemplateId.ToString())
                || itm.InheritsTemplate(BehaviorAdvicePageItem.TemplateId))
            {
                if (itm["BlogId"] == "" || itm["BlogId"] == "1")
                {
                    blogId = 4;
                    CreateTelligentPost(itm, blogId);
                }
            }
            else if (itm.InheritsFromType(BlogsPostPageItem.TemplateId.ToString()))
            {
                if (itm["BlogId"] == "")
                {
                    switch (itm.Parent.ID.ToString())
                    {
                        case "{37478172-CCDF-454E-BABA-D56096EBE8F9}":
                            blogId = 1;
                            break;
                        case "{23DC4EBA-B296-46A7-AC68-D813C9931AF0}":
                            blogId = 2;
                            break;
                        case "{A720AAA9-8AC8-4851-A873-0E0F158C61BD}":
                            blogId = 3;
                            break;
                        default:
                            return;
                    }
                    CreateTelligentPost(itm, blogId);
                }
                //if (blogId != 0 && (itm.TemplateID.ToString() == BlogsPostPageItem.TemplateId || itm.TemplateID.ToString() == DefaultArticlePageItem.TemplateId))
                //{
                    //CreateTelligentPost(itm, blogId);
                //}
            }
        }
        
        

        private void CreateTelligentPost(Item item, int blogId)
        {
            try
            {
                var webClient = new WebClient();

                // replace the "admin" and "Admin's API key" with your valid user and apikey!
              //  var adminKey = string.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
                var adminKeyBase64 = CommunityHelper.TelligentAuth(); //Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

                webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
                var requestUrl = string.Format("{0}api.ashx/v2/blogs/{1}/posts.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId);

                var values = new NameValueCollection();
                values["Title"] = item.Name;
                values["Body"] = item.Paths.Path;


                var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPost");
                foreach (XmlNode xn in nodes)
                {
                    try
                    {
                        item.Editing.BeginEdit();
                        item["BlogPostId"] = xn["Id"].InnerText;
                        item["BlogId"] = blogId.ToString();
                        item["ContentId"] = xn["ContentId"].InnerText;

                    }
                    finally
                    {
                        item.Editing.EndEdit();
                    }
                }
            }
            catch
            {
                // do nothing for now
            }
        }
    }
}