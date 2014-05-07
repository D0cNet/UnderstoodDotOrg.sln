using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class AssessmentQuizArticlePage1 : System.Web.UI.UserControl
    {
        AssessmentQuizArticlePage1Item ObjAssessmentQuizPage1;
        IEnumerable<QuizQuestionItem> _allQuestion;
        List<AssessmentQuizScorePage1> _AssessmentQuiz_Page1Score;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAssessmentQuizPage1 = new AssessmentQuizArticlePage1Item(Sitecore.Context.Item);
            if (ObjAssessmentQuizPage1 != null)
            {
                //Get list of Questions
                Session["AssessmentPage1Item"] = ObjAssessmentQuizPage1;
                _allQuestion = AssessmentQuizArticlePage1Item.GetAllQuestions(ObjAssessmentQuizPage1);
                if (_allQuestion != null)
                {
                    _AssessmentQuiz_Page1Score = new List<AssessmentQuizScorePage1>(_allQuestion.Count());
                    foreach (QuizQuestionItem q in _allQuestion)
                    {
                        _AssessmentQuiz_Page1Score.Add(new AssessmentQuizScorePage1(q));
                    }

                    rptQuestion.DataSource = _allQuestion;
                    rptQuestion.DataBind();
                }
                btnNext.OnClientClick += new EventHandler(btnNext_Click);

            }
        }

        protected void rptQuestion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                QuizQuestionItem _currentQ = e.Item.DataItem as QuizQuestionItem;
                if (_currentQ != null)
                {
                    FieldRenderer frQuestion = e.FindControlAs<FieldRenderer>("frQuestion");

                    if (frQuestion != null)
                    {
                        frQuestion.Item = _currentQ;
                        IEnumerable<QuizAnswersItem> _AllAnsers = QuizQuestionItem.GetAllAnswers(_currentQ);
                        if (_AllAnsers != null)
                        {
                            PlaceHolder phOption = e.FindControlAs<PlaceHolder>("phOption");
                            PlaceHolder phDropdown = e.FindControlAs<PlaceHolder>("phDropdown");
                            if (_currentQ.QuestionType.Raw == "Option List Style")
                            {
                                phOption.Visible = true;
                                phDropdown.Visible = false;
                                RadioButtonList rblAnswer = e.FindControlAs<RadioButtonList>("rblAnswer");
                                if (rblAnswer != null)
                                {

                                    foreach (QuizAnswersItem ans in _AllAnsers)
                                    {
                                        ListItem A = new ListItem("<span> " + ans.Answer + "</span>");
                                        rblAnswer.Items.Add(A);
                                    }
                                    rblAnswer.SelectedIndexChanged += rblAnswer_SelectedIndexChanged;
                                }
                            }

                            if (_currentQ.QuestionType.Raw == "Drop Down Style")
                            {
                                phDropdown.Visible = true;
                                phOption.Visible = false;
                                DropDownList ddlAnswer = e.FindControlAs<DropDownList>("ddlAnswer");
                                if (ddlAnswer != null)
                                {
                                    ddlAnswer.Items.Add(new ListItem(" Please Select Answer"));
                                    foreach (QuizAnswersItem ans in _AllAnsers)
                                    {
                                        ListItem A = new ListItem(ans.Answer);
                                        ddlAnswer.Items.Add(A);
                                    }
                                    ddlAnswer.SelectedIndexChanged += ddlAnswer_SelectedIndexChanged;
                                }
                            }
                        }
                    }

                }
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            //btnNext.PostBackUrl = string.Concat(Request.Url.Host.ToString(), ObjAssessmentQuizPage1.LinktoNextPage);
            Response.Redirect(string.Concat("http://",Request.Url.Host.ToString(), ObjAssessmentQuizPage1.LinktoNextPage));
        }
        public bool UpdateScore(AssessmentQuizArticlePage1Item ObjQuizPage1, string SelectedAnswer)
        {
            bool _Isdone = false;
            List<Item> _SelectedAns = AssessmentQuizArticlePage1Item.GetQuestionAndAnswer(ObjQuizPage1, SelectedAnswer);
            if (_SelectedAns != null)
            {
                QuizAnswersItem _ScoreA = new QuizAnswersItem(_SelectedAns[1]);
                foreach (AssessmentQuizScorePage1 s in _AssessmentQuiz_Page1Score)
                {
                    if (s.Question.ID == _SelectedAns[0].ID)
                    {
                        s.Score = _ScoreA.Score;
                        _Isdone = true;
                        //Response.Write(s.Question.Name + "<=>" + s.Score.ToString());
                    }
                }
            }
            return _Isdone;
        }


        protected void rblAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opAnsSel;
            opAnsSel = ((RadioButtonList)sender).SelectedValue.Replace("<span>", "");
            opAnsSel = opAnsSel.Replace("</span>", "");
            opAnsSel = opAnsSel.Trim();

            //Response.Write("opAnsSel = " + opAnsSel.ToString() + "<br/>");
            if (UpdateScore(ObjAssessmentQuizPage1, opAnsSel) == true)
            {

                Session["_AssessmentQuiz_Page1Score"] = _AssessmentQuiz_Page1Score;
            }


        }

        protected void ddlAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opAnsSel;
            opAnsSel = ((DropDownList)sender).SelectedValue.Replace("<span>", "");
            opAnsSel = opAnsSel.Replace("</span>", "");
            opAnsSel = opAnsSel.Trim();

            //Response.Write("ddlAnsSel = " + opAnsSel.ToString() + "<br/>");
            //DropDownList ddlAnswer = (DropDownList)this.FindControl("ddlAnswer");
            if (UpdateScore(ObjAssessmentQuizPage1, opAnsSel) == true)
            {
                Session["_AssessmentQuiz_Page1Score"] = _AssessmentQuiz_Page1Score;
            }
        }
    }

    public class AssessmentQuizScorePage1
    {
        private int _score;
        private Item _question;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public Item Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public AssessmentQuizScorePage1(QuizQuestionItem QuestionItem)
        {
            _question = QuestionItem;
            _score = 0;
        }
    }
}