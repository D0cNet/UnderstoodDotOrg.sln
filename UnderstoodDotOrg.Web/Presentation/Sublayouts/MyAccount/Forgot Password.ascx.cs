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
                Member member;
  
                try
                {
                    // verify email exists
                    MembershipManager membershipManager = new MembershipManager();
                    member = membershipManager.GetMember(email);
                }
                catch (Exception ex)
                {
                                       
                    litErrorMessage.Text = DictionaryConstants.EmailInvalidUser;
                    member = null;
                }

                if (member != null)
                {
                                        
                    var passwordReset = Sitecore.Context.Database.GetItem(Constants.TemplateIDs.ForgotPasswordPage);
                    var link = string.Format(Request.Url.Host + "{0}?guid={1}", passwordReset.GetUrl(), member.MemberId.ToString());
					
                    BaseReply reply = ExactTargetService.InvokeEM22ForgotPassword(new InvokeEM22ForgotPasswordRequest { PreferredLanguage = member.PreferredLanguage, PasswordResetLink = link, ToEmail = email });

                    if (reply.Successful)
                    {
                        uxView.ActiveViewIndex = 1;
                        litSuccessStory.Text = Model.SuccessMessage.Rendered.Replace("$email$", email);
                    }
                    else
                    {
                        uxView.ActiveViewIndex = 0;
                        litErrorMessage.Visible = true;
                        litErrorMessage.Text = DictionaryConstants.EmailException;
                    }
                }
                else
                {
                    //user does not exist
                    uxView.ActiveViewIndex = 0;
                    litErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error("Forgot password error", ex, this);
                uxView.ActiveViewIndex = 0;
                litErrorMessage.Visible = true;
                litErrorMessage.Text = DictionaryConstants.EmailException;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            var item = Sitecore.Context.Database.GetItem(Constants.Pages.SignIn);
            Response.Redirect(item.GetUrl());
        }
    }
}