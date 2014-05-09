using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools
{
    public partial class SalesforceContactAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text;
            string email = txtEmail.Text;
            string url = "http://understood.org.local/Handlers/RunSalesforceUpsert.ashx?fname=" + fname + "&lname=" + lname + "&email=" + email;
            Response.Redirect(url);
        }
    }
}