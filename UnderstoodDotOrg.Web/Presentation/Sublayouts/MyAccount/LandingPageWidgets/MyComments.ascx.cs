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
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent
{
    public partial class MyCommentsTest : BaseSublayout //System.Web.UI.UserControl
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
         
           
           
            var nodes = CommunityHelper.ReadUserComments(CurrentMember.ScreenName);

            if (nodes != null)
            {
                //Accept XmlNode of comments for now, because of special requirement of just the last two
                var comments = nodes.SelectNodes("Comments[position()<=2] ");
                // PagedList<Comment> commentList = PublicApi.Comments.Get(new CommentGetOptions() { UserId = 2100 });
                lblCount.Text = comments.Count.ToString();
                List<CommentSnippet> commentSource = new List<CommentSnippet>();
                foreach (XmlNode item in comments)
                {

                    CommentSnippet cm = new CommentSnippet();

                    var descNode = item.SelectSingleNode("//Content/HtmlDescription");
                    cm.Desc = descNode != null ? descNode.InnerText : string.Empty;

                    var titleNode = item.SelectSingleNode("//Content/HtmlName");
                    cm.Title = titleNode != null ? titleNode.InnerText : string.Empty;

                    var urlNode = item.SelectSingleNode("//Content/Url");
                    cm.Url = urlNode != null ? urlNode.InnerText : string.Empty;

                    commentSource.Add(cm);
                }

                topComments.DataSource = commentSource;
                topComments.DataBind();
            }

        }


    }
}