using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.Xml;
using Sitecore.Configuration;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent
{
    public partial class MyCommentsTest : System.Web.UI.UserControl
    {
        private class CommentSnippet
        {
            public string Title { get; set; }
            public string Desc { get; set; }
            public string Url { get; set; }

        }

        protected override void OnInit(EventArgs e)
        {
            topComments.ItemDataBound += topComments_ItemDataBound;
            
            base.OnInit(e);
        }

    
        void topComments_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            
            
                if (e.Item.ItemType == ListViewItemType.DataItem)
                {
                    if (e.Item.DataItem != null)
                    {
                        HyperLink lnk = (HyperLink)e.Item.FindControl("cLink");
                        if (lnk != null)
                        {
                            lnk.NavigateUrl = ((CommentSnippet)e.Item.DataItem).Url;
                            lnk.Text = ((CommentSnippet)e.Item.DataItem).Title;

                        }

                        Literal lit = (Literal)e.Item.FindControl("cDesc");
                        if (lit != null)
                            lit.Text = ((CommentSnippet)e.Item.DataItem).Desc;
                    }

                }
         
           

        }
        protected void Page_Load(object sender, EventArgs e)
        {
         
            var webClient = new WebClient();
            var apiKey = "d956up05xiu5l8fn7wpgmwj4ohgslp";
           
            var adminKey = String.Format("{0}:{1}", apiKey, "admin");
            var adminKeyBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(adminKey));

            //TODO: retrieve current logged in user
            var userId ="admin";
            //Todo: ID value should come from some inprocess maintained session of currently logged on user
            var id = "2100";
            webClient.Headers.Add("Rest-User-Token", adminKeyBase64);
            webClient.Headers.Add("Rest-Impersonate-User", userId);
            var requestUrl = Sitecore.Configuration.Settings.GetSetting("TelligentConfig")+"/api.ashx/v2/comments.xml?UserId="+id;
              
            
           
            var xml = webClient.DownloadString(requestUrl);
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            var nodes = xmlDoc.SelectNodes("Response/Comments[position()<=2] ");
         // PagedList<Comment> commentList = PublicApi.Comments.Get(new CommentGetOptions() { UserId = 2100 });
            lblCount.Text = nodes.Count.ToString();
            List<CommentSnippet> commentSource = new List<CommentSnippet>();
            foreach (XmlNode item in nodes)
            {
                
                CommentSnippet cm = new CommentSnippet();
                cm.Desc = item.SelectSingleNode("//Content/HtmlDescription").InnerText;
                cm.Title = item.SelectSingleNode("//Content/HtmlName").InnerText;
                cm.Url = item.SelectSingleNode("//Content/Url").InnerText;
                commentSource.Add(cm);
            }

            topComments.DataSource = commentSource;
            topComments.DataBind();

        }


    }
}