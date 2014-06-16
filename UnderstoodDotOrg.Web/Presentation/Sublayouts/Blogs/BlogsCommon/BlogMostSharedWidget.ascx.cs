using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogMostSharedWidget : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = "1,2,3;";
            var dataSource = CommunityHelper.ListBlogPosts(blogId, "3");
            rptMostShared.DataSource = dataSource;
            rptMostShared.DataBind();
        }
    }
}