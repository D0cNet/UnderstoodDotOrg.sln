using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Tabs
{
    public partial class Comments : BaseSublayout<PublicAccountCommentsItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindAccountMenu();
        }

        private void BindAccountMenu()
        {
            var publicAccountPage = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetPublicAccountFolder().GetPublicAccountPage();
            hypCommentsTab.NavigateUrl = publicAccountPage.GetPublicAccountCommentsPage().GetUrl();
            hypConnectionsTab.NavigateUrl = publicAccountPage.GetPublicAccountConnectionsPage().GetUrl();
            hypProfileTab.NavigateUrl = publicAccountPage.GetPublicAccountProfilePage().GetUrl();
        }
    }
}