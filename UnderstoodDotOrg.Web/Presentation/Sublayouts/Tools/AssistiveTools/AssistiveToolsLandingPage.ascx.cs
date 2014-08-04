using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using Sitecore;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.CommonSenseMedia.CSMReviews;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsLandingPage : BaseSublayout<AssistiveToolsLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litRelatedArticles.Text = DictionaryConstants.RelatedArticlesLabel;
            litWhatParentsAreSaying.Text = DictionaryConstants.WhatParentsAreSayingLabel;

            BindUserReviews();
            BindRelatedArticles();
        }

        protected void BindUserReviews()
        {
            // TODO: don't retrieve all reviews
            var reviews = CSMUserReviewExtensions.GetRecentReviews()
                    .Select(userReview =>
                    {
                        AssistiveToolsReviewPageItem item = (AssistiveToolsReviewPageItem)Sitecore.Context.Database.GetItem(userReview.CSMItemId);
                        var url = item.GetUrl();
                        var grade = Sitecore.Context.Database.GetItemAs<GradeLevelItem>(userReview.RatedGradeId);
                        var comment = TelligentService.ReadComments(item.BlogId, item.BlogPostId).Where(i => new Guid(i.CommentId).ToString() == userReview.TelligentCommentId.ToString()).FirstOrDefault();
                        var processedBody = comment != null && !string.IsNullOrEmpty(comment.Body) && comment.Body.Length > 100 ?
                            ""
                                .TakeWhile((c, i) => i < comment.Body.Length && (i < 100 || Char.IsLetter(c))) :
                            comment.Body;
                        var reviewBody = processedBody != null && processedBody.Any() ? new String(processedBody.ToArray()) : string.Empty;

                        return new
                        {
                            Title = userReview.ReviewTitle,
                            ReviewText = "<p>" + Sitecore.StringUtil.RemoveTags(reviewBody) + "...<a href=\"" + url + "\">" + DictionaryConstants.ReadMoreLabel + "</a></p>",
                            RatingHtml = GetRatingHTML(userReview.Rating),
                            Url = url,
                            LinkText = (grade != null ? grade.Name.Raw + " & " : string.Empty) +
                                string.Join(" & ", userReview.UserReviewIssues.Select(i => i.ContentTitle.Raw))
                        };
                    });

            if (reviews.Count() > 0)
            {
                rptrWhatParentsAreSaying.DataSource = reviews;
                rptrWhatParentsAreSaying.DataBind();
            }
            else
            {
                divParentReviews.Visible = false;
            }
        }

        protected void BindRelatedArticles()
        {
            var relatedArticles = Model.RelatedArticles.ListItems
                .Where(i => i != null && i.InheritsFromType(DefaultArticlePageItem.TemplateId))
                .Select(i => (DefaultArticlePageItem)i);

            rptrFeaturedArticles.DataSource = relatedArticles;
            rptrFeaturedArticles.ItemDataBound += rptrFeaturedArticles_ItemDataBound;
            rptrFeaturedArticles.DataBind();
        }

        void rptrFeaturedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var article = e.Item.DataItem as DefaultArticlePageItem;
                System.Web.UI.WebControls.Image imgThumbnail = e.FindControlAs<System.Web.UI.WebControls.Image>("imgThumbnail");
                imgThumbnail.ImageUrl = article.GetArticleThumbnailUrl(230, 129);
            }
        }

        protected string GetRatingHTML(int rating)
        {
            if (rating == 1)
            {
                return "<div class='results-slider blue-one' aria-label='1'>1</div>";
            }
            else if (rating == 2)
            {
                return "<div class='results-slider blue-two' aria-label='2'>2</div>";
            }
            else if (rating == 3)
            {
                return "<div class='results-slider blue-three' aria-label='3'>3</div>";
            }
            else if (rating == 4)
            {
                return "<div class='results-slider blue-four' aria-label='4'>4</div>";
            }
            else if (rating == 5)
            {
                return "<div class='results-slider blue-five' aria-label='5'>5</div>";
            }
            else
            {
                return "<div class='results-slider blue-zero' aria-label='0'>0</div>";
            }
        }
    }
}