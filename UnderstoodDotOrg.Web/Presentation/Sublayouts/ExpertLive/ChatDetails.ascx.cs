using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

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
        }
    }
}