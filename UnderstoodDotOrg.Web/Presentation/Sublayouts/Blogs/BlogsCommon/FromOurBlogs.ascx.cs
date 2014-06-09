using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class FromOurBlogs : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = "1,2,3;";
            var dataSource = CommunityHelper.ListBlogPosts(blogId, "6");
            BlogPostsRepeater.DataSource = dataSource;
            BlogPostsRepeater.DataBind();

        }
    }
}