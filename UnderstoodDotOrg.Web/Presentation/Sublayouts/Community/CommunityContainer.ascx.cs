using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
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
        }

        private bool IsArchiveItem(Item item) {
            bool isArchiveItem = false;
            Item contextItem = item;
            Item topicLandingPageItem = contextItem;
            while (contextItem != null && !contextItem.IsOfType(ArchiveItem.TemplateId)) {

                if (contextItem.Parent != null && contextItem.Parent.IsOfType(ArchiveItem.TemplateId)) {
                    topicLandingPageItem = contextItem.Parent;
                    isArchiveItem = true;
                    break;
                }
                contextItem = contextItem.Parent;
            }

            return isArchiveItem;
        }
    }


}