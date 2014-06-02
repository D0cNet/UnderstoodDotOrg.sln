using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class Eventcards : BaseSublayout<BaseEventDetailPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Handle conditional display
            if (Model.InnerItem.InheritsTemplate(ChatEventPageItem.TemplateId))
            {
                if (!Model.IsUpcoming())
                {
                    this.Visible = false;
                    return;
                }
            }

            BindContent();
        }

        private void BindContent()
        {
            var landing = GetExpertLiveLandingPage();
            if (landing == null)
            {
                this.Visible = false;
                return;
            }

            frChatHeading.Item = frChatSubheading.Item 
                = frUpcomingWebinarsHeading.Item = frUpcomingWebinarsSubheading.Item = landing.InnerItem;  

            // TODO: hide headings if no upcoming events
            var webinar = SearchHelper.GetNextUpcomingWebinar();
            if (webinar != null)
            {
                slExpertEvent.DataSource = webinar.ID.ToString();
            }

            var chat = SearchHelper.GetNextUpcomingChat();
            if (chat != null)
            {
                slExpertChat.DataSource = chat.ID.ToString();
            }
        }

        private ExpertLivePageItem GetExpertLiveLandingPage()
        {
            Item item = Sitecore.Context.Item;
            
            while (item != null)
            {
                if (item.IsOfType(ExpertLivePageItem.TemplateId)) 
                {
                    return (ExpertLivePageItem)item;
                }
                item = item.Parent;
            }

            return null;
        }
    }
}