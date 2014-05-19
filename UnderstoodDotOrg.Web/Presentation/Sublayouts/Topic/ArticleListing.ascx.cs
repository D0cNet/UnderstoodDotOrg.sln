using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic 
{
    public partial class ArticleListing : BaseSublayout<TopicLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            BindEvents();
            BindControls();
        }

        private void BindEvents()
        {
            lvArticles.ItemDataBound += lvArticles_ItemDataBound;
        }

        private void BindControls() 
        {
            bool hasMoreResults = false;
            IEnumerable<DefaultArticlePageItem> topicArticles = Model.GetTopicArticles(1, out hasMoreResults);
            pnlMoreArticle.Visible = hasMoreResults;

            lvArticles.DataSource = topicArticles;
            lvArticles.DataBind();
        }

        void lvArticles_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DefaultArticlePageItem article = (DefaultArticlePageItem)e.Item.DataItem;

                HyperLink hlThumbnail = (HyperLink)e.Item.FindControl("hlThumbnail");
                HyperLink hlTitle = (HyperLink)e.Item.FindControl("hlTitle");

                hlThumbnail.NavigateUrl = hlTitle.NavigateUrl = article.GetUrl();
                hlTitle.Text = article.ContentPage.PageTitle;

                Image imgThumbnail = (Image)e.Item.FindControl("imgThumbnail");
                imgThumbnail.ImageUrl = article.GetArticleThumbnailUrl(190, 107);
                imgThumbnail.Visible = !String.IsNullOrEmpty(imgThumbnail.ImageUrl);
            }
        }
    }
}