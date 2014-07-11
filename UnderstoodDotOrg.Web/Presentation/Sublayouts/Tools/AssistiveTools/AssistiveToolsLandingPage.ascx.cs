using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using Sitecore;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsLandingPage : BaseSublayout<AssistiveToolsLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			lblRelatedArticles.Text = DictionaryConstants.RelatedArticlesLabel;
			lblWhatParentsAreSaying.Text = DictionaryConstants.WhatParentsAreSayingLabel;
        }
    }
}