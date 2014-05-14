using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsAdviceVideoPage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
        }

        // TODO - Move related articles into sublayout
        private void BindEvents()
        {
            rptRelatedArticles.ItemDataBound += rptRelatedArticles_ItemDataBound;
        }

        void rptRelatedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item item = (Item)e.Item.DataItem;
                HyperLink hlArticleLink = e.FindControlAs<HyperLink>("hlArticleLink");
                hlArticleLink.NavigateUrl = item.GetUrl();
                BehaviorAdvicePageItem behaviorItem = item;
                hlArticleLink.Text = !String.IsNullOrEmpty(behaviorItem.TipTitle) ? behaviorItem.TipTitle : item.Name;
            }
        }

        private void BindContent()
        {
            BehaviorToolsAdviceVideoPageItem pageItem = new BehaviorToolsAdviceVideoPageItem(Sitecore.Context.Item);
            var articles = pageItem.BehaviorAdvicePage.RelatedArticlesItems.ListItems;
            if (articles.Any())
            {
                rptRelatedArticles.DataSource = articles;
                rptRelatedArticles.DataBind();
            }
        }
    }
}