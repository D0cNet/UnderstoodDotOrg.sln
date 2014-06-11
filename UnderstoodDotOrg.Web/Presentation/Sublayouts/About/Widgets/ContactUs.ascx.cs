using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class ContactUsWidget : BaseSublayout
    {
        protected GenericWidgetItem Model = new GenericWidgetItem(MainsectionItem.GetGlobals().GetMetaDataFolder().GetWidgetFolder().GetContactUsWidgetItem().InnerItem);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}