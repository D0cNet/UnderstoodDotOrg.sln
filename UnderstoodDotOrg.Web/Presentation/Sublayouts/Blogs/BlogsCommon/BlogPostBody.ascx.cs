using System;
using System.Net;
using System.Text;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using Sitecore.Links;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogPostBody : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BlogsPostPageItem blogCig = new BlogsPostPageItem(Sitecore.Context.Item);
            BlogsAuthorPageItem author = Sitecore.Context.Database.GetItem(blogCig.Author.Raw);
            linkAuthor.HRef = linkAuthor2.HRef = linkAuthor3.HRef = LinkManager.GetItemUrl(author);
            litAuthorBio.Text = CommunityHelper.FormatString100(author.Biography.Text) + "...";
            litAuthor.Text = litAuthor2.Text = author.Name;
        }
    }
}