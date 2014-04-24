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
        protected string Close
        {
            get { return DictionaryConstants.CloseButtonText; }
        }

        protected string CloseWindow
        {
            get { return DictionaryConstants.CloseWindowButtonText; }
        }

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
            btnSubmitSuggestion.Click += btnSubmitSuggestion_Click;
            cvSuggestion.ServerValidate += cvSuggestion_ServerValidate;
        }

        #region Event Handlers

        void cvSuggestion_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool hasSuggestion = !String.IsNullOrEmpty(txtSuggestion.Text.Trim());
            pnlSuggestError.Visible = !hasSuggestion;
            litSuggestError.Text = this.DataSource.Fields["Suggestion Required Field Message"].Value;
            args.IsValid = hasSuggestion;
        }

        void btnSubmitSuggestion_Click(object sender, EventArgs e)
        {
            Page.Validate("Suggestion");
            if (Page.IsValid) 
            {
                // TODO: send email
                // Field for to address - "Suggestion E-mail Address"
                // Field for failed email error - "Suggestion Submit Failed Message"

                pnlEntryForm.Visible = false;
                pnlSuccessForm.Visible = true;
            }
            
            pnlSuggest.Update();
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            Response.Redirect(FormHelper.GetBehaviorResultsUrl(ddlChallenges.SelectedValue, ddlGrades.SelectedValue));
        }

        #endregion

        private void BindContent()
        {
            btnSubmit.Text = DictionaryConstants.GoButtonText;
            btnSubmitSuggestion.Text = DictionaryConstants.SendSuggestionButtonText;
            txtSuggestion.Attributes.Add("placeholder", DictionaryConstants.EnterSuggestionWatermark);

            frSuggestionTitle.Item = frSuggestionInstructions.Item = 
                    frSuccessTitle.Item = frSuccessText.Item = frSuccessSignupLink.Item = 
                    frCalloutTitle.Item = frCalloutLinkText.Item = this.DataSource;
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