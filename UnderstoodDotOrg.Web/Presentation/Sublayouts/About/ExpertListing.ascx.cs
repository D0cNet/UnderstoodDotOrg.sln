using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class ExpertListing : System.Web.UI.UserControl
    {
        public IEnumerable<ExpertDetailPageItem> Experts { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            lvExperts.ItemDataBound += lvExperts_ItemDataBound;
        }

        private void BindControls()
        {
            if (Experts != null && Experts.Any())
            {
                lvExperts.DataSource = Experts;
                lvExperts.DataBind();
            }
        }

        void lvExperts_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

            }
        } 
    }
}