using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{

    public partial class KnowledgeQuizQuestionrArticlePage : System.Web.UI.UserControl
    {
        KnowledgeQuizQuestionArticlePageItem ObjKnowledgeQuiz;
        List<KnowledgeQuizQuestion> _KnowledgeQuizQuestions;
        string _panletoShow;

        protected void Page_Load(object sender, EventArgs e)
        {
            ObjKnowledgeQuiz = new KnowledgeQuizQuestionArticlePageItem(Sitecore.Context.Item);
            if (ObjKnowledgeQuiz != null)
            {
                if (IsPostBack == false)
                {
                    if (Session["CurrentQ"] == null) // loading first time or error while quiz in progress
                    {
                        //Reset all session variables
                        Session["QuizQs"] = null;
                        Session["ShowPanel"] = null;
                    }
                    if (Session["QuizQs"] == null) //loading first time , load  all questions of quiz
                    {
                        GetAllQuizQuestions();//load all question and make 1st question as curent question
                        pnlQuestion.Visible = true;
                        pnlResult.Visible = false;
                    }
                    ShowPanel();
                }
                else
                {
                     // ShowPanel();
                }

            }
        }

        private void ShowPanel()
        {
            if (GetPaneltoShow() == "Question")
            {
                KnowledgeQuizQuestion QuestiontoShow = (KnowledgeQuizQuestion)Session["CurrentQ"];
                List<KnowledgeQuizQuestion> quizQsCnt = (List<KnowledgeQuizQuestion>)Session["QuizQs"];
                if (quizQsCnt != null && QuestiontoShow != null) ShowQuestionDetails(QuestiontoShow, quizQsCnt.Count);

            }
            if (GetPaneltoShow() == "Result")
            {
                //check for last question result to show proper buttons
                if ((string)Session["LastQ"] == "1")
                {
                    btnResult.Visible = true;
                    btnNextQuestion.Visible = false;
                }
                else
                {
                    btnResult.Visible = false;
                    btnNextQuestion.Visible = true;
                }
                ShowQuestionResult();
            }
        }
        /// <summary>
        /// According to User selected answer show respective answer details
        /// </summary>
        private void ShowQuestionResult()
        {
            if (Session["UserResult"] != null)
            {
                pnlQuestion.Visible = false;
                pnlResult.Visible = true;
                KnowledgeQuizQuestion tempQ = (KnowledgeQuizQuestion)Session["UserResult"];
                if (tempQ != null)
                {
                    if (tempQ.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                    {
                        if (tempQ.UserAnswerBool == tempQ.ActualAnsBool)
                        {
                            //Users answer is correct
                            lblCorrect.Visible = true;
                            lblIncorrect.Visible = false;
                            frTrueAnsDetail.Item = tempQ.ActualAnswerObject;
                            frTrueAnsDetail.Visible = true;
                            frFalseAnsDetail.Visible = false;
                        }
                        else
                        {
                            //Users Answer is Incorrect
                            lblCorrect.Visible = false;
                            lblIncorrect.Visible = true;
                            frTrueAnsDetail.Item = tempQ.ActualAnswerObject;
                            frTrueAnsDetail.Visible = false;
                            frFalseAnsDetail.Visible = true;
                        }
                    }
                    else
                    {
                        if (tempQ.ActualAnswerObject == tempQ.UserdAnswerObject)
                        {
                            //user selected correct answer
                            lblCorrect.Visible = true;
                            lblIncorrect.Visible = false;
                            frTrueAnsDetail.Item = tempQ.ActualAnswerObject;
                            frTrueAnsDetail.Visible = true;
                            frFalseAnsDetail.Visible = false;
                        }
                        else
                        {
                            //user selected wrong answer
                            lblCorrect.Visible = false;
                            lblIncorrect.Visible = true;
                            frTrueAnsDetail.Item = tempQ.ActualAnswerObject;
                            frTrueAnsDetail.Visible = false;
                            frFalseAnsDetail.Visible = true;
                        }
                    }
                }
            }

        }
        /// <summary>
        /// set question layout with answer listing style as per question style. 
        /// </summary>
        /// <returns></returns>
        private void ShowQuestionDetails(KnowledgeQuizQuestion Question, int TotalQuestionCount)
        {
            //Set Question Counter
            if ((string)Session["LastQ"] == "1")
            {
                Session["ShowPanel"] = "Result";
                ShowPanel();
            }
            else
            {
                lblQuestionCounter.Text = "Question " + (Question.QuestionIndex + 1) + " of " + TotalQuestionCount;
                //set question title details
                frQuestionTitle.Item = Question.Question;
                //set Answer Listing style
                pnlQuestion.Visible = true;
                pnlResult.Visible = false;
                phBoolean.Visible = false;
                phOption.Visible = false;
                phDropdown.Visible = false;
                if (Question.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                {
                    //show boolean button ph
                    phBoolean.Visible = true;
                }
                else if (Question.Question.QuestionType.Raw.ToLower().Contains("option"))
                {
                    //show option ph
                    rblAnswer.Items.Clear();
                    IEnumerable<QuizAnswersItem> _allAns = QuizQuestionItem.GetAllAnswers(Question.Question);
                    if (_allAns != null)
                    {
                        foreach (QuizAnswersItem a in _allAns)
                        {
                            rblAnswer.Items.Add(new ListItem(a.Answer));
                        }
                    }
                    phOption.Visible = true;
                }
                else if (Question.Question.QuestionType.Raw.ToLower().Contains("drop down"))
                {
                    //show ddl ph
                    ddlAnswer.Items.Clear();
                    IEnumerable<QuizAnswersItem> _allAns = QuizQuestionItem.GetAllAnswers(Question.Question);
                    if (_allAns != null)
                    {
                        ddlAnswer.Items.Clear();
                        ddlAnswer.Items.Add(new ListItem("Plese Select Answer"));
                        foreach (QuizAnswersItem a in _allAns)
                        {
                            ddlAnswer.Items.Add(new ListItem(a.Answer));
                        }
                    }
                    phDropdown.Visible = true;
                }
            }
            
        }
        private string GetPaneltoShow()
        {
            _panletoShow = (string)Session["ShowPanel"];
            if (_panletoShow == null)
            {
                //show question panel with question 1.
                _panletoShow = "Question";
                Session["ShowPanel"] = "Question";
            }

            return _panletoShow;
        }
        /// <summary>
        /// If Sessiion[QuizQs"] is null, load all question details
        /// </summary>
        private void GetAllQuizQuestions()
        {
            //load all question details in array
            IEnumerable<QuizQuestionItem> AllQs = KnowledgeQuizQuestionArticlePageItem.GetAllQuestions(ObjKnowledgeQuiz);
            if (AllQs != null)
            {
                _KnowledgeQuizQuestions = new List<KnowledgeQuizQuestion>(AllQs.Count());
                int i = 0;
                foreach (QuizQuestionItem q in AllQs)
                {
                    _KnowledgeQuizQuestions.Add(new KnowledgeQuizQuestion(q, i));
                    i++;
                }
                Session["QuizQs"] = _KnowledgeQuizQuestions;
                Session["CurrentQ"] = _KnowledgeQuizQuestions[0];
            }
        }
        /// <summary>
        /// Update User selected answer in Quiz Question list and set current question as next quetsion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateUserSelectedAnswer(KnowledgeQuizQuestion UpdatedQuizQ)
        {
            _KnowledgeQuizQuestions = (List<KnowledgeQuizQuestion>)Session["QuizQs"];
            if (_KnowledgeQuizQuestions != null)
            {
                bool UserAnsSaved = false;
                for (int i = 0; i <= _KnowledgeQuizQuestions.Count() - 1; i++)
                {

                    KnowledgeQuizQuestion quizq = _KnowledgeQuizQuestions[i];
                    if (quizq.Question == UpdatedQuizQ.Question)
                    {
                        if (quizq.Question.QuestionType.Raw.ToLower().Contains("boolean") && UserAnsSaved == false)
                        {
                            UserAnsSaved = true;
                            quizq.UserAnswerBool = UpdatedQuizQ.UserAnswerBool;
                            Session["UserResult"] = quizq;
                            if (i + 1 <= _KnowledgeQuizQuestions.Count() - 1)
                            {
                                Session["NextQ"] = _KnowledgeQuizQuestions[i + 1];
                            }
                            else if (i  == _KnowledgeQuizQuestions.Count()-1 )
                            { Session["LastQ"] = "1"; }
                        }
                        if (!quizq.Question.QuestionType.Raw.ToLower().Contains("boolean") && UserAnsSaved == false)
                        {
                            UserAnsSaved = true;
                            quizq.UserdAnswerObject = UpdatedQuizQ.UserdAnswerObject;
                            Session["UserResult"] = quizq;
                            if (i + 1 <= _KnowledgeQuizQuestions.Count() - 1)
                            {
                                Session["NextQ"] = _KnowledgeQuizQuestions[i + 1];
                            }
                            else if (i  == _KnowledgeQuizQuestions.Count()-1)
                            { Session["LastQ"] = "1"; }
                        }
                    }

                }
                Session["QuizQs"] = _KnowledgeQuizQuestions;
            }
        }
        protected void btnTrue_Click(object sender, EventArgs e)
        {
            if (Session["CurrentQ"] != null)
            {
                KnowledgeQuizQuestion tempQ = (KnowledgeQuizQuestion)Session["CurrentQ"];
                if (tempQ.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                {
                    tempQ.UserAnswerBool = true;
                }
                UpdateUserSelectedAnswer(tempQ);

            }

            Session["ShowPanel"] = "Result";
            ShowPanel();
        }

        protected void btnFalse_Click(object sender, EventArgs e)
        {
            if (Session["CurrentQ"] != null)
            {
                KnowledgeQuizQuestion tempQ = (KnowledgeQuizQuestion)Session["CurrentQ"];
                if (tempQ.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                {
                    tempQ.UserAnswerBool = false;
                }
                UpdateUserSelectedAnswer(tempQ);
            }

            Session["ShowPanel"] = "Result";
            ShowPanel();
        }

        protected void rblAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["CurrentQ"] != null)
            {
                KnowledgeQuizQuestion tempQ = (KnowledgeQuizQuestion)Session["CurrentQ"];
                if (!tempQ.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                {
                    //Get All Answer and match selected answer
                    IEnumerable<QuizAnswersItem> allans = QuizQuestionItem.GetAllAnswers(tempQ.Question);
                    foreach (QuizAnswersItem a in allans)
                    {
                        if (a.Answer == rblAnswer.SelectedValue)
                        {
                            tempQ.UserdAnswerObject = a;
                        }
                    }
                }
                UpdateUserSelectedAnswer(tempQ);
            }

            Session["ShowPanel"] = "Result";
            ShowPanel();
        }

        protected void ddlAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["CurrentQ"] != null)
            {
                KnowledgeQuizQuestion tempQ = (KnowledgeQuizQuestion)Session["CurrentQ"];
                if (!tempQ.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                {
                    //Get All Answer and match selected answer
                    IEnumerable<QuizAnswersItem> allans = QuizQuestionItem.GetAllAnswers(tempQ.Question);
                    foreach (QuizAnswersItem a in allans)
                    {
                        if (a.Answer == ddlAnswer.SelectedValue)
                        {
                            tempQ.UserdAnswerObject = a;
                        }
                    }
                }
                UpdateUserSelectedAnswer(tempQ);
            }

            Session["ShowPanel"] = "Result";
            ShowPanel();
        }

        protected void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (Session["NextQ"] != null) Session["CurrentQ"] = Session["NextQ"];
            else if ((string)Session["LastQ"] == "1")
            {
                btnNextQuestion.Visible = false;
                btnResult.Visible = true;
            }
            Session["ShowPanel"] = "Question";
            ShowPanel();
        }

        protected void btnResult_Click(object sender, EventArgs e)
        {
            //store all question values in session
            Response.Redirect(string.Concat("http://",Request.Url.Host.ToString(), ObjKnowledgeQuiz.LinktoResultPage));
        }
    }
    public class KnowledgeQuizQuestion
    {
        private int _qIndex;
        private bool _score;
        private QuizQuestionItem _question;
        private QuizAnswersItem _UserAnsObj;
        private QuizAnswersItem _ActualAnsObj;
        private bool _userAnsBool;
        private bool _actualAnsBool;

        public int QuestionIndex
        {
            get { return _qIndex; }
            set { _qIndex = value; }
        }
        public bool Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public QuizQuestionItem Question
        {
            get { return _question; }
            set { _question = value; }
        }
        public QuizAnswersItem UserdAnswerObject
        {
            get { return _UserAnsObj; }
            set { _UserAnsObj = value; }
        }
        public QuizAnswersItem ActualAnswerObject
        {
            get { return _ActualAnsObj; }
            set { _ActualAnsObj = value; }
        }
        public bool UserAnswerBool
        {
            get { return _userAnsBool; }
            set { _userAnsBool = value; }
        }
        public bool ActualAnsBool
        {
            get { return _actualAnsBool; }
            set { _actualAnsBool = value; }
        }

        private bool SetActualBoolAnswerDetails(QuizQuestionItem Questn)
        {
            bool ActualBoolAns = false;
            if (Questn.QuestionType.Raw.ToLower().Contains("boolean"))
            {
                QuizAnswersItem _boolans = QuizQuestionItem.GetAllAnswers(Questn).FirstOrDefault();
                ActualBoolAns = _boolans.SetCorrectAnswer.Checked;
            }
            return ActualBoolAns;
        }
        private QuizAnswersItem SetActualAnswerDetails(QuizQuestionItem Questn)
        {
            QuizAnswersItem _ActualAnsObj = null;
            if (Questn.QuestionType.Raw.ToLower().Contains("option") || Questn.QuestionType.Raw.ToLower().Contains("drop down"))
            {
                IEnumerable<QuizAnswersItem> _allans = QuizQuestionItem.GetAllAnswers(Questn);
                if (_allans != null)
                {
                    foreach (QuizAnswersItem q in _allans)
                    {
                        if (q.SetCorrectAnswer.Checked == true)
                            _ActualAnsObj = q;
                    }
                }
            }
            else if (Questn.QuestionType.Raw.ToLower().Contains("boolean"))
            {
                _ActualAnsObj = QuizQuestionItem.GetAllAnswers(Questn).FirstOrDefault();
            }
            return _ActualAnsObj;
        }

        public KnowledgeQuizQuestion(QuizQuestionItem QuestionItem, int QuestionIndex)
        {
            _qIndex = QuestionIndex;
            _score = false;
            _question = QuestionItem;
            _UserAnsObj = null;
            _userAnsBool = false;
            if (QuestionItem.QuestionType.Raw.ToLower().Contains("boolean"))
            {
                _actualAnsBool = SetActualBoolAnswerDetails(QuestionItem);
                _ActualAnsObj = SetActualAnswerDetails(QuestionItem);
            }

            else
                _ActualAnsObj = SetActualAnswerDetails(QuestionItem);

        }
    }
}
