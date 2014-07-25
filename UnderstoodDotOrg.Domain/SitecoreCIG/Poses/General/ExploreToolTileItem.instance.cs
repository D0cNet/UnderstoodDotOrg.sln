using System;
using Sitecore.Data;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
    public partial class ExploreToolTileItem
    {
        public string GetSublayoutPath()
        {
            string path = string.Empty;

            string basePath = "~/Presentation/Sublayouts/Common/Tiles/";

            Item widget = ToolWidget.Item;
            if (widget != null)
            {
                if (widget.TemplateID == ID.Parse(AssistiveToolWidgetItem.TemplateId))
                {
                    path = "MiniAssistiveTool.ascx";
                }
                else if (widget.TemplateID == ID.Parse(BehaviorToolWidgetItem.TemplateId))
                {
                    path = "MiniBehaviorTool.ascx";
                }

                if (!string.IsNullOrEmpty(path))
                {
                    path = String.Concat(basePath, path);
                }
            }

            return path;
        }
    }
}