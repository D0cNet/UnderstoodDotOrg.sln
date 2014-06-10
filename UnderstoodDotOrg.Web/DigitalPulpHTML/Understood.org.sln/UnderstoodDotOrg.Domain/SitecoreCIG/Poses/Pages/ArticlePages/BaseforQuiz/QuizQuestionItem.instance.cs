using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web;

using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;


namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz
{
    public partial class QuizQuestionItem
    {
        public static IEnumerable<QuizAnswersItem> GetAllAnswers(QuizQuestionItem CurrentQ)
        {
            IEnumerable<QuizAnswersItem> AllSlideItems = CurrentQ.AllAnswers;
            return AllSlideItems;
        }
        private IEnumerable<QuizAnswersItem> _allAns;
        private IEnumerable<QuizAnswersItem> AllAnswers
        {
            get
            {
                if (_allAns == null)
                {
                    _allAns = this.InnerItem.GetChildren()
                   .Where(t => t.TemplateID.ToString() == QuizAnswersItem.TemplateId.ToString())
                   .Select(x => new QuizAnswersItem(x));
                }
                return _allAns;
            }
        }
        //Get Question Style 
        // private string _quizQuestionStyleFolder = "{DF0BD986-B886-451C-9029-A6BC42FB1B0F}";
        //public static IEnumerable<MetadataItem> GetQuestionStyles(QuizQuestionItem CurrentQuiz1)
        //{

        //    IEnumerable<MetadataItem> AllSlideItems = CurrentQuiz1.AllQuestionStyles;
        //    return AllSlideItems;
        //}
        //private IEnumerable<MetadataItem> _allQStyle;
        //private IEnumerable<MetadataItem> AllQuestionStyles
        //{
        //    get
        //    {
        //        if (_allQStyle == null)
        //        {

        //            _allQStyle = this.InnerItem.GetChildren()
        //           .Where(t => t.TemplateID.ToString() == MetadataItem.TemplateId.ToString() &&
        //               this.InnerItem.TemplateID.ToString() == _quizQuestionStyleFolder)
        //           .Select(x => new MetadataItem(x));
        //        }
        //        return _allQStyle;
        //    }
        //}

      

    }
}