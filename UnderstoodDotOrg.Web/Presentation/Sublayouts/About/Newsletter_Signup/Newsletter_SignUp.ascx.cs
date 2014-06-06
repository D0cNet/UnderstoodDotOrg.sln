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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_SignUp : BaseSublayout<SignUpPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear out session
            Session[Constants.SessionNewsletterKey] = null;

            BindContent();
            BindEvents();

            // TODO: validate email doesn't exist
            if (!IsPostBack)
            {
                string email = Request.QueryString["email"] ?? String.Empty;
                if (!String.IsNullOrEmpty(email))
                {
                    txtEmail.Text = email;
                    Page.Validate();
                    ProcessEmail();
                }
            }
        }

        private void BindContent()
        {
            revEmail.ValidationExpression = Sitecore.Configuration.Settings.GetSetting("EmailValidation");
            revEmail.Text = Model.InvalidEmailError;
            txtEmail.Attributes["placeholder"] = DictionaryConstants.EnterEmailAddressWatermark;
            btnSignup.Text = DictionaryConstants.SubscribeButtonText;
        }

		private void BindEvents()
		{
			btnSignup.Click += btnSignup_Click;
		}

        private void ProcessEmail()
        {
            if (Page.IsValid)
            {
                // TODO: validate email
                string email = txtEmail.Text.Trim();
				MembershipManager mbrShadowUser = new MembershipManager();
				MembershipUser checkValidity = mbrShadowUser.GetUser(email);

				if (checkValidity.Email != null && checkValidity.Email != "")
				{
					lblEmailFail.Text = "It appears you already have an Email with us, please sign in first.";
				}
				else
				{

					Submission submission = new Submission
					{
						Email = email
					};

					Session[Constants.SessionNewsletterKey] = submission;

					var item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(Constants.Pages.NewsletterChildInfo.ToString()));
					Response.Redirect(item.GetUrl());
				}
            }
        }

        void btnSignup_Click(object sender, EventArgs e)
        {
				ProcessEmail();
        }
    }
}