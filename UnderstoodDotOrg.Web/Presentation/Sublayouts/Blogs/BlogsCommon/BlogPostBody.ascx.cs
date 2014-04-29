using System;
using System.Net;
using System.Text;
using System.Xml;
using Sitecore.Configuration;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogPostBody : System.Web.UI.UserControl
    {
        public static int blogId = 2;
        public static int blogPostId = 2;

        protected void Page_Load(object sender, EventArgs e)
        {
            BlogPost bp = CommunityHelper.ReadBlogBody(blogId, blogPostId);
            BlogTitle.Text = bp._title;
            BlogBody.Text = bp._body;
            BlogDate.Text = bp._publishedDate;
            BlogAuthor.Text = bp._author;
        }
    }
}