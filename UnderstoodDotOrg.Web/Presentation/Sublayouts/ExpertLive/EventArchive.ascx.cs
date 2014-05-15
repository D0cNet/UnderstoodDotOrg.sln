using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Data.Managers;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using System.ComponentModel;
using Sitecore.ContentSearch.Converters;
using Sitecore.Data;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using Sitecore.Links;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.Search;
//using Sitecore.ContentSearch.Linq.Utilities;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve {
   

    public partial class EventArchive : System.Web.UI.UserControl {
        private List<ID> _templateRestrictions = new List<ID>();

        public List<ID> TemplateRestrictions {
            get { return _templateRestrictions; }
            set { _templateRestrictions = value; }
        }

        public string SearchKey { get; set; }

        protected void Page_Load(object sender, EventArgs e) {
            
            if (Request.QueryString["q"] != null && !Request.QueryString["q"].ToString().IsNullOrEmpty()) {
                SearchKey = Request.QueryString["q"].ToString();
                if (!IsPostBack) {
                    txtSearch.Value = SearchKey;
                }
            }
            ExpertLivePageItem ContextItem = GetExpertLivePageItem();
            if (ContextItem != null) {
                ArchiveItem archivePage = ContextItem.GetArchiveItem();

                if (archivePage != null) {
                    hlSeeArchive.Text = DictionaryConstants.SeeArchiveLabel;
                    hlSeeArchive.NavigateUrl = archivePage.InnerItem.GetUrl();

                    var results = GetFilters();
                    if (results != null && results.Any()) {
                        if (SearchKey.IsNullOrEmpty()) {
                            rptEventCard.DataSource = results.Take(2);
                        }
                        else {
                            rptEventCard.DataSource = results;
                        }

                        rptEventCard.DataBind();
                    }
                    else {
                        this.Visible = false;
                    }
                }
                else {
                    this.Visible = false;
                }
            }
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
                searchResultItems = searchItems.Where(t => IsArchiveItem(t)).Select(t => new BaseEventDetailPageItem(t)).OrderByDescending(t => t.EventDate.DateTime).ToList();

            }
            return searchResultItems;
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


        protected ExpertLivePageItem GetExpertLivePageItem() {
            Item contextItem = Sitecore.Context.Item;
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
                            hlExpertBio.NavigateUrl = expertItem.InnerItem.GetUrl();
                            if (scExpertImage != null && expertItem.ExpertImage.MediaItem != null) {
                                scExpertImage.Item = expertItem;
                                pnlExpertImageLabel.Visible = true;
                            }
                            if (ltExpertType != null) {
                                ltExpertType.Text = expertItem.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
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

        protected void btnSubmit_Click(object sender, EventArgs e) {
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "?q=" + txtSearch.Value, true);
        }
    }
}