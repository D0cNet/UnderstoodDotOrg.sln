using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class ExpertLandingPage : System.Web.UI.UserControl
    {
        ExpertLandingPageItem contextItem = Sitecore.Context.Item;

        /// <summary>
        /// Get topic landing page iTems.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExpertDetailPageItem> GetExpertDetailPages(Item item) {
            return item.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(ExpertDetailPageItem.TemplateId)).Select(i => (ExpertDetailPageItem)i);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                frBodyContent.Item = contextItem;               
                litShowMore.Text = DictionaryConstants.ShowMoreLabel;
                var expertDetailItems = GetExpertDetailPages(contextItem.InnerItem);
              
              //  var expertLiveChatItems =GetExpertLivePages
                if (expertDetailItems.Any())
                {
                    rptListing.Visible = true;
                    rptListing.DataSource = expertDetailItems;
                    rptListing.DataBind();
                }
                //if (livePageItem.Any())
                //{
                //    rptEventCarousel.DataSource = livePageItem;
                //    rptEventCarousel.DataBind();
                //}
            }
        }

        protected void rptListing_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ExpertDetailPageItem detailItem = e.Item.DataItem as ExpertDetailPageItem;
                Panel rowSubParentPanel = e.FindControlAs<Panel>("rowSubParentPanel");
                Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
                FieldRenderer frHeading = e.FindControlAs<FieldRenderer>("frHeading");
                FieldRenderer frSubHeading = e.FindControlAs<FieldRenderer>("frSubHeading");
                Link scFollowTwittLink = e.FindControlAs<Link>("scFollowTwittLink");
                Link scFollowBlogLink = e.FindControlAs<Link>("scFollowBlogLink");
                Link scBioLink = e.FindControlAs<Link>("scBioLink");
                if (detailItem != null)
                {
                    FieldRenderer frParticipation = e.FindControlAs<FieldRenderer>("frParticipation");
                    if (frParticipation != null)
                    {
                        frParticipation.Item = detailItem;
                    }
                    if (rowSubParentPanel != null)
                    {
                        if ((e.Item.ItemIndex + 1) % 3 == 1)
                            rowSubParentPanel.CssClass = "col col-6 " + "offset-1";
                        else
                            rowSubParentPanel.CssClass = "col col-6 " + "offset-2";
                    }
                    if (scExpertImage != null)
                    {
                        scExpertImage.Item = detailItem;
                    }
                    if (frHeading != null)
                    {
                        frHeading.Item = detailItem;
                    }
                    if (frSubHeading != null)
                    {
                        frSubHeading.Item = detailItem;
                    }
                    if (scFollowTwittLink != null)
                    {
                        scFollowTwittLink.Item = detailItem;
                    }
                    if (scFollowBlogLink != null)
                    {
                        scFollowBlogLink.Item = detailItem;
                    }
                    if (scBioLink != null)
                    {
                        scBioLink.Item = detailItem;
                    }
                }
            }
        }

        //protected void rptEventCarousel_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.IsItem())
        //    {
        //        ExpertLivePageItem detailItem = e.Item.DataItem as ExpertLivePageItem;
        //        Sitecore.Web.UI.WebControls.Image scExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scExpertImage");
        //        FieldRenderer frHeading = e.FindControlAs<FieldRenderer>("frHeading");
        //        FieldRenderer frSubHeading = e.FindControlAs<FieldRenderer>("frSubHeading");
        //        Link scFollowTwittLink = e.FindControlAs<Link>("scFollowTwittLink");
        //        Link scFollowBlogLink = e.FindControlAs<Link>("scFollowBlogLink");
        //        Link scBioLink = e.FindControlAs<Link>("scBioLink");
        //        Literal litExpert = e.FindControlAs<Literal>("litExpert");
        //        Date scDate = e.FindControlAs<Date>("scDate");
        //        if (detailItem != null)
        //        {
        //            FieldRenderer frParticipation = e.FindControlAs<FieldRenderer>("frParticipation");                                 
        //            if (scExpertImage != null)
        //            {
        //                scExpertImage.Item = detailItem;
        //            }
        //            if (frHeading != null)
        //            {
        //                frHeading.Item = detailItem;
        //            }
        //            if (frSubHeading != null)
        //            {
        //                frSubHeading.Item = detailItem;
        //            }
        //            if (scFollowTwittLink != null)
        //            {
        //                scFollowTwittLink.Item = detailItem;
        //            }
        //            if (scFollowBlogLink != null)
        //            {
        //                scFollowBlogLink.Item = detailItem;
        //            }
        //            if (scBioLink != null)
        //            {
        //                scBioLink.Item = detailItem;
        //            }
        //        }
        //    }
        //}
    }
}