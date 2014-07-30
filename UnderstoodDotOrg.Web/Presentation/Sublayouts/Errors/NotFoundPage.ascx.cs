using System;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Errors;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Errors
{
    public partial class NotFoundPage : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();

            if (!IsPostBack)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = 404;
                Response.Flush();
            }
        }

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
        }

        private void BindContent()
        {
            btnSubmit.Text = ((NotFoundPageItem)Sitecore.Context.Item).SearchBoxButton.Rendered;
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect(FormHelper.GetSearchResultsUrl(txtSearch.Text.Trim()));
        }
    }
}