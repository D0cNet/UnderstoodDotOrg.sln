using System;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using System.Collections.Generic;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common;
using System.Web;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class ExpertsDetailPage : BaseSublayout<ExpertDetailPageItem>
    {
        protected string EventTimeframe { get; set; }

        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
            BindControls();
        }

        private void BindEvents()
        {
            rptEvents.ItemDataBound += rptEvents_ItemDataBound;
        }

        private void BindContent()
        {
            IEnumerable<DefaultArticlePageItem> articles = SearchHelper.GetArticlesByAuthor(Sitecore.Context.Item.ID, 2);

            if (articles.Count() > 0)
            {
                rptAuthorArticles.DataSource = articles;
                rptAuthorArticles.DataBind();
            }
            else
                relatedArticlesDiv.Visible = false;
            imgExpert.ImageUrl = Model.GetThumbnailUrl(189, 189);
        }

        private void BindControls()
        {
            var upcoming = SearchHelper.GetExpertsUpcomingEvents(Sitecore.Context.Item.ID, 2);
            if (upcoming.Any())
            {
                EventTimeframe = "future";
                rptEvents.DataSource = upcoming;
                rptEvents.DataBind();
                return;
            }
            else
            {
                var archived = SearchHelper.GetExpertsArchivedEvents(Sitecore.Context.Item.ID, 2);
                if (archived.Any())
                {
                    rptEvents.DataSource = archived;
                    rptEvents.DataBind();
                    EventTimeframe = "past";
                    return;
                }
            }

            phEvents.Visible = false;
        }

        void rptEvents_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                BaseEventDetailPageItem item = (BaseEventDetailPageItem)e.Item.DataItem;

                PlaceHolder phLinksCta = e.FindControlAs<PlaceHolder>("phLinksCta");
                phLinksCta.Visible = item.IsUpcoming();

                HyperLink hlExpertImage = e.FindControlAs<HyperLink>("hlExpertImage");
                HyperLink hlEventDetails = e.FindControlAs<HyperLink>("hlEventDetails");
                HyperLink hlEventTitle = e.FindControlAs<HyperLink>("hlEventTitle");
                hlExpertImage.NavigateUrl = hlEventDetails.NavigateUrl 
                    = hlEventTitle.NavigateUrl = item.GetUrl();

                Literal litEventDate = e.FindControlAs<Literal>("litEventDate");
                litEventDate.Text = item.GetFormattedEventStartDate();

                Literal litEventDatePast = e.FindControlAs<Literal>("litEventDatePast");
                litEventDatePast.Text = item.GetFormattedArchiveEventDate();

                Literal litEventType = e.FindControlAs<Literal>("litEventType");
                litEventType.Text = item.GetEventType();

                FieldRenderer frEventTitle = e.FindControlAs<FieldRenderer>("frEventTitle");
                FieldRenderer frRsvpLink = e.FindControlAs<FieldRenderer>("frRsvpLink");
                FieldRenderer frEventHeading = e.FindControlAs<FieldRenderer>("frEventHeading");
                FieldRenderer frEventSubheading = e.FindControlAs<FieldRenderer>("frEventSubheading");
                frEventTitle.Item = frRsvpLink.Item = frEventHeading.Item = frEventSubheading.Item = item;

                ExpertDetailPageItem expert = item.Expert.Item;
                if (expert != null)
                {
                    System.Web.UI.WebControls.Image imgExpert = e.FindControlAs<System.Web.UI.WebControls.Image>("imgExpert");
                    imgExpert.ImageUrl = expert.GetThumbnailUrl(230, 129);
                }
            }
        }

        protected void rptAuthorArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem article = (DefaultArticlePageItem)e.Item.DataItem;

                if (article != null)
                {
                    HyperLink hypImageLink = e.FindControlAs<HyperLink>("hypImageLink");
                    HyperLink hypAuthor = e.FindControlAs<HyperLink>("hypAuthor");
                    HyperLink hypReadMore = e.FindControlAs<HyperLink>("hypReadMore");
                    Literal litCommentCount = e.FindControlAs<Literal>("litCommentCount");
                    Literal litArticleTitle = e.FindControlAs<Literal>("litArticleTitle");
                    Literal litDatePosted = e.FindControlAs<Literal>("litDatePosted");
                    Literal litAbstract = e.FindControlAs<Literal>("litAbstract");
                    ArticleRecommendationIcons articleRecommendationIcons = e.FindControlAs<ArticleRecommendationIcons>("articleRecommendationIcons");

                    if (article.AuthorName.Item != null)
                    {
                        hypAuthor.Text = article.AuthorName.Item.DisplayName;
                        hypAuthor.NavigateUrl = Sitecore.Context.Item.GetUrl();

                        hypImageLink.NavigateUrl = hypReadMore.NavigateUrl = article.GetUrl();
                        hypImageLink.ImageUrl = article.GetArticleThumbnailUrl(230, 129);

                        litArticleTitle.Text = article.DisplayName;
                        litDatePosted.Text = article.InnerItem.Statistics.Created.ToString("mm dd, yyyy");
                        litAbstract.Text = UnderstoodDotOrg.Common.Helpers.TextHelper.TruncateText(
                            Sitecore.StringUtil.RemoveTags(HttpUtility.HtmlDecode(article.ContentPage.BodyContent.Raw)), 150);

                        bool hasMoreResults;
                        int totalComments;

                        List<Comment> dataSource = TelligentService.ReadComments(
                            article.BlogId.ToString(), article.BlogPostId.ToString(), 1, Constants.ARTICLE_COMMENTS_PER_PAGE, "CreatedUtcDate", true, out totalComments, out hasMoreResults);

                        litCommentCount.Text = totalComments.ToString();

                        if (IsUserLoggedIn)
                        {
                            articleRecommendationIcons.HasMatchingParentInterest = article.HasMatchingParentInterest(CurrentMember);
                            articleRecommendationIcons.MatchingChildrenIds = article.GetMatchingChildrenIds(CurrentMember);
                        }
                    }
                    else
                        e.Item.Visible = false;
                }
            }
        }
    }
}