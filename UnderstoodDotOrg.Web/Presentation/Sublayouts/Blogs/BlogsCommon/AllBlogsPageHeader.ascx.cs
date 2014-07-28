using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class AllBlogsPageHeader : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnUnderstoodBlog.HRef = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{401A4297-3D08-4BB5-8F19-EC32A38C82C6}"));
        }
    }
}