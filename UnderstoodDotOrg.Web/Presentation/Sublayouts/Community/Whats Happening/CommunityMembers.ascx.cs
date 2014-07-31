using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class CommunityMembers : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var dataSource = CommunityHelper.GetModerators();
            var repeater = Page.FindControl("rptModerators") as Repeater;
            if (repeater != null)
            {
                repeater.DataSource = TelligentService.GetModerators();
                repeater.DataBind();
            }
            //rptModerators.DataSource = CommunityHelper.GetModerators();
            //rptModerators.DataBind();

        }
    }
}