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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class AssessmentQuizArticlePageEnd : System.Web.UI.UserControl
    {
        AssessmentQuizArticlePageEndItem ObjAssessmentEndPage;
        List<AssessmentQuizScorePage1> _AssessmentQuiz_Page1Score;
        List<AssessmentQuizScorePage2> _AssessmentQuiz_Page2Score;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAssessmentEndPage = new AssessmentQuizArticlePageEndItem(Sitecore.Context.Item);
            if (ObjAssessmentEndPage != null)
            {
                //Get Reviewer Name
                if (ObjAssessmentEndPage.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjAssessmentEndPage.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjAssessmentEndPage.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }
                IEnumerable<QuizResultItem> _allResults = AssessmentQuizArticlePageEndItem.GetAllResults(ObjAssessmentEndPage);
                if (_allResults != null)
                {
                    if (Session["_AssessmentQuiz_Page1Score"] == null)
                    {
                        if (Session["AssessmentPage1Item"] != null)
                        {
                            AssessmentQuizArticlePage1Item ObjPage1 = (AssessmentQuizArticlePage1Item)Session["AssessmentPage1Item"];
                            if (ObjPage1 != null)
                            {
                                Response.Redirect(string.Concat( "http://",Request.Url.Host.ToString(),ObjPage1.InnerItem.GetUrl()));
                            }
                            
                        }
                        

                    }
                    if (Session["_AssessmentQuiz_Page2Score"] == null)
                    {
                        if (Session["AssessmentPage2Item"] != null)
                        {
                            AssessmentQuizArticlePage2Item ObjPage2 = (AssessmentQuizArticlePage2Item)Session["AssessmentPage1Item"];
                            if (ObjPage2 != null)
                            {
                                Response.Redirect(string.Concat( "http://",Request.Url.Host.ToString(),ObjPage2.InnerItem.GetUrl()));
                            }
                            
                        }
                    }
                    int _FinalScore = 0;
                    if (Session["_AssessmentQuiz_Page1Score"] != null)
                    {
                        //Get Page 1 score
                        _AssessmentQuiz_Page1Score = (List<AssessmentQuizScorePage1>)Session["_AssessmentQuiz_Page1Score"];
                        if (_AssessmentQuiz_Page1Score != null)
                        {
                            foreach (AssessmentQuizScorePage1 p1 in _AssessmentQuiz_Page1Score)
                            {
                                if (p1 != null) _FinalScore += p1.Score;
                            }
                        }

                    }
                    if (Session["_AssessmentQuiz_Page2Score"] != null)
                    {
                        //Get Page 1 score
                        _AssessmentQuiz_Page2Score = (List<AssessmentQuizScorePage2>)Session["_AssessmentQuiz_Page2Score"];
                        if (_AssessmentQuiz_Page2Score != null)
                        {
                            foreach (AssessmentQuizScorePage2 p2 in _AssessmentQuiz_Page2Score)
                            {
                                if (p2 != null) _FinalScore += p2.Score;
                            }
                        }
                    }

                    foreach (QuizResultItem r in _allResults)
                    {
                        if (_FinalScore <= r.MaximumScore && _FinalScore >= r.MinimumScore)
                        {
                            frQuizIntro.Item = r;
                            frResultTitle.Item = r;
                            frResultDesc.Item = r;
                        }
                    }
                }
            }
        }
    }
}