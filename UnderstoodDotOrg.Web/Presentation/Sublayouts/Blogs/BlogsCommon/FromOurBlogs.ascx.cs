using Sitecore.Configuration;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class FromOurBlogs : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = Settings.GetSetting(Constants.Settings.TelligentBlogIds);
            var dataSource = CommunityHelper.ListBlogPosts(blogId, "6");
            foreach (var item in dataSource)
            {
                BlogsPostPageItem blogPost = Sitecore.Context.Database.GetItem("/Sitecore/Content/Home/Community and Events/Blogs/" + item.BlogName + "/" + item.Title);
                item.Author = blogPost.Author;
                item.Body = CommunityHelper.FormatString100(CommunityHelper.FormatRemoveHtml(blogPost.Body.Raw));
                item.AuthorUrl = "/Community and Events/Blogs/Author/" + item.Author;
            }
            BlogPostsRepeater.DataSource = dataSource;
            BlogPostsRepeater.DataBind();
        }
    }
}