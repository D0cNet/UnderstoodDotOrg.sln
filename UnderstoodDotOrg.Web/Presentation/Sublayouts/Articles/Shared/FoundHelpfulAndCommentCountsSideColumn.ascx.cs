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
    public partial class FoundHelpfulAndCommentCountsSideColumn : BaseSublayout
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
            int helpfulCount = tempLog.GetActivityCountByValue(new Guid(Sitecore.Context.Item.ID.ToString()), Constants.UserActivity_Values.FoundHelpful); 
            int commentCount = 0;

            if (!string.IsNullOrEmpty(page.BlogId.Raw) && !string.IsNullOrEmpty(page.BlogPostId.Raw))
            {
                commentCount = CommunityHelper.GetTotalComments(page.BlogId.Raw, page.BlogPostId.Raw);
            }

            lblHelpfulCount.Text = lblHelpfulCountMobile.Text = helpfulCount.ToString();
            lblCommentCount.Text = lblCommentCountMobile.Text = commentCount.ToString();

            ltlFoundThisHelpful.Text = ltlFoundThisHelpfulMobile.Text = DictionaryConstants.FoundThisHelpful;

            string commentLabel = DictionaryConstants.PluralCommentLabel;
            if (commentCount == 1)
            {
                commentLabel = DictionaryConstants.SingleCommentLabel;
            }

            ltlComments.Text = ltlCommentsMobile.Text = commentLabel;
        }
    }
}