using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsBehaviorAdvice : BaseSublayout
    {
        private string SelectedGrade
        {
            get { return Request.QueryString[Constants.GRADE_QUERY_STRING] ?? String.Empty; }
        }

        private string SelectedChallenge
        {
            get { return Request.QueryString[Constants.CHALLENGE_QUERY_STRING] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();

            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            // TODO: no error treatment provided, add required field validators?
            if (!Page.IsValid)
            {
                return;
            }

            Response.Redirect(FormHelper.GetBehaviorResultsUrl(ddlChallenges.SelectedValue, ddlGrades.SelectedValue));
        }

        private void BindContent()
        {
            btnSubmit.Text = DictionaryConstants.GoButtonText;
        }

        private void BindControls()
        {
            ddlGrades.DataSource = FormHelper.GetGrades();
            ddlGrades.DataTextField = "Text";
            ddlGrades.DataValueField = "Value";
            ddlGrades.DataBind();
            ddlGrades.SelectedIndex = ddlGrades.GetSelectedIndex(SelectedGrade);         

            ddlChallenges.DataSource = FormHelper.GetChallenges();
            ddlChallenges.DataTextField = "Text";
            ddlChallenges.DataValueField = "Value";
            ddlChallenges.DataBind();
            ddlChallenges.SelectedIndex = ddlChallenges.GetSelectedIndex(SelectedChallenge);
        }
    }
}