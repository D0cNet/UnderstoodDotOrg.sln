using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using Sitecore.Links;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class MyAccountHeader : BaseSublayout
    {
        protected MyProfileItem MyProfilePage { get; set; }
        protected MyAccountItem MyAccountPage { get; set; }
        protected String MyNotifications
        {
            get
            {
                return MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetUrl();
            }
        }   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                MyProfilePage = MyProfileItem.GetMyProfilePage();
                MyAccountPage = MyAccountItem.GetMyAccountPage();

                var accountPages = MyAccountPage.GetAccountPages();

                rptrAccountNav.DataSource = accountPages;
                rptrAccountNav.DataBind();

                hlSectionTitle.NavigateUrl = MainsectionItem.GetHomePageItem().GetUrl();
                frSectionTitle.Item = MainsectionItem.GetHomePageItem();
            }
            else
            {
                Response.Redirect(MainsectionItem.GetHomePageItem().GetUrl());
            }
        }
    }
}