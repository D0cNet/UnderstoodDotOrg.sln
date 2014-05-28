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

            // TODO: create constants for query string vars
            
            string featured = HttpHelper.GetQueryString("featured");
            Issue = HttpHelper.GetQueryString("issue").Trim();
            Grade = HttpHelper.GetQueryString("grade").Trim();
            Topic = HttpHelper.GetQueryString("topic").Trim();

            IsFeatured = featured.ToLower() == "true";
            
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
        public static ExpertliveFilterFolderItem GetExpertLiveFilterFolder() 
        {
            MainsectionItem objSiteItem = MainsectionItem.GetSiteRoot();
            ExpertliveFilterFolderItem objExpertliveFilterFolderItem = null;
            if (objSiteItem != null) 
            {
                GlobalsItem objGlobalItem = MainsectionItem.GetGlobals();
                if (objGlobalItem != null) 
                {
                   MetadataFolderFolderItem metaDataFolder = objGlobalItem.GetMetaDataFolder();
                   if (metaDataFolder != null) 
                   {
                       objExpertliveFilterFolderItem = metaDataFolder.GetExpertliveFilterFolder();
                   }
                }
            }
            return objExpertliveFilterFolderItem;
        }

        private IEnumerable<NavigationLinkItem> GetNavigationLinkItem(ExpertliveFilterFolderItem expertLiveFolder) 
        {
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

        protected void rptFilter_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.IsItem()) 
            {
                NavigationLinkItem navItem = e.Item.DataItem as NavigationLinkItem;

                if (navItem != null) 
                {
                    FieldRenderer frLink = e.FindControlAs<FieldRenderer>("frLink");

                    if (frLink != null) 
                    {
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