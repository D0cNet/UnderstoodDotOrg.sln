using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Understood.Helper;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsBehaviorAdvice : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindControls()
        {
            ddlGrades.DataSource = FormHelper.GetGrades();
            ddlGrades.DataBind();

            ddlChallenges.DataSource = FormHelper.GetChallenges();
            ddlChallenges.DataBind();
        }
    }
}