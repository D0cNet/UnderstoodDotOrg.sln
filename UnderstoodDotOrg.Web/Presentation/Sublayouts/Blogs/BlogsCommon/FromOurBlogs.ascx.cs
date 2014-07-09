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
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common;

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
                if (blogPost != null)
                {
                    item.Author = blogPost.Author.Rendered;
                    item.ContentTypeId = blogPost.ContentTypeId;
                    item.Body = CommunityHelper.FormatString100(CommunityHelper.FormatRemoveHtml(blogPost.Body.Raw));
                    var author = Sitecore.Context.Database.GetItem("/sitecore/content/Home/Community and Events/Blogs/Author/" + item.Author);
                    item.AuthorUrl = "/Community and Events/Blogs/Author/" + item.Author;
                    if (this.CurrentMember != null)
                    {
                        if (!this.CurrentMember.ScreenName.IsNullOrEmpty())
                        {
                            if (CommunityHelper.IsBookmarked(this.CurrentMember.ScreenName, item.ContentId))
                            {
                                item.IsFollowing = true;
                            }
                        }
                    }
                }
            }
            BlogPostsRepeater.DataSource = dataSource;
            BlogPostsRepeater.DataBind();
        }

        protected void BlogPostRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item)
            //{
            //    BlogPost post = (BlogPost)e.Item.DataItem;
            //    Button button = (Button)e.Item.FindControl("btnFollow");
            //    button.Click += new System.EventHandler(this.btnFollow_Click);
            //    if (post.IsFollowing)
            //    {
            //        button.Text = "Unfollow";
            //    }
            //    else
            //    {
            //        button.Text = "Follow";
            //    }
            //}
            var post = (BlogPost)e.Item.DataItem;
            FollowButton follBtn = (FollowButton)e.Item.FindControl("follBtn");
            follBtn.LoadState(post.ContentId, post.ContentTypeId, UnderstoodDotOrg.Common.Constants.TelligentContentType.BlogPost);
        }

        protected void btnFollow_Click(object sender, EventArgs e)
        {
            Button btn = (Button)(sender);
            string[] id = btn.CommandArgument.Split('&');
            string contentId = id[0];
            string contentTypeId = id[1];
            if (this.CurrentMember != null)
            {
                if (!this.CurrentMember.ScreenName.IsNullOrEmpty())
                {
                    CommunityHelper.SaveItem(this.CurrentMember.ScreenName, contentId, contentTypeId);
                }
            }
        }
    }
}