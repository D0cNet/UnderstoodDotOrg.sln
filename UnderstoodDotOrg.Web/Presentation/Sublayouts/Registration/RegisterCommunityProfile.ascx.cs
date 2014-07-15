using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration
{
    public partial class RegisterCommunityProfile : BaseSublayout<RegisterCommunityProfileItem>//System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnRegister.Text = DictionaryConstants.JoinGroupButtonText;
            txtScreenName.Attributes["placeholder"] = DictionaryConstants.ScreenNameWatermark;
            hypCompleteMyProfile.Text = Model.CompleteMyFullProfileText.Rendered;
            hypCompleteMyProfile.NavigateUrl = MyProfileStepOneItem.GetCompleteMyProfileStepOne().GetUrl();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                this.UpdateUser();

                this.NextStep();
            }
            catch (Exception ex)
            {
                uxErrorMessage.Visible = true;
                uxErrorMessage.Text = string.Format("<span class='validationerror'>{0}</span>", ex.Message);
            }

        }

        protected void NextStep()
        {
            //throw back to interrupt
            this.ReturnRedirect();
            
            //oh, you're still here? well...lets just go to your account page...
            Response.Redirect(MyAccountItem.GetMyAccountPage().GetUrl());
        }

        protected void UpdateUser()
        {
            var membershipManager = new MembershipManager();

            this.CurrentMember.ScreenName = TextHelper.RemoveHTML(txtScreenName.Text);

            try
            {
                if (!string.IsNullOrEmpty(this.CurrentMember.ScreenName))
                {
                    this.checkUsername(this.CurrentMember.ScreenName);
                }

                this.updateMember();

                this.createCommunityUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void createCommunityUser()
        {
            var tMember = TelligentService.GetPosesMember(this.CurrentMember.ScreenName);

            //if we have a screen name and it doesn't exist in Telligent yet...
            if (!string.IsNullOrEmpty(this.CurrentMember.ScreenName) && !string.IsNullOrEmpty(this.CurrentUser.Email) && tMember == null)
            {
                try
                {
                    bool communitySuccess = CommunityHelper.CreateUser(this.CurrentMember.ScreenName, this.CurrentUser.Email);

                    if (communitySuccess == false)
                    {
                        throw new Exception("I'm sorry, the Community User failed to be created properly.");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void updateMember()
        {
            var membershipManager = new MembershipManager();

            try
            {
                this.CurrentMember = membershipManager.UpdateMember(this.CurrentMember);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void checkUsername(string ScreenName)
        {
            try
            {
                var tMember = TelligentService.GetPosesMember(ScreenName);

                if (tMember != null)
                {
                    throw new Exception("Community Screen Name already taken");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}