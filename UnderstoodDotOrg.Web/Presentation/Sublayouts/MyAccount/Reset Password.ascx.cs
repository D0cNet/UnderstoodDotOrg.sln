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
            var guid = Request.QueryString["guid"].ToString();

            uxPassword.Attributes["placeholder"] = DictionaryConstants.EnterNewPasswordWatermark;
            uxPasswordConfirm.Attributes["placeholder"] = DictionaryConstants.ReEnterNewPasswordWatermark;
            uxSave.Text = DictionaryConstants.SubmitButtonText;

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
            var guid = Request.QueryString["guid"].ToString();
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