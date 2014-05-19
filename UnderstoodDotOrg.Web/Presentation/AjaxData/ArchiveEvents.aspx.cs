using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Links;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using Sitecore.ContentSearch.Linq.Utilities;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.Search;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData {
    public partial class ArchiveEvents : System.Web.UI.Page {
        Int32 clickCount = 1;

        private List<ID> _templateRestrictions = new List<ID>();

        public List<ID> TemplateRestrictions {
            get { return _templateRestrictions; }
            set { _templateRestrictions = value; }
        }

        public string SearchKey { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsTagged { get; set; }
        public string ChildIssue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }
        public string ItemID { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            LoadArchiveEvents();
        }

        private void LoadArchiveEvents() {
            if (Request["count"] != null) {
                clickCount = Int32.Parse(Request["count"]);
            }

            IsTagged = false;

            if (Request.QueryString["itemid"] != null && !Request.QueryString["itemid"].ToString().IsNullOrEmpty()) {
                this.ItemID = Request.QueryString["itemid"].ToString();

            }

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

            int resultsPeClick = 2;
            if (Request.QueryString["rpc"] != null)
                int.TryParse(Request.QueryString["rpc"], out resultsPeClick);
            Item expertLivePage = Sitecore.Context.Database.GetItem(ItemID);
            if (expertLivePage != null) {

                var results = GetFilters();
                if (results != null && results.Any()) {
                    rptEventCard.DataSource = results.Skip(clickCount * resultsPeClick).Take(resultsPeClick).ToList();
                    rptEventCard.DataBind();


                    int itemCount = ((clickCount * resultsPeClick) + resultsPeClick);
                    if (results.Count() <= itemCount) {
                        lblmoreArticle.Text = "false";
                    }
                }
                else {
                    this.Visible = false;
                }

            }
        }

        protected ExpertLivePageItem GetExpertLivePageItem(Item contextItem) {
            //Item contextItem = Sitecore.Context.Item;
            Item topicLandingPageItem = contextItem;
            while (contextItem != null && !contextItem.IsOfType(ExpertLivePageItem.TemplateId)) {

                if (contextItem.Parent != null && contextItem.Parent.IsOfType(ExpertLivePageItem.TemplateId)) {
                    topicLandingPageItem = contextItem.Parent;
                    break;
                }
                contextItem = contextItem.Parent;
            }

            return topicLandingPageItem;
        }

        /// Gets the search result based on keyword
        /// </summary>
        /// <returns></returns>
        public List<BaseEventDetailPageItem> GetFilters() {
            List<BaseEventDetailPageItem> searchResultItems = new List<BaseEventDetailPageItem>();
            List<Item> searchItems = new List<Item>();
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            using (var context = index.CreateSearchContext()) {
                //var predicate = PredicateBuilder.True<EventArchiveSearch>();

                //var predicate = PredicateBuilder.True<EventArchiveSearch>();
                var predicate = PredicateBuilder.True<EventArchiveSearch>();
                var predicate1 = PredicateBuilder.True<EventArchiveSearch>();
                var predicate2 = PredicateBuilder.True<EventArchiveSearch>();
                var predicate3 = PredicateBuilder.True<EventArchiveSearch>();
                TemplateRestrictions.Clear();
                TemplateRestrictions.Add(new ID(ChatEventPageItem.TemplateId));
                TemplateRestrictions.Add(new ID(WebinarEventPageItem.TemplateId));

                predicate1 = predicate1.And(i => i.Path.Contains("/sitecore/content"));
                // Restrict search to limited number of templates (only person items) using an Or on the predicate
                predicate2 = TemplateRestrictions.Aggregate(predicate2, (current, t) => current.Or(p => p.TemplateId == t));

                if (!SearchKey.IsNullOrEmpty()) {
                    predicate3 = predicate3.And(i => i.Content.Contains(SearchKey));
                }

                predicate = predicate.And(predicate1).And(predicate2).And(predicate3);
                // Use filter and get an IQueryable
                searchItems = context.GetQueryable<EventArchiveSearch>().Where(predicate).Select(i => (Item)i.GetItem()).ToList();


                if (IsTagged) {
                    searchResultItems = searchItems.Where(t => IsArchiveItem(t) && IsTaggedItem(t)).Select(t => new BaseEventDetailPageItem(t)).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }
                else {
                    searchResultItems = searchItems.Where(t => IsArchiveItem(t)).Select(t => new BaseEventDetailPageItem(t)).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }

            }
            return searchResultItems;
        }

        private bool IsTaggedItem(BaseEventDetailPageItem baseEvent) {

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

        protected void rptEventCard_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                BaseEventDetailPageItem baseEventItem = e.Item.DataItem as BaseEventDetailPageItem;
                ContentPageItem contentPageItem = new ContentPageItem(baseEventItem.InnerItem);
                if (baseEventItem != null) {
                    Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                    System.Web.UI.WebControls.Image imgExpertDefault = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpertDefault");
                    Literal ltExpertType = e.FindControlAs<Literal>("ltExpertType");
                    Literal ltEventType = e.FindControlAs<Literal>("ltEventType");
                    Literal ltEventDate = e.FindControlAs<Literal>("ltEventDate");
                    Literal ltEventSubDate = e.FindControlAs<Literal>("ltEventSubDate");

                    HyperLink hlExpertBio = e.FindControlAs<HyperLink>("hlExpertBio");
                    FieldRenderer frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                    FieldRenderer frHeading = e.FindControlAs<FieldRenderer>("frHeading");
                    FieldRenderer frSubheading = e.FindControlAs<FieldRenderer>("frSubheading");
                    HyperLink hlWebniearDetail = e.FindControlAs<HyperLink>("hlWebniearDetail");
                    Panel pnlExpertImageLabel = e.FindControlAs<Panel>("pnlExpertImageLabel");

                    if (baseEventItem.InnerItem.IsOfType(ChatEventPageItem.TemplateId)) {
                        ltEventType.Text = DictionaryConstants.ChatLabel;
                    }
                    else if (baseEventItem.InnerItem.IsOfType(WebinarEventPageItem.TemplateId)) {
                        ltEventType.Text = DictionaryConstants.WebniarLabel;
                    }

                    if (baseEventItem != null) {
                        Double totalDays = (DateTime.Now - baseEventItem.EventDate.DateTime).TotalDays;
                        if (totalDays <= 30) {
                            ltEventDate.Text = Math.Floor(totalDays).ToString();
                            ltEventSubDate.Text = DictionaryConstants.DaysagoLabel;
                        }
                        else {
                            ltEventDate.Text = baseEventItem.EventDate.DateTime.ToString("MMM dd");
                            ltEventSubDate.Text = baseEventItem.EventDate.DateTime.ToString("yyyy");
                        }
                        if (frHeading != null) {
                            frHeading.Item = baseEventItem;
                        }

                        if (frSubheading != null) {
                            frSubheading.Item = baseEventItem;
                        }

                        ExpertDetailPageItem expertItem = baseEventItem.Expert.Item;

                        if (expertItem != null) {
                            if (hlExpertBio != null) {
                                hlExpertBio.NavigateUrl = expertItem.InnerItem.GetUrl();
                            }
                            if (scExpertImage != null && expertItem.ExpertImage.MediaItem != null) {
                                scExpertImage.Item = expertItem;
                                scExpertImage.Visible = true;
                                if (pnlExpertImageLabel != null) {
                                    pnlExpertImageLabel.Visible = true;
                                }
                            }
                            else {
                                if (imgExpertDefault != null) {
                                    imgExpertDefault.Visible = true;
                                }
                            }
                            if (ltExpertType != null) {
                                ltExpertType.Text = expertItem.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                            }

                        }
                        else {
                            if (imgExpertDefault != null) {
                                imgExpertDefault.Visible = true;
                            }
                            if (pnlExpertImageLabel != null) {
                                pnlExpertImageLabel.Visible = true;
                            }
                        }
                    }

                    if (frPageTitle != null && contentPageItem != null) {
                        frPageTitle.Item = contentPageItem;
                    }

                    if (hlWebniearDetail != null) {
                        hlWebniearDetail.NavigateUrl = baseEventItem.InnerItem.GetUrl();
                    }
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