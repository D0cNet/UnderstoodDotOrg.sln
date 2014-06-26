using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Page_Topic : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            if (Sitecore.Context.Item.InheritsTemplate(BehaviorAdvicePageItem.TemplateId)
                    || Sitecore.Context.Item.TemplateID == Sitecore.Data.ID.Parse(BehaviorToolsResultsPageItem.TemplateId))
            {
                PopulateBehaviorInfo();
            }
            else
            {
                PopulateArticleInfo();
            }
        }

        private void PopulateArticleInfo()
        {
            phAuthorInfo.Visible = false;

            if (Sitecore.Context.Item.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                DefaultArticlePageItem article = Sitecore.Context.Item;

                if (article.AuthorName.Item != null)
                {
                    frAuthorName.Item = article.AuthorName.Item;
                    hlAuthorName.NavigateUrl = article.AuthorName.Item.GetUrl();
                    hlAuthorName.Text = article.AuthorName.Item.Name;
                    phAuthorInfo.Visible = true;
                }
            }

            //UNAO-434 - refactored to recursively go up the tree until it finds something to navigate back to
            this.SetBreadcrumb(Sitecore.Context.Item.Parent);
        }

        private void SetBreadcrumb(BasePageNEWItem item)
        {
            if (!string.IsNullOrEmpty(item.NavigationTitle.Text) )
            {
                frSectionTitle.Item = item;
                hlSectionTitle.NavigateUrl = item.GetUrl();

                return;
            }
            else
            {
                this.SetBreadcrumb(item.InnerItem.Parent);
            }
        }

        private void PopulateBehaviorInfo()
        {
            phBehaviorArticleInfo.Visible = true;
            hlSectionTitle.Visible = false;

            frTitle.FieldName = "Hero Heading";

            Item dataSource = null;

            // TEMP: look up parent item until DataSource is updated
            if (this.DataSource != null && this.DataSource != Sitecore.Context.Item)
            {
                dataSource = this.DataSource;
            }
            else
            {
                Item parent = Sitecore.Context.Item.Parent;
                while (parent != null)
                {
                    if (parent.TemplateID == Sitecore.Data.ID.Parse(BehaviorToolsLandingPageItem.TemplateId))
                    {
                        dataSource = ((BehaviorToolsLandingPageItem)parent).HeroImageDatasource.Item;
                        break;
                    }
                    parent = parent.Parent;
                }
            }

            if (dataSource != null)
            {
                frTitle.Item = frBehaviorSubtitle.Item = dataSource;
            }
        }
    }
}