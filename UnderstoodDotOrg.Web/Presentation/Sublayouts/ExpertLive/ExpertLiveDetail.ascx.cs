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
        public bool IsTagged { get; set; }
        public string Issue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }

        protected void Page_Load(object sender, EventArgs e) 
        {
            // TODO: create constants for query string vars
            
            string featured = HttpHelper.GetQueryString("featured");
            Issue = HttpHelper.GetQueryString("issue").Trim();
            Grade = HttpHelper.GetQueryString("grade").Trim();
            Topic = HttpHelper.GetQueryString("topic").Trim();

            IsFeatured = featured.ToLower() == "true";
            IsTagged = !String.IsNullOrEmpty(Issue) || !String.IsNullOrEmpty(Grade) || !String.IsNullOrEmpty(Topic);

            if (!IsPostBack)
            {
                FillFilterOptions();

                SetSelectedState(ddlIssue, Issue);
                SetSelectedState(ddlGrade, Grade);
                SetSelectedState(ddlTopics, Topic);
            }

            ExpertliveFilterFolderItem expertLiveFilterFolder = GetExpertLiveFilterFolder();
            if (expertLiveFilterFolder != null)
            {
                var result = GetNavigationLinkItem(expertLiveFilterFolder);
                if (result != null && result.Any())
                {
                    rptFilter.DataSource = result;
                    rptFilter.DataBind();
                }
            }

            PopulateUpcomingEvents();
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

        private void SetSelectedState(DropDownList ddl, string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                ListItem li = ddl.Items.FindByValue(value);
                if (li != null)
                {
                    li.Selected = true;
                }
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

        private void FillFilterOptions() 
        {
            var childIssues = FormHelper.GetIssues(DictionaryConstants.ChildIssueLabel);
            var grades = FormHelper.GetGrades(DictionaryConstants.GradeLabel);
            var topics = FormHelper.GetParentInterests(DictionaryConstants.TopicLabel);

            // TODO: refactor to function
            if (childIssues.Any()) 
            {
                ddlIssue.DataSource = childIssues;
                ddlIssue.DataTextField = "Text";
                ddlIssue.DataValueField = "Value";
                ddlIssue.DataBind();
            }
            if (grades.Any()) 
            {
                ddlGrade.DataSource = grades;
                ddlGrade.DataTextField = "Text";
                ddlGrade.DataValueField = "Value";
                ddlGrade.DataBind();
            }
            if (topics.Any()) 
            {
                ddlTopics.DataSource = topics;
                ddlTopics.DataTextField = "Text";
                ddlTopics.DataValueField = "Value";
                ddlTopics.DataBind();
            }
        }

        
        protected void rptUpcomingWebinars_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.IsItem()) 
            {
                BaseEventDetailPageItem item = e.Item.DataItem as BaseEventDetailPageItem;

                Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                System.Web.UI.WebControls.Image imgExpertDefault = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpertDefault");
                Literal ltExpertType = e.FindControlAs<Literal>("ltExpertType");
                Literal ltEventDate = e.FindControlAs<Literal>("ltEventDate");
                HyperLink hlExpertBio = e.FindControlAs<HyperLink>("hlExpertBio");
                FieldRenderer frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                HyperLink hlWebinarDetail = e.FindControlAs<HyperLink>("hlWebinarDetail");
                Panel pnlExpertImageLabel = e.FindControlAs<Panel>("pnlExpertImageLabel");

                ExpertDetailPageItem expertItem = item.Expert.Item;

                if (expertItem != null)
                {
                    hlExpertBio.NavigateUrl = expertItem.GetUrl();
                    if (expertItem.ExpertImage.MediaItem != null)
                    {
                        scExpertImage.Item = expertItem;
                        pnlExpertImageLabel.Visible = true;
                    }
                    else
                    {
                        imgExpertDefault.Visible = true;
                    }

                    ltExpertType.Text = !expertItem.IsGuest.Checked ? DictionaryConstants.ExpertLabel : DictionaryConstants.GuestExpertLabel;
                }
                else
                {
                    imgExpertDefault.Visible = true;
                    pnlExpertImageLabel.Visible = false;
                }

                if (!item.EventDate.Raw.IsNullOrEmpty())
                {
                    TimeZoneItem timezone = item.Timezone.Item;
                    string timeZoneText = (timezone != null) ? timezone.Timezone.Rendered : string.Empty;

                    ltEventDate.Text = String.Format("{0} at {1} {2}", item.EventDate.DateTime.ToString("ddd MMM dd"), item.EventDate.DateTime.ToString("hh:mm tt").ToLower(), timeZoneText);
                }

                frPageTitle.Item = item;
                hlWebinarDetail.NavigateUrl = item.GetUrl();
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

                    hlChatDetail.NavigateUrl = webinarItem.InnerItem.GetUrl();

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
                                ltExpertType.Text = expertItem.IsGuest.Checked ? DictionaryConstants.GuestExpertLabel : DictionaryConstants.ExpertLabel;
                            }
                        }
                        else {
                            imgExpertDefault.Visible = true;
                            pnlExpertImageLabel.Visible = false;
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

        protected void ddlIssue_SelectedIndexChanged(object sender, EventArgs e) 
        {
            Response.Redirect(Model.GetUrl() + "?issue=" + ddlIssue.SelectedItem.Value, true);
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e) 
        {
            Response.Redirect(Model.GetUrl() + "?grade=" + ddlGrade.SelectedItem.Value, true);
        }

        protected void ddlTopics_SelectedIndexChanged(object sender, EventArgs e) 
        {
            Response.Redirect(Model.GetUrl() + "?topic=" + ddlTopics.SelectedItem.Value, true);
        }
    }
}