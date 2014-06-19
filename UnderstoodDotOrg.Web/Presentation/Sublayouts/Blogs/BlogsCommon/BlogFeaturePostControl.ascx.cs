using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class BlogFeaturePostControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Try to get the blog ID from querystring
            string id = Request.QueryString["BlogId"];
            if (id != null)
                follBtn.LoadState(id, UnderstoodDotOrg.Common.Constants.TelligentContentType.Blog);

        }
    }
}