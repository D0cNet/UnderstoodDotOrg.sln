using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class RecentQuestions : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Question> dataSource = CommunityHelper.GetQuestionsList("2");
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