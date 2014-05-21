using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals
{
    public partial class CommunityQAQuestionAsked : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitQuestionButton_Click(object sender, EventArgs e)
        {
            string title = QuestionTitleTextBox.Text;
            string body = EnterQuestionTextBox.Text;
            string user = "";
            try
            {
                if (this.CurrentMember.ScreenName != String.Empty || this.CurrentMember.ScreenName != null)
                {
                    user = this.CurrentMember.ScreenName;
                }
            }
            catch
            {
                user = "admin";
            }
            string url = "/en/Community and Events/Q and A/Q and A Details.aspx" + CommunityHelper.CreateQuestion(title, body, user);
            Response.Redirect(url);

        }
    }
}