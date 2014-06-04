using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class ShareNSave_SendEmail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtYourname.Attributes.Add("placeholder", "Enter your name");
            txtYourEMailID.Attributes.Add("placeholder", "Enter your email");
            txtRecipentEMailID.Attributes.Add("placeholder", "Friend's Email");
            txtThoughts.Attributes.Add("placeholder", "I saw this and thought you might find it helpful");
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            DefaultArticlePageItem article = (DefaultArticlePageItem)Sitecore.Context.Item;
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            MailAddress fromAddress = new MailAddress(txtYourEMailID.Text.Trim(), txtYourname.Text.Trim(), System.Text.Encoding.Default);
            message.From = fromAddress;
            message.Subject = txtYourname.Text.Trim() + " has found this helpful information for you!";

            if (article != null)
                message.Body = txtThoughts.Text.Trim() + "</br></br>Here is the link<a href='" + article.GetUrl();
            else
                message.Body = txtThoughts.Text.Trim();

            message.To.Add(txtRecipentEMailID.Text.Trim());
            smtpClient.Send(message);
        }
    }
}