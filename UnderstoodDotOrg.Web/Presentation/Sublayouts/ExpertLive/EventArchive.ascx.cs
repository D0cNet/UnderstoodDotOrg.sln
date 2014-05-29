using Sitecore.Data.Items;
using System;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class EventArchive : System.Web.UI.UserControl
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
            // TODO: re-used in landing page modules - create central function
            ExpertLivePageItem ContextItem = GetExpertLivePageItem();

            if (ContextItem != null)
            {
                frHeading.Item = ContextItem;
                ArchiveItem archivePage = ContextItem.GetArchiveItem();

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
    }
}