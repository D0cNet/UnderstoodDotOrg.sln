using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.ListTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
    public partial class ChildLearningIssueItem
    {
        #region Field Instance Methods (fields with search)
        public CustomMultiListField ExpertSummaryWithSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["Expert Summary With Subtitles"]);
            }
        }
        public CustomMultiListField ExpertSummaryWithoutSubtitles
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["Expert Summary Without Subtitles"]);
            }
        }
        #endregion
    }
}