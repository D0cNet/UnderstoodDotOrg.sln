using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Section
{
    public partial class SectionTools : BaseSublayout<SectionLandingPageItem>
    {
        protected string BackgroundImage { get; set; }
        protected string BaseWidgetPath = "~/Presentation/Sublayouts/Common/Widgets/";

        protected void Page_Init(object sender, EventArgs e)
        {
            // NOTE: Populate repeater in Init event to prevent loss of viewstate in sublayouts
            BindEvents();

            BindControls();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            if (Model.BackgroundImage.MediaItem != null)
            {
                BackgroundImage = String.Format("background-image: url({0});", Model.BackgroundImage.MediaItem.GetImageUrl());
            }  
        }

        private void BindControls()
        {
            IEnumerable<Item> items = Model.GetToolWidgets();
            if (items.Any())
            {
                rptWidgets.DataSource = items;
                rptWidgets.DataBind();
            }
        }

        private void BindEvents()
        {
            rptWidgets.ItemDataBound += rptWidgets_ItemDataBound;
        }

        void rptWidgets_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item item = (Item)e.Item.DataItem;

                Sublayout slWidget = e.FindControlAs<Sublayout>("slWidget");
                slWidget.DataSource = item.ID.ToString();

                if (item.IsOfType(GenericToolWidgetItem.TemplateId))
                {
                    slWidget.Path = String.Concat(BaseWidgetPath, "GenericTool.ascx");
                }
                else if (item.IsOfType(BehaviorToolWidgetItem.TemplateId))
                {
                    slWidget.Path = String.Concat(BaseWidgetPath, "BehaviorTool.ascx");
                }
                else if (item.IsOfType(AssistiveToolWidgetItem.TemplateId))
                {
                    slWidget.Path = String.Concat(BaseWidgetPath, "AssistiveTool.ascx");
                }
            }
        }
    }
}