using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class MostRecentBlogsPage : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = Request.QueryString["id"];
            List<BlogPost> dataSource = CommunityHelper.ListBlogPosts(blogId);
            rptBlogInfo.DataSource = dataSource;
            rptBlogInfo.DataBind();

            lbBlogName.Text = dataSource[0].BlogName;
        }
    }
}