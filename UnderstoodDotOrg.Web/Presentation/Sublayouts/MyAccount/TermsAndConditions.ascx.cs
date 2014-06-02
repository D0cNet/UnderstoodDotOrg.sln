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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class TermsAndConditions : BaseRegistration<TermsandConditionsItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnNotAgree_Click(object sender, EventArgs e)
        {
            Logout();
            Response.Redirect(MainsectionItem.GetHomePageItem().GetUrl());
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            CurrentMember.AgreedToSignUpTerms = true;
            var membershipManager = new MembershipManager();
            membershipManager.UpdateMember(CurrentMember);
            Response.Redirect(MembershipHelper.GetNextStepURL(1));
        }
    }
}