using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.LearningTool;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools.ReviewTabs
{
    public partial class ParentReviewsTab : BaseSublayout<AssistiveToolsReviewPageItem>
    {
        public List<Comment> Comments;
        public bool OpenTab = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            Comments = TelligentService.ReadComments(Model.BlogId, Model.BlogPostId);

            if (!IsPostBack)
            {
                BindDropDowns();
                BindReviews();
            }

            AssistiveToolsSkillFolderItem issuesFolder = MainsectionItem.GetGlobals().GetIssuesFolder();
            rptIssuesChecklist.DataSource = issuesFolder.InnerItem.Children.Select(i => (MetadataItem)i);
            rptIssuesChecklist.DataBind();

            litAverageRating.Text = GetRatingHTML(Int32.Parse(CSMUserReviewExtensions.GetAverageRating(Model.ID.ToGuid())));

            rfvGrades.ErrorMessage = DictionaryConstants.ReviewSelectGradeErrorMessage;
            rfvIThinkItIs.ErrorMessage = DictionaryConstants.ReviewIThinkItIsErrorMessaage;
            rfvWhatYouThink.ErrorMessage = DictionaryConstants.ReviewWhatYouThinkErrorMessage; 
            rfvReviewTitle.ErrorMessage = DictionaryConstants.ReviewGiveTitleErrorMessage;
        }

        protected void BindDropDowns()
        {
            ddlGrades.DataSource = FormHelper.GetGrades(DictionaryConstants.SelectGradeLabel);
            ddlGrades.DataTextField = "Text";
            ddlGrades.DataValueField = "Value";
            ddlGrades.DataBind();

            List<ListItem> iThinkItIsItems = new List<ListItem>();

            iThinkItIsItems.Add(new ListItem("Select", "", true));
            iThinkItIsItems.Add(new ListItem("On", "On", true));
            iThinkItIsItems.Add(new ListItem("Off", "Off", true));
            iThinkItIsItems.Add(new ListItem("Pause", "Pause", true));

            ddlIThinkItIs.DataSource = iThinkItIsItems;
            ddlIThinkItIs.DataTextField = "Text";
            ddlIThinkItIs.DataValueField = "Value";
            ddlIThinkItIs.DataBind();

            List<ListItem> sortingOptions = new List<ListItem>();

            sortingOptions.Add(new ListItem("Date: Newest to Oldest", "1", true));
            sortingOptions.Add(new ListItem("Date: Oldest to Newest", "2", true));
            sortingOptions.Add(new ListItem("Rating: Highest to Lowest", "3", true));
            sortingOptions.Add(new ListItem("Rating: Lowest to Highest", "4", true));

            ddlSorting.DataSource = sortingOptions;
            ddlSorting.DataBind();
        }

        protected string GetRatingHTML(int rating)
        {
            if (rating == 1)
                return "<div class='results-slider blue-one' aria-label='1'>1</div>";
            else if (rating == 2)
                return "<div class='results-slider blue-two' aria-label='2'>2</div>";
            else if (rating == 3)
                return "<div class='results-slider blue-three' aria-label='3'>3</div>";
            else if (rating == 4)
                return "<div class='results-slider blue-four' aria-label='4'>4</div>";
            else
                return "<div class='results-slider blue-five' aria-label='5'>5</div>";
        }

        protected void BindReviews()
        {
            List<CSMUserReview> reviews = CSMUserReviewExtensions.GetReviews(Sitecore.Context.Item.ID.ToGuid());

            int totalReviews = GetTotalReviews(reviews);

            if (IsUserLoggedIn)
            {
                if (reviews.Where(i => i.MemberId == CurrentMember.MemberId).Count() > 0)
                {
                    pnlReview.Visible = false;
                    divReviewSideBar.Visible = false;
                }
            }

            if (ddlSorting.SelectedIndex == 0)
                reviews = reviews.OrderBy(i => i.Created).Reverse().ToList();
            else if (ddlSorting.SelectedIndex == 1)
                reviews = reviews.OrderBy(i => i.Created).ToList();
            else if (ddlSorting.SelectedIndex == 2)
                reviews = reviews.OrderBy(i => i.Rating).Reverse().ToList();
            else
                reviews = reviews.OrderBy(i => i.Rating).ToList();

            rptReviews.DataSource = reviews.Take(3);
            rptReviews.DataBind();

            if (reviews.Count > 3)
            {
                rptShowMoreReviews.DataSource = reviews.Skip(3).Take(3);
                rptShowMoreReviews.DataBind();
                pnlMoreLink.Visible = true;
            }

            litNumberOfReviews.Text = totalReviews.ToString() + " Reviews of this App";
        }

        private int GetTotalReviews(List<CSMUserReview> reviews)
        {
            int total = 0;
            foreach (CSMUserReview r in reviews)
            {
                Comment comment = Comments.Where(i => new Guid(i.CommentId).ToString() == r.TelligentCommentId.ToString()).FirstOrDefault();
                if (comment != null && !string.IsNullOrEmpty(comment.Body))
                    total += 1;
            }

            return total;
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
                HtmlAnchor reportAnchor = e.FindControlAs<HtmlAnchor>("reportAnchor");

                if (litRating != null)
                {
                    litRating.Text = GetRatingHTML(review.Rating);
                }

                if (litGrade != null)
                    litGrade.Text = review.GradeAppropriateness.ToString();

                if (litReviewDate != null)
                    litReviewDate.Text = review.Created.ToString("MMMM dd, yyyy");

                if (litReviewContent != null)
                {
                    Comment comment = Comments.Where(i => new Guid(i.CommentId).ToString() == review.TelligentCommentId.ToString()).FirstOrDefault();
                    if(comment != null)
                        litReviewContent.Text = comment.Body;
                    else
                        e.Item.Visible = false;
                }

                if (litTitle != null)
                    litTitle.Text = review.ReviewTitle;

                if (review.UserReviewIssues.Count > 0)
                {
                    rptSkills.DataSource = review.UserReviewIssues;
                    rptSkills.DataBind();
                }

                reportAnchor.Attributes.Add("data-id", review.TelligentCommentId.ToString());
            }
        }

        protected void rptSkills_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            MetadataItem issue = e.Item.DataItem as MetadataItem;

            if (issue != null)
            {
                Literal litSkill = e.FindControlAs<Literal>("litSkill");

                litSkill.Text = issue.ContentTitle;
            }
        }

        protected void rptSkillsChecklist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                MetadataItem issue = e.Item.DataItem as MetadataItem;

                if (issue != null)
                {
                    Literal litSkill = e.FindControlAs<Literal>("litSkill");
                    HtmlInputCheckBox inputSkill = e.FindControlAs<HtmlInputCheckBox>("inputSkill");
                    HtmlGenericControl issueLabel = e.FindControlAs<HtmlGenericControl>("issueLabel");

                    inputSkill.Attributes.Add("data-id", issue.ID.ToString());
                    litSkill.Text = issue.ContentTitle;
                    issueLabel.Attributes.Add("for", inputSkill.ID);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsUserLoggedIn)
            {
                Page.Validate("vlgReviewInputs");

                if (Page.IsValid)
                {
                    CSMUserReview review = new CSMUserReview();

                    if (hfRating.Value != null)
                        review.Rating = Int32.Parse(hfRating.Value);

                    if (!string.IsNullOrEmpty(hfKeyValuePairs.Value))
                    {
                        string[] IDs = hfKeyValuePairs.Value.Split('|');

                        foreach (string s in IDs)
                        {
                            review.UserReviewIssues.Add(new MetadataItem(Sitecore.Context.Database.GetItem(new Guid(s))));
                        }
                    }

                    GradeLevelItem grade = Sitecore.Context.Database.GetItem(ddlGrades.SelectedValue);

                    if (grade != null)
                    {
                        review.GradeAppropriateness = grade.GradeNumber;
                        review.RatedGradeId = grade.ID.ToGuid();
                    }

                    if (txbReviewTitle.Text != null)
                        review.ReviewTitle = Sitecore.StringUtil.RemoveTags(txbReviewTitle.Text);

                    if (txbWhatYouThink != null)
                        review.ReviewBody = Sitecore.StringUtil.RemoveTags(txbWhatYouThink.Text);

                    review.CSMItemId = Model.ID.ToGuid();
                    review.MemberId = CurrentMember.MemberId;
                    review.BlogPostId = Model.BlogPostId;
                    review.BlogId = Model.BlogId;
                    review.ContentId = Model.ContentId;
                    review.UserScreenName = CurrentMember.ScreenName;
                    review.IThinkItIs = ddlIThinkItIs.SelectedValue;

                    try
                    {
                        CSMUserReviewExtensions.InsertNewReview(review);

                        BindReviews();

                        Response.Redirect(Request.RawUrl + "#tabs2-parent-reviews");
                    }
                    catch
                    {
                        //something went wrong
                    }
                }
            }
            else
            {
                Page.Session[Constants.SessionPreviousUrl] = null;
                this.ProfileRedirect(UnderstoodDotOrg.Common.Constants.UserPermission.RegisteredUser);
            }
        }

        protected void reportAnchor_ServerClick(object sender, EventArgs e)
        {
            HtmlAnchor button = sender as HtmlAnchor;

            TelligentService.FlagComment(button.Attributes["data-id"]);
        }

        protected void ddlSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindReviews();
            OpenTab = true;
        }
    }
}