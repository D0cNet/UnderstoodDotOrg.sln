using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class HeaderMainNav : BaseSublayout
    {
        protected HeaderFolderItem HeaderFolder { get; set; }
        private Item _levelOne = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            _levelOne = Sitecore.Context.Item.Axes.SelectSingleItem(String.Format("ancestor-or-self::*[@@templateid='{0}']", SectionLandingPageItem.TemplateId));

            HeaderFolder = HeaderFolderItem.GetHeader();
            GetMainNavigationItems();

            var parentToolkitFolder = HeaderFolder.GetParentToolkitFolder();
            if (parentToolkitFolder != null)
            {
                frParentToolKitHeading.Item = parentToolkitFolder;
            }
        }

        protected string GetSelectedState(NavigationLinkItem item, string selectedCss)
        {
            return (item.Link.Field.TargetItem != null
                    && item.Link.Field.TargetItem.ID == _levelOne.ID) 
                    ? selectedCss 
                    : string.Empty;
        }

        private void GetMainNavigationItems()
        {
            var mainNavigationFolder = HeaderFolder.GetMainNavigationFolder();
            if (mainNavigationFolder != null)
            {
                var results = mainNavigationFolder.GetNavigationLinkItems();
                if (results != null && results.Any())
                {
                    rptMainNavigation.DataSource = results;
                    rptMainNavigation.DataBind();
                }
            }
        }

        protected void rptMainNavigation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var item = e.Item.DataItem as NavigationLinkItem;
                if (item != null)
                {
                    var frMainNavigationLink = e.FindControlAs<FieldRenderer>("frMainNavigationLink");
                    if (frMainNavigationLink != null)
                    {
                        frMainNavigationLink.Item = item;
                    }

                    var results = item.GetNavigationLinkItems();
                    if (results != null && results.Any())
                    {
                        var rptPrimaryNav = e.FindControlAs<Repeater>("rptPrimaryNavigation");
                        if (rptPrimaryNav != null)
                        {
                            rptPrimaryNav.DataSource = results;
                            rptPrimaryNav.DataBind();
                        }
                    }
                }
            }
        }

        protected void rptPrimaryNavigation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var item = e.Item.DataItem as NavigationLinkItem;

                if (item != null)
                {
                    var frPrimaryNavigationLink = e.FindControlAs<FieldRenderer>("frPrimaryNavigationLink");
                    if (frPrimaryNavigationLink != null)
                    {
                        frPrimaryNavigationLink.Item = item;
                    }
                }
            }
        }
    }
}