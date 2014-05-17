using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool
{
    public partial class DecisionToolResultsPage : BaseSublayout<DecisionToolResultsPageItem>
    {
        protected DecisionQuestionPageItem Question { get; set; }
        protected List<DecisionAnswerItem> Answers { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}