using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ArticleListings
{
    public partial class SubtopicLandingArticles : System.Web.UI.UserControl
    {
        public IEnumerable<DefaultArticlePageItem> Articles;

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

                Sublayout sbArticleEntry = e.FindControlAs<Sublayout>("sbArticleEntry");
                sbArticleEntry.DataSource = item.ID.ToString();
            }
        }

        private void BindControls()
        {
            if (Articles != null && Articles.Any())
            {
                rptArticles.DataSource = Articles;
                rptArticles.DataBind();
            }
        }
    }
}