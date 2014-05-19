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
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool
{
    public partial class DecisionToolResultsPage : BaseSublayout<DecisionToolResultsPageItem>
    {
        protected DecisionQuestionPageItem QuestionPage { get; set; }
        protected List<DecisionAnswerItem> Answers { get; set; }
        protected DecisionToolLandingPageItem LandingPage { get; set; }
        protected string IndicatedAnswerAbstract { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LandingPage = Model.GetDecisionToolLandingPage();
            var questionPageId = Request.QueryString[Constants.QueryStrings.DecisionTool.QuestionId];
            if (!string.IsNullOrEmpty(questionPageId) && (QuestionPage = Sitecore.Context.Database.GetItem(questionPageId)) != null)
            {
                Answers = QuestionPage.GetAnswers().ToList();
                var rawIndAnswerHistory = Request.QueryString[Constants.QueryStrings.DecisionTool.IndicationAnswerHistory];
                var indAnswerHistory = rawIndAnswerHistory != null ? rawIndAnswerHistory.Split(',') : new string[] { };

                var answerModels = Answers
                    .Select((a, i) => new
                    {
                        IndicatorCount = indAnswerHistory.Count(iah => iah == i.ToString()),
                        AnswerText = a.DisplayText.Rendered,
                        Abstract = a.Abstract.Rendered
                    })
                    .OrderByDescending(am => am.IndicatorCount);
                rptrAnswers.DataSource = answerModels;
                rptrAnswers.DataBind();

                IndicatedAnswerAbstract = string.Empty;
                var maximumIndications = answerModels != null ? answerModels.First().IndicatorCount : 0;
                if (maximumIndications > 0)
                {
                    IndicatedAnswerAbstract = string.Join(
                        @"<br/>", 
                        answerModels
                            .TakeWhile(am => am.IndicatorCount == maximumIndications)
                            .Select(am => am.Abstract));
                }

                var questions = LandingPage.GetDecisionQuestionCategories()
                    .SelectMany(category => category.GetDecisionQuestions())
                    .OrderBy(question => Guid.NewGuid())
                    .Take(3);

                rptrQuestions.DataSource = questions;
                rptrQuestions.DataBind();
            }
            else
            {
                Response.Redirect(LandingPage.GetUrl());
            }
        }

        protected void StartOver_Click(object sender, EventArgs e)
        {
            Response.Redirect(QuestionPage.GetStartUrl());
        }
    }
}