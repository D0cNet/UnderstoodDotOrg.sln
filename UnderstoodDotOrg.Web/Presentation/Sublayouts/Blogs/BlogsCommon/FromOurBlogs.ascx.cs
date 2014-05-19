using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class FromOurBlogs : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = "1,2,3;";
            List<BlogPost> dataSource = CommunityHelper.ListBlogPosts(blogId);
            BlogPostsRepeater.DataSource = dataSource;
            BlogPostsRepeater.DataBind();
        }
    }
}