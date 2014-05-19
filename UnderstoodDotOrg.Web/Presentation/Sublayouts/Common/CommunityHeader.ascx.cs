using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class BlogHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Update with better logic for getting nav root item
            var navRoot = Sitecore.Context.Database.GetItem("{1A6F9D01-4152-4F2F-979B-8BD670B037A4}");
            var navLinks = navRoot.Children
                .Where(i => i.IsOfType(NavigationLinkItem.TemplateId))
                .Select(i => (NavigationLinkItem)i);

            rptLinks.DataSource = navLinks;
            rptLinks.DataBind();
        }
    }
}