using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics 
{
    public partial class SubTopicArticleListing : System.Web.UI.UserControl 
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            rptArticles.ItemDataBound += rptArticles_ItemDataBound;
        }

        void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem item = (DefaultArticlePageItem)e.Item.DataItem;

                HyperLink hlThumbnail = e.FindControlAs<HyperLink>("hlThumbnail");
                HyperLink hlTitle = e.FindControlAs<HyperLink>("hlTitle");
                Image imgThumbnail = e.FindControlAs<Image>("imgThumbnail");

                hlThumbnail.NavigateUrl = hlTitle.NavigateUrl = item.GetUrl();
                string imgSource = item.GetArticleThumbnailUrl(190, 107);
                imgThumbnail.ImageUrl = imgSource;
                imgThumbnail.Visible = !(String.IsNullOrEmpty(imgSource));
            }
        }

        private void BindControls()
        {
            SubtopicLandingPageItem item = Sitecore.Context.Item;
            IEnumerable<DefaultArticlePageItem> articles = item.GetArticles();
            if (articles.Any())
            {
                rptArticles.DataSource = articles;
                rptArticles.DataBind();
            }
            else
            {
                // TODO: show error?
            }
        }
    }
}