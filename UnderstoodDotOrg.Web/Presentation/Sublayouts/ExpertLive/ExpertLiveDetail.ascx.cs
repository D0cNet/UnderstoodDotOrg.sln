using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve 
{
    public partial class ExpertLiveDetail : BaseSublayout<ExpertLivePageItem> 
    {
        private List<ID> _templateRestrictions = new List<ID>();

        public bool IsFeatured { get; set; }
        public string Issue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }

        protected void Page_Load(object sender, EventArgs e) 
        {
            BindEvents();

            string featured = HttpHelper.GetQueryString(Constants.EVENT_FEATURED_FILTER_QUERY_STRING);
            Issue = HttpHelper.GetQueryString(Constants.EVENT_ISSUE_FILTER_QUERY_STRING).Trim();
            Grade = HttpHelper.GetQueryString(Constants.EVENT_GRADE_FILTER_QUERY_STRING).Trim();
            Topic = HttpHelper.GetQueryString(Constants.EVENT_TOPIC_FILTER_QUERY_STRING).Trim();

            IsFeatured = featured.ToLower() == "true";

            PopulateUpcomingEvents();
        }

        private void BindEvents()
        {
            rptUpcomingWebinars.ItemDataBound += rptUpcomingWebinars_ItemDataBound;
            rptExpertChat.ItemDataBound += rptExpertChat_ItemDataBound;
        }

        private void PopulateUpcomingEvents()
        {
            // Chats
            var chats = SearchHelper.GetUpcomingChats(Grade, Issue, Topic);
            bool hasChats = chats.Any();
            pnlNoChatMessage.Visible = !hasChats;

            if (hasChats)
            {
                rptExpertChat.DataSource = chats;
                rptExpertChat.DataBind();
            }

            // Webinars
            var webinars = SearchHelper.GetUpcomingWebinars(Grade, Issue, Topic);
            bool hasWebinars = webinars.Any();
            pnlNoWebinars.Visible = !hasWebinars;

            if (hasWebinars)
            {
                rptUpcomingWebinars.DataSource = webinars;
                rptUpcomingWebinars.DataBind();
            }
        }
        
        protected void rptUpcomingWebinars_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.IsItem()) 
            {
                BaseEventDetailPageItem item = e.Item.DataItem as BaseEventDetailPageItem;

                Sublayout slExpertEvent = e.FindControlAs<Sublayout>("slExpertEvent");
                slExpertEvent.DataSource = item.ID.ToString();
            }
        }

        protected void rptExpertChat_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.IsItem()) 
            {
                BaseEventDetailPageItem item = e.Item.DataItem as BaseEventDetailPageItem;

                Sublayout slExpertChat = e.FindControlAs<Sublayout>("slExpertChat");
                slExpertChat.DataSource = item.ID.ToString();
            }
        }
    }
}