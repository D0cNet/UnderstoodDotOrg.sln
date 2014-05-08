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
            try
            {
                var blogCig = new BlogsPostPageItem(Sitecore.Context.Item);
                var contentId = blogCig.ContentId.Raw;
                var likesCount = CommunityHelper.ReadLikes(contentId);
                LikeCount.Text = likesCount;
            }
            catch
            {
                LikeCount.Text = "0";
            }
            
            try
            {
                var blogCig = new BlogsPostPageItem(Sitecore.Context.Item);
                var blogId = blogCig.BlogId.Raw;
                var blogPostId = blogCig.BlogPostId.Raw;
                List<Comment> comments = CommunityHelper.ReadComments(Convert.ToInt32(blogId), Convert.ToInt32(blogPostId));
                CommentCount.Text = comments.Count.ToString();
            }
            catch
            {
                CommentCount.Text = "0";
            }
        }
    }
}