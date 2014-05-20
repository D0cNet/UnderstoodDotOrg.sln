using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyConnections : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccountConnections);
            hypConnectionsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);
        }
    }
}