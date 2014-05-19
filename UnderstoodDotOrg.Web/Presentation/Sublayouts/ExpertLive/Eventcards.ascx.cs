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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive {
    public partial class Eventcards : System.Web.UI.UserControl {
        private List<ID> _templateRestrictions = new List<ID>();

        public List<ID> TemplateRestrictions {
            get { return _templateRestrictions; }
            set { _templateRestrictions = value; }
        }

        ExpertLivePageItem expertLivePageItem = Sitecore.Context.Item;

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
        
        protected void Page_Load(object sender, EventArgs e) {
            // show event card on upcoming chat
            if (IsArchiveItem(Sitecore.Context.Item)) {
                this.Visible = false;
            }
            else {
                this.Visible = true;
            }

            if (!Sitecore.Context.Item.IsOfType(ExpertLivePageItem.TemplateId)) {
                expertLivePageItem = GetExpertLivePageItem();
            }
            if (expertLivePageItem != null) {
                //Get header detail for webniars and chat
                frChatHeading.Item = frChatSubheading.Item = frUpcomingWebniarsHeading.Item = frUpcomingWebniarsSubheading.Item = expertLivePageItem;
                GetUpcomingWebinars();
                GetExpertChat();
            }
        }

        private void GetUpcomingWebinars() {
            var webniars = GetWebinars(WebinarEventPageItem.TemplateId);
            if (webniars != null && webniars.Any()) {
                rptUpcomingWebinars.DataSource = webniars.Take(1);
                rptUpcomingWebinars.DataBind();
            }

        }

        private void GetExpertChat() {
            var expertChats = GetChat(ChatEventPageItem.TemplateId, false);
            if (expertChats != null && expertChats.Any()) {
                rptExpertChat.DataSource = expertChats.Take(1);
                rptExpertChat.DataBind();
                //frChatHeading.Visible = true;
                //frChatSubheading.Visible = true;
            }
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

                
                    predicate = predicate.And(predicate1).And(predicate2);
                

                result = context.GetQueryable<EventArchiveSearch>().Where(predicate).Select(i => i.GetItem()).ToList();
                if (isLive) {
                    searchResultItems = result.Select(i => new BaseEventDetailPageItem(i)).Where(t => IsLiveChat(t)).Where(t => t.EventDate.DateTime >= DateTime.Today).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }
                else {
                    searchResultItems = result.Select(i => new BaseEventDetailPageItem(i)).Where(t => !IsLiveChat(t)).Where(t => t.EventDate.DateTime >= DateTime.Today).OrderByDescending(t => t.EventDate.DateTime).ToList();
                }
            }


            searchResultItems = searchResultItems.Where(t => !IsArchiveItem(t.InnerItem)).ToList();


            return searchResultItems;
        }

        private bool IsLiveChat(BaseEventDetailPageItem t) {
            ChatEventPageItem chatEventPage = new ChatEventPageItem(t.InnerItem);
            if (chatEventPage != null && !chatEventPage.OpenOfficeHour.Raw.IsNullOrEmpty()) {
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

                TemplateRestrictions.Add(new ID(WebinarEventPageItem.TemplateId));

                predicate1 = predicate1.And(i => i.Path.Contains("/sitecore/content"));
                // Restrict search to limited number of templates (only person items) using an Or on the predicate
                predicate2 = TemplateRestrictions.Aggregate(predicate2, (current, t) => current.Or(p => p.TemplateId == t));


                predicate = predicate.And(predicate1).And(predicate2);


                result = context.GetQueryable<EventArchiveSearch>().Where(predicate).Select(i => i.GetItem()).ToList();
                searchResultItems = result.Select(t => new BaseEventDetailPageItem(t)).Where(t => t.EventDate.DateTime >= DateTime.Today).OrderByDescending(t => t.EventDate.DateTime).ToList();

                result = result.Where(t => !IsArchiveItem(t)).ToList();


            }
            return searchResultItems;
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
                        if (ltExpertType != null) {
                            ltExpertType.Text = expertItem.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
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
    }
}