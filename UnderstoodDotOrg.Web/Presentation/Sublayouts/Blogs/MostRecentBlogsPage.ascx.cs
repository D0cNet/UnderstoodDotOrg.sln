using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class MostRecentBlogsPage : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = Request.QueryString["BlogId"];
            List<UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost> dataSource = CommunityHelper.ListBlogPosts(blogId, "100");
            foreach (var item in dataSource)
            {
                BlogsPostPageItem blogPost = Sitecore.Context.Database.GetItem("/Sitecore/Content/Home/Community and Events/Blogs/" + item.BlogName + "/" + item.Title);
                item.Author = blogPost.Author.Rendered;
                item.Body = CommunityHelper.FormatString100(CommunityHelper.FormatRemoveHtml(blogPost.Body.Raw));
                item.AuthorUrl = "/Community and Events/Blogs/Author/" + item.Author;
            }

            //Bind most recent posts
            rptRecentBlogInfo.DataSource = dataSource;
            rptRecentBlogInfo.DataBind();

            //Bind most talked about posts
            var mostTalkedDataSource = dataSource;
            mostTalkedDataSource.Sort((x, y) => -1 * x.CommentCount.CompareTo(y.CommentCount));
            rptMostTalkedBlogInfo.DataSource = mostTalkedDataSource;
            rptMostTalkedBlogInfo.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string query = TextHelper.RemoveHTML(txtSearch.Text);
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{B1EFCAA6-C79A-4908-84D0-B4BDFA5E25A3}")) + "?q=" + query + "&a=blog");
        }
    }
}