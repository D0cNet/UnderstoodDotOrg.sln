using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic
{
    public partial class CalloutContainer : BaseSublayout<TopicLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Model.EventWidget.Item != null)
            {
                slUpcomingEvent.DataSource = Model.EventWidget.Item.ID.ToString();
            }
        }
    }
}