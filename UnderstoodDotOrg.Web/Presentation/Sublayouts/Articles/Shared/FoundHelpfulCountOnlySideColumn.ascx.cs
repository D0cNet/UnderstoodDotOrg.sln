using Sitecore.Data;
using Sitecore.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class FoundHelpfulCountOnlySideColumn : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataSource != null && TemplateManager.GetTemplate(DataSource).InheritsFrom(new ID(DefaultArticlePageItem.TemplateId)))
            {
                BindData((DefaultArticlePageItem)DataSource);
            }
        }

        private void BindData(DefaultArticlePageItem page)
        {
            int helpfulCount = 0;

            if (!string.IsNullOrEmpty(page.ContentId.Raw))
            {
                helpfulCount = CommunityHelper.GetTotalLikes(page.ContentId.Raw);
            }

            lblHelpfulCount.Text = lblHelpfulCountMobile.Text = helpfulCount.ToString();

            ltlFoundThisHelpful.Text = ltlFoundThisHelpfulMobile.Text = DictionaryConstants.FoundThisHelpful;
        }
    }
}