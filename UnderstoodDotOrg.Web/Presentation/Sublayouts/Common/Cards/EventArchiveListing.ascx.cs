using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards
{
    public partial class EventArchiveListing : System.Web.UI.UserControl
    {
        public IEnumerable<BaseEventDetailPageItem> ArchivedEvents { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();

            if (ArchivedEvents != null && ArchivedEvents.Any())
            {
                rptEvents.DataSource = ArchivedEvents;
                rptEvents.DataBind();
            }
        }

        private void BindEvents()
        {
            rptEvents.ItemDataBound += rptEvents_ItemDataBound;
        }

        void rptEvents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                BaseEventDetailPageItem item = (BaseEventDetailPageItem)e.Item.DataItem;

                Sublayout slEventArchive = e.FindControlAs<Sublayout>("slEventArchive");
                slEventArchive.DataSource = item.ID.ToString();
            }
        }
    }
}