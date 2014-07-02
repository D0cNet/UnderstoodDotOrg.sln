using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Folders.KnowledgeQuizArticlePage;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.KnowledgeQuizArticlePage;
using System.Web.UI.HtmlControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Folders.AssessmentQuizFolder;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.PageResources.Items.AssessmentQuizArticlePage;
using Sitecore.Web.UI.WebControls;
using Newtonsoft.Json;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Understood.Quiz;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Assessment_Quiz : BaseSublayout
    {
        private Item PageResources = Sitecore.Context.Item.Children.FirstOrDefault();
        private int PageNumber = 1;
        private List<Item> Pages;

        public class QuestionAnswer {
            public Item Question;
            public string Answer;

            public QuestionAnswer(Item Question, string Answer) {
                this.Question = Question;
                this.Answer = Answer;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pageNum"] != null)
                PageNumber = (int)Session["pageNum"];

            if (PageResources != null)
            {
                Item questionsFolder = PageResources.Children.ToList().Where(i => i.IsOfType(AssessmentQuizQuestionsFolderItem.TemplateId)).FirstOrDefault();
                if (questionsFolder != null)
                {
                    btnNextPage.CausesValidation = true;
                    btnNextPage.ValidationGroup = "vlgPageQuestions";
                    btnPrevPage.CausesValidation = true;
                    btnPrevPage.ValidationGroup = "vlgPageQuestions";
                    btnShowResults.CausesValidation = true;
                    btnShowResults.ValidationGroup = "vlgPageQuestions";

                    Pages = questionsFolder.Children.ToList();
                    List<Item> pageQuestions = Pages[PageNumber - 1].Children.ToList();
                    lblPageCounter.Text = "Page " + PageNumber.ToString() + " of " + Pages.Count.ToString();

                    if (!(Pages.Count > PageNumber))
                    {
                        btnNextPage.Visible = false;
                        btnShowResults.Visible = true;
                    }

                    if (Session["AnsweredQuestions"] == null)
                        SetUpQuestionsTracker();

                    if (Session["done"] != null && (string)Session["done"] == "true")
                    {
                        FinishQuiz();
                    }
                    else
                    {
                        if (PageNumber != 1)
                        {
                            btnPrevPage.Visible = true;
                            frQuizIntro.Visible = false;
                        }
                        rptPageQuestions.DataSource = pageQuestions;
                        rptPageQuestions.DataBind();
                    }
                }
            }
        }

        private void FinishQuiz()
        {
            btnTakeQuizAgain.Visible = true;
            btnShowResults.Visible = false;
            lblPageCounter.Visible = false;
            btnPrevPage.Visible = false;

            frResultHeadline.Visible = true;
            frQuizIntro.Visible = false;

            Item resultsFolder = PageResources.Children.Where(i => i.IsOfType(AssessmentQuizResultsFolderItem.TemplateId)).FirstOrDefault();

            int score = CalculateScore();

            foreach (Item i in resultsFolder.Children)
            {
                AssessmentQuizResultItem range = (AssessmentQuizResultItem)i;
                if (score >= range.MinimumValue)
                {
                    if (range.MaximumValue.ToString().IsNullOrEmpty() || (score <= range.MaximumValue))
                    {
                        frEndExplanation.Visible = true;
                        frEndExplanation.Item = i;
                        break;
                    }
                }
            }

            if (IsUserLoggedIn)
                SaveQuiz();

            Reset();
        }

        private void SaveQuiz()
        {
            Guid thisGuid = Sitecore.Context.Item.ID.ToGuid();
            Quiz quiz = new Quiz();
            quiz.QuizID = thisGuid;
            Dictionary<string, QuestionAnswer> AnswerTracker = (Dictionary<string, QuestionAnswer>)Session["AnsweredQuestions"];

            foreach (KeyValuePair<string, QuestionAnswer> question in AnswerTracker)
            {
                quiz.MemberAnswers.Add(new QuizItem(new Guid(question.Key), question.Value.Answer));
            }

            try
            {
                MembershipManager mgr = new MembershipManager();
                mgr.QuizResults_SaveToDb(CurrentMember.MemberId, quiz);
            }
            catch
            { 
            
            }
        }

        private int CalculateScore()
        {
            Dictionary<string, QuestionAnswer> AnswerTracker = (Dictionary<string, QuestionAnswer>)Session["AnsweredQuestions"];
            int totalPoints = 0;

            foreach (KeyValuePair<string, QuestionAnswer> question in AnswerTracker)
            {
                Item genericQuestion = question.Value.Question;
                if (question.Value.Question.IsOfType(AssessmentTrueFalseItem.TemplateId))
                {
                    AssessmentTrueFalseItem contextQuestion = (AssessmentTrueFalseItem)genericQuestion;
                    if (question.Value.Answer == "True")
                    {
                        totalPoints += contextQuestion.TrueValue;
                    }
                    else if (question.Value.Answer == "True")
                    {
                        totalPoints += contextQuestion.FalseValue;
                    }
                }
                else if (question.Value.Question.IsOfType(AssessmentMultipleChoiceItem.TemplateId))
                {
                    AssessmentMultipleChoiceItem contextQuestion = (AssessmentMultipleChoiceItem)genericQuestion;
                    foreach (Item i in contextQuestion.InnerItem.Children)
                    {
                        AssessmentMultipleChoiceAnswerItem answerItem = (AssessmentMultipleChoiceAnswerItem)i;
                        if(answerItem.Answer == question.Value.Answer)
                            totalPoints += answerItem.Value;
                    }
                }
            }

            return totalPoints;
        }

        private void SetUpQuestionsTracker()
        {
            Quiz savedQuiz = null;
            if (CurrentMember != null)
            {
                try
                {
                    MembershipManager mgr = new MembershipManager();
                    CurrentMember = mgr.QuizResults_FillMember(CurrentMember);
                    savedQuiz = CurrentMember.CompletedQuizes.Where(i => i.QuizID == Sitecore.Context.Item.ID.ToGuid()).FirstOrDefault<Quiz>();
                }
                catch
                { 
                       
                }
            }

            Dictionary<string, QuestionAnswer>  answeredQuestions = new Dictionary<string, QuestionAnswer>();

            foreach (Item i in Pages)
            {
                foreach (Item j in i.Children)
                {
                    QuizItem potentialPreviousAnswer = null;

                    if (savedQuiz != null)
                        potentialPreviousAnswer = savedQuiz.MemberAnswers.Where(k => k.QuestionId == j.ID.ToGuid()).FirstOrDefault();

                    if (j.IsOfType(AssessmentTrueFalseItem.TemplateId) || j.IsOfType(AssessmentMultipleChoiceItem.TemplateId))
                    {
                        string answerValue = "";
                        if (potentialPreviousAnswer != null)
                            answerValue = potentialPreviousAnswer.AnswerValue;

                        answeredQuestions.Add(j.ID.ToString(), new QuestionAnswer(j, answerValue));
                    }
                }
            }

            Session["AnsweredQuestions"] = answeredQuestions;
        }

        public void Reset()
        {
            Session["done"] = null;
            Session["pageNum"] = 1;
            Session["AnsweredQuestions"] = null;
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            Session["pageNum"] = (PageNumber + 1);

            UpdateAnswerTracker();

            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        protected void btnPrevPage_Click(object sender, EventArgs e)
        {
            Session["pageNum"] = (PageNumber - 1);

            UpdateAnswerTracker();

            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        private void UpdateAnswerTracker()
        {
            string JSON = hfKeyValuePairs.Value;
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(JSON);
            Dictionary<string, QuestionAnswer> AnswerTracker = (Dictionary<string, QuestionAnswer>)Session["AnsweredQuestions"];

            if (values != null)
            {
                foreach (KeyValuePair<string, string> entry in values)
                {
                    if (AnswerTracker.ContainsKey(entry.Key))
                    {
                        AnswerTracker[entry.Key] = new QuestionAnswer(AnswerTracker[entry.Key].Question, entry.Value);
                    }
                }
            }
        }

        protected void btnTakeQuizAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            UpdateAnswerTracker();
            Session["done"] = "true";
            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        protected void rptPageQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                FieldRenderer frQuestionTitle = e.FindControlAs<FieldRenderer>("frQuestionTitle");
                Panel pnlQuestion = e.FindControlAs<Panel>("pnlQuestion");
                Panel pnlTrueFalse = e.FindControlAs<Panel>("pnlTrueFalse");
                Panel pnlRadioQuestion = e.FindControlAs<Panel>("pnlRadioQuestion");
                Panel pnlDropDown = e.FindControlAs<Panel>("pnlDropDown");
                HtmlButton btnTrue = e.FindControlAs<HtmlButton>("btnTrue");
                HtmlButton btnFalse = e.FindControlAs<HtmlButton>("btnFalse");
                DropDownList ddlQuestion = e.FindControlAs<DropDownList>("ddlQuestion");
                RadioButtonList rblAnswer = e.FindControlAs<RadioButtonList>("rblAnswer");
                RadioButtonList rblHiddenButtonList = e.FindControlAs<RadioButtonList>("rblHiddenButtonList");

                foreach (ListItem l in rblHiddenButtonList.Items)
                {
                    l.Attributes.Add("hidden", "");
                }

                Dictionary<string, QuestionAnswer> AnswerTracker = new Dictionary<string, QuestionAnswer>();

                if (Session["AnsweredQuestions"] != null)
                    AnswerTracker = (Dictionary<string, QuestionAnswer>)Session["AnsweredQuestions"];

                Item question = (Item)e.Item.DataItem;

                bool alreadyAnswered = AnswerTracker.ContainsKey(question.ID.ToString()) && AnswerTracker[question.ID.ToString()].Answer != "";

                if(frQuestionTitle != null)
                    frQuestionTitle.Item = question;

                if (question.IsOfType(AssessmentTrueFalseItem.TemplateId))
                {
                    btnTrue.Attributes.Add("data-id", question.ID.ToString());
                    btnFalse.Attributes.Add("data-id", question.ID.ToString());

                    if (alreadyAnswered)
                    {
                        string selected = "button answer-choice-true rs_skip selected";
                        string not_selected = "button gray answer-choice-false rs_skip disabled";

                        if (AnswerTracker[question.ID.ToString()].Answer == "True")
                        {
                            rblHiddenButtonList.Items.FindByText("True").Selected = true;
                            btnTrue.Attributes.Add("class", selected);
                            btnFalse.Attributes.Add("class", not_selected);
                        }
                        else
                        {
                            rblHiddenButtonList.Items.FindByText("False").Selected = true;
                            btnTrue.Attributes.Add("class", not_selected);
                            btnFalse.Attributes.Add("class", selected);
                        }
                    }
                    pnlTrueFalse.Visible = true;
                }
                else if (question.IsOfType(AssessmentMultipleChoiceItem.TemplateId))
                {
                    AssessmentMultipleChoiceItem Question = (AssessmentMultipleChoiceItem)question;
                    if (Question.IsDropDownList.Checked)
                    {
                        ddlQuestion.Attributes.Add("data-id", question.ID.ToString());
                        ddlQuestion.Items.Add(new ListItem(Question.DropDownDefaultText));

                        foreach (Item i in Question.InnerItem.Children)
                            ddlQuestion.Items.Add(new ListItem(i.Fields["Answer"].ToString()));

                        if (alreadyAnswered)
                            ddlQuestion.Items.FindByText(AnswerTracker[question.ID.ToString()].Answer).Selected = true;

                        ddlQuestion.Items.FindByText(Question.DropDownDefaultText).Value = "";

                        pnlDropDown.Visible = true;
                    }
                    else
                    {
                        rblAnswer.Attributes.Add("data-id", question.ID.ToString());

                        foreach (Item i in Question.InnerItem.Children)
                            rblAnswer.Items.Add(new ListItem(i.Fields["Answer"].ToString()));

                        if (alreadyAnswered)
                            rblAnswer.Items.FindByText(AnswerTracker[question.ID.ToString()].Answer).Selected = true;

                        pnlRadioQuestion.Visible = true;
                    }
                }
                
            }
        }
    }
}