namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    using System;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
    using UnderstoodDotOrg.Framework.UI;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
    using UnderstoodDotOrg.Common;
    using System.Text;

    public partial class WebinarDetails : BaseSublayout<WebinarEventPageItem>
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            ExpertLivePageItem landingPage = ExpertLivePageItem.GetLandingPage();
            bool landingExists = landingPage != null;
            hlBackExperts.Visible = landingExists;
            litTopicsCoveredLabel.Text = DictionaryConstants.TopicsCoveredLabel;
            if (landingExists)
            {
                hlBackExperts.NavigateUrl = landingPage.GetUrl();
                hlBackExperts.Text = landingPage.ContentPage.BasePageNEW.NavigationTitle;
            }

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
                frHostTitle.Item = expert;
                litExpertType.Text = expert.GetExpertType();
            }

            //Get Topics overed in webinar based on Topics embedded in Parent interest field
            StringBuilder sb = new StringBuilder();
            foreach (var topics in Model.BaseEventDetailPage.ParentInterest.ListItems)
            {
                sb.Append(topics.Name);
                sb.Append(",");
            }
            litTopicsCovered.Text = sb.Length >1?  sb.Remove(sb.Length - 1, 1).ToString():sb.ToString();
            CommunityRecommendationIcons2.MatchingChildrenIds = CommunityRecommendationIcons.MatchingChildrenIds = Model.BaseEventDetailPage.GetMatchingChildrenIds(this.CurrentMember);
        }
    }
}