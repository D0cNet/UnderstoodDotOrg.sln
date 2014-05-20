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
        protected HeaderFolderItem HeaderFolder { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            HeaderFolder = HeaderFolderItem.GetHeader();
            GetParentTookKitItems();
        }

        private void GetParentTookKitItems()
        {
            var parentToolkitFolder = HeaderFolder.GetParentToolkitFolder();
            if (parentToolkitFolder != null)
            {
                var result = parentToolkitFolder.GetNavigationLinkItems();
                if (result != null)
                {
                    rptParentToolkit.DataSource = result;
                    rptParentToolkit.DataBind();
                }
            }
        }

        protected void rptParentToolkit_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var item = e.Item.DataItem as NavigationLinkItem;
                if (item != null)
                {
                    var frNavLink = e.FindControlAs<FieldRenderer>("frNavLink");
                    var pnlParentToolKit = e.FindControlAs<Panel>("pnlParentToolKit");
                    if (frNavLink != null)
                    {
                        frNavLink.Item = item;
                    }

                    if (pnlParentToolKit != null && item.Image != null && item.Image.MediaItem != null)
                    {
                        pnlParentToolKit.Style.Add(
                            "background", 
                            string.Format("url('{0}') no-repeat scroll 0 0 / 100px 100px rgba(0, 0, 0, 0); background-size:40px 40px; height:180px; background-color:#ffffff; background-position:50% 10px; position:relative;", item.Image.MediaUrl));
                    }
                }
            }
        }
    }
}