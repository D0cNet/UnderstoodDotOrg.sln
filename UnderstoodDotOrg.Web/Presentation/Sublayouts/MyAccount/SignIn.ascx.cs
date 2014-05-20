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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class SignIn : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uxEmailAddress.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
            uxPassword.Attributes["placeholder"] = DictionaryConstants.EnterPasswordWatermark;
            uxSignIn.Text = DictionaryConstants.SignInButtonText;
            uxRegisterLink.Text = DictionaryConstants.SignUpButtonText;

            uxRegisterLink.NavigateUrl = MembershipHelper.GetNextStepURL(0);
        }

        protected void uxSignIn_Click(object sender, EventArgs e)
        {
            //blow out any existing member when someone tries to sign in
            try
            {
                //lets make sure to reset all user&member info before we start inflating it
                this.FlushCurrentMemberUser();

                var membershipManager = new MembershipManager();

                var currentMember = membershipManager.AuthenticateUser(uxEmailAddress.Text, uxPassword.Text);

                if (currentMember != null)
                {
                    this.CurrentMember = currentMember;
                    this.CurrentUser = membershipManager.GetUser(currentMember.MemberId, true);

                    var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccount);
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