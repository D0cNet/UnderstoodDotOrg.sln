using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community {
    public partial class CommunityContainer : System.Web.UI.UserControl {
        Item ContextItem = Sitecore.Context.Item;
        public string ContainerClass { get; set; }
        protected void Page_Load(object sender, EventArgs e) {
            if (ContextItem.IsOfType(ExpertLivePageItem.TemplateId)) {
                ContainerClass = "experts-page experts-landing";
            }
            else if (ContextItem.IsOfType(ArchiveItem.TemplateId)) {
                ContainerClass = "experts-page archive-results";
            }
            else if (ContextItem.IsOfType(ChatEventPageItem.TemplateId) && !IsArchiveItem(ContextItem)) {
                ContainerClass = "experts-page chat upcoming";
            }
            else if (ContextItem.IsOfType(WebinarEventPageItem.TemplateId) && !IsArchiveItem(ContextItem)) {
                ContainerClass = "experts-page webinar upcoming ";
            }
            else if (ContextItem.IsOfType(ChatEventPageItem.TemplateId) && IsArchiveItem(ContextItem)) {
                ContainerClass = "experts-page chat past";
            }
            else if (ContextItem.IsOfType(WebinarEventPageItem.TemplateId) && IsArchiveItem(ContextItem)) {
                ContainerClass = "experts-page webinar past ";
            }
            else {
                ContainerClass = string.Empty;
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