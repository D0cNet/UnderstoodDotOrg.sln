using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsRelatedArticles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
        }

        private void BindEvents()
        {
            rptLinks.ItemDataBound += rptLinks_ItemDataBound;
        }

        void rptLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem item = (NavigationLinkItem)e.Item.DataItem;
                FieldRenderer frLink = e.FindControlAs<FieldRenderer>("frLink");
                frLink.Item = item;
            }
        }

        private void BindContent()
        {
            BehaviorToolsResultsPageItem item = new BehaviorToolsResultsPageItem(Sitecore.Context.Item);

            var results = item.GetRelatedArticles();
            if (results.Any())
            {
                rptLinks.DataSource = results;
                rptLinks.DataBind();
            }
        }
    }
}