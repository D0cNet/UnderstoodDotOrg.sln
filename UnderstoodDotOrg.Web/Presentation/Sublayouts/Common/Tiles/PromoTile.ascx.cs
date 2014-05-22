using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles
{
    public partial class PromoTile : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataSource != null && DataSource.InheritsFromType(ExplorePromoTileItem.TemplateId))
            {
                BindData((ExplorePromoTileItem)DataSource);
            }
        }

        private void BindData(ExplorePromoTileItem tile)
        {
            frTileTitle.Item =
            frTileDescription.Item =
            frTileImage.Item = 
            frTileLink1.Item = 
            frTileLink2.Item = tile;

            pnlImage.Visible = (tile.TileImage.MediaItem.InnerItem != null);
        }
    }
}