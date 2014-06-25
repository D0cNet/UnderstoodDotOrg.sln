namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    using System;
using System.Collections.Generic;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.Models.Telligent;

    public partial class SortBlogsRecent : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
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
            rptBlogInfo.DataSource = dataSource;
            rptBlogInfo.DataBind();
        }
    }
}