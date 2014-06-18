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
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class FoundHelpfulCountOnly : BaseSublayout
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
            ActivityLog tempLog = new ActivityLog();
            //ContentId, ActivityValue
            int helpfulCount = tempLog.GetActivityCountByValue(new Guid(Sitecore.Context.Item.ID.ToString()), Constants.UserActivity_Values.FoundHelpful_True);

            lblHelpfulCount.Text = lblHelpfulCountMobile.Text = helpfulCount.ToString();

            ltlFoundThisHelpful.Text = ltlFoundThisHelpfulMobile.Text = DictionaryConstants.FoundThisHelpful;
        }
    }
}