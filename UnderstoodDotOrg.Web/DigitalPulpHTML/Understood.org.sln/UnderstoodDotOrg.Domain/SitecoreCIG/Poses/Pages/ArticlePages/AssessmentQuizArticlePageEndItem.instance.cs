using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.BaseforQuiz;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class AssessmentQuizArticlePageEndItem 
{
    public static IEnumerable<QuizResultItem> GetAllResults(AssessmentQuizArticlePageEndItem CurrentQuizE)
    {
        IEnumerable<QuizResultItem> AllSlideItems = CurrentQuizE.AllResults;
        return AllSlideItems;
    }
    private IEnumerable<QuizResultItem> _allRs;
    private IEnumerable<QuizResultItem> AllResults
    {
        get
        {
            if (_allRs == null)
            {
                _allRs = this.InnerItem.GetChildren()
               .Where(t => t.TemplateID.ToString() == QuizResultItem.TemplateId.ToString())
               .Select(x => new QuizResultItem(x));
            }
            return _allRs;
        }
    }
}
}