using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Data.Items;
using Sitecore.Links;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class CommentsSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BasicArticlePageItem article = new BasicArticlePageItem(Sitecore.Context.Item);

            Comment recentComment = null;

            if (String.IsNullOrEmpty(article.DefaultArticlePage.BlogId.Raw)
                || String.IsNullOrEmpty(article.DefaultArticlePage.BlogPostId.Raw))
            {
                 pnlCommentTeaser.Visible = false;
                return;
            }

            try
            {
                //Retrieve ovveride ID from field of current item
                string commentId = article.CommentOverrideID;
                if (!string.IsNullOrEmpty(commentId))
                {
                    recentComment = TelligentService.ReadComment(commentId);
                }
                
                int totalComments;
                bool hasMoreResults;

                if (recentComment == null)
                {
                    List<Comment> comments = TelligentService.ReadComments(
                        article.DefaultArticlePage.BlogId.Raw,
                        article.DefaultArticlePage.BlogPostId.Raw,
                        1,
                        1,
                        Constants.TelligentCommentSort.CreateDate, 
                        false,
                        out totalComments,
                        out hasMoreResults);

                    if (comments.Any())
                    {
                        if (totalComments >= 2)
                        {
                            litNumComments.Text = String.Format("{0} ({1})", DictionaryConstants.CommentsLabel, totalComments);
                        }

                        recentComment = comments.First();
                    }
                }

                if (recentComment != null)
                {
                    litCommentblurb.Text = recentComment.Body;
                    litAuthorName.Text = recentComment.AuthorDisplayName;
                    DateTime twoWeeks = DateTime.Now.AddDays(14);
                    if (DateTime.Now.Ticks < (recentComment.CommentDate.AddDays(14).Ticks))
                        litTimeStamp.Text = recentComment.PublishedDate;
                    else
                    {
                        litTimeStamp.Visible = false;
                        bulletSpan.Visible = false;
                    }
                    pnlCommentTeaser.Visible=  article.ShowComment.Checked;
                }
                else
                {
                    pnlCommentTeaser.Visible = false;
                }

            }
            catch (Exception ex)
            {
                this.Visible = false;
                Sitecore.Diagnostics.Log.Error(ex.Message, GetType());
            }

            string url = Sitecore.Context.Item.GetUrl();

            hlAllComments.HRef = url + "#comment-list"; //Navigate to top of comment section
            hlAllComments.InnerText = DictionaryConstants.Articles_SeeAllCommentsText;
            hlAddMyComment.HRef = url + "#comment-submit";
            hlAddMyComment.InnerText = DictionaryConstants.Articles_AddMyCommentText;
        }
    }
}