using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class MembershipTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var un = string.Empty;

            if (!string.IsNullOrEmpty(Request.QueryString["un"]))
            {
                un = Request.QueryString["un"];
            }
            else
            {
                un = "everythingisawesome1";
            }

            var roles = TelligentService.GetUserRoles(un);

            foreach (var role in roles)
            {
                litRoles.Text += role.ToString() + " - " + Constants.TelligentRoles.Roles[role] + "</br>";
            }
        }

    }
}