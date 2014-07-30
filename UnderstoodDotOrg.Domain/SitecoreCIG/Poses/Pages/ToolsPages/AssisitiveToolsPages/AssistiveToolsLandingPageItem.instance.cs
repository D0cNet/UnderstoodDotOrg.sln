using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.ListTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages
{
    public partial class AssistiveToolsLandingPageItem
    {
        public AssistiveToolsSearchResultsPageItem GetSearchPage()
        {
            return InnerItem.Children
                .FirstOrDefault(i => i.IsOfType(AssistiveToolsSearchResultsPageItem.TemplateId));
        }

        public IEnumerable<AssistiveToolsReviewPageItem> GetToolDetailPages()
        {
            var searchPage = GetSearchPage();
            return searchPage != null ? searchPage.GetToolDetailPages() : new List<AssistiveToolsReviewPageItem>();
        }

        #region Field Instance Methods (fields with search)
        public CustomMultiListField RelatedArticles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["Related Articles"]);
            }
        }
        #endregion
    }
}