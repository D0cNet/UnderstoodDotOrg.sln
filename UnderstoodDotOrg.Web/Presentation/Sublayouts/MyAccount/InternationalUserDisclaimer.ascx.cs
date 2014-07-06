using System;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
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

            Response.Redirect(MyAccountFolderItem.GetSignUpPage());
        }

        protected void lnkSignIn_Click(object sender, EventArgs e)
        {
            AuthorizeInternationalUser();

            Response.Redirect(MyAccountFolderItem.GetSignInPage());
        }

        protected void AuthorizeInternationalUser()
        {
            this.SetAuthorizedInternationalUser();
        }
	}
}