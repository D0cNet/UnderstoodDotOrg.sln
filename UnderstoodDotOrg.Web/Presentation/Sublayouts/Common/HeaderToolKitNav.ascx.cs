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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class HeaderToolKitNav : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            lvParentToolkit.ItemDataBound += lvParentToolkit_ItemDataBound;
        }

        private void BindControls()
        {
            var headerFolder = HeaderFolderItem.GetHeader();
            if (headerFolder == null)
            {
                return;
            }
            
            var parentToolkitFolder = headerFolder.GetParentToolkitFolder();
            if (parentToolkitFolder == null)
            {
                return;
            }

            var links = parentToolkitFolder.GetNavigationLinkItems();
            if (links.Any())
            {
                // TODO: add extension to filter out logged in links?
                if (!IsUserLoggedIn)
                {
                    links = links.Where(x => !x.DisplayOnlyForLoggedInUsers.Checked);
                }

                lvParentToolkit.DataSource = links;
                lvParentToolkit.DataBind();
            }
        }

        void lvParentToolkit_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var item = e.Item.DataItem as NavigationLinkItem;

                var frNavLink = (FieldRenderer)e.Item.FindControl("frNavLink");
                var pnlParentToolKit = (Panel)e.Item.FindControl("pnlParentToolKit");

                frNavLink.Item = item;

                if (item.Image.MediaItem != null)
                {
                    pnlParentToolKit.Style.Add(
                        "background-image",
                        string.Format("url({0})", item.Image.MediaUrl));
                    pnlParentToolKit.Style.Add("background-repeat", "no-repeat");
                }
            }
        }
    }
}