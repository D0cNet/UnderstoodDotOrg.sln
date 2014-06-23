using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets
{
    public partial class SocialCounter : BaseSublayout<BehaviorToolsAdvicePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            BehaviorAdvicePageItem item = Sitecore.Context.Item;
            ActivityLog log = new ActivityLog();

            litCommentsCount.Text = CommunityHelper.GetTotalComments(item.BlogId.Raw, item.BlogPostId.Raw).ToString();
            
            Guid contentId;
            int helpfulCount = 0;
            if (Guid.TryParse(Model.BehaviorAdvicePage.ContentId.Raw, out contentId))
            {
                helpfulCount = log.GetActivityCountByValue(contentId, Constants.UserActivity_Values.FoundHelpful_True);
            }
            litHelpfulCount.Text = helpfulCount.ToString();
        }
    }
}