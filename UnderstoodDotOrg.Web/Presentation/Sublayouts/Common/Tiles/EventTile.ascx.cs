using Sitecore.Links;
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
    public partial class EventTile : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataSource != null && DataSource.InheritsFromType(ExploreEventTileItem.TemplateId))
            {
                BindData((ExploreEventTileItem)DataSource);
            }
        }

        private void BindData(ExploreEventTileItem tile)
        {
            var eventItem = tile.GetEvent();

            frEventImage.Item = tile;

            hlLearnMore.Text = tile.MoreText.Rendered;

            if (eventItem != null)
            {
                hlLearnMore.NavigateUrl = LinkManager.GetItemUrl(eventItem);
                frHeading.Item = eventItem;
                ltlSubHeading.Text = tile.GetSubhead(eventItem);
            }
        }
    }
}