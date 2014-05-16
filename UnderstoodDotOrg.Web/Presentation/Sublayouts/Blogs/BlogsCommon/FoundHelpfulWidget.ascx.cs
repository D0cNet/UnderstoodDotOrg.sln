using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class FoundHelpfulWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var blogCig = new BlogsPostPageItem(Sitecore.Context.Item);
            var contentId = blogCig.ContentId.Raw;

            LikeCount.Text = CommunityHelper.GetTotalLikes(contentId).ToString();

            var blogId = blogCig.BlogId.Raw;
            var blogPostId = blogCig.BlogPostId.Raw;

            CommentCount.Text = CommunityHelper.GetTotalComments(blogId, blogPostId).ToString();
        }
    }
}