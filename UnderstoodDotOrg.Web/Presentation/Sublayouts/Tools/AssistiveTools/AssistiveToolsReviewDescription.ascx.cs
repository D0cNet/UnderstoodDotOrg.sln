using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsReviewDescription : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			lblParentReviews.Text = DictionaryConstants.ParentReviewsLabel;
			lblWhatYouNeedToKnow.Text = DictionaryConstants.WhatYouNeedToKnowLabel;
        }
    }
}