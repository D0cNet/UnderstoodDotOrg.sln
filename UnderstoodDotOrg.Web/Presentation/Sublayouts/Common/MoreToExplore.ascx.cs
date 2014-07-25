using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class MoreToExplore : System.Web.UI.UserControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            // Repeaters may contain forms with post-back so bind repeater in init so viewstate is not lost
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
                else if (dataItem.TemplateID == Sitecore.Data.ID.Parse(ExploreToolTileItem.TemplateId))
                {
                    slTile.Path = ((ExploreToolTileItem)dataItem).GetSublayoutPath();
                }
            }
        }
    }
}