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
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs
{
    public partial class ParentReviewsTab : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        public AssistiveToolsReviewPageItem pageItem = Sitecore.Context.Item;
        public List<Comment> comments;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<CSMUserReview> reviews = CSMUserReviewExtensions.GetReviews(Sitecore.Context.Item.ID.ToGuid());

            comments = TelligentService.ReadComments(pageItem.BlogId, pageItem.BlogPostId);

            rptReviews.DataSource = reviews;
            rptReviews.DataBind();

            if (!IsPostBack)
            {
                ddlGrades.DataSource = FormHelper.GetGrades(DictionaryConstants.SelectGradeLabel);
                ddlGrades.DataTextField = "Text";
                ddlGrades.DataValueField = "Value";
                ddlGrades.DataBind();
            }

            AssistiveToolsSkillFolderItem skillsFolder = MainsectionItem.GetGlobals().GetSkillsFolder();
            rptSkillsChecklist.DataSource = skillsFolder.InnerItem.Children;
            rptSkillsChecklist.DataBind();
        }

        protected void rptReviews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            CSMUserReview review = e.Item.DataItem as CSMUserReview;

            if (review != null)
            {

                Literal litRating = e.FindControlAs<Literal>("litRating");
                Literal litGrade = e.FindControlAs<Literal>("litGrade");
                Literal litReviewDate = e.FindControlAs<Literal>("litReviewDate");
                Literal litReviewContent = e.FindControlAs<Literal>("litReviewContent");
                Repeater rptSkills = e.FindControlAs<Repeater>("rptSkills");
                Literal litTitle = e.FindControlAs<Literal>("litTitle");

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

                if (litReviewContent != null)
                {
                    litReviewContent.Text = comments.Where(i => new Guid(i.CommentId).ToString() == review.TelligentCommentId.ToString()).FirstOrDefault().Body;
                }

                if (litTitle != null)
                    litTitle.Text = review.ReviewTitle;

                if (review.UserReviewSkills.Count > 0)
                {
                    rptSkills.DataSource = review.UserReviewSkills;
                    rptSkills.DataBind();
                }
            }
        }

        protected void rptSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            AssistiveToolsSkillItem skill = e.Item.DataItem as AssistiveToolsSkillItem;

            if (skill != null)
            {
                Literal litSkill = e.FindControlAs<Literal>("litSkill");

                litSkill.Text = skill.DisplayName;
            }
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

                if (hfRating.Value != null)
                    review.Rating = Int32.Parse(hfRating.Value);

                if (hfKeyValuePairs.Value != null)
                {
                    string[] IDs = hfKeyValuePairs.Value.Split('|');

                    foreach (string s in IDs)
                    {
                        review.UserReviewSkills.Add(new AssistiveToolsSkillItem(Sitecore.Context.Database.GetItem(new Guid(s))));
                    }
                }

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

                review.CSMItemId = pageItem.ID.ToGuid();
                review.MemberId = CurrentMember.MemberId;
                review.BlogPostId = pageItem.BlogPostId;
                review.BlogId = pageItem.BlogId;
                review.ContentId = pageItem.ContentId;
                review.UserScreenName = CurrentMember.ScreenName;

                try
                {
                    CSMUserReviewExtensions.InsertNewReview(review);
                }
                catch
                {
                    string url = MyAccountFolderItem.GetSignUpPage();
                    Response.Redirect(url);
                }
            }
        }
    }
}