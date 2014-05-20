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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve {
    public partial class ExpertLiveDetail : System.Web.UI.UserControl {
        private List<ID> _templateRestrictions = new List<ID>();

        public List<ID> TemplateRestrictions {
            get { return _templateRestrictions; }
            set { _templateRestrictions = value; }
        }

        public bool IsFeatured { get; set; }
        public bool IsTagged { get; set; }
        public string ChildIssue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }

        ExpertLivePageItem expertLivePageItem = Sitecore.Context.Item;

       
        protected void Page_Load(object sender, EventArgs e) {
            
            if (Request.QueryString["featured"] != null && !Request.QueryString["featured"].ToString().IsNullOrEmpty()) {
                if (Request.QueryString["featured"].ToString() == "true") {
                    IsFeatured = true;
                }
                else {
                    IsFeatured = false;
                }
            }

            IsTagged = false;
            if (Request.QueryString["issue"] != null && !Request.QueryString["issue"].ToString().IsNullOrEmpty()) {
                this.ChildIssue = Request.QueryString["issue"].ToString();
                IsTagged = true;
            }

            if (Request.QueryString["grade"] != null && !Request.QueryString["grade"].ToString().IsNullOrEmpty()) {
                this.Grade = Request.QueryString["grade"].ToString();
                IsTagged = true;
            }

            if (Request.QueryString["topic"] != null && !Request.QueryString["topic"].ToString().IsNullOrEmpty()) {
                this.Topic = Request.QueryString["topic"].ToString();
                IsTagged = true;
            }

            if (expertLivePageItem != null) {
                //Get header detail for webniars and chat
                frChatHeading.Item = frChatSubheading.Item = frUpcomingWebniarsHeading.Item = frUpcomingWebniarsSubheading.Item = expertLivePageItem;
                if (!IsPostBack) {
                    FillFilterOptions();

                    if (!this.ChildIssue.IsNullOrEmpty()) {
                        ddlIssue.SelectedItem.Text = this.ChildIssue;
                    }
                    if (!this.Grade.IsNullOrEmpty()) {
                        ddlGrade.SelectedItem.Text = this.Grade;
                    }
                    if (!this.Topic.IsNullOrEmpty()) {
                        ddlTopics.SelectedItem.Text = this.Topic;
                    }
                }

                ExpertliveFilterFolderItem expertLiveFilterFolder = GetExpertLiveFilterFolder();
                if (expertLiveFilterFolder != null) {
                    var result = GetNavigationLinkItem(expertLiveFilterFolder);
                    if (result != null && result.Any()) {
                        rptFilter.DataSource = result;
                        rptFilter.DataBind();
                    }
                }

                GetUpcomingWebinars();
                GetExpertChat();
            }
        }

        /// <summary>
        /// Gets expert live filter folder
        /// </summary>
        /// <returns></returns>
        public static ExpertliveFilterFolderItem GetExpertLiveFilterFolder() {
            MainsectionItem objSiteItem = MainsectionItem.GetSiteRoot();
            ExpertliveFilterFolderItem objExpertliveFilterFolderItem = null;
            if (objSiteItem != null) {
                GlobalsItem objGlobalItem = MainsectionItem.GetGlobals();
                if (objGlobalItem != null) {
                   MetadataFolderFolderItem metaDataFolder = objGlobalItem.GetMetaDataFolder();
                   if (metaDataFolder != null) {
                       objExpertliveFilterFolderItem = metaDataFolder.GetExpertliveFilterFolder();
                   }
                }
            }
            return objExpertliveFilterFolderItem;
        }

        private IEnumerable<NavigationLinkItem> GetNavigationLinkItem(ExpertliveFilterFolderItem expertLiveFolder) {
            return expertLiveFolder.InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(NavigationLinkItem.TemplateId)).Select(i => (NavigationLinkItem)i);
        }

        private void GetExpertChat() {
            var expertChats = GetChat(ChatEventPageItem.TemplateId, false);
            if (expertChats != null && expertChats.Any()) {
                rptExpertChat.DataSource = expertChats;
                rptExpertChat.DataBind();
                frChatHeading.Visible = true;
                frChatSubheading.Visible = true;
            }
            else {
                // Show No webniars message
                pnlNoChatMessage.Visible = true;
                if (frNoChatMessage != null && expertLivePageItem != null) {
                    frNoChatMessage.Item = expertLivePageItem;
                }
            }
        }

        private void GetUpcomingWebinars() {
            var webniars = GetWebinars(WebinarEventPageItem.TemplateId);
            if (webniars != null && webniars.Any()) {
                rptUpcomingWebinars.DataSource = webniars;
                rptUpcomingWebinars.DataBind();
            }
            else { 
                // Show No webniars message
                pnlNoWebniars.Visible = true;
                if (frNoWebniars != null && expertLivePageItem != null) {
                    frNoWebniars.Item = expertLivePageItem;
                }
            }
        }

        private void FillFilterOptions() {
            var childIssues = GetFilters(ChildIssueItem.TemplateId);
            var grades = GetFilters(GradeLevelItem.TemplateId);
            var topics = GetFilters(ParentInterestItem.TemplateId);

            if (childIssues != null && childIssues.Any()) {

                ddlIssue.DataSource = childIssues;
                ddlIssue.DataTextField = "DisplayName";
                ddlIssue.DataValueField = "ID";
                ddlIssue.DataBind();
                ddlIssue.Items.Insert(0, new ListItem("Child's Issue", "0"));
            }
            if (grades != null && grades.Any()) {
                ddlGrade.DataSource = grades;
                ddlGrade.DataTextField = "DisplayName";
                ddlGrade.DataValueField = "ID";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, new ListItem("Grade", "0"));
            }
            if (topics != null && topics.Any()) {
                ddlTopics.DataSource = topics;
                ddlTopics.DataTextField = "DisplayName";
                ddlTopics.DataValueField = "ID";
                ddlTopics.DataBind();
                ddlTopics.Items.Insert(0, new ListItem("Topic", "0"));
            }
        }

        /// Gets the search result based on keyword
        /// </summary>
        /// <returns></returns>
        public List<BaseEventDetailPageItem> GetWebinars(string templateId) {
            List<BaseEventDetailPageItem> searchResultItems = new List<BaseEventDetailPageItem>();
            List<Item> result = new List<Item>();
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            
            using (var context = index.CreateSearchContext()) {
                var predicate = PredicateBuilder.True<EventArchiveSearch>();
                var predicate1 = PredicateBuilder.True<EventArchiveSearch>();
                var predicate2 = PredicateBuilder.True<EventArchiveSearch>();
                var predicate3 = PredicateBuilder.True<EventArchiveSearch>();
                TemplateRestrictions.Clear();
                TemplateRestrictions.Add(new ID(WebinarEventPageItem.TemplateId));

                predicate1 = predicate1.And(i => i.Path.Contains("/sitecore/content"));
                // Restrict search to limited number of templates (only person items) using an Or on the predicate
                predicate2 = TemplateRestrictions.Aggregate(predicate2, (current, t) => current.Or(p => p.TemplateId == t));

                if (IsFeatured) {

                    if (expertLivePageItem != null) {
                        var resultItems = expertLivePageItem.FeaturedEvent.ListItems.Where(t => t.TemplateID.ToString().Equals(WebinarEventPageItem.TemplateId)).ToList();
                        if (resultItems != null && resultItems.Any()) {
                            foreach (var categoryItem in resultItems) {
                                predicate3 = predicate3.Or(p => p.ItemId == categoryItem.ID);
                            }
                        }
                        else {
                            return searchResultItems;
                        }
                    }
                    predicate = predicate.And(predicate1).And(predicate2).And(predicate3);
                }
                else {
                    predicate = predicate.And(predicate1).And(predicate2);
                }

                result = context.GetQueryable<EventArchiveSearch>().Where(predicate).Select(i => i.GetItem()).ToList();
                searchResultItems = result.Select(t => new BaseEventDetailPageItem(t)).Where(t => t.EventDate != null && t.EventDate.DateTime >= DateTime.Today).OrderByDescending(t => t.EventDate.DateTime).ToList();
                if (IsTagged) {
                    searchResultItems = searchResultItems.Where(t => !IsArchiveItem(t) && IsTaggedItem(t)).ToList();
                }
                else {
                    searchResultItems = searchResultItems.Where(t => !IsArchiveItem(t)).ToList();
                }

            }
            return searchResultItems;
        }

        private bool IsTaggedItem(BaseEventDetailPageItem baseEvent) {
            //if (baseEventItem.InnerItem.IsOfType(ChatEventPageItem.TemplateId)) {
            //    ltEventType.Text = DictionaryConstants.ChatLabel;
            //}
            //else if (baseEventItem.InnerItem.IsOfType(WebinarEventPageItem.TemplateId)) {
            //    ltEventType.Text = DictionaryConstants.WebniarLabel;
            //}

            if (baseEvent != null) {
                if (!ChildIssue.IsNullOrEmpty()) {

                    if (baseEvent.ChildIssue.ListItems.Any()) {
                        foreach (var childIssue in baseEvent.ChildIssue.ListItems) {
                            if (childIssue.DisplayName.ToString().Equals(ChildIssue)) {
                                return true;
                            }
                        }
                    }

                }
                else if (!Grade.IsNullOrEmpty()) {
                    if (baseEvent.Grade.ListItems.Any()) {
                        foreach (var grade in baseEvent.Grade.ListItems) {
                            if (grade.DisplayName.ToString().Equals(Grade)) {
                                return true;
                            }
                        }
                    }
                }
                else if (!Topic.IsNullOrEmpty()) {
                    if (baseEvent.ParentInterest.ListItems.Any()) {
                        foreach (var topic in baseEvent.ParentInterest.ListItems) {
                            if (topic.DisplayName.ToString().Equals(Topic)) {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
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

        /// Gets the search result based on keyword
        /// </summary>
        /// <returns></returns>
        public List<Item> GetFilters(string templateId) {
            List<Item> searchResultItems = new List<Item>();
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            using (var context = index.CreateSearchContext()) {
                searchResultItems = context.GetQueryable<SearchResultItem>().
                   Where(i => i.TemplateId == Sitecore.Data.ID.Parse(templateId) && i.Path.Contains("/sitecore/content")).Select(i => (Item)i.GetItem()).ToList();
            }
            return searchResultItems;
        }

        /// Gets the search result based on keyword
        /// </summary>
        /// <returns></returns>
        public List<BaseEventDetailPageItem> GetChat(string templateId, bool isLive) {
            List<BaseEventDetailPageItem> searchResultItems = new List<BaseEventDetailPageItem>();
            List<Item> result = new List<Item>();
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            using (var context = index.CreateSearchContext()) {
                var predicate = PredicateBuilder.True<EventArchiveSearch>();
                var predicate1 = PredicateBuilder.True<EventArchiveSearch>();
                var predicate2 = PredicateBuilder.True<EventArchiveSearch>();
                var predicate3 = PredicateBuilder.True<EventArchiveSearch>();
                TemplateRestrictions.Clear();
                TemplateRestrictions.Add(new ID(ChatEventPageItem.TemplateId));

                predicate1 = predicate1.And(i => i.Path.Contains("/sitecore/content"));
                // Restrict search to limited number of templates (only person items) using an Or on the predicate
                predicate2 = TemplateRestrictions.Aggregate(predicate2, (current, t) => current.Or(p => p.TemplateId == t));

                if (IsFeatured) {

                    if (expertLivePageItem != null) {
                        var resultItems = expertLivePageItem.FeaturedEvent.ListItems.Where(t => t.TemplateID.ToString().Equals(ChatEventPageItem.TemplateId)).ToList();
                        if (resultItems != null && resultItems.Any()) {
                            foreach (var categoryItem in resultItems) {
                                predicate3 = predicate3.Or(p => p.ItemId == categoryItem.ID);
                            }
                        }
                        else {
                            return searchResultItems;
                        }
                    }
                    predicate = predicate.And(predicate1).And(predicate2).And(predicate3);
                }
                else {
                    predicate = predicate.And(predicate1).And(predicate2);
                }

                result = context.GetQueryable<EventArchiveSearch>().Where(predicate).Select(i => i.GetItem()).ToList();
                if (isLive) {
                    searchResultItems = result.Select(i => new BaseEventDetailPageItem(i)).Where(t => IsLiveChat(t)).Where(t => t.EventDate.DateTime >= DateTime.Today).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }
                else {
                    searchResultItems = result.Select(i => new BaseEventDetailPageItem(i)).Where(t => !IsLiveChat(t)).Where(t => t.EventDate.DateTime >= DateTime.Today).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }
            }

            if (IsTagged) {
                searchResultItems = searchResultItems.Where(t => !IsArchiveItem(t.InnerItem) && IsTaggedItem(t)).ToList();
            }
            else {
                searchResultItems = searchResultItems.Where(t => !IsArchiveItem(t.InnerItem)).ToList();
            }

            return searchResultItems;
        }

        private bool IsLiveChat(BaseEventDetailPageItem t) {
            ChatEventPageItem chatEventPage = new ChatEventPageItem(t.InnerItem);
            if (chatEventPage != null && t.InnerItem.IsOfType(ChatEventPageItem.TemplateId) && !chatEventPage.OpenOfficeHour.Raw.IsNullOrEmpty()) {
                return true;
            }

            return false;
        }

        
        protected void rptUpcomingWebinars_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                BaseEventDetailPageItem webinarItem = e.Item.DataItem as BaseEventDetailPageItem;
                ContentPageItem contentPageItem = new ContentPageItem(webinarItem.InnerItem);

                if (webinarItem != null) {
                    Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                    System.Web.UI.WebControls.Image imgExpertDefault = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpertDefault");
                    Literal ltExpertType = e.FindControlAs<Literal>("ltExpertType");
                    Literal ltEventDate = e.FindControlAs<Literal>("ltEventDate");
                    HyperLink hlExpertBio = e.FindControlAs<HyperLink>("hlExpertBio");
                    FieldRenderer frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                    HyperLink hlWebniearDetail = e.FindControlAs<HyperLink>("hlWebniearDetail");
                    Panel pnlExpertImageLabel = e.FindControlAs<Panel>("pnlExpertImageLabel");
                    //BaseEventDetailPageItem webinarItem = new BaseEventDetailPageItem(item);


                    ExpertDetailPageItem expertItem = webinarItem.Expert.Item;

                    if (expertItem != null) {
                        hlExpertBio.NavigateUrl = expertItem.InnerItem.GetUrl();
                        if (scExpertImage != null && expertItem.ExpertImage.MediaItem != null) {
                            scExpertImage.Item = expertItem;
                            pnlExpertImageLabel.Visible = true;
                        }
                        else {
                            imgExpertDefault.Visible = true;
                        }
                        if (ltExpertType != null) {
                            ltExpertType.Text = expertItem.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                        }
                    }
                    else {
                        imgExpertDefault.Visible = true;
                        pnlExpertImageLabel.Visible = true;
                    }

                    if (ltEventDate != null && !webinarItem.EventDate.Raw.IsNullOrEmpty()) {
                        TimeZoneItem timezone = webinarItem.Timezone.Item;
                        string timeZoneText = string.Empty;

                        if (timezone != null) {
                            timeZoneText = timezone.Timezone.Rendered;
                        }

                        ltEventDate.Text = String.Format("{0} at {1} {2}", webinarItem.EventDate.DateTime.ToString("ddd MMM dd"), webinarItem.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                    }

                    if (frPageTitle != null && contentPageItem != null) {
                        frPageTitle.Item = contentPageItem;
                    }

                    if (hlWebniearDetail != null) {
                        hlWebniearDetail.NavigateUrl = webinarItem.InnerItem.GetUrl();
                    }

                }
            }
        }

        protected void rptExpertChat_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                BaseEventDetailPageItem webinarItem = e.Item.DataItem as BaseEventDetailPageItem;
                ContentPageItem contentPageItem = new ContentPageItem(webinarItem.InnerItem);
                if (webinarItem != null) {
                    Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                    System.Web.UI.WebControls.Image imgExpertDefault = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpertDefault");
                    Literal ltExpertType = e.FindControlAs<Literal>("ltExpertType");
                    Literal ltEventDate = e.FindControlAs<Literal>("ltEventDate");
                    HyperLink hlExpertBio = e.FindControlAs<HyperLink>("hlExpertBio");
                    HyperLink hlChatDetail = e.FindControlAs<HyperLink>("hlChatDetail");
                    FieldRenderer frExpertHeading = e.FindControlAs<FieldRenderer>("frExpertHeading");
                    FieldRenderer frHostTitle = e.FindControlAs<FieldRenderer>("frHostTitle");
                    Panel pnlExpertImageLabel = e.FindControlAs<Panel>("pnlExpertImageLabel");

                    if (hlChatDetail != null) {
                        hlChatDetail.NavigateUrl = webinarItem.InnerItem.GetUrl();
                    }

                    if (webinarItem != null) {
                        if (frHostTitle != null) {
                            frHostTitle.Item = webinarItem;
                        }

                        ExpertDetailPageItem expertItem = webinarItem.Expert.Item;

                        if (expertItem != null) {
                            hlExpertBio.NavigateUrl = expertItem.InnerItem.GetUrl();
                            if (scExpertImage != null && expertItem.ExpertImage.MediaItem != null) {
                                scExpertImage.Item = expertItem;
                                pnlExpertImageLabel.Visible = true;
                            }
                            else {
                                imgExpertDefault.Visible = true;
                            }

                            if (frExpertHeading != null) {
                                frExpertHeading.Item = expertItem;
                            }

                            if (ltExpertType != null) {
                                ltExpertType.Text = expertItem.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                            }
                        }
                        else {
                            imgExpertDefault.Visible = true;
                            pnlExpertImageLabel.Visible = true;
                        }
                    }

                    if (ltEventDate != null && !webinarItem.EventDate.Raw.IsNullOrEmpty()) {
                        TimeZoneItem timezone = webinarItem.Timezone.Item;
                        string timeZoneText = string.Empty;

                        if (timezone != null) {
                            timeZoneText = timezone.Timezone.Rendered;
                        }
                        ltEventDate.Text = String.Format("{0} at {1} {2}", webinarItem.EventDate.DateTime.ToString("ddd MMM dd"), webinarItem.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                    }
                }
            }
        }

        protected void rptFilter_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                NavigationLinkItem navItem = e.Item.DataItem as NavigationLinkItem;

                if (navItem != null) {
                    FieldRenderer frLink = e.FindControlAs<FieldRenderer>("frLink");

                    if (frLink != null) {
                        frLink.Item = navItem;
                    }

                }
            }
        }

        protected void ddlIssue_SelectedIndexChanged(object sender, EventArgs e) {
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "?issue=" + ddlIssue.SelectedItem.Text, true);
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e) {
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "?grade=" + ddlGrade.SelectedItem.Text, true);
        }

        protected void ddlTopics_SelectedIndexChanged(object sender, EventArgs e) {
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "?topic=" + ddlTopics.SelectedItem.Text, true);
        }
    }
}