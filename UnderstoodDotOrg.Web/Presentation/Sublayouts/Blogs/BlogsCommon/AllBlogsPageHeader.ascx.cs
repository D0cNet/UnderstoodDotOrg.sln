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
            var itm = Sitecore.Context.Database.GetItem("{E486F071-8B5F-42B9-91C1-CC8A61A8622E}");
            var url = LinkManager.GetItemUrl(itm) + "?BlogId=1";
            btnUnderstoodBlog.HRef = url;
        }
    }
}