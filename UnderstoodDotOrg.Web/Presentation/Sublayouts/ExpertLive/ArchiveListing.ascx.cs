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