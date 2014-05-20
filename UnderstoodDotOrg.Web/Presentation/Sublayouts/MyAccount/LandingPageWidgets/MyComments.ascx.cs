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
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Test.Telligent
{
    public partial class MyCommentsTest : BaseSublayout //System.Web.UI.UserControl
    {
        private class CommentModel
        {
            public string Title { get; set; }
            public string Desc { get; set; }
            public string Url { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var itemMyAccountComment = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccountComments);
            hypCommentsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(itemMyAccountComment);
            
            var nodes = CommunityHelper.ReadUserComments(CurrentMember.ScreenName);

            if (nodes != null)
            {
                //Accept XmlNode of comments for now, because of special requirement of just the last two
                var comments = nodes.SelectNodes("Comments[position()<=2] ");
                // PagedList<Comment> commentList = PublicApi.Comments.Get(new CommentGetOptions() { UserId = 2100 });
                lblCount.Text = comments.Count.ToString();
                List<CommentModel> commentSource = new List<CommentModel>();
                foreach (XmlNode item in comments)
                {

                    CommentModel cm = new CommentModel();

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

        protected void topComments_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                if (e.Item.DataItem != null)
                {
                    HyperLink lnk = (HyperLink)e.Item.FindControl("cLink");
                    lnk.NavigateUrl = ((CommentModel)e.Item.DataItem).Url;
                    lnk.Text = ((CommentModel)e.Item.DataItem).Title;

                    Literal lit = (Literal)e.Item.FindControl("cDesc");
                    lit.Text = ((CommentModel)e.Item.DataItem).Desc;
                }

            }
        }

    }
}