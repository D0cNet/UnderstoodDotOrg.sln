using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Services.AccessControlServices;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class TermsAndConditions : BaseRegistration<TermsandConditionsItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAgree.Text = Model.Agree.Rendered;
            btnNotAgree.Text = Model.NotAgree.Rendered;
            if (CurrentMember == null)
            {
                Response.Redirect(MainsectionItem.GetHomeItem().GetUrl());
            }
        }

        protected void btnNotAgree_Click(object sender, EventArgs e)
        {
            //Logout(MainsectionItem.GetHomePageItem().GetUrl());
            uxError.Visible = true;
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            CurrentMember.AgreedToSignUpTerms = true;
            
            var membershipManager = new MembershipManager();
            membershipManager.UpdateMember(CurrentMember);
            
            //string url = MembershipHelper.GetNextStepURL(1);
            // send them to My Account, not into CMP
            string url = MyAccountFolderItem.GetMyAccountPage();
            
            // NOTE: temorarily commented out to prevent 404 redirect

            //if (Session[Constants.SessionPreviousUrl] != null)
            //{
            //    url = Session[Constants.SessionPreviousUrl].ToString();
            //}
            
            //redirect based on interrupt
            //this.ReturnRedirect();

            //if no sign-up interrupt was set, redirect as normal
            Response.Redirect(url);
        }

        protected void lbSignIn_Click(object sender, EventArgs e)
        {
            Logout(MyAccountFolderItem.GetSignInPage());
        }
    }
}