using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals
{
    public partial class CommunityQAQuestionAsked : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitQuestionButton_Click(object sender, EventArgs e)
        {
            string title = QuestionTitleTextBox.Text;
            string body = EnterQuestionTextBox.Text;
            string queryString = CommunityHelper.CreateQuestion(title, body);
        }
    }
}