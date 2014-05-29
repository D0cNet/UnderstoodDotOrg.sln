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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class ArchiveEvents : System.Web.UI.Page
    {
        private string Topic
        {
            get { return Request.QueryString[Constants.EVENT_TOPIC_FILTER_QUERY_STRING] ?? String.Empty; }
        }
        private string Grade
        {
            get { return Request.QueryString[Constants.EVENT_GRADE_FILTER_QUERY_STRING] ?? String.Empty; }
        }
        private string Issue
        {
            get { return Request.QueryString[Constants.EVENT_ISSUE_FILTER_QUERY_STRING] ?? String.Empty; }
        }
        private string ResultPage
        {
            get { return Request.QueryString["page"] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int page;

            if (int.TryParse(ResultPage, out page))
            {
                int pageSize = Constants.EVENT_ARCHIVE_ENTRIES_PER_PAGE;
                int totalResults;
                // TODO: refactor to return custom object with hasmoreresults
                List<BaseEventDetailPageItem> results = SearchHelper.GetArchivedEvents(page, pageSize, out totalResults, Grade, Issue, Topic);

                if (results.Any())
                {
                    eventListing.ArchivedEvents = results;

                    phMoreResults.Visible = ((page - 1) * pageSize) + results.Count < totalResults;
                }
            }
            

        }
    }
}