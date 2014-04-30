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
    public partial class AssessmentQuizArticlePage2 : System.Web.UI.UserControl
    {
        AssessmentQuizArticlePage2Item ObjAssessmentQuizPage2;
        IEnumerable<QuizQuestionItem> _allQuestion;
        List<AssessmentQuizScorePage2> _AssessmentQuiz_Page2Score;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAssessmentQuizPage2 = new AssessmentQuizArticlePage2Item(Sitecore.Context.Item);
            if (ObjAssessmentQuizPage2 != null)
            {
                //Get list of Questions
                _allQuestion = AssessmentQuizArticlePage2Item.GetAllQuestions(ObjAssessmentQuizPage2);
                if (_allQuestion != null)
                {
                    _AssessmentQuiz_Page2Score = new List<AssessmentQuizScorePage2>(_allQuestion.Count());
                    foreach (QuizQuestionItem q in _allQuestion)
                    {
                        _AssessmentQuiz_Page2Score.Add(new AssessmentQuizScorePage2(q));
                    }

                    rptQuestion.DataSource = _allQuestion;
                    rptQuestion.DataBind();
                }
                btnSubmit.OnClientClick += new EventHandler(btnSubmit_Click);
                btnBack.OnClientClick += new EventHandler(btnBack_Click);

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            //btnSubmit.PostBackUrl =string.Concat( Request.Url.Host.ToString() , ObjAssessmentQuizPage2.LinktoBackPage);
            Response.Redirect(string.Concat(Request.Url.Host.ToString(),"/", ObjAssessmentQuizPage2.LinktoBackPage));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
        
            //btnSubmit.PostBackUrl =string.Concat( Request.Url.Host.ToString() , ObjAssessmentQuizPage2.LinktoResultPage);
            Response.Redirect(string.Concat(Request.Url.Host.ToString(), "/", ObjAssessmentQuizPage2.LinktoResultPage));
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

        public bool UpdateScore(AssessmentQuizArticlePage2Item ObjQuizPage1, string SelectedAnswer)
        {
            bool _Isdone = false;
            List<Item> _SelectedAns = AssessmentQuizArticlePage2Item.GetQuestionAndAnswer(ObjQuizPage1, SelectedAnswer);
            if (_SelectedAns != null)
            {
                QuizAnswersItem _ScoreA = new QuizAnswersItem(_SelectedAns[1]);
                foreach (AssessmentQuizScorePage2 s in _AssessmentQuiz_Page2Score)
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
            if (UpdateScore(ObjAssessmentQuizPage2, opAnsSel) == true)
            {

                Session["_AssessmentQuiz_Page2Score"] = _AssessmentQuiz_Page2Score;
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
            if (UpdateScore(ObjAssessmentQuizPage2, opAnsSel) == true)
            {
                Session["_AssessmentQuiz_Page1Score"] = _AssessmentQuiz_Page2Score;
            }
        }
        
    }
    public class AssessmentQuizScorePage2
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

        public AssessmentQuizScorePage2(QuizQuestionItem QuestionItem)
        {
            _question = QuestionItem;
            _score = 0;
        }
    }
}