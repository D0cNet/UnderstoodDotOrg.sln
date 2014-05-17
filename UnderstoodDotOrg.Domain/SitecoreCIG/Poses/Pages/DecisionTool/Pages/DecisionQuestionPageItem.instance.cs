using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.DecisionTool;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages
{
    public partial class DecisionQuestionPageItem
    {
        public DecisionAnswersFolderItem GetAnswersFolder()
        {
            return InnerItem.Children
                .FirstOrDefault(i => i.IsOfType(DecisionAnswersFolderItem.TemplateId));
        }

        public IEnumerable<DecisionAnswerItem> GetAnswers()
        {
            var answersFolder = GetAnswersFolder();
            return answersFolder != null ? answersFolder.GetAnswers() : null;
        }

        public DecisionIndicationQuestionsFolderItem GetIndicationQuestionsFolder()
        {
            return InnerItem.Children
                .FirstOrDefault(i => i.IsOfType(DecisionIndicationQuestionsFolderItem.TemplateId));
        }

        public IEnumerable<DecisionIndicationQuestionItem> GetIndicationQuestions()
        {
            var indicationQuestionsFolder = GetIndicationQuestionsFolder();
            return indicationQuestionsFolder != null ? indicationQuestionsFolder.GetIndicationQuestions() : null;
        }

        public DecisionToolLandingPageItem GetDecisionToolLandingPage()
        {
            return Sitecore.Context.Item.Parent.Parent;
        }
    }
}