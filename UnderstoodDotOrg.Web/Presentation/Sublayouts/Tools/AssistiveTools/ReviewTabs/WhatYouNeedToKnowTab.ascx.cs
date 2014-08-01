using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs
{
    public partial class WhatYouNeedToKnowTab : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        protected string[] SpelledNumbers = new[] { "zero", "one", "two", "three", "four", "five" };

        protected void Page_Load(object sender, EventArgs e)
        {
            AssistiveToolsSearchResultsPageItem searchPage = MainsectionItem.GetHomePageItem().GetToolsPage().GetAssistiveToolsLandingPage().GetSearchPage();

            frFooterContent.Item = searchPage;

            var screenshots = Model.Screenshots.ListItems
                .Where(i => i != null && i.Paths.IsMediaItem)
                .Select(i => (MediaItem)i);

            rptrScreenshots.DataSource = screenshots
                .Select(mi => new
                {
                    Alt = mi.Alt,
                    Url = mi.GetImageUrl()
                }).ToList();
            rptrScreenshots.DataBind();

            var platforms = Model.Platforms.ListItems
                .Where(i => i != null && i.IsOfType(AssistiveToolsPlatformItem.TemplateId))
                .Select(i => (MetadataItem)i).ToList();

            rptrPlatforms.DataSource = platforms;
            rptrPlatforms.DataBind();

            var subjectsAndSkills = Model.Subjects.ListItems
                .Where(i => i != null)
                .Select(i => (MetadataItem)i).ToList();
            subjectsAndSkills.AddRange(Model.Skills.ListItems
                .Where(i => i != null)
                .Select(i => (MetadataItem)i));

            rptrSubjectsAndSkills.DataSource = subjectsAndSkills;
            rptrSubjectsAndSkills.DataBind();

            frPlatformsLink.Item = MainsectionItem.GetHomePageItem().GetToolsPage().GetAssistiveToolsLandingPage().GetSearchPage();
        }

        protected void rptrPlatforms_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                MetadataItem platform = (MetadataItem)e.Item.DataItem;

                Literal litPlatform = e.FindControlAs<Literal>("litPlatform");

                if (e.Item.ItemIndex == 0)
                {
                    litPlatform.Text = platform.ContentTitle.Raw;
                }
                else
                    litPlatform.Text = ", " + platform.ContentTitle.Raw;

            }
        }
    }
}