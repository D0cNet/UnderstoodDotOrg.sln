using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic
{
    public partial class CalloutContainer : BaseSublayout<TopicLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Model.EventWidget.Item != null)
            {
                slUpcomingEvent.DataSource = Model.EventWidget.Item.ID.ToString();
            }

            BindRecommendedQuestion();
        }

        private void BindRecommendedQuestion()
        {
            List<RecommendationQuestionItem> questions = MainsectionItem.GetGlobals().GetRecommendationsFolder().InnerItem.Children.Select(i => (RecommendationQuestionItem)i).ToList();

            RecommendationQuestionItem theQuestion = questions.Shuffle().ToList().FirstOrDefault();

            if (theQuestion != null)
            {
                hypCompleteProfile.Text = theQuestion.ButtonText;
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