namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    using System;
    using System.Linq;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.Search;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
    using UnderstoodDotOrg.Framework.UI;

    public partial class ArchivedEventsModule : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Handle conditional display
            if (Sitecore.Context.Item.InheritsTemplate(ChatEventPageItem.TemplateId))
            {
                ChatEventPageItem chat = Sitecore.Context.Item;
                if (!chat.BaseEventDetailPage.IsUpcoming())
                {
                    this.Visible = false;
                    return;
                }
            }
            BindContent();
            BindControls();
        }

        private void BindControls()
        {
            int totalResults;
            archiveEvents.ArchivedEvents = SearchHelper.GetArchivedEvents(1, 2, out totalResults);

            if (!archiveEvents.ArchivedEvents.Any())
            {
                pnlNoArchiveMessage.Visible = true;
            }
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