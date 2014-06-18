using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets.Base
{
    public partial class ToolWidgetItem
    {
        public static string GetWidgetSublayoutPath(Item item)
        {
            // TODO: move into config
            string baseWidgetPath = "~/Presentation/Sublayouts/Common/Widgets/";

            if (item.IsOfType(GenericToolWidgetItem.TemplateId))
            {
                return String.Concat(baseWidgetPath, "GenericTool.ascx");
            }
            else if (item.IsOfType(BehaviorToolWidgetItem.TemplateId))
            {
                return String.Concat(baseWidgetPath, "BehaviorTool.ascx");
            }
            else if (item.IsOfType(AssistiveToolWidgetItem.TemplateId))
            {
                return String.Concat(baseWidgetPath, "AssistiveTool.ascx");
            }

            return String.Empty;
        }
    }
}