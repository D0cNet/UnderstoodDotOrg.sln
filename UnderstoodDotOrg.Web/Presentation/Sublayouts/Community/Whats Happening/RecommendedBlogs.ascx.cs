
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class RecommendedBlogs : BaseSublayout //System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hypAllBlogs.Text = DictionaryConstants.SeeAllBlogsLabel;
            hypAllBlogs.NavigateUrl = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.AllBlogs));

            if (this.CurrentMember != null)
            {
                lvBlogCards.DataSource = SearchHelper.GetRecommendedContent(this.CurrentMember, BlogsPostPageItem.TemplateId)
                            .Where(a => a.GetItem() != null)
                            .Select(a => new BlogsPostPageItem(a.GetItem()))
                            .ToList();
                lvBlogCards.DataBind();
            }

        }

        protected void lvBlogCards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var hypBlogTitle = e.Item.FindControl("hypBlogTitle") as HyperLink;
            var litBlogDateStamp = e.Item.FindControl("litBlogDateStamp") as Literal;
            var btnFollowBlog = e.Item.FindControl("btnFollowBlog") as UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.FollowButton;

            var item = e.Item.DataItem as BlogsPostPageItem;

            if (hypBlogTitle != null && litBlogDateStamp != null && btnFollowBlog != null)
            {
                hypBlogTitle.Text = item.Name;
                hypBlogTitle.NavigateUrl = item.GetUrl();

                string link = @"<a href='{1}'>{0}</a>";
                litBlogDateStamp.Text = DictionaryConstants.BlogDateStampLabel
                    .Replace("{{datePublished}}", item.InnerItem.Publishing.PublishDate.ToShortDateString())
                    .Replace("{{link}}",
                        string.Format(link, item.Name, item.GetUrl()));

                btnFollowBlog.LoadState(item.BlogId, Constants.TelligentContentType.Blog);
            }
        }
    }
}
