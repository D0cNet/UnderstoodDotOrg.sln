using System;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class Forgot_Password : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uxSubmit.Text = DictionaryConstants.SubmitButtonText;
            uxCancel.Text = DictionaryConstants.CancelButtonText;
            litErrorMessage.Visible = false;
            litErrorMessage.Text = DictionaryConstants.EmailAddressErrorMessage;
            uxEmailAddress.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            var email = uxEmailAddress.Text;
            var membershipManager = new MembershipManager();
            var user = membershipManager.GetUser(email);
            
            if (user != null)
            {
                ForgotPasswordItem currentItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Item.ID);

                uxView.ActiveViewIndex = 1;
                uxSuccessStory.Text = currentItem.SuccessMessage.Rendered.Replace("$email$", email);

                string emailMessage = "<br/><br/><br/>Hi {0},<br/>SMTP isn't setup yet, so this is your email.<br/>Please click this link to go to the password reset screen: <a href=\"{1}\">{2}</a>";

                var passwordReset = Sitecore.Configuration.Factory.GetDatabase("master").GetItem("{328F5121-EFF8-441B-AFB6-A3DF41F7BFA4}");
                var link = string.Format("{0}?guid={1}", Sitecore.Links.LinkManager.GetItemUrl(passwordReset), user.ProviderUserKey.ToString());

                uxSuccessStory.Text += string.Format(emailMessage, email, link, link);
            }
            else
            {
                //user does not exist
                litErrorMessage.Visible = true;
            }
        }

        protected void uxCancel_Click(object sender, EventArgs e)
        {
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.SignIn);
            Response.Redirect(Sitecore.Links.LinkManager.GetItemUrl(item));
        }
    }
}