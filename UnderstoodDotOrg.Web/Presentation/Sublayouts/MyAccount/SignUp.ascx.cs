using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class SignUp : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uxEmailAddress.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
            uxFirstName.Attributes["placeholder"] = DictionaryConstants.FirstNameWatermark;
            uxPassword.Attributes["placeholder"] = DictionaryConstants.EnterPasswordWatermark;
            uxPasswordConfirm.Attributes["placeholder"] = DictionaryConstants.ReEnterNewPasswordWatermark;
            uxZipCode.Attributes["placeholder"] = DictionaryConstants.ZipCodeWatermark;

            uxSubmit.Text = DictionaryConstants.SubmitButtonText;
        }

        protected void uxSubmit_Click(object sender, EventArgs e)
        {
            // server-side validation
            string name = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            
            string zip = uxZipCode.Text;
            bool newsletter = uxNewsletterSignup.Checked;

            if (!string.IsNullOrEmpty(uxFirstName.Text))
            {
                name = uxFirstName.Text;
            }

            if (!string.IsNullOrEmpty(uxEmailAddress.Text))
            {
                email = uxEmailAddress.Text;
            }

            if (!string.IsNullOrEmpty(uxPassword.Text) && !string.IsNullOrEmpty(uxPasswordConfirm.Text) && uxPassword.Text == uxPasswordConfirm.Text)
            {
                password = uxPassword.Text;
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                //damnit barry, this is how you get ants. 
                // the site keeps breaking when we test, and its breaking ugly.
                // if someone clicks to create a new user, we have to blow up the existing user or we're going to have a problem.
                this.FlushRegisteringUser();

                //everything's cool
                if (this.registeringUser == null)
                {
                    this.registeringUser = new Domain.Membership.Member();
                }

                this.registeringUser.FirstName = name;
                
                //bg: adding in zip code
                this.registeringUser.ZipCode = zip;
                



                var membershipManager = new MembershipManager();

                // helps to call the right addMember method...
                this.registeringUser = membershipManager.AddMember(this.registeringUser, email, password);
                
                this.CurrentMember = this.registeringUser;
                this.CurrentUser = membershipManager.GetUser(this.CurrentMember.MemberId);

                Response.Redirect(MembershipHelper.GetNextStepURL(1));
            }
            else
            {
                //something failed...
            }
        }
    }
}