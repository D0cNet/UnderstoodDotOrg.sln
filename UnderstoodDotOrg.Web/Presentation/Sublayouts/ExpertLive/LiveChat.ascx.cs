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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve {
    public partial class LiveChat : System.Web.UI.UserControl {

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
                frLiveChatHeading.Item = frLiveChatSubHeading.Item = contextItem;
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
                rptLiveChat.DataSource = liveChat;
                rptLiveChat.DataBind();
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
                if (baseEventPageItem.EventStartDate.DateTime < DateTime.Today) {
                    isArchiveItem = true;
                }
            }

            return isArchiveItem;
        }

        protected void rptLiveChat_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                BaseEventDetailPageItem liveChatItem = e.Item.DataItem as BaseEventDetailPageItem;
                ContentPageItem contentPageItem = new ContentPageItem(liveChatItem.InnerItem);
                if (liveChatItem != null) {
                    Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                    System.Web.UI.WebControls.Image imgExpertDefault = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpertDefault");
                    Literal litGuest = e.FindControlAs<Literal>("litGuest");
                    HyperLink hlLInkCardImage = e.FindControlAs<HyperLink>("liveChat");
                    Literal ltOpenOfficeHours = e.FindControlAs<Literal>("ltOpenOfficeHours");
                    FieldRenderer frExpertName = e.FindControlAs<FieldRenderer>("frExpertName");
                    FieldRenderer frPageSummary = e.FindControlAs<FieldRenderer>("frPageSummary");
                    Panel pnlExpertImageLabel = e.FindControlAs<Panel>("pnlExpertImageLabel");
                    HyperLink hlOfficeHours = e.FindControlAs<HyperLink>("hlOfficeHours");
                    HyperLink hlMeetExpert = e.FindControlAs<HyperLink>("hlMeetExpert");

                    if (contentPageItem != null) {
                       
                        if (frPageSummary != null) {
                            frPageSummary.Item = contentPageItem;
                        }
                    }

                    if (liveChatItem != null) {
                        if (ltOpenOfficeHours != null) {
                            ltOpenOfficeHours.Text = DictionaryConstants.OfficeHoursWithLabel;
                        }

                        ExpertDetailPageItem expertItem = liveChatItem.Expert.Item;
                        if (expertItem != null) {
                            if (hlMeetExpert != null) {
                                hlMeetExpert.NavigateUrl = expertItem.InnerItem.GetUrl();
                                hlMeetExpert.Text = String.Format("{0} {1}", DictionaryConstants.MeetLabel, expertItem.ExpertName.Rendered);
                            }

                            if (hlOfficeHours != null) {
                                hlOfficeHours.NavigateUrl = expertItem.InnerItem.GetUrl();
                                hlOfficeHours.Text = DictionaryConstants.SeeHerOfficeHoursLabel;
                            }

                            if (frExpertName != null) {
                                frExpertName.Item = expertItem;
                            }

                            if (litGuest != null) {
                                litGuest.Text = expertItem.IsGuest.Rendered.IsNullOrEmpty() ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                            }
                            if (scExpertImage != null && expertItem.ExpertImage.MediaItem != null) {
                                scExpertImage.Item = expertItem;
                                pnlExpertImageLabel.Visible = true;
                            }
                            else {
                                imgExpertDefault.Visible = true;
                            }

                            if (hlLInkCardImage != null) {
                                hlLInkCardImage.NavigateUrl = expertItem.InnerItem.GetUrl();
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
}