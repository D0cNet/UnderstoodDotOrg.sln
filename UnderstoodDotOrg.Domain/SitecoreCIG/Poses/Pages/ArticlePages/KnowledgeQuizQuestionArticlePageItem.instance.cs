using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;
using CustomItemGenerator.Fields.LinkTypes;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
    public partial class KnowledgeQuizQuestionArticlePageItem
    {
        public CustomGeneralLinkField LinktoResultPage
        {
            get
            {
                return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link to Result Page"]);
            }
        }

        public static IEnumerable<QuizQuestionItem> GetAllQuestions(KnowledgeQuizQuestionArticlePageItem CurrentQuiz1)
        {
            IEnumerable<QuizQuestionItem> AllSlideItems = CurrentQuiz1.AllQuestions;
            return AllSlideItems;
        }
        private IEnumerable<QuizQuestionItem> _allQs;
        private IEnumerable<QuizQuestionItem> AllQuestions
        {
            get
            {
                if (_allQs == null)
                {
                    _allQs = this.InnerItem.GetChildren()
                   .Where(t => t.TemplateID.ToString() == QuizQuestionItem.TemplateId.ToString())
                   .Select(x => new QuizQuestionItem(x));
                }
                return _allQs;
            }
        }


    }
}