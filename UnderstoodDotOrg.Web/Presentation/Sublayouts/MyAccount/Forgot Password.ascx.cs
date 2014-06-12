using System;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.ExactTarget;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class Forgot_Password : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = DictionaryConstants.SubmitButtonText;
            btnCancel.Text = DictionaryConstants.CancelButtonText;
            litErrorMessage.Visible = false;
            litErrorMessage.Text = DictionaryConstants.EmailAddressErrorMessage;
            txtEmailAddress.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;

            Page.Form.DefaultButton = btnSubmit.UniqueID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var email = txtEmailAddress.Text;
                var membershipManager = new MembershipManager();
                var user = membershipManager.GetUser(email);
                if (user != null)
                {
                    ForgotPasswordItem currentItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Item.ID);

                    uxView.ActiveViewIndex = 1;
                    litSuccessStory.Text = currentItem.SuccessMessage.Rendered.Replace("$email$", email);

                    var passwordReset = Sitecore.Configuration.Factory.GetDatabase("master").GetItem("{328F5121-EFF8-441B-AFB6-A3DF41F7BFA4}");
                    var link = string.Format(Request.Url.Host + "{0}?guid={1}", Sitecore.Links.LinkManager.GetItemUrl(passwordReset), user.ProviderUserKey.ToString());

					
                    BaseReply reply = ExactTargetService.InvokeEM22ForgotPassword(new InvokeEM22ForgotPasswordRequest { PreferredLanguage = CurrentMember.PreferedLanguage, PasswordResetLink = link, ToEmail = email, UserName = user.UserName });
                }
                else
                {
                    //user does not exist
                    litErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                litErrorMessage.Visible = true;
                litErrorMessage.Text = DictionaryConstants.EmailException;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.SignIn);
            Response.Redirect(Sitecore.Links.LinkManager.GetItemUrl(item));
        }
    }
}