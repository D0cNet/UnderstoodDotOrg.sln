using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Section 
{
    public partial class SectionListing : BaseSublayout<SectionLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            BindControls();
        }

        private void BindControls()
        {
            var topicPages = Model.GetTopicLandingPageItem();
            if (topicPages != null && topicPages.Any())
            {
                rptTopicLandingItems.DataSource = topicPages;
                rptTopicLandingItems.DataBind();
            }
        }

        protected void rptTopicLanding_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.IsItem()) 
            {
                TopicLandingPageItem topic = e.Item.DataItem as TopicLandingPageItem;
                if (topic != null) 
                {
                    HyperLink hlTopicLink = e.FindControlAs<HyperLink>("hlTopicLink");
                    Repeater rptTopicListItems = e.FindControlAs<Repeater>("rptTopicListItems");

                    hlTopicLink.Text = topic.ContentPage.PageTitle;
                    hlTopicLink.NavigateUrl = topic.InnerItem.GetUrl();

                    IEnumerable<DefaultArticlePageItem> topicArticles = Enumerable.Empty<DefaultArticlePageItem>();
                    var curated = topic.CuratedFeaturedcontent.ListItems;

                    // Check curated first, fallback to most recent articles
                    if (curated.Any())
                    {
                        topicArticles = curated.Take(3).Select(x => new DefaultArticlePageItem(x));
                    }
                    else
                    {
                        var recent = SearchHelper.GetMostRecentArticlesWithin(topic.ID, 3);
                        if (recent.Any())
                        {
                            topicArticles = from r in recent
                                            let i = r.GetItem()
                                            where i != null
                                            select new DefaultArticlePageItem(i);
                        }
                    }

                    if (topicArticles.Any())
                    {
                        rptTopicListItems.DataSource = topicArticles;
                        rptTopicListItems.DataBind();
                    }
                }
            }
        }

        protected void rptTopicListItems_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.IsItem()) 
            {
                DefaultArticlePageItem item = (DefaultArticlePageItem)e.Item.DataItem;

                HyperLink hlTopicTitle = e.FindControlAs<HyperLink>("hlTopicTitle");
                hlTopicTitle.NavigateUrl = item.GetUrl();
                hlTopicTitle.Text = item.ContentPage.PageTitle.Rendered;

                // Handle first image
                if (e.Item.ItemIndex == 0)
                {
                    Image imgThumbnail = e.FindControlAs<Image>("imgThumbnail");
                    imgThumbnail.ImageUrl = item.GetArticleFeaturedThumbnailUrl(190, 107);
                    imgThumbnail.Visible = !String.IsNullOrEmpty(imgThumbnail.ImageUrl);
                }
            }
        }

    }
}