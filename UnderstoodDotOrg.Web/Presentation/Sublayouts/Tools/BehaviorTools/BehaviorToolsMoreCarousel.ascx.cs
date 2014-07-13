using Sitecore.Data.Items;
using System;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsMoreCarousel : System.Web.UI.UserControl
    {
        private Item currentItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            currentItem = Sitecore.Context.Item;

            if (currentItem.InheritsTemplate(BehaviorToolsLandingPageItem.TemplateId)
                || currentItem.InheritsTemplate(BehaviorAdvicePageItem.TemplateId))
            {
                BindEvents();
                BindControls();
            }
            else
            {
                this.Visible = false;
            }
        }

        private void BindEvents()
        {
            rptArticles.ItemDataBound += rptArticles_ItemDataBound;
        }

        private void BindControls()
        {
            var articles = Enumerable.Empty<Item>();

            if (currentItem.InheritsTemplate(BehaviorToolsLandingPageItem.TemplateId))
            {
                articles = ((BehaviorToolsLandingPageItem)currentItem).CarouselRelatedArticlesItems.ListItems;
            }
            else if (currentItem.InheritsTemplate(BehaviorAdvicePageItem.TemplateId))
            {
                articles = ((BehaviorAdvicePageItem)currentItem).CarouselRelatedArticlesItems.ListItems;
            }

            articles = articles.Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId)
                                        || i.InheritsTemplate(BehaviorAdvicePageItem.TemplateId));

            if (articles.Any())
            {
                rptArticles.DataSource = articles.Take(Constants.BEHAVIOR_TOOLS_FEATURED_ARTICLES);
                rptArticles.DataBind();
            }
        }

        void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item item = (Item)e.Item.DataItem;

                BehaviorAdvicePageItem article = new BehaviorAdvicePageItem(item);

                if (article != null)
                {

                    System.Web.UI.WebControls.Image imgThumbnail = e.FindControlAs<System.Web.UI.WebControls.Image>("imgThumbnail");
                    imgThumbnail.ImageUrl = article.GetArticleThumbnailUrl(230, 129);

                    HyperLink hlArticleLink = e.FindControlAs<HyperLink>("hlArticleLink");
                    hlArticleLink.NavigateUrl = article.GetUrl();

                    Literal litArticleTitle = e.FindControlAs<Literal>("litArticleTitle");
                    litArticleTitle.Text = article.InnerItem.Fields["Navigation Title"].ToString();
                }
            }
        }
    }
}