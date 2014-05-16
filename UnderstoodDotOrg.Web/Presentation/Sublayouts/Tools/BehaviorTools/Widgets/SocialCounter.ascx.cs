using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets
{
    public partial class SocialCounter : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            BehaviorAdvicePageItem item = Sitecore.Context.Item;

            litCommentsCount.Text = CommunityHelper.GetTotalComments(item.BlogId.Raw, item.BlogPostId.Raw).ToString();
            litHelpfulCount.Text = CommunityHelper.GetTotalLikes(item.ContentId.Raw).ToString();
        }
    }
}