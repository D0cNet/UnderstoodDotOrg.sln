using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ArticleListings
{
    public partial class TopicLandingArticles : System.Web.UI.UserControl
    {
        public IEnumerable<DefaultArticlePageItem> Articles { get; set; }

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
            if (Articles != null && Articles.Any())
            {
                lvArticles.DataSource = Articles;
                lvArticles.DataBind();
            }
        }

        void lvArticles_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                DefaultArticlePageItem article = (DefaultArticlePageItem)e.Item.DataItem;

                Sitecore.Web.UI.WebControls.Sublayout sbArticleEntry = (Sitecore.Web.UI.WebControls.Sublayout)e.Item.FindControl("sbArticleEntry");
                sbArticleEntry.DataSource = article.ID.ToString();
            }
        }
    }
}