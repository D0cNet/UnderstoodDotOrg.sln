using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class SuggestArticlePageCarousal : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
        }

        private void BindEvents()
        {
            rptArticles.ItemDataBound += rptArticles_ItemDataBound;
        }

        private void BindContent()
        {
            DefaultArticlePageItem item = Sitecore.Context.Item;
            if (!item.InnerItem.InheritsTemplate(DefaultArticlePageItem.TemplateId)
                || item.HideMoreLikeThisModule.Checked)
            {
                this.Visible = false;
                return;
            }

            var articles = item.GetMoreLikeThisArticles();
            if (articles.Any())
            {
                rptArticles.DataSource = articles;
                rptArticles.DataBind();
            }
        }

        void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem item = (DefaultArticlePageItem)e.Item.DataItem;

                HyperLink hlArticleDetail = e.FindControlAs<HyperLink>("hlArticleDetail");
                hlArticleDetail.NavigateUrl = item.GetUrl();

                System.Web.UI.WebControls.Image imgThumbnail = e.FindControlAs<System.Web.UI.WebControls.Image>("imgThumbnail");
                imgThumbnail.ImageUrl = item.GetArticleThumbnailUrl(230, 129);

                FieldRenderer frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                frPageTitle.Item = item;
            }
        }
    }
}
