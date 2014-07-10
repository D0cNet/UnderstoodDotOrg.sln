namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    using System;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Domain.ExactTarget;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
    using UnderstoodDotOrg.Services.ExactTarget;

    public partial class Reset_Password : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            var guid = Guid.Empty.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["guid"]))
            {
                guid = Request.QueryString["guid"].ToString();
            }
            ResetPasswordTicket ResetTicket = new ResetPasswordTicket(guid);

            uxPassword.Attributes["placeholder"] = DictionaryConstants.EnterNewPasswordWatermark;
            uxPasswordConfirm.Attributes["placeholder"] = DictionaryConstants.ReEnterNewPasswordWatermark;
            uxSave.Text = DictionaryConstants.SubmitButtonText;

            valPassword.ErrorMessage = valPasswordConfirm.ErrorMessage = DictionaryConstants.PasswordErrorMessage;
            valRegPassword.ValidationExpression = valRegPasswordConfirm.ValidationExpression = Constants.Validators.Password;
            //TODO: move to dictionary
            valRegPassword.ErrorMessage = valRegPasswordConfirm.ErrorMessage = DictionaryConstants.PasswordErrorMessage;
            //TODO: move to dictionary
            valCompPassword.ErrorMessage = valCompPasswordConfirm.ErrorMessage = DictionaryConstants.PasswordMatchError;
            valPassword.Display =
                valRegPassword.Display =
                valCompPassword.Display =
                valPasswordConfirm.Display =
                valRegPasswordConfirm.Display =
                valCompPasswordConfirm.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;

            // TODO: fix hardcoded text
            if (string.IsNullOrEmpty(Request.QueryString["guid"]))
            {
                uxPassword.Enabled = false;
                uxPasswordConfirm.Enabled = false;
                ResetYourPasswordItem context = (ResetYourPasswordItem)Sitecore.Context.Item;
                string redirect = context.ForgotPasswordText + " <a href=\"{0}\">{1}</a>";

                var forgotPassword = Sitecore.Context.Database.GetItem("{06AC924E-D5D1-4CED-AF7A-EB2F631AE4C4}");
                string linkText = context.ForgotPasswordLinkText;
                var link = Sitecore.Links.LinkManager.GetItemUrl(forgotPassword);

                uxMessage.Text = string.Format(redirect, link, linkText);
            }
            else if (ResetTicket.Used || !string.IsNullOrEmpty(ResetTicket.Status))
            {
                uxPassword.Enabled = false;
                uxPasswordConfirm.Enabled = false;
                string redirect = ResetTicket.Status + " <a href=\"{0}\">{1}</a>";

                var forgotPassword = Sitecore.Context.Database.GetItem("{06AC924E-D5D1-4CED-AF7A-EB2F631AE4C4}");
                var link = Sitecore.Links.LinkManager.GetItemUrl(forgotPassword);

                uxMessage.Text = string.Format(redirect, link, link);
            }
        }

        protected void uxSave_Click(object sender, EventArgs e)
        {
            var guid = Guid.Empty.ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["guid"]))
            {
                guid = Request.QueryString["guid"].ToString();
            }

            ResetPasswordTicket ResetTicket = new ResetPasswordTicket(guid);
            string password = string.Empty;

            // TODO: Add validation that passwords match

            if (uxPassword.Text == uxPasswordConfirm.Text && !string.IsNullOrEmpty(uxPasswordConfirm.Text))
            {
                ResetTicket.CompleteTicket(Request.UserHostAddress);
                password = uxPassword.Text;
                ResetYourPasswordItem context = (ResetYourPasswordItem)Sitecore.Context.Item;
                var membershipManager = new MembershipManager();
                var reset = membershipManager.ResetPassword(Guid.Parse(ResetTicket.UserID), password);

                

                uxMessage.Text = context.PasswordUpdatedText;

                var member = membershipManager.GetMember(Guid.Parse(ResetTicket.UserID));
                ExactTargetService.InvokeEM23PasswordResetConfirmation(new InvokeEM23PasswordResetConfirmationRequest { PreferredLanguage = member.PreferredLanguage, EmailAddress = member.Email, ReportChangedPasswordLink = "#", ToEmail = member.Email, UserPassword = "**********" });
            }
        }
    }
}