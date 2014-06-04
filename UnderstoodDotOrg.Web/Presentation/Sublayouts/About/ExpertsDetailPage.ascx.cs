using System;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class ExpertsDetailPage : BaseSublayout<ExpertDetailPageItem>
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
            BindControls();
        }

        private void BindEvents()
        {

        }

        private void BindContent()
        {
            imgExpert.ImageUrl = Model.GetThumbnailUrl(189, 189);
        }

        private void BindControls()
        {

        }
    }
}