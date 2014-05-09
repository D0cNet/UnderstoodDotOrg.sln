using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Web.UI.WebControls;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home {
    public partial class HomeHeroCarousel : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            HomePageItem ContextItem = Sitecore.Context.Item;
            if (ContextItem != null) {
                GetSliderItem(ContextItem);
            }
        }

        private void GetSliderItem(HomePageItem ContextItem) {
            PageResourceFolderItem pageResourceFolder = ContextItem.GetPageResourceFolderItem();
            if (pageResourceFolder != null) {
                HomeSliderFolderItem homeSliderFolderItem = pageResourceFolder.GetHomeSliderFolderItem();
                if (homeSliderFolderItem != null) {
                    if (!homeSliderFolderItem.RandomizeSlides.Rendered.IsNullOrEmpty()) {
                        hfRandomizeSlider.Value = "true";
                    }
                    else {
                        hfRandomizeSlider.Value = "false";
                    }
                    var sliderItems = homeSliderFolderItem.GetHomeSliderItems();
                    if (sliderItems != null && sliderItems.Any()) {
                        rptHomeSlider.DataSource = sliderItems;
                        rptHomeSlider.DataBind();
                    }
                }

            }
        }

        protected void rptHomeSlider_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                HomeSliderItem item = e.Item.DataItem as HomeSliderItem;
                if (item != null) {
                    FieldRenderer frSliderText = e.FindControlAs<FieldRenderer>("frSliderText");
                    Panel pnlSliderImage = e.FindControlAs<Panel>("pnlSliderImage");
                    Panel pnlSliderText = e.FindControlAs<Panel>("pnlSliderText");

                    if (frSliderText != null) {
                        frSliderText.Item = item;
                    }

                    if (pnlSliderImage != null && item.HeroImage.MediaItem != null) { 
                        pnlSliderImage.Style.Add("background-image",string.Format("url('{0}')", item.HeroImage.MediaUrl));
                        pnlSliderImage.Attributes.Add("onclick", string.Format("location.href='{0}'", item.Link.Url));
                    }

                    if (pnlSliderText != null) {
                        pnlSliderText.Attributes.Add("class", string.Format("text {0}", item.TextCss.Rendered));
                    }
                }
            }
        }
    }
}