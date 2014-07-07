namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    using System;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Domain.Membership;

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

            uxPassword.Attributes["placeholder"] = DictionaryConstants.EnterNewPasswordWatermark;
            uxPasswordConfirm.Attributes["placeholder"] = DictionaryConstants.ReEnterNewPasswordWatermark;
            uxSave.Text = DictionaryConstants.SubmitButtonText;

            valPassword.ErrorMessage = valPasswordConfirm.ErrorMessage = DictionaryConstants.PasswordErrorMessage;
            valRegPassword.ValidationExpression = valRegPasswordConfirm.ValidationExpression = Constants.Validators.Password;
            //TODO: move to dictionary
            valRegPassword.ErrorMessage = valRegPasswordConfirm.ErrorMessage = DictionaryConstants.PasswordErrorMessage;
            //TODO: move to dictionary
            valCompPassword.ErrorMessage = valCompPasswordConfirm.ErrorMessage = "It looks like your passwords don't match";
            valPassword.Display =
                valRegPassword.Display =
                valCompPassword.Display =
                valPasswordConfirm.Display =
                valRegPasswordConfirm.Display =
                valCompPasswordConfirm.Display = System.Web.UI.WebControls.ValidatorDisplay.Dynamic;

            // TODO: fix hardcoded text
            if (string.IsNullOrEmpty(guid))
            {
                uxPassword.Enabled = false;
                uxPasswordConfirm.Enabled = false;
                string redirect = "Please start the process back on the forgot password screen: <a href=\"{0}\">{1}</a>";

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

            string password = string.Empty;

            // TODO: Add validation that passwords match

            if (uxPassword.Text == uxPasswordConfirm.Text && !string.IsNullOrEmpty(uxPasswordConfirm.Text))
            {
                password = uxPassword.Text;

                var membershipManager = new MembershipManager();
                var reset = membershipManager.ResetPassword(Guid.Parse(guid), password);

                uxMessage.Text = "password updated successfully";
            }
        }
    }
}