using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Data.Managers;
using Sitecore.Data;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class MoreToExplore : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GlobalsItem globalItem = MainsectionItem.GetGlobals();
            if (globalItem != null)
            {
                var moreExploreFolder = globalItem.GetMoreExploreFolder();
                if (moreExploreFolder != null)
                {
                    frMoreExploreTitle.Item = moreExploreFolder;
                    var moreExploreItems = moreExploreFolder.InnerItem.GetChildren(); //moreExploreFolder.GetMoreExploreItems();
                    if (moreExploreItems != null && moreExploreItems.Any())
                    {
                        rptMoreExplorer.Visible = true;
                        rptMoreExplorer.DataSource = moreExploreItems;
                        rptMoreExplorer.DataBind();
                    }
                }
            }
        }

        protected void rptMoreExplorer_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var dataItem = e.Item.DataItem as Item;
                var slTile = e.FindControlAs<Sublayout>("slTile");

                slTile.DataSource = dataItem.ID.ToString();

                if (dataItem.InheritsFromType(ExplorePromoTileItem.TemplateId))
                {
                    slTile.Path = "~/Presentation/Sublayouts/Common/Tiles/PromoTile.ascx";
                }
                else if (dataItem.InheritsFromType(ExploreEventTileItem.TemplateId))
                {
                    slTile.Path = "~/Presentation/Sublayouts/Common/Tiles/EventTile.ascx";
                }
            }
        }
    }
}