using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData {
    public partial class ExpertListing : System.Web.UI.Page {
        Int32 clickCount = 1;
       
        public string ItemID { get; set; }
        protected void Page_Load(object sender, EventArgs e) {
            if (Request.QueryString["itemid"] != null && !Request.QueryString["itemid"].ToString().IsNullOrEmpty()) {
                this.ItemID = Request.QueryString["itemid"].ToString();

            }

            if (Request["count"] != null) {
                clickCount = Int32.Parse(Request["count"]);
            }

            int resultsPeClick = 3;
            if (Request.QueryString["rpc"] != null)
                int.TryParse(Request.QueryString["rpc"], out resultsPeClick);

            if (!Page.IsPostBack) {
                ExpertLandingPageItem contextItem = Sitecore.Context.Database.GetItem(ItemID);

                var expertDetailItems = contextItem.GetExpertDetailPages();

                if (expertDetailItems.Any()) {
                    rptListing.Visible = true;
                    rptListing.DataSource = expertDetailItems.Skip(clickCount * resultsPeClick).Take(resultsPeClick).ToList(); 
                    rptListing.DataBind();
                    int itemCount = ((clickCount * resultsPeClick) + resultsPeClick);
                    if (expertDetailItems.Count() <= itemCount) {
                        lblmoreArticle.Text = "false";
                    }
                }
            }
        }

        protected void rptListing_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                ExpertDetailPageItem detailItem = e.Item.DataItem as ExpertDetailPageItem;
                Panel rowSubParentPanel = e.FindControlAs<Panel>("rowSubParentPanel");
                Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                System.Web.UI.WebControls.Image imgDefaultImage = e.FindControlAs<System.Web.UI.WebControls.Image>("imgDefaultImage");
                FieldRenderer frHeading = e.FindControlAs<FieldRenderer>("frHeading");
                FieldRenderer frSubHeading = e.FindControlAs<FieldRenderer>("frSubHeading");
                Link scFollowTwittLink = e.FindControlAs<Link>("scFollowTwittLink");
                Link scFollowBlogLink = e.FindControlAs<Link>("scFollowBlogLink");
                HyperLink hlBioLink = e.FindControlAs<HyperLink>("hlBioLink");
                if (detailItem != null) {
                    FieldRenderer frParticipation = e.FindControlAs<FieldRenderer>("frParticipation");
                    if (frParticipation != null) {
                        frParticipation.Item = detailItem;
                    }
                    if (rowSubParentPanel != null) {
                        if ((e.Item.ItemIndex + 1) % 3 == 1)
                            rowSubParentPanel.CssClass = "col col-6 " + "offset-1";
                        else
                            rowSubParentPanel.CssClass = "col col-6 " + "offset-2";
                    }
                    if (scExpertImage != null && detailItem.ExpertImage.MediaItem != null) {
                        scExpertImage.Item = detailItem;
                        imgDefaultImage.Visible = false;
                    }
                    else {
                        imgDefaultImage.Visible = true;
                    }
                    if (frHeading != null) {
                        frHeading.Item = detailItem;
                    }
                    if (frSubHeading != null) {
                        frSubHeading.Item = detailItem;
                    }
                    if (scFollowTwittLink != null) {
                        scFollowTwittLink.Item = detailItem;
                    }
                    if (scFollowBlogLink != null) {
                        scFollowBlogLink.Item = detailItem;
                    }
                    if (hlBioLink != null) {
                        hlBioLink.NavigateUrl = detailItem.GetUrl();
                        hlBioLink.Text = "See my bio";
                    }
                }
            }
        }
    }
}