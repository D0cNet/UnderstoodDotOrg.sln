using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class ShareNSave_SendEmail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress   (txtYourEmail.Text.Trim(),txtYourName.Text.Trim(),System.Text.Encoding.Default);
            message.From = fromAddress;
            message.Subject = txtYourName.Text.Trim() + " has found this helpful information for you!";
            message.Body = txtThoughts.Text.Trim();//Here put the textbox text
            message.To.Add(txtRecipientEmail.Text.Trim());
            smtpClient.Send(message);
            
        }
    }
}