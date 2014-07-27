using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Common;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class ChatDetails : BaseSublayout<ChatEventPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            ExpertLivePageItem landingPage = ExpertLivePageItem.GetLandingPage();
            bool landingExists = landingPage != null;
            hlBackExperts.Visible = landingExists;
            if (landingExists)
            {
                hlBackExperts.NavigateUrl = landingPage.GetUrl();
                hlBackExperts.Text = landingPage.ContentPage.BasePageNEW.NavigationTitle;
            }

            bool isUpcoming = Model.BaseEventDetailPage.IsUpcoming();
            phCallToActions.Visible = isUpcoming;

            phPastChatDetails.Visible = phPastSidebarDetails.Visible = !isUpcoming;

            litEventDate.Text = Model.BaseEventDetailPage.GetFormattedEventStartDate();

            // Expert details
            ExpertDetailPageItem expert = Model.BaseEventDetailPage.Expert.Item;
            frExpertName.Item = frHostTitle.Item = expert;
            
            if (expert != null)
            {
                imgExpert.ImageUrl = expert.GetThumbnailUrl(150, 150);
                litExpertType.Text = expert.GetExpertType();
                hlExpertDetails.NavigateUrl = expert.GetUrl();
            }

            CommunityRecommendationIcons1.MatchingChildrenIds = CommunityRecommendationIcons2.MatchingChildrenIds = Model.BaseEventDetailPage.GetMatchingChildrenIds(this.CurrentMember);
        }
    }
}