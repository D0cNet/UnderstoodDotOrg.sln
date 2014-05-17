using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components;
using System.Web.UI.HtmlControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool
{
    public partial class DecisionToolQuestionPage : BaseSublayout<DecisionQuestionPageItem>
    {
        protected int? CurrentIndicationQuestionIndex { get; set; }
        protected int IndicationQuestionsCount { get; set; }
        protected DecisionIndicationQuestionItem CurrentIndicationQuestion { get; set; }
        protected List<DecisionAnswerItem> Answers { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var rawCurrentIndicationQuestionIndex = Request.QueryString["q"];
            if (!string.IsNullOrEmpty(rawCurrentIndicationQuestionIndex))
            {
                List<DecisionIndicationQuestionItem> indQuestions;
                int currentIndQuestionIndex;

                //if there are more questions to ask
                if (int.TryParse(rawCurrentIndicationQuestionIndex, out currentIndQuestionIndex) && 
                    (IndicationQuestionsCount = (indQuestions = Model.GetIndicationQuestions().ToList()).Count) > currentIndQuestionIndex)
                {
                    CurrentIndicationQuestionIndex = currentIndQuestionIndex;
                    CurrentIndicationQuestion = indQuestions.ElementAt(CurrentIndicationQuestionIndex.Value);

                    Answers = Model.GetAnswers().ToList();
                    var indAnswers = CurrentIndicationQuestion.GetIndicationAnswers().ToList();

                    if (indAnswers.Count <= 2)
                    {
                        divAnswerRadios.Visible = false;

                        InitializeAnswerButton(btnIndicationAnswer1, indAnswers.ElementAt(0));
                        InitializeAnswerButton(btnIndicationAnswer2, indAnswers.ElementAt(1));
                    }
                    else
                    {
                        divAnswerButtons.Visible = false;

                        rptrAnswerRadios.DataSource = indAnswers;
                        rptrAnswerRadios.DataBind();
                    }

                    rptrIndicationAnswers.DataSource = indAnswers;
                    rptrIndicationAnswers.DataBind();
                }
                else
                {
                    Response.Redirect(Sitecore.Context.Item.Parent.Parent.GetUrl());
                }
            }
            else
            {
                Response.Redirect(Sitecore.Context.Item.Parent.Parent.GetUrl());
            }
        }

        protected void InitializeAnswerButton(HtmlButton button, DecisionIndicationAnswerItem indAnswer)
        {
            button.InnerHtml = indAnswer.DisplayText.Rendered;
            button.Attributes.Add("data-answer-index", GetAnswerIndex(indAnswer).ToString());
            button.Attributes.Add("data-indication-answer-id", "a" + indAnswer.ID.Guid.ToString());
        }

        protected int GetAnswerIndex(DecisionIndicationAnswerItem indAnswer)
        {
            return Answers.Select(a => a.ID).ToList().IndexOf(indAnswer.Indicator.Item.ID);
        }

        protected void SubmitAndProceed_Click(object sender, EventArgs e)
        {
            if (CurrentIndicationQuestionIndex.HasValue)
            {
                var indQuestionHistory = Request.QueryString["qh"] ?? string.Empty;
                var indAnswerHistory = Request.QueryString["ah"] ?? string.Empty;
                if (!string.IsNullOrEmpty(indQuestionHistory) && !string.IsNullOrEmpty(indAnswerHistory))
                {
                        indQuestionHistory += ",";
                        indAnswerHistory += ",";
                }

                indQuestionHistory += CurrentIndicationQuestionIndex;
                indAnswerHistory += hfAnswerIndex.Value;

                var qs = "?qh=" + indQuestionHistory + "&ah=" + indAnswerHistory + "&q=" + (CurrentIndicationQuestionIndex + 1);
                Response.Redirect(Model.GetUrl() + qs);
            }
            else
            {
                Response.Redirect(Sitecore.Context.Item.Parent.Parent.GetUrl());
            }
        }
    }
}