using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class PastWebinar : System.Web.UI.UserControl
    {
        private bool IsArchiveItem(Item item) {
            bool isArchiveItem = false;
            BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(item);
            if (baseEventPageItem != null) {
                if (baseEventPageItem.EventDate.DateTime < DateTime.Today) {
                    isArchiveItem = true;
                }
            }

            return isArchiveItem;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WebinarEventPageItem contextItem = Sitecore.Context.Item;
            if (contextItem != null) {
                if (IsArchiveItem(contextItem)) {
                    this.Visible = true;
                }
                else {
                    this.Visible = false;
                }
            }
        }
    }
}