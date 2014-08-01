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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsReviewDetails : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        protected string[] SpelledNumbers = new [] { "zero", "one", "two", "three", "four", "five" };

        protected void Page_Load(object sender, EventArgs e) 
        {
            if (Session["Search Query"] != null)
            {
                anchorBackLink.Attributes.Add("href", Session["Search Query"].ToString());
                Session["Search Query"] = null;
                lblBackToResults.Text = DictionaryConstants.BackToResultsLabel;
            }
            else
                arrowDiv.Visible = false;

            AssistiveToolsSearchResultsPageItem searchPage = MainsectionItem.GetHomePageItem().GetToolsPage().GetAssistiveToolsLandingPage().GetSearchPage();

            frSponsorImage.Item = searchPage.InnerItem.Parent;
            frRandRby.Item = searchPage.InnerItem.Parent;
            AppleImage.Item = searchPage.InnerItem.Parent;
            GoogleImage.Item = searchPage.InnerItem.Parent;

			lblAboutOurRatingSystem.Text = DictionaryConstants.AboutOurRatingSystemLabel;
			lblBestFragment.Text = DictionaryConstants.BestFragment;
			lblContentIsAppropriate.Text = DictionaryConstants.ContentIsAppropriateLabel;
			lblDisappointing.Text = DictionaryConstants.DisappointingLabel;
			lblDontBother.Text = DictionaryConstants.DontBotherLabel;
			lblEngaging.Text = DictionaryConstants.EngagingLabel;
			lblFairFragment.Text = DictionaryConstants.Fairfragment;
			lblGoodFragment.Text = DictionaryConstants.Goodfragment;
			lblGrade.Text = DictionaryConstants.GradeLabel;
			lblJustFine.Text = DictionaryConstants.JustFineLabel;
			lblKnowYourChild.Text = DictionaryConstants.KnowYourChildLabel;
			lblMoreInfo.Text = DictionaryConstants.MoreInformationLabel;
			lblMoreInformation.Text = DictionaryConstants.MoreInformationLabel;
			lblMoreInformation1.Text = DictionaryConstants.MoreInformationLabel;
			lblNotAgeAppropriate.Text = DictionaryConstants.NotAgeAppropriateLabel;
			lblNotAppropriate.Text = DictionaryConstants.NotAppropriateLabel;
			lblNotForKidsFragment.Text = DictionaryConstants.NotAppropriateLabel;
			lblNotForLearningFragment.Text = DictionaryConstants.NotForLearningfragment;
			lblNotRecommended.Text = DictionaryConstants.NotRecommendedLabel;
			lblOffFragment.Text = DictionaryConstants.OffFragment;
			lblOnFragment.Text = DictionaryConstants.OnRatingLabel;
			lblPauseFragment.Text = DictionaryConstants.Pausefragment;
			lblPrettyEngaging.Text = DictionaryConstants.PrettyEngagingLabel;
			lblQuality.Text = DictionaryConstants.QualityLabel;
			lblQualityRating.Text = DictionaryConstants.QualityRatingLabel;
			lblReallyEngaging.Text = DictionaryConstants.ReallyEngagingLabel;
			lblReallyGood.Text = DictionaryConstants.ReallyGoodLabel;
			lblSomewhatEngaging.Text = DictionaryConstants.SomewhatEngagingLabel;
			lblTheBest.Text = DictionaryConstants.TheBestLabel;
			lblVeryGoodFragment.Text = DictionaryConstants.VeryGoodfragment;

            var screenshots = Model.Screenshots.ListItems
                .Where(i => i != null && i.Paths.IsMediaItem)
                .Select(i => (MediaItem)i);

            rptrScreenshots.DataSource = screenshots
                .Select(mi => new { Alt = mi.Alt, Url = mi.GetImageUrl() }).ToList();
            rptrScreenshots.DataBind();

            var appropriateGrades = Enumerable.Range(1, 12)
                .Select(i => new
                {
                    Grade = i,
                    Color = i <= Model.OffGrade ? "red" : i < Model.OnGrade ? "yellow" : "green"
                });

            rptrAppropriateGrades.DataSource = appropriateGrades;
            rptrAppropriateGrades.DataBind();

            var subjects = Model.Subjects.ListItems
                .Where(i => i != null && i.IsOfType(AssistiveToolsSubjectItem.TemplateId))
                .Select(i => (AssistiveToolsSubjectItem)i).ToList();

            rptrSubjects.DataSource = subjects;
            rptrSubjects.DataBind();
        }

        protected string GetSpelledNumber(int index)
        {
            return SpelledNumbers.Length > index ? SpelledNumbers[index] : "zero";
        }
    }
}