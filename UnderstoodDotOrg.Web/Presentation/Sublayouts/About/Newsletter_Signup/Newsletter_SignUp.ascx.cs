using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Understood.Newsletter;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter;
using UnderstoodDotOrg.Domain.Membership;
using System.Web.Security;
using UnderstoodDotOrg.Domain.ExactTarget;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_SignUp : BaseSublayout<SignUpPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear out session
            Session[Constants.SessionNewsletterKey] = null;

            // Skip process for existing members
            if (IsUserLoggedIn)
            {
                HandleAuthenticatedMember();
            }

            BindContent();
            BindEvents();

            // TODO: validate email doesn't exist
            if (!IsPostBack)
            {
                string email = Request.QueryString["email"] ?? String.Empty;
                if (!String.IsNullOrEmpty(email))
                {
                    txtEmail.Text = email;
                    Page.Validate("NewsletterSignup");
                    if (Page.IsValid)
                    {
                        ProcessEmail();
                    }
                }
            }
        }

        private void HandleAuthenticatedMember()
        {
            if (!CurrentMember.allowNewsletter)
            {
                CurrentMember.allowNewsletter = true;
                MembershipManager mm = new MembershipManager();
                mm.UpdateMember(CurrentMember);
            }

            RedirectToConfirmation();
        }

        private void RedirectToConfirmation()
        {
            // TODO: wire up exact target call

            var confirmationPage = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.NewsletterConfirmation.ToString()));
            Response.Redirect(confirmationPage.GetUrl());
        }

        private void BindContent()
        {
            revEmail.ValidationExpression = Sitecore.Configuration.Settings.GetSetting("EmailValidation");
            revEmail.Text = Model.InvalidEmailError.Rendered;
            txtEmail.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
            btnSignup.Text = DictionaryConstants.SubscribeButtonText;
        }

		private void BindEvents()
		{
			btnSignup.Click += btnSignup_Click;
		}

        private void ProcessEmail()
        {
            // TODO: validate email
            string email = txtEmail.Text.Trim();
            MembershipManager mm = new MembershipManager();
            MembershipUser subscriber = mm.GetUser(email);

            if (subscriber != null && subscriber.Comment != Constants.UnauthenticatedMember_Flag)
            {
                litErrorMessage.Text = Model.UnauthenticatedMemberError.Rendered;
            }
            else
            {
                // temporarily skip personalized questions
                if (subscriber == null)
                {
                    Member member = new Member
                    {
                        Email = email,
                        allowNewsletter = true
                    };

                    mm.AddUnauthorizedMember(member);
                    mm.UpdateMember_ExtendedProperties(member);
                }
                else
                {
                    Member member = mm.GetMember(email);
                    member.allowNewsletter = true;
                    mm.UpdateMember(member);
                }

                RedirectToConfirmation();

                /*
                Submission submission = new Submission
                {
                    Email = email
                };

                Session[Constants.SessionNewsletterKey] = submission;

                var item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.NewsletterChildInfo.ToString()));
                Response.Redirect(item.GetUrl());*/
            }
        }

		private void btnSignup_Click(object sender, EventArgs e)
		{
            Page.Validate("NewsletterSignup");
            if (Page.IsValid)
            {
                ProcessEmail();
            }
		}
    }
}