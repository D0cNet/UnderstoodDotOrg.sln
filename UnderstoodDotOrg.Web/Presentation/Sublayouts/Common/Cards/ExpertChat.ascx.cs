using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards
{
    public partial class ExpertChat : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            if (DataSource != null && DataSource.InheritsTemplate(BaseEventDetailPageItem.TemplateId))
            {
                BaseEventDetailPageItem item = (BaseEventDetailPageItem)DataSource;

                hlEventDetail.NavigateUrl = item.GetUrl();
                litEventDate.Text = item.GetFormattedEventStartDate();

                // Expert details
                ExpertDetailPageItem expert = item.Expert.Item;
                if (expert != null)
                {
                    imgThumbnail.ImageUrl = expert.GetThumbnailUrl(150, 150);
                
                    // TODO: verify Heading should be tied to expert or actual event page
                    frExpertHeading.Item = frExpertSubheading.Item = expert.InnerItem;
                    hlExpertDetail.NavigateUrl = expert.GetUrl();
                    litExpertType.Text = expert.GetExpertType();
                }
            }
        }
    }
}