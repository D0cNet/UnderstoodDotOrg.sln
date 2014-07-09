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
    public partial class Forgot_Password : BaseSublayout<ForgotPasswordItem>
    {
        ForgotPasswordItem context = (ForgotPasswordItem)Sitecore.Context.Item;

        protected void Page_Load(object sender, EventArgs e)
        {
            btnSubmit.Text = DictionaryConstants.SubmitButtonText;
            btnCancel.Text = DictionaryConstants.CancelButtonText;
            //litErrorMessage.Visible = false;
            //litErrorMessage.Text = DictionaryConstants.EmailAddressErrorMessage;
            txtEmailAddress.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;

            //set validation
            valEmailRequired.ErrorMessage = valEmailRegex.ErrorMessage = DictionaryConstants.EmailAddressErrorMessage; //"it looks like you had a typo"
            valEmailRegex.ValidationExpression = Constants.Validators.Email;

            Page.Form.DefaultButton = btnSubmit.UniqueID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var email = txtEmailAddress.Text;
            try
            {
                //always show success message, even if we don't send the email
                //add ASP.Net validation

                MembershipManager membershipManager = new MembershipManager();
                Member member;

                member = membershipManager.GetMember(email);

                if (member != null)
                {
                    var passwordReset = Sitecore.Context.Database.GetItem(Constants.TemplateIDs.ForgotPasswordPage);
                    var link = string.Format(Request.Url.Host + "{0}?guid={1}", passwordReset.GetUrl(), new ResetPasswordTicket(member.MemberId).ResetTicketID);

                    BaseReply reply = ExactTargetService.InvokeEM22ForgotPassword(new InvokeEM22ForgotPasswordRequest { PreferredLanguage = member.PreferredLanguage, PasswordResetLink = link, ToEmail = email });

                    if (reply.Successful)
                    { }
                    else
                    {
                        litErrorMessage.Text = context.ProblemText;
                        throw new Exception("Issue sending email to: " + email);
                    }
                }
                else
                {
                    throw new Exception("User does not exist: " + email);
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Forgot password error", ex, this);
                //uxView.ActiveViewIndex = 0;
                //litErrorMessage.Visible = true;
                //litErrorMessage.Text = DictionaryConstants.EmailException;
            }

            if (string.IsNullOrEmpty(litErrorMessage.Text))
            {
                uxView.ActiveViewIndex = 1;
                litSuccessStory.Text = Model.SuccessMessage.Rendered.Replace("$email$", Server.HtmlEncode(email));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var item = Sitecore.Context.Database.GetItem(Constants.Pages.SignIn);
            Response.Redirect(item.GetUrl());
        }
    }
}