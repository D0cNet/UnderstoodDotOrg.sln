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
using Sitecore.Data.Items;

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

        protected void rptrAccountNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var currentItemId = Sitecore.Context.Item.ID.ToString();
            HyperLink hlNavLink = (HyperLink)e.Item.FindControl("hlNavLink");
            var currentUrl = Sitecore.Context.Database.GetItem(currentItemId).GetUrl();
            var item = e.Item.DataItem as MyAccountBaseItem;

            if (currentItemId != null)
            {
                switch (currentItemId)
                {
                    case "{1041DF93-81A2-46FD-910F-8927F22DA4F1}":
                        if (item.AccountNavigationTitle.Text.Equals("Groups"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{355E4A54-A133-4FD4-B796-8C515F194751}":
                        if (item.AccountNavigationTitle.Text.Equals("Events"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{E092EB37-B488-4A42-97CC-7EA875CCF877}":
                        if (item.AccountNavigationTitle.Text.Equals("Comments"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{2A5936E4-1C1A-4F4C-8DDE-EB768BD43E81}":
                        if (item.AccountNavigationTitle.Text.Equals("Saved"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                    case "{840AEEF4-5294-4A0D-8D1C-6839E39FE3FE}":
                        if (item.AccountNavigationTitle.Text.Equals("Connections"))
                        {
                            hlNavLink.CssClass = "active";
                        } break;
                }
            }
        }
    }
}