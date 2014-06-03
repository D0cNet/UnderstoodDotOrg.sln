using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;

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
                ExpertDetailPageItem expert = (ExpertDetailPageItem)e.Item.DataItem;

                FieldRenderer frExpertName = (FieldRenderer)e.Item.FindControl("frExpertName");
                FieldRenderer frExpertSubheading = (FieldRenderer)e.Item.FindControl("frExpertSubheading");
                FieldRenderer frTwitterLink = (FieldRenderer)e.Item.FindControl("frTwitterLink");
                FieldRenderer frBlogLink = (FieldRenderer)e.Item.FindControl("frBlogLink");
                
                frExpertName.Item = frExpertSubheading.Item = frTwitterLink.Item 
                    = frBlogLink.Item = expert;

                System.Web.UI.WebControls.Image imgExpert = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgExpert");
                imgExpert.ImageUrl = expert.GetThumbnailUrl(230, 230);

                HyperLink hlExpertDetail = (HyperLink)e.Item.FindControl("hlExpertDetail");
                hlExpertDetail.NavigateUrl = expert.GetUrl();

                Repeater rptTasks = (Repeater)e.Item.FindControl("rptTasks");
            }
        } 
    }
}