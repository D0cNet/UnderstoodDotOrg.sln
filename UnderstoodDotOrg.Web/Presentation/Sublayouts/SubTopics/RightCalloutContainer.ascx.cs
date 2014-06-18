using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets.Base;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics
{
    public partial class RightCalloutContainer : BaseSublayout<SubtopicLandingPageItem>
    {
        protected string baseWidgetPath = "~/Presentation/Sublayouts/Common/Widgets/";

        protected void Page_Init(object sender, EventArgs e)
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            rptWidgets.ItemDataBound += rptWidgets_ItemDataBound;
        }

        private void BindControls()
        {
            var widgets = Model.GetWidgets();
            if (widgets.Any())
            {
                rptWidgets.DataSource = widgets;
                rptWidgets.DataBind();
            }
        }

        void rptWidgets_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item item = (Item)e.Item.DataItem;

                Sublayout slWidget = e.FindControlAs<Sublayout>("slWidget");
                PlaceHolder phToolWrapperStart = e.FindControlAs<PlaceHolder>("phToolWrapperStart");
                PlaceHolder phToolWrapperEnd = e.FindControlAs<PlaceHolder>("phToolWrapperEnd");

                slWidget.DataSource = item.ID.ToString();

                if (item.InheritsTemplate(ToolWidgetItem.TemplateId))
                {
                    phToolWrapperStart.Visible = phToolWrapperEnd.Visible = true;
                    slWidget.Path = ToolWidgetItem.GetWidgetSublayoutPath(item);
                }
                else if (item.InheritsTemplate(UpcomingEventWidgetItem.TemplateId))
                {
                    slWidget.Path = String.Concat(baseWidgetPath, "UpcomingEvent.ascx");
                }
            }
        }
    }
}