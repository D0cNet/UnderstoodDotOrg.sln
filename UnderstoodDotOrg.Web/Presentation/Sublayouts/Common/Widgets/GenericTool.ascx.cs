using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets
{
    public partial class GenericTool : BaseSublayout<GenericToolWidgetItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
        }

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
        }

        private void BindContent()
        {
            frWidgetContent.Item = frWidgetCopy.Item = frWidgetTitle.Item = Model;
            btnSubmit.Text = Model.ToolWidget.WidgetButtonText.Rendered;
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Model.ToolWidget.WidgetButtonLink.Url))
            {
                Response.Redirect(Model.ToolWidget.WidgetButtonLink.Url);
            }
        } 
    }
}