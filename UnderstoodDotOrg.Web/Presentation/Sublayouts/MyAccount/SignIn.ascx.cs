using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Services.AccessControlServices;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class SignIn : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uxEmailAddress.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
            uxPassword.Attributes["placeholder"] = DictionaryConstants.EnterPasswordWatermark;
            uxSignIn.Text = DictionaryConstants.SignInButtonText;
            uxRegisterLink.Text = DictionaryConstants.SignUpButtonText;

            uxRegisterLink.NavigateUrl = MyAccountFolderItem.GetSignUpPage();
            uxForgotPassword.NavigateUrl = MyAccountFolderItem.GetForgotPasswordPage();

            this.Page.Form.DefaultButton = this.uxSignIn.UniqueID;

            if (!string.IsNullOrEmpty(AccessToken))
            {
                doLogin();
            }
        }

        protected void uxSignIn_Click(object sender, EventArgs e)
        {
            doLogin();
        }

        private void doLogin()
        {

            //blow out any existing member when someone tries to sign in
            try
            {
               
                //lets make sure to reset all user&member info before we start inflating it
                this.FlushCurrentMemberUser();

                var membershipManager = new MembershipManager();

                var currentMember = new Member();

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    var client = new Facebook.FacebookClient(AccessToken);
                    dynamic me = client.Get("me", new { fields = "email" });

                    currentMember = membershipManager.GetMember(me.email);
                }
                else
                {
                    currentMember = membershipManager.AuthenticateUser(uxEmailAddress.Text, uxPassword.Text);
                }

                if (currentMember != null)
                {
                    this.CurrentMember = currentMember;
                    this.CurrentUser = membershipManager.GetUser(currentMember.MemberId, true);

                    //Redirect used here for profile??
                    //this.ReturnRedirect();

                    var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccount);

                    Response.Redirect(Sitecore.Links.LinkManager.GetItemUrl(item));
                }
            }
            catch (Exception ex)
            {
                uxError.Text = ex.Message;
            }
        }
    }
}