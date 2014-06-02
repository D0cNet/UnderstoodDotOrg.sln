using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve {
    public partial class SingleLiveChat : System.Web.UI.UserControl {

        protected void Page_Load(object sender, EventArgs e) {
            ExpertLivePageItem contextItem = Sitecore.Context.Item;
            if (!Sitecore.Context.Item.IsOfType(ExpertLivePageItem.TemplateId)) {
                if (IsArchiveItem(Sitecore.Context.Item)) {
                    this.Visible = true;
                    contextItem = GetExpertLivePageItem();
                }
                else {
                    this.Visible = false;
                }
            }

            if (contextItem != null) {
                //frLiveChatHeading.Item = frLiveChatSubHeading.Item = contextItem;
            }
            GetLiveChat();
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

        private void GetLiveChat() {
            var liveChat = GetChat(ChatEventPageItem.TemplateId, true);
            if (liveChat != null && liveChat.Any()) {
                rptEventCarousel.DataSource = liveChat;
                rptEventCarousel.DataBind();
            }
            else {
                this.Visible = false;
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
                result = context.GetQueryable<SearchResultItem>().
                       Where(i => i.TemplateId == Sitecore.Data.ID.Parse(templateId) && i.Path.Contains("/sitecore/content")).Select(i => i.GetItem()).ToList();
                if (isLive) {
                    searchResultItems = result.Select(i => new BaseEventDetailPageItem(i)).Where(t => IsLiveChat(t)).ToList();
                }
                else {
                    searchResultItems = result.Select(i => new BaseEventDetailPageItem(i)).Where(t => !IsLiveChat(t)).ToList();
                }

                searchResultItems = searchResultItems.Where(t => !IsArchiveItem(t)).ToList();
            }
            return searchResultItems;
        }

        private bool IsLiveChat(BaseEventDetailPageItem t) {
            //ChatEventPageItem chatEventPage = new ChatEventPageItem(t.InnerItem);
            //if (chatEventPage != null && !chatEventPage.OpenOfficeHour.Raw.IsNullOrEmpty()) {
            //    return true;
            //}

            return false;
        }

        private bool IsArchiveItem(Item item) {
            bool isArchiveItem = false;
            BaseEventDetailPageItem baseEventPageItem = new BaseEventDetailPageItem(item);
            if (baseEventPageItem != null) {
                if (baseEventPageItem.EventEndDate.DateTime < DateTime.Today) {
                    isArchiveItem = true;
                }
            }

            return isArchiveItem;
        }

        protected void rptEventCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                BaseEventDetailPageItem detailItem = e.Item.DataItem as BaseEventDetailPageItem;
                ContentPageItem contentPageItem = new ContentPageItem(detailItem.InnerItem);
                Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                System.Web.UI.WebControls.Image imgExpertDefault = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpertDefault");
                Panel pnlExpertImageLabel = e.FindControlAs<Panel>("pnlExpertImageLabel");
                FieldRenderer frHeading = e.FindControlAs<FieldRenderer>("frHeading");
                FieldRenderer frSubHeading = e.FindControlAs<FieldRenderer>("frSubHeading");
                Link scFollowTwittLink = e.FindControlAs<Link>("scFollowTwittLink");
                Link scFollowBlogLink = e.FindControlAs<Link>("scFollowBlogLink");
                Link scBioLink = e.FindControlAs<Link>("scBioLink");
                Literal litExpert = e.FindControlAs<Literal>("litExpert");
                Literal ltEventDate = e.FindControlAs<Literal>("ltEventDate");
                Date scDate = e.FindControlAs<Date>("scDate");
                imgExpertDefault.Visible = true;
                if (detailItem != null) {
                    FieldRenderer frParticipation = e.FindControlAs<FieldRenderer>("frParticipation");
                    ExpertDetailPageItem expertItem = detailItem.Expert.Item;
                    if (expertItem != null) {
                        if (scExpertImage != null) {
                            scExpertImage.Item = expertItem;
                            pnlExpertImageLabel.Visible = true;
                            imgExpertDefault.Visible = false;
                        }
                        else {
                            imgExpertDefault.Visible = true;
                        }
                    }
                    if (frHeading != null) {
                        frHeading.Item = detailItem;
                    }
                    if (frSubHeading != null) {
                        frSubHeading.Item = detailItem;
                    }

                    if (ltEventDate != null && !detailItem.EventStartDate.Raw.IsNullOrEmpty()) {
                        TimeZoneItem timezone = detailItem.EventTimezone.Item;
                        string timeZoneText = string.Empty;

                        if (timezone != null) {
                            timeZoneText = timezone.Timezone.Rendered;
                        }

                        ltEventDate.Text = String.Format("{0} at {1} {2}", detailItem.EventStartDate.DateTime.ToString("ddd MMM dd"), detailItem.EventStartDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                    }
                    if (scFollowTwittLink != null) {
                        scFollowTwittLink.Item = detailItem;
                    }
                    if (litExpert != null) {
                        litExpert.Text = DictionaryConstants.ExpertLabel;
                    }
                    if (scFollowBlogLink != null) {
                        scFollowBlogLink.Item = detailItem;
                    }
                    if (scBioLink != null) {
                        scBioLink.Item = detailItem;
                    }
                    if (scDate != null) {
                        scDate.Item = detailItem;
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