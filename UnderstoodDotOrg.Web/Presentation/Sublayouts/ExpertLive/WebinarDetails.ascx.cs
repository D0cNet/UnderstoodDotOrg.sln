namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    using System;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
    using UnderstoodDotOrg.Framework.UI;
    using UnderstoodDotOrg.Common.Extensions;

    public partial class WebinarDetails : BaseSublayout<WebinarEventPageItem>
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            // TODO: replace with correct check for archived state
            bool isUpcoming = Model.BaseEventDetailPage.IsUpcoming();
            phCallToActions.Visible = isUpcoming;
            phVideoDetails.Visible = phHelpful.Visible = !isUpcoming;

            litEventDate.Text = Model.BaseEventDetailPage.GetFormattedEventStartDate();

            if (isUpcoming)
            {
                // TODO: add display logic to hide if no video/transcript present
            }

            // Expert details
            var expert = new ExpertDetailPageItem(Model.BaseEventDetailPage.Expert.Item);
            if (expert.InnerItem != null)
            {
                hlExpertDetail.NavigateUrl = expert.GetUrl();
                imgExpert.ImageUrl = expert.GetThumbnailUrl(150, 150);
                frExpertName.Item = Model.BaseEventDetailPage.Expert;
                litExpertType.Text = expert.GetExpertType();
            }
        }
    }
}