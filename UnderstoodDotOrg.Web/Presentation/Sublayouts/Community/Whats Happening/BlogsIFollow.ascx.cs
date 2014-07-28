namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    using Sitecore.Links;
    using System;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Framework.UI;
    using UnderstoodDotOrg.Services.Models.Telligent;
    using UnderstoodDotOrg.Services.TelligentService;
    using System.Collections.Generic;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;

    public partial class BlogsIFollow : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            InitContent();
        }

        protected void InitContent()
        {
            lnkSeeAll.NavigateUrl = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.AllBlogs));

            if (IsUserLoggedIn)
            {
                var followedBlogs = TelligentService.GetFollowedBlogs(this.CurrentMember.ScreenName);

                string blogIds = string.Empty;

                foreach (var item in followedBlogs)
                {
                    blogIds = string.Format("{0}{1},", blogIds, Constants.BlogIds[item.Title]);
                }

                var dataSource = new List<BlogPost>();
                string temp = string.Empty;
                var blogPostList = TelligentService.ListBlogPosts(blogIds, "100");
                foreach (var item in blogPostList)
                {
                    if (!item.BlogName.Equals(temp))
                    {
                        dataSource.Add(item);
                        temp = item.BlogName;
                    }
                    if (dataSource.Count == 2)
                    {
                        break;
                    }
                }
                foreach (var item in dataSource)
                {
                    var sitecoreId = string.Empty;
                    if (item.Title.Contains("{"))
                    {
                        string[] s = item.Title.Split('{');
                        item.Title = s[0];
                        sitecoreId = "{" + s[1];
                    }
                    else
                    {
                        string[] s = item.Body.Split('<');
                        sitecoreId = s[0];
                    }
                    if (!sitecoreId.IsNullOrEmpty())
                    {
                        BlogsPostPageItem blogPost = Sitecore.Context.Database.GetItem(sitecoreId);
                        item.Body = TelligentService.FormatString160(blogPost.Body);
                        
                        try
                        {
                            item.Author = Sitecore.Context.Database.GetItem(blogPost.Author.Raw)["Name"];
                        }
                        catch (Exception)
                        { }

                        item.ItemUrl = blogPost.GetUrl();
                        item.AuthorUrl = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(blogPost.Author.Raw));
                    }
                }
                rptBlogCards.DataSource = dataSource;
                rptBlogCards.DataBind();
            }
        }
    }
}