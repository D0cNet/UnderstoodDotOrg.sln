using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class RecentQuestions : BaseSublayout
    {
        protected string CurrentItemUrl { get { return LinkManager.GetItemUrl(this.DataSource); } }
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkSeeAll.NavigateUrl = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{F349C92A-9781-4342-A05A-5A793630D7DB}"));
            List<Question> dataSource = CommunityHelper.GetQuestionsList("2", 10);
            foreach (Question q in dataSource)
            {
                if (q.Body.Length > 100)
                {
                    q.Body = CommunityHelper.FormatString100(q.Body) + "...";
                }
            }
            RecentQuestionsRepeater.DataSource = dataSource;
            RecentQuestionsRepeater.DataBind();
        }
    }
}