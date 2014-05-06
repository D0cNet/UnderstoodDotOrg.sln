using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common.Extensions;
namespace UnderstoodDotOrg.Web.Presentation.Layouts
{
    public partial class Browser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item ContextItem = Sitecore.Context.Item;
            if (ContextItem != null && ContextItem.InheritsFromType(BasePageNEWItem.TemplateId)) {
                BasePageNEWItem basePage = new BasePageNEWItem(ContextItem);
                if (basePage != null && !basePage.ShowWelcomeTour.Raw.IsNullOrEmpty()) {
                    ltWelcomeTour.Text = "<div data-show-welcome-tour=\"true\" id=\"community-page\"></div>";
                }
            }
        }
    }
}