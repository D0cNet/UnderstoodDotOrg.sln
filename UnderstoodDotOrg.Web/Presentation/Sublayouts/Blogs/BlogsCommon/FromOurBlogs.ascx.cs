using Sitecore.Configuration;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class FromOurBlogs : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = Settings.GetSetting(Constants.Settings.TelligentBlogIds);
            var dataSource = TelligentService.ListBlogPosts(blogId, "3");
            foreach (var item in dataSource)
            {
                string[] s = item.Title.Split('{');
                BlogsPostPageItem blogPost = Sitecore.Context.Database.GetItem(String.Format("{0}{1}", "{", s[1]));
                if (blogPost != null)
                {
                    var author = Sitecore.Context.Database.GetItem(blogPost.Author.Raw);
                    item.Author = author.Name;
                    item.Title = blogPost.Name;
                    item.ContentTypeId = blogPost.ContentTypeId;
                    item.Body = TelligentService.FormatString100(Sitecore.StringUtil.RemoveTags(blogPost.Body.Raw));
                    item.AuthorUrl = LinkManager.GetItemUrl(author);
                }
            }
            BlogPostsRepeater.DataSource = dataSource;
            BlogPostsRepeater.DataBind();
        }

        protected void BlogPostRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var post = (BlogPost)e.Item.DataItem;
            FollowButton follBtn = (FollowButton)e.Item.FindControl("follBtn");
            follBtn.LoadState(post.ContentId,  UnderstoodDotOrg.Common.Constants.TelligentContentType.BlogPost,post.ContentTypeId);
        }
    }
}