using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool;
using System.Web.UI.HtmlControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages.ReviewData;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs
{
    public partial class ParentReviewsTab : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CSMUserReview> reviews = CSMUserReviewExtensions.GetReviews(new Guid("E6819FC9-8F50-4708-96F5-6737CC53BDA2"));

            rptReviews.DataSource = reviews;
            rptReviews.DataBind();

            ddlGrades.DataSource = FormHelper.GetGrades(DictionaryConstants.SelectGradeLabel);
            ddlGrades.DataTextField = "Text";
            ddlGrades.DataValueField = "Value";
            ddlGrades.DataBind();

            AssistiveToolsSkillFolderItem skillsFolder = MainsectionItem.GetGlobals().GetToolsFolder();
            rptSkillsChecklist.DataSource = skillsFolder.InnerItem.Children;
            rptSkillsChecklist.DataBind();
        }

        protected void rptReviews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CSMUserReview review = e.Item.DataItem as CSMUserReview;

            Literal litRating = e.FindControlAs<Literal>("litRating");
            Literal litGrade = e.FindControlAs<Literal>("litGrade");
            Literal litReviewDate = e.FindControlAs<Literal>("litReviewDate");

            if (litRating != null)
            {
                if (review.Rating == 1)
                    litRating.Text = "<div class='results-slider blue-one' aria-label='1'>1</div>";
                else if (review.Rating == 2)
                    litRating.Text = "<div class='results-slider blue-two' aria-label='2'>2</div>";
                else if (review.Rating == 3)
                    litRating.Text = "<div class='results-slider blue-three' aria-label='3'>3</div>";
                else if (review.Rating == 4)
                    litRating.Text = "<div class='results-slider blue-four' aria-label='4'>4</div>";
                else
                    litRating.Text = "<div class='results-slider blue-five' aria-label='5'>5</div>";
            }

            if (litGrade != null)
                litGrade.Text = review.GradeAppropriateness.ToString();

            if (litReviewDate != null)
                litReviewDate.Text = review.Created.ToString("MMMM dd, yyyy");


        }

        protected void rptSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void rptSkillsChecklist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item skill = e.Item.DataItem as Item;

                Literal litSkill = e.FindControlAs<Literal>("litSkill");
                HtmlInputCheckBox inputSkill = e.FindControlAs<HtmlInputCheckBox>("inputSkill");

                inputSkill.Attributes.Add("data-id", skill.ID.ToString());
                litSkill.Text = skill.DisplayName;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                CSMUserReview review = new CSMUserReview();
                AssistiveToolsReviewPageItem page = Sitecore.Context.Item;

                if (hfRating.Value != null)
                    review.Rating = Int32.Parse(hfRating.Value);

                GradeLevelItem grade = Sitecore.Context.Database.GetItem(ddlGrades.SelectedValue);

                if (grade != null)
                {
                    review.GradeAppropriateness = grade.GradeNumber;
                    review.RatedGradeId = grade.ID.ToGuid();
                }

                if (txbReviewTitle.Text != null)
                    review.ReviewTitle = txbReviewTitle.Text;

                if (txbWhatYouThink != null)
                    review.ReviewBody = txbWhatYouThink.Text;

                review.CSMItemId = page.ID.ToGuid();
                review.MemberId = CurrentMember.MemberId;

                CSMUserReviewExtensions.InsertNewReview(review);
            }
        }
    }
}