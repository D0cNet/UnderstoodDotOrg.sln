using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class PastWebinar : System.Web.UI.UserControl
    {
        private bool IsArchiveItem(Item item) {
            bool isArchiveItem = false;
            BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(item);
            if (baseEventPageItem != null) {
                if (baseEventPageItem.EventDate.DateTime < DateTime.Today) {
                    isArchiveItem = true;
                }
            }

            return isArchiveItem;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            WebinarEventPageItem contextItem = Sitecore.Context.Item;
            BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(contextItem);
            ExpertDetailPageItem expert = baseEventPageItem.Expert.Item;
            ltVideoDetailShow.Text = DictionaryConstants.CloseTranscriptLabel;
            if (contextItem != null) {
               frVideoTranscript.Item = contextItem;
               if (!contextItem.VideoID.Raw.IsNullOrEmpty()) {
                   pnlVideo.Visible = true;
               }
            }
            if (baseEventPageItem != null) {
                frEventHeading.Item = baseEventPageItem;
                frbody.Item = baseEventPageItem;
            }

            if (expert != null) {
                FieldRenderer scThumbImg = FindControl("scThumbImg") as FieldRenderer;
                if (expert != null && expert.ExpertImage.MediaItem != null && scThumbImg != null) {
                    scThumbImg.Item = expert.InnerItem;
                }
                else {
                    imgExpertDefault.Visible = true;
                }
                if (litGuest != null) {
                   
                    litGuest.Text = expert.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                }

                frExpertName.Item = expert;
                frHeading.Item = expert;
                frSubHeading.Item = expert;
            }

            if (ltEventDate != null && !baseEventPageItem.EventDate.Raw.IsNullOrEmpty()) {
                TimeZoneItem timezone = baseEventPageItem.Timezone.Item;
                string timeZoneText = string.Empty;

                if (timezone != null) {
                    timeZoneText = timezone.Timezone.Rendered;
                }

                ltEventDate.Text = String.Format("{0} at {1} {2}", baseEventPageItem.EventDate.DateTime.ToString("ddd MMM dd"), baseEventPageItem.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
            }

            if (contextItem != null) {
                if (IsArchiveItem(contextItem)) {
                    this.Visible = true;
                }
                else {
                    this.Visible = false;
                }
            }
        }
    }
}