using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy
{
    public partial class AdvocacyLandingPage : BaseSublayout<AdvocacyLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var globalsItem = MainsectionItem.GetGlobals();
            var advocacyLinks = globalsItem.GetAdvocacyLinksFolder().GetAdvocacyLinks();

            rptrActionAlerts.DataSource = advocacyLinks;
            rptrActionAlerts.DataBind();
        }

        protected void btnActNow_Click(object sender, EventArgs e)
        {
            var btnActNow = sender as HtmlButton;
            var url = btnActNow.Attributes["data-url"];
            if (!string.IsNullOrEmpty(url))
            {
                Response.Redirect(url);
            }
        }
    }
}