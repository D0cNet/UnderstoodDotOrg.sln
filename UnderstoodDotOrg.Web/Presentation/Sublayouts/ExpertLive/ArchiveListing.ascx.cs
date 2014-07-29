using System;
using System.Collections.Generic;
using System.Linq;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class ArchiveListing : System.Web.UI.UserControl
    {
        public string Issue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }
        public string AjaxEndpoint
        {
            get { return Sitecore.Configuration.Settings.GetSetting("EventArchiveEndpoint"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Issue = HttpHelper.GetQueryString(Constants.EVENT_ISSUE_FILTER_QUERY_STRING).Trim();
            Grade = HttpHelper.GetQueryString(Constants.EVENT_GRADE_FILTER_QUERY_STRING).Trim();
            Topic = HttpHelper.GetQueryString(Constants.EVENT_TOPIC_FILTER_QUERY_STRING).Trim();

            PopulateArchive();
        }

        private void PopulateArchive()
        {
            int totalResults;
            List<BaseEventDetailPageItem> results = SearchHelper.GetArchivedEvents(1, Constants.EVENT_ARCHIVE_ENTRIES_PER_PAGE, out totalResults, Grade, Issue, Topic);

            archiveEvents.ArchivedEvents = results;

            pnlMoreArticle.Visible = results.Count() < totalResults;
        }
    }
}