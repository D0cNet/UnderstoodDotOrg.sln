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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Blogs;

namespace UnderstoodDotOrg.Framework.EventHandlers
{
    class ArticlesAndBlogsHandler
    {
        protected void OnItemSaved(object sender, EventArgs args)
        {
            //item.path.paths
            var itm = Event.ExtractParameter(args, 0) as Item;
            int blogId = 0;
            switch (itm.Parent.Name)
            {
                case "The Understood Blog":
                    blogId = 1;
                    break;
                case "Motherlode":
                    blogId = 2;
                    break;
                case "Live Well":
                    blogId = 3;
                    break;
                default:
                    return;
            }
            if (itm["Post"] == "")
            {
                if (blogId != 0 && (itm.TemplateID.ToString() == BlogsPostPageItem.TemplateId || itm.TemplateID.ToString() == DefaultArticlePageItem.TemplateId))
                {
                    CreateTelligentPost(itm, blogId);
                }
            }
        }

        private void CreateTelligentPost(Item item, int blogId)
        {
            var webClient = new WebClient();

            // replace the "admin" and "Admin's API key" with your valid user and apikey!
            var adminKey = String.Format("{0}:{1}", Settings.GetSetting(Constants.Settings.TelligentAdminApiKey), "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            var requestUrl = String.Format("{0}api.ashx/v2/blogs/{1}/posts.xml", Settings.GetSetting(Constants.Settings.TelligentConfig), blogId);

            var values = new NameValueCollection();
            values["Title"] = item.Name;
            values["Body"] = item.Paths.FullPath;

            var xml = Encoding.UTF8.GetString(webClient.UploadValues(requestUrl, values));

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList nodes = xmlDoc.SelectNodes("Response/BlogPost");
            foreach (XmlNode xn in nodes)
            {
                try
                {
                    item.Editing.BeginEdit();
                    item["Post"] = xn["ContentId"].InnerText;
                }
                finally
                {
                    item.Editing.EndEdit();
                }
            }
        }
    }
}
