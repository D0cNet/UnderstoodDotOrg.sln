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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Assessment_Quiz : System.Web.UI.UserControl
    {
        private Item PageResources = Sitecore.Context.Item.Children.FirstOrDefault();
        private Item ResultsFolder;
        private int PageNumber;
        private List<Item> Pages;
        private string Answer;
        private List<Item> Questions;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pageNum"] != null)
            {
                PageNumber = (int)Session["pageNum"];
            }
            else
            {
                if (!IsPostBack)
                {
                    Reset();
                }
                PageNumber = 1;
            }

            Item questionsFolder = PageResources.Children.ToList().Where(i => i.IsOfType(AssessmentQuizQuestionsFolderItem.TemplateId)).FirstOrDefault();
            if (questionsFolder != null)
            {
                Pages = questionsFolder.Children.ToList();
                Questions = Pages[PageNumber - 1].Children.ToList();
                lblPageCounter.Text = "Page " + PageNumber.ToString() + " of " + Pages.Count.ToString();

                if (!(Pages.Count > PageNumber))

                {
                    btnNextPage.Visible = false;
                    btnShowResults.Visible = true;
                }


                if (Session["done"] != null && (string)Session["done"] == "true")
                {
                    btnTakeQuizAgain.Visible = true;
                    btnShowResults.Visible = false;

                    ResultsFolder = PageResources.Children.Where(i => i.IsOfType(AssessmentQuizResultsFolderItem.TemplateId)).FirstOrDefault();

                    Reset();
                }
                else
                {
                    rptPageQuestions.DataSource = Questions;
                    rptPageQuestions.DataBind();
                }
            }
        }

        public void Reset()
        {
            Session["done"] = null;
            Session["pageNum"] = null;
        }

        protected void btnNextPage_Click(object sender, EventArgs e)
        {
            Session["pageNum"] = (PageNumber + 1);

            EvaluateAnswers();

            Response.Redirect(Request.CurrentExecutionFilePath);
        }

        private void EvaluateAnswers()
        {
            
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

        public void UpdateAnswers(bool result)
        {
            if (Session["CorrectTracker"] != null)
            {
                List<bool> answers = (List<bool>)Session["CorrectTracker"];
                answers.Add(result);
                Session["CorrectTracker"] = answers;
            }
            else
            {
                List<bool> answers = new List<bool>();
                answers.Add(result);
                Session["CorrectTracker"] = answers;
            }
        }

        protected void rptPageQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                FieldRenderer frQuestionTitle = e.FindControlAs<FieldRenderer>("frQuestionTitle");
                Panel pnlQuestion = e.FindControlAs<Panel>("pnlQuestion");
                Panel pnlTrueFalse = e.FindControlAs<Panel>("pnlTrueFalse");
                Panel pnlRadioQuestion = e.FindControlAs<Panel>("pnlRadioQuestion");
                RadioButtonList rblAnswer = e.FindControlAs<RadioButtonList>("rblAnswer");

                Item question = (Item)e.Item.DataItem;

                if(frQuestionTitle != null)
                    frQuestionTitle.Item = question;

                if (question.IsOfType(AssessmentTrueFalseItem.TemplateId))
                {
                    AssessmentTrueFalseItem Question = (AssessmentTrueFalseItem)question;
                    Answer = Question.CorrectAnswer.Item.Fields["Content Title"].ToString();

                    pnlTrueFalse.Visible = true;
                }
                else if (question.IsOfType(AssessmentMultipleChoiceItem.TemplateId))
                {
                    AssessmentMultipleChoiceItem Question = (AssessmentMultipleChoiceItem)question;

                    if(Question.CorrectAnswer != null)
                        Answer = Question.CorrectAnswer.Item.Fields["Answer"].ToString();

                    foreach (Item i in Question.InnerItem.Children)
                    {
                        rblAnswer.Items.Add(new ListItem(i.Fields["Answer"].ToString()));
                    }

                    pnlRadioQuestion.Visible = true;
                }
                
            }
        }
    }
}