namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA
{
    using System;
    using System.Collections.Generic;
    using UnderstoodDotOrg.Domain.TelligentCommunity;

    public partial class FeaturedQuestions : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            List<Question> dataSource = CommunityHelper.GetQuestionsList("2");
            questionsRepeater.DataSource = dataSource;
            questionsRepeater.DataBind();
        }
    }
}