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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive {
    public partial class ExpertDetailPage : System.Web.UI.UserControl {
        private List<ID> _templateRestrictions = new List<ID>();

        public List<ID> TemplateRestrictions {
            get { return _templateRestrictions; }
            set { _templateRestrictions = value; }
        }

        public bool ShowPastEvent = false;
        ExpertDetailPageItem ContextItem = Sitecore.Context.Item;
        protected void Page_Load(object sender, EventArgs e) {

            if (ContextItem != null) {
                if (IsArchiveItem(ContextItem)) {
                    ShowPastEvent = true;
                }
                else {
                    ShowPastEvent = false;
                }
            }

            if (ContextItem != null) {
                if (scBioImage != null && ContextItem.ExpertImage.MediaItem != null) {
                    scBioImage.Item = ContextItem;
                }
                else {
                    imgExpertDefault.Visible = true;
                }

                if (litHours != null) {
                    litHours.Text = DictionaryConstants.OnlineOfficeHours;
                }
                if (frHours != null) {
                    frHours.Item = ContextItem;
                }
                if (scFollowTwittLink != null) {
                    scFollowTwittLink.Item = ContextItem;
                }
                if (scFollowBlogLink != null) {
                    scFollowBlogLink.Item = ContextItem;
                }
                if (scBioLink != null) {
                    scBioLink.Item = ContextItem;
                }
                if (frBodyContent != null) {
                    frBodyContent.Item = ContextItem;
                }

                var expertEvents = GetFilters();
                if (expertEvents != null && expertEvents.Any()) {
                    rptEventDetails.DataSource = expertEvents;
                    rptEventDetails.DataBind();
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
                predicate = predicate.And(predicate1).And(predicate2);
                // Use filter and get an IQueryable
                searchItems = context.GetQueryable<EventArchiveSearch>().Where(predicate).Select(i => (Item)i.GetItem()).ToList();

                if (ShowPastEvent) {
                    searchResultItems = searchItems.Where(t => IsArchiveItem(t) && IsEventOwner(t)).Select(t => new BaseEventDetailPageItem(t)).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }
                else {
                    searchResultItems = searchItems.Where(t => !IsArchiveItem(t) && IsEventOwner(t)).Select(t => new BaseEventDetailPageItem(t)).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }

            }
            return searchResultItems;
        }

        private bool IsEventOwner(Item item) {
            BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(item);
            if (baseEventPageItem.Expert.Item.ID.ToString().Equals(ContextItem.ID.ToString())) {
                return true;
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

        protected void rptEventDetails_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                BaseEventDetailPageItem baseEventItem = e.Item.DataItem as BaseEventDetailPageItem;
                ContentPageItem contentPageItem = new ContentPageItem(baseEventItem.InnerItem);
                if (baseEventItem != null) {
                    ExpertDetailPageItem expertItem = baseEventItem.Expert.Item;
                    Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                    System.Web.UI.WebControls.Image imgExpertDefault = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpertDefault");
                    Literal ltExpertType = e.FindControlAs<Literal>("ltExpertType");
                    Literal ltEventDate = e.FindControlAs<Literal>("ltEventDate");
                    Literal ltEventSubDate = e.FindControlAs<Literal>("ltEventSubDate");
                    Literal ltEventType = e.FindControlAs<Literal>("ltEventType");
                    HyperLink hlExpertBio = e.FindControlAs<HyperLink>("hlExpertBio");
                    FieldRenderer frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                    FieldRenderer frHeading = e.FindControlAs<FieldRenderer>("frHeading");
                    FieldRenderer frSubHeading = e.FindControlAs<FieldRenderer>("frSubHeading");
                    HyperLink hlWebniearDetail = e.FindControlAs<HyperLink>("hlWebniearDetail");
                    Panel pnlExpertImageLabel = e.FindControlAs<Panel>("pnlExpertImageLabel");

                    HyperLink hlEventLine = e.FindControlAs<HyperLink>("hlEventLine");
                    FieldRenderer frRSVNLink = e.FindControlAs<FieldRenderer>("frRSVNLink");
                    FieldRenderer frAddToMyCalendar = e.FindControlAs<FieldRenderer>("frAddToMyCalendar");

                    if (hlEventLine != null) {
                        hlEventLine.NavigateUrl = baseEventItem.InnerItem.GetUrl();
                    }

                    if (frPageTitle != null) {
                        frPageTitle.Item = contentPageItem;
                    }

                    if (frRSVNLink != null) {
                        frRSVNLink.Item = baseEventItem;
                    }

                    if (frAddToMyCalendar != null) {
                        frAddToMyCalendar.Item = baseEventItem;
                    }

                    if (frHeading != null) {
                        frHeading.Item = baseEventItem;
                    }

                    if (frSubHeading != null) {
                        frSubHeading.Item = baseEventItem;
                    }

                    if (baseEventItem.InnerItem.IsOfType(ChatEventPageItem.TemplateId)) {
                        ltEventType.Text = DictionaryConstants.ChatLabel;
                    }
                    else if (baseEventItem.InnerItem.IsOfType(WebinarEventPageItem.TemplateId)) {
                        ltEventType.Text = DictionaryConstants.WebniarLabel;
                    }

                    Double totalDays = (DateTime.Now - baseEventItem.EventDate.DateTime).TotalDays;
                    if (totalDays <= 30) {
                        ltEventDate.Text = Math.Floor(totalDays).ToString();
                        ltEventSubDate.Text = DictionaryConstants.DaysagoLabel;
                    }
                    else {
                        ltEventDate.Text = baseEventItem.EventDate.DateTime.ToString("MMM dd");
                        ltEventSubDate.Text = baseEventItem.EventDate.DateTime.ToString("yyyy");
                    }

                    if (ltEventDate != null && !baseEventItem.EventDate.Raw.IsNullOrEmpty()) {
                        TimeZoneItem timezone = baseEventItem.Timezone.Item;
                        string timeZoneText = string.Empty;

                        if (timezone != null) {
                            timeZoneText = timezone.Timezone.Rendered;
                        }

                        ltEventDate.Text = String.Format("{0} at {1} {2}", baseEventItem.EventDate.DateTime.ToString("ddd MMM dd"), baseEventItem.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                    }

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
                }
            }
        }
    }
}