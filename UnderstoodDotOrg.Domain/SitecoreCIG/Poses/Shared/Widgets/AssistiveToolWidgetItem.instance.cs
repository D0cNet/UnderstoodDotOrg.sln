using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets
{
    public partial class AssistiveToolWidgetItem
    {
        public string GetSearchResultsUrl()
        {
            string url = ToolWidget.WidgetButtonLink.Url;

            if (string.IsNullOrEmpty(url))
            {
                Item fallback = Sitecore.Context.Database.GetItem(Constants.Pages.AssistiveToolResults);
                if (fallback != null)
                {
                    url = fallback.GetUrl();
                }
            }

            return url;
        }
    }
}