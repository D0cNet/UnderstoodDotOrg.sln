using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.QuizPages
{
    
    public partial class AssesmentQuizPageItem
    {

        public static IEnumerable<QuizQuestionItem> GetAllQuestions(AssesmentQuizPageItem ObjAssessmentQuiz)
        {
            IEnumerable<QuizQuestionItem> AllQuestions = ObjAssessmentQuiz.AllQuestions;//.OrderByDescending(x => x.ActionNumber);
            return AllQuestions;
        }
        private IEnumerable<QuizQuestionItem> _allQuestions;
        private IEnumerable<QuizQuestionItem> AllQuestions
        {
            get
            {
                if (_allQuestions == null)
                {
                    _allQuestions = this.InnerItem.GetChildren()
                        .Where(t => t.TemplateID.ToString() == QuizQuestionItem.TemplateId.ToString())
                        .Select(x => new QuizQuestionItem(x));
                }

                return _allQuestions;
            }
        }


        public static IEnumerable<QuizResultItem> GetAllResults(AssesmentQuizPageItem ObjAssessmentQuiz)
        {
            IEnumerable<QuizResultItem> AllResults = ObjAssessmentQuiz.AllResults;//.OrderByDescending(x => x.ActionNumber);
            return AllResults;
        }
        private IEnumerable<QuizResultItem> _allResults;
        private IEnumerable<QuizResultItem> AllResults
        {
            get
            {
                if (_allResults == null)
                {
                    _allResults = this.InnerItem.GetChildren()
                        .Where(t => t.TemplateID.ToString() == QuizResultItem.TemplateId.ToString())
                        .Select(x => new QuizResultItem(x));
                }

                return _allResults;
            }
        }
      
    }
}  