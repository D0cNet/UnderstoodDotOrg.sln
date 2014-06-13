using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Entity;
using MembershipProvider = System.Web.Security.Membership;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class MembershipTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //set validation
            //valGender.ErrorMessage = "Please tell us the gender of your child";
            valGender.ErrorMessage = "Please tell us the gender of your child";
            Page.ClientScript.RegisterExpandoAttribute(valGender.ClientID, "groupName", uxBoy.GroupName);

            CustomValidator1.ErrorMessage = "Please tell us the gender of your child";
            Page.ClientScript.RegisterExpandoAttribute(CustomValidator1.ClientID, "groupName", RadioButton1.GroupName);

            Page.Form.DefaultButton = uxSubmit.ClientID;
        }

    }
}