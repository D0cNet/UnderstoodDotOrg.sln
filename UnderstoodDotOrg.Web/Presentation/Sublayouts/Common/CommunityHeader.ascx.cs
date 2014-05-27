using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class BlogHeader : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
            BindControls();
        }

        private void BindEvents()
        {
            rptLinks.ItemDataBound += rptLinks_ItemDataBound;
        }

        private void BindContent()
        {
            // TODO: wire up text
        }

        private void BindControls()
        {
            // TODO: Update with better logic for getting nav root item
            var navRoot = Sitecore.Context.Database.GetItem("{1A6F9D01-4152-4F2F-979B-8BD670B037A4}");
            var navLinks = navRoot.Children
                .Where(i => i.IsOfType(NavigationLinkItem.TemplateId))
                .Select(i => (NavigationLinkItem)i);

            if (navLinks.Any())
            {
                rptLinks.DataSource = navLinks;
                rptLinks.DataBind();
            }
        }

        private void rptLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem item = (NavigationLinkItem)e.Item.DataItem;

                FieldRenderer frLink = e.FindControlAs<FieldRenderer>("frLink");
                frLink.Item = item;

                if (item.Link.Field != null)
                {
                    // Handle initial menu choice
                    if (e.Item.ItemIndex == 0)
                    {
                        litInitialMenuChoice.Text = item.Link.Field.Text;
                    }

                    // Selected state
                    Item navItem = Sitecore.Context.Item;
                    while (navItem != null)
                    {
                        if (item.Link.Field.TargetID == navItem.ID) 
                        {
                            frLink.Parameters = "class=selected";
                            break;
                        }
                        navItem = navItem.Parent;
                    }
                }
            }
        }
    }
}