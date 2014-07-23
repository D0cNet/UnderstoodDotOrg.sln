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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Tools.BehaviorTool;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsBehaviorAdvice : BaseSublayout
    {
        protected string AjaxPath
        {
            get { return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.BehaviorSuggestionEndpoint); }
        }

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

        private BehaviorSearchCalloutItem Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.DataSource != null)
            {
                Model = new BehaviorSearchCalloutItem(this.DataSource);
            }

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

        #region Event Handlers

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
            txtSuggestion.Attributes.Add("placeholder", DictionaryConstants.EnterSuggestionWatermark);
            
            if (Model != null)
            {
                frSuggestionTitle.Item = frSuggestionInstructions.Item =
                        frSuccessTitle.Item = frSuccessText.Item = frSuccessSignupLink.Item =
                        frCalloutTitle.Item = frCalloutLinkText.Item = Model.InnerItem;

                rfvChallenges.Text = Model.CalloutChallengeRequiredFieldMessage.Text;
                rfvGrades.Text = Model.CalloutGradeRequiredFieldMessage.Text;
                litSuggestError.Text = Model.SuggestionRequiredFieldMessage.Text;

                hlSignUp.NavigateUrl = SignUpPageItem.GetSignUpPage().GetUrl();
            }
        }

        private void BindControls()
        {
            ddlChallenges.DataSource = FormHelper.GetChallenges(DictionaryConstants.SelectChallengeLabel);
            ddlChallenges.DataTextField = "Text";
            ddlChallenges.DataValueField = "Value";
            ddlChallenges.DataBind();
            ddlChallenges.SelectedIndex = ddlChallenges.GetSelectedIndex(SelectedChallenge);

            BehaviorToolsLandingPageItem landingPage = Sitecore.Context.Database.GetItem(Constants.BehaviorToolLandingArticlesContainer);
            if (landingPage != null)
            {
                ddlGrades.DataSource = landingPage.GetGradeChoices();
                ddlGrades.DataTextField = "Text";
                ddlGrades.DataValueField = "Value";
                ddlGrades.DataBind();
                ddlGrades.SelectedIndex = ddlGrades.GetSelectedIndex(SelectedGrade);
            }
        }
    }
}