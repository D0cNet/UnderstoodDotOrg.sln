using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsResultListing : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        protected string[] SpelledNumbers = new[] { "zero", "one", "two", "three", "four", "five" };

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Dictionary Constants
            lblAboutOurRatingSystem.Text = DictionaryConstants.AboutOurRatingSystemLabel;
			lblBestFragment.Text = DictionaryConstants.BestFragment;
			lblContentIsAppropriate.Text = DictionaryConstants.ContentIsAppropriateLabel;
			lblDisappointing.Text = DictionaryConstants.DisappointingLabel;
			lblDontBother.Text = DictionaryConstants.DontBotherLabel;
			lblEngaging.Text = DictionaryConstants.EngagingLabel;
			lblFairFragment.Text = DictionaryConstants.Fairfragment;
			lblGoodFragment.Text = DictionaryConstants.Goodfragment;
			lblGrade.Text = DictionaryConstants.GradeLabel;
			lblGrade1.Text = DictionaryConstants.GradeLabel;
			lblJustFine.Text = DictionaryConstants.GradeLabel;
			lblKnowYourChild.Text = DictionaryConstants.KnowYourChildLabel;
			lblLearningFragment.Text = DictionaryConstants.Learningfragment;
			lblLearningFragment1.Text = DictionaryConstants.Learningfragment;
			lblMoreInformation.Text = DictionaryConstants.MoreInformationLabel;
			lblMoreInformation1.Text = DictionaryConstants.MoreInformationLabel;
			lblMoreInformation2.Text = DictionaryConstants.MoreInformationLabel;
			lblNotAgeAppropriate.Text = DictionaryConstants.NotAgeAppropriateLabel;
			lblNotAppropriate.Text = DictionaryConstants.NotAppropriateLabel;
			lblNotForKidsFragment.Text = DictionaryConstants.NotAppropriateLabel;
			lblNotForLearningFragment.Text = DictionaryConstants.NotForLearningfragment;
			lblNotRecommended.Text = DictionaryConstants.NotRecommendedLabel;
			lblOffFragment.Text = DictionaryConstants.OffFragment;
			lblOnFragment.Text = DictionaryConstants.Onfragment;
			lblPauseFragment.Text = DictionaryConstants.Pausefragment;
			lblPrettyEngaging.Text = DictionaryConstants.PrettyEngagingLabel;
			lblQuality.Text = DictionaryConstants.QualityLabel;
			lblQuality1.Text = DictionaryConstants.QualityLabel;
			lblQualityRating.Text = DictionaryConstants.QualityRatingLabel;
			lblReallyEngaging.Text = DictionaryConstants.ReallyEngagingLabel;
			lblReallyGood.Text = DictionaryConstants.ReallyGoodLabel;
			lblSearch.Text = DictionaryConstants.SearchLabel;
			lblSeeRating.Text = DictionaryConstants.SeeRatingLabel;
			lblSomewhatEngaging.Text = DictionaryConstants.SomewhatEngagingLabel;
			lblTheBest.Text = DictionaryConstants.TheBestLabel;
			lblVeryGoodFragment.Text = DictionaryConstants.VeryGoodfragment;
            #endregion

            var screenshots = Model.Screenshots.ListItems
                .Where(i => i != null && i.Paths.IsMediaItem)
                .Select(i => (MediaItem)i);

            rptrScreenshots.DataSource = screenshots
                .Select(mi => new
                {
                    Alt = mi.Alt,
                    Url = mi.GetImageUrl()
                }).ToList();
            rptrScreenshots.DataBind();

            var appropriateGrades = Enumerable.Range(1, 12)
                .Select(i => new
                {
                    Grade = i,
                    Color = i <= Model.OffGrade ? "red" : i < Model.OnGrade ? "yellow" : "green"
                });

            rptrAppropriateGrades.DataSource = appropriateGrades;
            rptrAppropriateGrades.DataBind();

            rptrAppropriateGrades2.DataSource = appropriateGrades;
            rptrAppropriateGrades2.DataBind();

            var subjects = Model.Subjects.ListItems
                .Where(i => i != null && i.IsOfType(AssistiveToolsSubjectItem.TemplateId))
                .Select(i => (AssistiveToolsSubjectItem)i).ToList();

            rptrSubjects.DataSource = subjects;
            rptrSubjects.DataBind();

            litNumReviews.Text = CSMUserReviewExtensions.GetReviews(Model.ID.ToGuid()).Count().ToString();
        }

        protected string GetSpelledNumber(int index)
        {
            return index >= 0 && index < SpelledNumbers.Length ? SpelledNumbers[index] : "zero";
        }
    }
}