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
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class KnowledgeQuizQuestionrArticlePage : System.Web.UI.UserControl
    {
        public class KnowledgeAnswer
        {
            public Guid ID { get; set; }
            public string CorrectAnswer { get; set; }
            public bool Result { get; set; }
        }

        public bool JumpToAnswer;
        private Item PageResources = Sitecore.Context.Item.Children.FirstOrDefault();
        private Item ResultsFolder;
        private int QuestionNumber;
        private Item GenericQuestion;
        private bool MoreQuestions = false;
        private KnowledgeAnswer Answer = new KnowledgeAnswer();
        List<Item> Questions;        

        protected void Page_Load(object sender, EventArgs e)
        {
            JumpToAnswer = false;
            litCorrect.Text = DictionaryConstants.CorrectText;
            litIncorrect.Text = DictionaryConstants.IncorrectText;

            Item questionsFolder = PageResources.Children.ToList().Where(i => i.IsOfType(KnowledgeQuizQuestionsFolderItem.TemplateId)).FirstOrDefault();
            if (questionsFolder != null)
                Questions = questionsFolder.Children.ToList();

            if (Session["done"] != null && (string)Session["done"] == "true")
            {
                string correctAnswers = Session["CorrectAnswers"].ToString();
                litTextResults.Text = correctAnswers + DictionaryConstants.OutOfFragment + Questions.Count;
                btnTakeQuizAgain.Visible = true;

                ResultsFolder = PageResources.Children.Where(i => i.IsOfType(KnowledgeQuizResultsFolderItem.TemplateId)).FirstOrDefault();

                int correct = Int32.Parse(correctAnswers);

                foreach (Item i in ResultsFolder.Children)
                {
                    KnowledgeQuizResultItem range = (KnowledgeQuizResultItem)i;
                    if (correct >= range.MinimumCorrectAnswers)
                    {
                        if (range.MaximumCorrectAnswers.ToString().IsNullOrEmpty() || (correct <= range.MaximumCorrectAnswers))
                        {
                            frEndExplanation.Item = i;
                            break;
                        }
                    }
                }

                rptCorrectAnswers.DataSource = Session["CorrectTracker"];
                rptCorrectAnswers.DataBind();
                divQuestionsRight.Visible = true;
                Reset();
            }
            else
            {
                if (Session["qNum"] != null)
                {
                    QuestionNumber = (int)Session["qNum"];
                }
                else
                {
                    if (!IsPostBack)
                    {
                        Reset();
                    }
                    QuestionNumber = 1;
                }

                SetQuestion();
            }
        }

        public void Reset()
        {
            Session["done"] = null;
            Session["qNum"] = null;
            Session["CorrectAnswers"] = 0;
            Session["CorrectTracker"] = null;
        }

        public void SetQuestion()
        {
            lblQuestionCounter.Text = "Question " + QuestionNumber.ToString() + " of " + Questions.Count.ToString();

            GenericQuestion = Questions[QuestionNumber - 1];
            if (Questions.Count > QuestionNumber)
                MoreQuestions = true;

            frQuestionTitle.Item = GenericQuestion;

            if (GenericQuestion.IsOfType(TrueFalseQuestionItem.TemplateId))
            {
                TrueFalseQuestionItem Question = (TrueFalseQuestionItem)GenericQuestion;
                Answer.CorrectAnswer = Question.CorrectAnswer.Item.Fields["Content Title"].ToString();
                Answer.ID = Question.ID.ToGuid();

                pnlTrueFalse.Visible = true;
            }
            else if (GenericQuestion.IsOfType(MultipleChoiceQuestionItem.TemplateId))
            {
                MultipleChoiceQuestionItem Question = (MultipleChoiceQuestionItem)GenericQuestion;

                Answer.CorrectAnswer = Question.CorrectAnswer.Item.Fields["Answer"].ToString();
                Answer.ID = Question.ID.ToGuid();

                foreach (Item i in Question.InnerItem.Children)
                {
                    rblAnswer.Items.Add(new ListItem(i.Fields["Answer"].ToString()));
                }

                pnlRadioQuestion.Visible = true;
            }
        }

        private void ShowQuestionResult()
        {
            pnlResult.Visible = true;
            btnTrue.Visible = false;
            btnFalse.Visible = false;
            frExplanation.Item = GenericQuestion;

            if (MoreQuestions)
                btnResult.Visible = false;
            else
                btnNextQuestion.Visible = false;

        }
        
        protected void btnTrue_Click(object sender, EventArgs e)
        {
            if (Answer.CorrectAnswer == "True")
            {
                Answer.Result = true;
                spanCurrentAnswerResult.Attributes.Add("class", "correct-incorrect correct");
                litIncorrect.Visible = false;
            }
            else
            {
                Answer.Result = false;
                spanCurrentAnswerResult.Attributes.Add("class", "correct-incorrect incorrect");
                litCorrect.Visible = false;
            }

            UpdateAnswers(Answer);
            ShowQuestionResult();
            JumpToAnswer = true;
        }

        protected void btnFalse_Click(object sender, EventArgs e)
        {
            if (Answer.CorrectAnswer == "False")
            {
                Answer.Result = true;
                spanCurrentAnswerResult.Attributes.Add("class", "correct-incorrect correct");
                litIncorrect.Visible = false;
            }
            else
            {
                Answer.Result = false;
                spanCurrentAnswerResult.Attributes.Add("class", "correct-incorrect incorrect");
                litCorrect.Visible = false;
            }

            UpdateAnswers(Answer);
            ShowQuestionResult();
            JumpToAnswer = true;
        }

        protected void rblAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Answer.CorrectAnswer == rblAnswer.SelectedValue)
            {
                Answer.Result = true;
                spanCurrentAnswerResult.Attributes.Add("class", "correct-incorrect correct");
                litIncorrect.Visible = false;
            }
            else
            {
                Answer.Result = false;
                spanCurrentAnswerResult.Attributes.Add("class", "correct-incorrect incorrect");
                litCorrect.Visible = false;
            }

            UpdateAnswers(Answer);
            rblAnswer.Items.Clear();
            ShowQuestionResult();
            JumpToAnswer = true;
        }

        protected void btnNextQuestion_Click(object sender, EventArgs e)
        {
            Session["qNum"] = (QuestionNumber + 1);
            btnTrue.Visible = true;
            btnFalse.Visible = true;
            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        protected void btnTakeQuizAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            //store all question values in session
            Session["done"] = "true";
            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        public void UpdateScore(int value)
        {
            if (Session["CorrectAnswers"] != null)
            {
                Session["CorrectAnswers"] = (int)Session["CorrectAnswers"] + value;
            }
            else
            {
                Session["CorrectAnswers"] = value;
            }
        }

        public void UpdateAnswers(KnowledgeAnswer answer)
        {
            if (Session["CorrectTracker"] != null)
            {
                List<KnowledgeAnswer> answers = (List<KnowledgeAnswer>)Session["CorrectTracker"];

                if (answers.Where(i => i.ID == answer.ID).Count() == 0)
                {
                    answers.Add(answer);
                    Session["CorrectTracker"] = answers;
                    if (answer.Result)
                        UpdateScore(1);
                }
            }
            else
            {
                List<KnowledgeAnswer> answers = new List<KnowledgeAnswer>();
                answers.Add(answer);
                Session["CorrectTracker"] = answers;
                if (answer.Result)
                    UpdateScore(1);
            }
        }

        protected void rptCorrectAnswers_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                HtmlGenericControl spanResult = e.FindControlAs<HtmlGenericControl>("spanResult");

                KnowledgeAnswer answer = (KnowledgeAnswer)e.Item.DataItem;

                if (spanResult != null)
                {
                    if (answer.Result)
                        spanResult.Attributes.Add("class", "results-indicator correct");
                    else
                        spanResult.Attributes.Add("class", "results-indicator incorrect");
                }
            }
        }
    }
}
