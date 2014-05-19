using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class UpComingWebinar : System.Web.UI.UserControl
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
            if (Request.UrlReferrer != null && !Request.UrlReferrer.ToString().IsNullOrEmpty()) {
                hlBackToLink.NavigateUrl = Request.UrlReferrer.ToString();
                string backto = Request.UrlReferrer.ToString().Substring(Request.UrlReferrer.ToString().LastIndexOf("/") + 1);
                if(backto == string.Empty){
                    backto = Request.UrlReferrer.ToString().Substring(0, Request.UrlReferrer.ToString().Length - 1);
                    backto = backto.Substring(backto.LastIndexOf("/") + 1);
                }

                hlBackToLink.Text = String.Format("{0} {1}", DictionaryConstants.BacktoLabel, backto);
            }
            WebinarEventPageItem contextItem = Sitecore.Context.Item;
            BaseEventDetailPageItem baseEventDetailpage = new BaseEventDetailPageItem(contextItem);
            ExpertDetailPageItem expert = baseEventDetailpage.Expert.Item;
            if (contextItem != null) {
                if (IsArchiveItem(contextItem)) {
                    this.Visible = false;
                }
                else {
                    this.Visible = true;
                }
            }
            if (!Page.IsPostBack)
            {


                if (contextItem != null)
                {
                    if (frPageTItle != null)
                    {

                        frPageTItle.Item = contextItem;
                    }
                    if (hlLink != null)
                    {
                        hlLink.NavigateUrl = expert.InnerItem.GetUrl();
                    }
                    FieldRenderer scThumbImg = FindControl("scThumbImg") as FieldRenderer;
                    if (expert != null && expert.ExpertImage.MediaItem != null && scThumbImg != null) {
                        scThumbImg.Item = expert.InnerItem;
                    }
                    else {
                        imgExpertDefault.Visible = true;
                    }
                    if (litGuest != null)
                    {
                        litGuest.Text = expert.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;                            
                    }
                    if (frHeading != null)
                    {
                        frHeading.Item = contextItem;
                    }
                    if (frSubHeading != null)
                    {
                        frSubHeading.Item = contextItem;
                    }
                    if (ltEventDate != null && !baseEventDetailpage.EventDate.Raw.IsNullOrEmpty()) {
                        TimeZoneItem timezone = baseEventDetailpage.Timezone.Item;
                        string timeZoneText = string.Empty;

                        if (timezone != null) {
                            timeZoneText = timezone.Timezone.Rendered;
                        }

                        ltEventDate.Text = String.Format("{0} at {1} {2}", baseEventDetailpage.EventDate.DateTime.ToString("ddd MMM dd"), baseEventDetailpage.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                    }
                    if (frBodyContent != null)
                    {
                        frBodyContent.Item = contextItem;
                    }
                    if (scLinkCalendar != null)
                    {                      
                        scLinkCalendar.Item = contextItem;
                    }
                    if (scLinkRSVP != null)
                    {                       
                        scLinkRSVP.Item = contextItem;
                    }

                }
            }

        }
    }
}