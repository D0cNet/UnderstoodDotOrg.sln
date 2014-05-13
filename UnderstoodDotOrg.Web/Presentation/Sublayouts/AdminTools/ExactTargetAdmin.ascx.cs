namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools
{
    using System;
    
    using UnderstoodDotOrg.Services.ExactTarget;
    using UnderstoodDotOrg.Domain.ExactTarget;
    using System.Collections.Generic;

    public partial class ExactTargetAdmin : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // initialize text boxes
                tbxSubscriberEmail1.Text = "jtesta@agencyoasis.com";
                tbxSubscriberKey1.Text = "jtesta@agencyoasis.com";
                tbxSubscriberFN1.Text = "Joe";

                tbxEmailID.Text = "177";   // This is the "Text Only Test Email" configured within NCLD's ExactTarget system ....  Available in the ET UI [Content > My Emails > Properties]

                lblMessage.Text = "Email Test has not started ...";
                txtHtmlContent.Text = "<p><b>This is a test!</b></p>";
            }
        }

        protected void btnETTests_Click(object sender, EventArgs e)
        {
            //InvokeEM2ParentToolkitReply reply = ExactTargetService.InvokeEM2ParentToolkit(new InvokeEM2ParentToolkitRequest { ToEmail = tbxSubscriberEmail1.Text });
			InvokeWelcomeToUnderstoodReply reply = ExactTargetService.InvokeWelcomeToUnderstood(new InvokeWelcomeToUnderstoodRequest { ToEmail = tbxSubscriberEmail1.Text, FirstName = tbxSubscriberFN1.Text });
            lblMessage.Text = reply.Message;
        }

      

    }
}