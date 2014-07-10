using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
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

            if (DataSource != null && TemplateManager.GetTemplate(DataSource).InheritsFrom(new ID(BehaviorToolsAdvicePageItem.TemplateId)))
            {
                BindData((BehaviorToolsAdvicePageItem)DataSource);
            }
        }

        private void BindData(Item thePage)
        {
            string BlogId = "";
            string BlogPostId = "";

            if (thePage.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                BlogId = new DefaultArticlePageItem(thePage).BlogId.Raw;
                BlogPostId = new DefaultArticlePageItem(thePage).BlogPostId.Raw;
            }
            else if (thePage.InheritsTemplate(BehaviorToolsAdvicePageItem.TemplateId))
            {
                BlogId = new BehaviorAdvicePageItem(thePage).BlogId.Raw;
                BlogPostId = new BehaviorAdvicePageItem(thePage).BlogPostId.Raw;
            }

            ActivityLog tempLog = new ActivityLog();
            //ContentId, ActivityValue
            int helpfulCount = tempLog.GetActivityCountByValue(new Guid(Sitecore.Context.Item.ID.ToString()), Constants.UserActivity_Values.FoundHelpful_True); 
            int commentCount = 0;

            if (!string.IsNullOrEmpty(BlogId) && !string.IsNullOrEmpty(BlogPostId))
            {
                commentCount = CommunityHelper.GetTotalComments(BlogId, BlogPostId);
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