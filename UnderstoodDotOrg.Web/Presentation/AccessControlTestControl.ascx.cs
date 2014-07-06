using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation
{
    public partial class AccessControlTest1 : BaseSublayout //System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.CurrentMember != null)
            {
                //update logged in state
                uxLoggedInState.Text = bool.TrueString;

                //update community state
                uxScreenName.Text = !string.IsNullOrEmpty(this.CurrentMember.ScreenName) ? this.CurrentMember.ScreenName : string.Empty;

                //update T&C state
                uxInternationalUser.Text = this.isInternationalUser.ToString();

                //update IntUser state
                uxTandC.Text = this.CurrentMember.AgreedToSignUpTerms.ToString();
            }
            else
            {
                uxLoggedInState.Text = bool.FalseString;
            }

            uxIPAddress.Text = this.GetIPAddress();
            uxCountry.Text = UnderstoodDotOrg.Services.LocationServices.GeoIPLookup.GetCountry(this.GetIPAddress());
        }

        protected void btnLoggedIn_Click(object sender, EventArgs e)
        {
            this.ProfileRedirect(Common.Constants.UserPermission.RegisteredUser);
        }

        protected void btnCommunity_Click(object sender, EventArgs e)
        {
            this.ProfileRedirect(Common.Constants.UserPermission.CommunityUser);
        }

        protected void btnInternational_Click(object sender, EventArgs e)
        {
            this.ProfileRedirect(Common.Constants.UserPermission.InternationalUser);
        }

        protected void btnTermsAndConditions_Click(object sender, EventArgs e)
        {
            this.ProfileRedirect(Common.Constants.UserPermission.AgreedToTerms);
        }
    }
}