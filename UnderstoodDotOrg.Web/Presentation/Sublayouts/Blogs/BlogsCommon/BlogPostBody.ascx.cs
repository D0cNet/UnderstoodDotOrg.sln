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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogPostBody : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BlogsPostPageItem blogCig = new BlogsPostPageItem(Sitecore.Context.Item);
            linkAuthor.HRef = linkAuthor2.HRef = "/Community and Events/Blogs/Author/" + blogCig.Author;
        }
    }
}