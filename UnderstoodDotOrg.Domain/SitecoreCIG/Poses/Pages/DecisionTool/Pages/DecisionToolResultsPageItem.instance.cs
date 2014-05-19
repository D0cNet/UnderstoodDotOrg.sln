using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages
{
    public partial class DecisionToolResultsPageItem
    {
        public DecisionToolLandingPageItem GetDecisionToolLandingPage()
        {
            return Sitecore.Context.Item.Parent;
        }
    }
}