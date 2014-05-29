using Sitecore.Data.Items;
using System;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class EventArchive : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
            BindControls();
        }

        private void BindControls()
        {
            int totalResults;
            archiveEvents.ArchivedEvents = SearchHelper.GetArchivedEvents(1, 2, out totalResults);
        }

        private void BindContent()
        {
            ExpertLivePageItem item = Sitecore.Context.Database.GetItem(Constants.Pages.ExpertLive);

            if (item != null)
            {
                frHeading.Item = item;
                ArchiveItem archivePage = item.GetArchiveItem();

                if (archivePage != null)
                {
                    hlSeeArchive.Text = DictionaryConstants.SeeArchiveLabel;
                    hlSeeArchive.NavigateUrl = archivePage.InnerItem.GetUrl();
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
    }
}