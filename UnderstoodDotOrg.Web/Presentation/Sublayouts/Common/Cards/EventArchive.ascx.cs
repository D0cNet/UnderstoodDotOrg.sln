using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards
{
    public partial class EventArchive : BaseSublayout
    {
        protected string EventUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            if (DataSource != null && DataSource.InheritsTemplate(BaseEventDetailPageItem.TemplateId))
            {
                BaseEventDetailPageItem item = (BaseEventDetailPageItem)DataSource;

                EventUrl = item.GetUrl();

                // Field renderers
                frHeading.Item = frSubheading.Item = frPageTitle.Item = item;

                // Expert details
                ExpertDetailPageItem expert = item.Expert.Item;
                if (expert != null)
                {
                    imgExpert.ImageUrl = expert.GetThumbnailUrl(150, 150);
                    litExpertType.Text = expert.GetExpertType();
                }

                // Webinar/chat
                litEventType.Text = item.GetEventType();

                // Time elapsed
                // TODO: consider moving into helper function
                // TODO: verify documentation for display logic
                DateTime? eventDate = item.GetEventStartDateUtc();
                if (eventDate.HasValue)
                {
                    int daysElapsed = (DateTime.UtcNow - eventDate.Value).Days;
                    if (daysElapsed == 0) 
                    {
                        // TODO: display something?
                    } 
                    else if (daysElapsed <= 30)
                    {
                        litEventDate.Text = daysElapsed.ToString();
                        litEventSubDate.Text = DictionaryConstants.DaysAgoLabel;
                    }
                    else
                    {
                        litEventDate.Text = eventDate.Value.ToString("MMM dd");
                        litEventSubDate.Text = eventDate.Value.ToString("yyyy");
                    }
                }
                CommunityRecommendationIcons.MatchingChildrenIds = item.GetMatchingChildrenIds(this.CurrentMember);
            }
        }
    }
}