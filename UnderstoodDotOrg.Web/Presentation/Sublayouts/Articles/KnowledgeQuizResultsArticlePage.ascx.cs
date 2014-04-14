using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class KnowledgeQuizResultsArticlePage : System.Web.UI.UserControl
    {
        KnowledgeQuizResultsArticlePageItem ObjKnowledgeQuizResult;
        List<KnowledgeQuizQuestion> _KnowledgeQuizQuestions;
        int _CorrectCnt = 0;
        int _TotalCount = 0;
        int _finalScore = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjKnowledgeQuizResult = new KnowledgeQuizResultsArticlePageItem(Sitecore.Context.Item);
           
            if (ObjKnowledgeQuizResult != null)
            {
                //Get Reviewer Name
                if (ObjKnowledgeQuizResult.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjKnowledgeQuizResult.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjKnowledgeQuizResult.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }
                if (Session["QuizQs"] != null)
                {
                    //open result panel and load rpt control
                    _KnowledgeQuizQuestions = (List<KnowledgeQuizQuestion>)Session["QuizQs"];
                    
                    if (_KnowledgeQuizQuestions != null)
                    {
                        _TotalCount = _KnowledgeQuizQuestions.Count();
                        rptCorrectCheck.DataSource = _KnowledgeQuizQuestions;
                        rptCorrectCheck.DataBind();
                    }
                    //Check score and set reuslt data
                    
                    QuizResultItem ResultItem = GetResultData(_KnowledgeQuizQuestions);
                    if (ResultItem != null)
                    {
                        frResultDetail.Item = ResultItem;
                        lblScoreStatus.Text = _CorrectCnt + " out of " + _TotalCount + " correct";
                    }
                   
                }

            }

        }

        public QuizResultItem GetResultData(List<KnowledgeQuizQuestion> QuizQs)
        {
            QuizResultItem _returnRes = null;
            _CorrectCnt = 0;
            _finalScore = 0;
            foreach (KnowledgeQuizQuestion q in _KnowledgeQuizQuestions)
            {
                if (q.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                {
                    if (q.UserAnswerBool == q.ActualAnsBool)
                    {
                        _CorrectCnt += 1;
                        _finalScore += (int)q.ActualAnswerObject.Score;
                    }
                }
                if (q.Question.QuestionType.Raw.ToLower().Contains("option") || q.Question.QuestionType.Raw.ToLower().Contains("drop down"))
                {
                    if (q.UserdAnswerObject.Answer == q.ActualAnswerObject.Answer)
                    {
                        _CorrectCnt += 1;
                        _finalScore += (int)q.ActualAnswerObject.Score;
                    }
                }
            }
            IEnumerable<QuizResultItem> AllRes = KnowledgeQuizResultsArticlePageItem.GetAllQuestions(ObjKnowledgeQuizResult);
            if (AllRes != null)
            {
                foreach (QuizResultItem r in AllRes)
                {
                    if (_finalScore <= r.MaximumScore && _finalScore >= r.MinimumScore)
                    {
                        _returnRes = r;
                    }
                }
            }
            return _returnRes;
        }
        protected void rptCorrectCheck_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                KnowledgeQuizQuestion _CurrentQAns = e.Item.DataItem as KnowledgeQuizQuestion;
                if (_CurrentQAns.Question.QuestionType.Raw.ToLower().Contains("boolean"))
                {
                    if(_CurrentQAns.UserAnswerBool==_CurrentQAns.ActualAnsBool)
                    {
                        PlaceHolder phCorrect=e.FindControlAs<PlaceHolder>("phCorrect");
                        if (phCorrect!=null)
                        {
                            phCorrect.Visible=true;
                        }
                    }
                   else
                    {
                       PlaceHolder phIncorrect=e.FindControlAs<PlaceHolder>("phIncorrect");
                        if(phIncorrect!=null)
                        {
                            phIncorrect.Visible=true;
                        }
                    }
                 
                }
                if (_CurrentQAns.Question.QuestionType.Raw.ToLower().Contains("option") || _CurrentQAns.Question.QuestionType.Raw.ToLower().Contains("drop down"))
                {
                    if(_CurrentQAns.ActualAnswerObject==_CurrentQAns.UserdAnswerObject)
                    {   PlaceHolder phCorrect=e.FindControlAs<PlaceHolder>("phCorrect");
                        if (phCorrect!=null)
                        {
                            phCorrect.Visible=true;
                        }
                    }
                   else
                    {
                       PlaceHolder phIncorrect=e.FindControlAs<PlaceHolder>("phIncorrect");
                        if(phIncorrect!=null)
                        {
                            phIncorrect.Visible=true;
                        }
                    }

                }
                }

            }
        }
    }
