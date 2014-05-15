using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class UpComingChat : System.Web.UI.UserControl
    {
        ChatEventPageItem ContextItem = Sitecore.Context.Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            ChatEventPageItem contextItem = Sitecore.Context.Item;
            BaseEventDetailPageItem baseEventDetailpage = new BaseEventDetailPageItem(contextItem);
            ExpertDetailPageItem expert = baseEventDetailpage.Expert.Item;

            if (contextItem != null) {
                if (frPageTitle != null) {

                    frPageTitle.Item = contextItem;
                }
                if (expert != null) {
                    if (hlLink != null) {
                        hlLink.NavigateUrl = expert.InnerItem.GetUrl();
                    }
                    FieldRenderer scThumbImg = FindControl("scThumbImg") as FieldRenderer;
                    if (scThumbImg != null) {
                        scThumbImg.Item = expert.InnerItem;
                    }
                    if (litGuest != null) {
                        litGuest.Text = expert.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                    }
                }
                if (ltEventDate != null && !baseEventDetailpage.EventDate.Raw.IsNullOrEmpty()) {
                    TimeZoneItem timezone = baseEventDetailpage.Timezone.Item;
                    string timeZoneText = string.Empty;

                    if (timezone != null) {
                        timeZoneText = timezone.Timezone.Rendered;
                    }

                    ltEventDate.Text = String.Format("{0} at {1} {2}", baseEventDetailpage.EventDate.DateTime.ToString("ddd MMM dd"), baseEventDetailpage.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                }

                if (frHeading != null) {
                    frHeading.Item = contextItem;
                }
                if (frSubHeading != null) {
                    frSubHeading.Item = contextItem;
                }
                if (frBodyContent != null) {
                    frBodyContent.Item = contextItem;
                }
                if (scLinkCalendar != null) {
                    scLinkCalendar.Item = contextItem;
                }
                if (scLinkRSVP != null) {
                    scLinkRSVP.Item = contextItem;
                }

            }

            if (ContextItem != null) {
                if (IsArchiveItem(ContextItem)) {
                    this.Visible = false;
                }
            }
        }
                
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
    }
}