using Sitecore.Data.Items;
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
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class MostRecentBlogsPage : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnMostRead.Text = UnderstoodDotOrg.Common.DictionaryConstants.MostReadLabel;
            btnMostShared.Text = UnderstoodDotOrg.Common.DictionaryConstants.MostSharedLabel;
            btnMostRecent.Text = UnderstoodDotOrg.Common.DictionaryConstants.MostRecentLabel;
            btnMostTalked.Text = UnderstoodDotOrg.Common.DictionaryConstants.MostTalkedLabel;

            var dataSource = InitContent();

            rptRecentBlogInfo.DataSource = dataSource;
            rptRecentBlogInfo.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Panel panResultText = (Panel)FindControl("panResultText");
            panResultText.Visible = true;

            Literal litResultCount = (Literal)FindControl("litResultCount");
            Literal litSearchTerm = (Literal)FindControl("litSearchTerm");

            Repeater rptRecentBlogInfo = (Repeater)FindControl("rptRecentBlogInfo");
            string query = TextHelper.RemoveHTML(txtSearch.Text);
            var dataSource = TelligentService.CommunitySearch(query, Constants.TelligentSearchParams.Blog, Constants.BlogNames[Sitecore.Context.Item["BlogId"]]);

            litSearchTerm.Text = query;

            if (dataSource.Any())
            {
                foreach (var item in dataSource)
                {
                    string[] s = item.Title.Split('{');
                    BlogsPostPageItem blogPost = Sitecore.Context.Database.GetItem(String.Format("{0}{1}", "{", s[1]));

                    if (blogPost != null)
                    {
                        item.Title = s[0].Trim();

                        if (!item.Title.ToLower().Contains("comment on"))
                        {
                            item.Body = Sitecore.StringUtil.RemoveTags(TelligentService.FormatString100(blogPost.Body));
                        }

                        BlogsAuthorPageItem author = Sitecore.Context.Database.GetItem(blogPost.Author.Raw);
                        if (author != null)
                        {
                            item.Author = author.Name;
                        }
                        else { item.Author = null; }
                    }
                }
            }

            litResultCount.Text = dataSource.Count.ToString();

            rptRecentBlogInfo.DataSource = dataSource;
            rptRecentBlogInfo.DataBind();
        }

        protected void btnMostRecent_Click(object sender, EventArgs e)
        {
            Panel panResultText = (Panel)FindControl("panResultText");
            panResultText.Visible = false;

            var dataSource = InitContent();

            rptRecentBlogInfo.DataSource = dataSource;
            rptRecentBlogInfo.DataBind();
        }

        protected void btnMostTalked_Click(object sender, EventArgs e)
        {
            Panel panResultText = (Panel)FindControl("panResultText");
            panResultText.Visible = false;

            var dataSource = InitContent();

            var mostTalkedDataSource = dataSource;
            mostTalkedDataSource.Sort((x, y) => -1 * x.CommentCount.CompareTo(y.CommentCount));
            rptRecentBlogInfo.DataSource = mostTalkedDataSource;
            rptRecentBlogInfo.DataBind();
        }

        protected void btnMostShared_Click(object sender, EventArgs e)
        {
            Panel panResultText = (Panel)FindControl("panResultText");
            panResultText.Visible = false;
        }

        protected void btnMostRead_Click(object sender, EventArgs e)
        {
            Panel panResultText = (Panel)FindControl("panResultText");
            panResultText.Visible = false;
        }

        protected List<BlogPost> InitContent()
        {
            BlogPageItem blogPage = Sitecore.Context.Item;
            string blogId = blogPage.BlogId;
            List<BlogPost> dataSource = TelligentService.ListBlogPosts(blogId, "100");
            foreach (var item in dataSource)
            {
                BlogsPostPageItem blogPost;
                if (item.Title.Contains("{"))
                {
                    string[] s = item.Title.Split('{');
                    item.Title = s[0];
                    blogPost = Sitecore.Context.Database.GetItem("{" + s[1]);
                }
                else
                {
                    blogPost = Sitecore.Context.Database.GetItem("/Sitecore/Content/Home/Community and Events/Blogs/" + item.BlogName + "/" + item.Title);
                }
                BlogsAuthorPageItem author = Sitecore.Context.Database.GetItem(blogPost.Author.Raw);
                item.Author = author.Name;
                item.Body = TelligentService.FormatString100(Sitecore.StringUtil.RemoveTags(blogPost.Body.Raw));
                item.AuthorUrl = LinkManager.GetItemUrl(author);
            }
            return dataSource;
        }
    }
}