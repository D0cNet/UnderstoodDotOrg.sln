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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsLandingPage : BaseSublayout<AssistiveToolsLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblRelatedArticles.Text = DictionaryConstants.RelatedArticlesLabel;
            lblWhatParentsAreSaying.Text = DictionaryConstants.WhatParentsAreSayingLabel;

            var reviewItems = AssistiveToolsSearchResultsPageItem.GetSearchResults(searchTerm: "*");
            var reviews = reviewItems
                .SelectMany(item => CSMUserReviewExtensions.GetReviews(Sitecore.Context.Item.ID.ToGuid())
                    .Select(userReview =>
                    {
                        var url = item.GetUrl();
                        var grade = Sitecore.Context.Database.GetItemAs<GradeLevelItem>(userReview.RatedGradeId);
                        return new
                        {
                            Title = item.Title.Rendered,
                            ReviewText = userReview.ReviewBody
                                .TakeWhile((c, i) => i < userReview.ReviewBody.Length && (i < 100 || Char.IsLetter(c)))
                                .Concat("...<a href=\"" + url + "\">Read more</a>"),
                            RatingHtml = GetRatingHTML(userReview.Rating),
                            Url = url,
                            LinkText = (grade != null ? grade.Name.Raw + " & " : string.Empty) +
                                string.Join(" & ", userReview.UserReviewIssues.Select(i => i.ContentTitle.Raw))
                        };
                    }));

            rptrWhatParentsAreSaying.DataSource = reviews;
            rptrWhatParentsAreSaying.DataBind();
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