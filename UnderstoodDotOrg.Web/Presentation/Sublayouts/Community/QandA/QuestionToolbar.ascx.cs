namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
    using UnderstoodDotOrg.Domain.TelligentCommunity;
    using UnderstoodDotOrg.Framework.UI;

    public partial class QuestionToolbar : BaseSublayout
    {
        protected override void OnInit(EventArgs e)
        {
            litAsk.Text = UnderstoodDotOrg.Common.DictionaryConstants.AskLabel;
            litAnswer.Text = UnderstoodDotOrg.Common.DictionaryConstants.AnswerLabel;
            litDiscover.Text = UnderstoodDotOrg.Common.DictionaryConstants.DiscoverLabel;

            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
        }
    }
}