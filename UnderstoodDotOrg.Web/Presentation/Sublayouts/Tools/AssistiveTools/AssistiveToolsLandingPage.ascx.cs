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
            lblRelatedArticles.Text = DictionaryConstants.RelatedArticlesLabel;
            lblWhatParentsAreSaying.Text = DictionaryConstants.WhatParentsAreSayingLabel;

            BindUserReviews();
            BindRelatedArticles();
        }

        protected void BindUserReviews()
        {
            var reviewItems = AssistiveToolsSearchResultsPageItem.GetSearchResults();
            var reviews = reviewItems
                .SelectMany(item => CSMUserReviewExtensions.GetReviews(item.ID.ToGuid())
                    .Select(userReview =>
                    {
                        var url = item.GetUrl();
                        var grade = Sitecore.Context.Database.GetItemAs<GradeLevelItem>(userReview.RatedGradeId);
                        var comments = TelligentService.ReadComments(item.BlogId, item.BlogPostId);
                        var reviewComment = comments
                            .FirstOrDefault(i => new Guid(i.CommentId) == userReview.TelligentCommentId);
                        var processedBody = reviewComment != null && !string.IsNullOrEmpty(reviewComment.Body) ? 
                            reviewComment.Body
                                .TakeWhile((c, i) => i < reviewComment.Body.Length && (i < 100 || Char.IsLetter(c))) : 
                            null;
                        var reviewBody = processedBody != null && processedBody.Any() ? new String(processedBody.ToArray()) : string.Empty;

                        return new
                        {
                            Title = item.Title.Rendered,
                            ReviewText = reviewBody + "...<a href=\"" + url + "\">Read more</a>",
                            RatingHtml = GetRatingHTML(userReview.Rating),
                            Url = url,
                            LinkText = (grade != null ? grade.Name.Raw + " & " : string.Empty) +
                                string.Join(" & ", userReview.UserReviewIssues.Select(i => i.ContentTitle.Raw))
                        };
                    }));

            rptrWhatParentsAreSaying.DataSource = reviews;
            rptrWhatParentsAreSaying.DataBind();
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
                var frArticleImage = e.FindControlAs<FieldRenderer>("frArticleImage");
                frArticleImage.Item = article.InnerItem;
                frArticleImage.FieldName = article.ContentThumbnail.MediaItem != null ? "Content Thumbnail" : "Featured Image";
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