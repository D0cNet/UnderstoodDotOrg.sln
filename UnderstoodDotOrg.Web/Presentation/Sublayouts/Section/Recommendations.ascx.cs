using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Section {
    public partial class Recommendations : BaseSublayout {

        protected void Page_Load(object sender, EventArgs e) {
            BindRecommendedQuestion();
        }

        private void BindRecommendedQuestion()
        {
            List<RecommendationQuestionItem> questions = MainsectionItem.GetGlobals().GetRecommendationsFolder().InnerItem.Children.Select(i => (RecommendationQuestionItem)i).ToList();

            RecommendationQuestionItem theQuestion = questions.Shuffle().ToList().FirstOrDefault();

            if (theQuestion != null)
            {
                hypCompleteProfile.Text = theQuestion.ButtonText;
                if (IsUserLoggedIn)
                    hypCompleteProfile.NavigateUrl = MainsectionItem.GetHomeItem().GetMyAccountFolder().GetMyProfilePage().GetUrl();
                else
                    hypCompleteProfile.NavigateUrl = MainsectionItem.GetHomeItem().GetUrl() + "?recommend=true";
                litQuestion.Text = theQuestion.Question;
                litQuestionHeader.Text = theQuestion.QuestionHeader;
                litWhyAskContent.Text = theQuestion.WhyAreWeAskingContent;
                litWhyAskHeader.Text = theQuestion.WhyAreWeAskingHeader;
            }
        }
    }
}