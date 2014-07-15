using System;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
	public partial class InternationalUserDisclaimer : BaseSublayout
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            //OrFragment
            uxOr.Text = DictionaryConstants.OrFragment;
            
            //set link text
            lnkSignIn.Text = DictionaryConstants.SignInButtonText;
            lnkSignUp.Text = DictionaryConstants.SignUpButtonText;
            
		}

        protected void lnkSignUp_Click(object sender, EventArgs e)
        {
            AuthorizeInternationalUser();

            Response.Redirect(SignUpPageItem.GetSignUpPage().GetUrl());
        }

        protected void lnkSignIn_Click(object sender, EventArgs e)
        {
            AuthorizeInternationalUser();

            Response.Redirect(SignInPageItem.GetSignInPage().GetUrl());
        }

        protected void AuthorizeInternationalUser()
        {
            this.SetAuthorizedInternationalUser();
        }
	}
}