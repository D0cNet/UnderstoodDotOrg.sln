using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Utilities;
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
        public bool IsRecommended { get; set; }
        public string Issue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }

        protected void Page_Load(object sender, EventArgs e) 
        {
            BindEvents();

            string featured = HttpHelper.GetQueryString(UnderstoodDotOrg.Common.Constants.EVENT_FEATURED_FILTER_QUERY_STRING); 
            string recommended = HttpHelper.GetQueryString(UnderstoodDotOrg.Common.Constants.EVENT_RECOMMENDED_FILTER_QUERY_STRING);
            Issue = HttpHelper.GetQueryString(UnderstoodDotOrg.Common.Constants.EVENT_ISSUE_FILTER_QUERY_STRING).Trim();
            Grade = HttpHelper.GetQueryString(UnderstoodDotOrg.Common.Constants.EVENT_GRADE_FILTER_QUERY_STRING).Trim();
            Topic = HttpHelper.GetQueryString(UnderstoodDotOrg.Common.Constants.EVENT_TOPIC_FILTER_QUERY_STRING).Trim();

            IsFeatured = featured.ToLower() == "true";
            IsRecommended = recommended.ToLower() == "true";
            PopulateUpcomingEvents();
        }

        private void BindEvents()
        {
            rptUpcomingWebinars.ItemDataBound += rptUpcomingWebinars_ItemDataBound;
            rptExpertChat.ItemDataBound += rptExpertChat_ItemDataBound;
        }
        private Boolean FilterFound(BaseEventDetailPageItem it,string GradeID,string IssueID,string TopicID)
        {
            bool found = false;
            if( !String.IsNullOrEmpty(GradeID))
            {
                found = it.Grade.ListItems.Where(lItem => lItem.ID.ToString().Equals(GradeID)).Any();
            }
             
             if(!String.IsNullOrEmpty(IssueID))
            {

                found = it.ChildIssue.ListItems
                                    .Where(lItem => lItem.ID.ToString().Equals(IssueID)).Any();
             }

             if (!String.IsNullOrEmpty(TopicID))
             {
                 found = it.ParentInterest.ListItems
                                          .Where(lItem => lItem.ID.ToString().Equals(TopicID)).Any();
             }

             return found;

        }
        private void PopulateUpcomingEvents()
        {
            Item currItem = Sitecore.Context.Item;
            var condition = String.IsNullOrEmpty(Issue)?(String.IsNullOrEmpty(Grade)?(String.IsNullOrEmpty(Topic)?"":Topic):Grade):Issue;
            // Chats
            var chats = ((ExpertLivePageItem)currItem).FeaturedChat.ListItems
                .Select(it=> new BaseEventDetailPageItem(it))
                .ToList();
            if (!String.IsNullOrEmpty(condition))
                chats = chats.Where(it => FilterFound(it,Grade,Issue,Topic)).ToList();

            //var chat = UnderstoodDotOrg.Domain.Search.SearchHelper.GetUpcomingChats(Grade, Issue, Topic);
            bool hasChats = chats.Any();
            pnlNoChatMessage.Visible = !hasChats;

            if (hasChats)
            {
                rptExpertChat.DataSource = chats.Take(2);
                rptExpertChat.DataBind();
            }

            // Webinars
            //var webinars = UnderstoodDotOrg.Domain.Search.SearchHelper.GetUpcomingWebinars(Grade, Issue, Topic);
            
          
            
            var webinars = ((ExpertLivePageItem)currItem).FeaturedEvent.ListItems
                        .Select(it => new BaseEventDetailPageItem(it))
                       .ToList();

            if (IsRecommended)
            {
                if (IsUserLoggedIn && CurrentMember.Children.Count > 0)
                {
                    //function that returns a list of webinars that match any of the current users child issues,grades or topics
                    String[] issues = new List<string>(CurrentMember.Children.Select(x => x.Issues.Select(k => k.Key.ToString("B").ToUpper())).SelectMany(x => x)).ToArray();
                    String[] grades = new List<string>(CurrentMember.Children.Select(x => x.Grades.Select(g => g.Key.ToString("B").ToUpper())).SelectMany(x => x)).ToArray();
                    String[] topics = CurrentMember.Interests.Select(x => x.Key.ToString("B").ToUpper()).ToArray();
                    webinars = MatchWebinars(webinars, issues, grades, topics);
                }
            }
            if (!String.IsNullOrEmpty(condition))
                webinars = webinars.Where(it => FilterFound(it, Grade, Issue, Topic)).ToList();

            bool hasWebinars = webinars.Any();
            pnlNoWebinars.Visible = !hasWebinars;

            if (hasWebinars)
            {
                rptUpcomingWebinars.DataSource = webinars.Take(2);
                rptUpcomingWebinars.DataBind();
            }
        }

        private List<BaseEventDetailPageItem> MatchWebinars(List<BaseEventDetailPageItem> webinars, string[] issues, string[] grades, string[] topics)
        {
            List<BaseEventDetailPageItem> items = new List<BaseEventDetailPageItem>();
            foreach (var item in issues)
            {
                foreach (var wevent in webinars)
                {
                    if(FilterFound(wevent, String.Empty, item, String.Empty))
                    {
                        items.Add(wevent);
                    }

                }
              

                
                
            }
            foreach (var item in grades)
            {
                foreach (var wevent in webinars)
                {
                    if (FilterFound(wevent, item, String.Empty, String.Empty))
                    {

                        items.Add(wevent);
                    }

                }
            }

            foreach (var item in topics)
            {
                foreach (var wevent in webinars)
                {
                    if (FilterFound(wevent, String.Empty, String.Empty, item))
                    {
                        items.Add(wevent);
                    }

                }
            }

            return items;
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