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
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Understood.Helper;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class ArchiveListing : System.Web.UI.UserControl
    {
        public string Issue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Issue = HttpHelper.GetQueryString("issue").Trim();
            Grade = HttpHelper.GetQueryString("grade").Trim();
            Topic = HttpHelper.GetQueryString("topic").Trim();

            if (!IsPostBack)
            {
                FillFilterOptions();

                SetSelectedState(ddlIssue, Issue);
                SetSelectedState(ddlGrade, Grade);
                SetSelectedState(ddlTopics, Topic);
            }

            PopulateArchive();
        }

        private void PopulateArchive()
        {
            int totalResults;
            List<BaseEventDetailPageItem> results = SearchHelper.GetArchivedEvents(1, Constants.EVENT_ARCHIVE_ENTRIES_PER_PAGE, out totalResults, Grade, Issue, Topic);

            archiveEvents.ArchivedEvents = results;

            pnlMoreArticle.Visible = results.Count() < totalResults;
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

        protected ExpertLivePageItem GetExpertLivePageItem()
        {
            Item contextItem = Sitecore.Context.Item;
            Item topicLandingPageItem = contextItem;
            while (contextItem != null && !contextItem.IsOfType(ExpertLivePageItem.TemplateId))
            {

                if (contextItem.Parent != null && contextItem.Parent.IsOfType(ExpertLivePageItem.TemplateId))
                {
                    topicLandingPageItem = contextItem.Parent;
                    break;
                }
                contextItem = contextItem.Parent;
            }

            return topicLandingPageItem;
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
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "?issue=" + ddlIssue.SelectedItem.Text, true);
        }

        protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "?grade=" + ddlGrade.SelectedItem.Text, true);
        }

        protected void ddlTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "?topic=" + ddlTopics.SelectedItem.Text, true);
        }
    }
}