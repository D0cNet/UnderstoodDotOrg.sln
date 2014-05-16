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
using UnderstoodDotOrg.Domain.TelligentCommunity;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class CommentsSummary : System.Web.UI.UserControl
    {
        BasicArticlePageItem ObjBasicArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjBasicArticle = new BasicArticlePageItem(Sitecore.Context.Item);
            int numComments = 0;

            if (String.IsNullOrEmpty(ObjBasicArticle.DefaultArticlePage.BlogId.Raw)
                || String.IsNullOrEmpty(ObjBasicArticle.DefaultArticlePage.BlogPostId.Raw))
            {
                return;
            }

            try
            {
                List<Comment> comments = CommunityHelper.ReadComments(
                    ObjBasicArticle.DefaultArticlePage.BlogId.Raw,
                    ObjBasicArticle.DefaultArticlePage.BlogPostId.Raw);

                if (comments != null)
                {
                    numComments = comments.Count();
                    if (numComments > 2)
                    {
                        litNumComments.Text = "(" + numComments + ")";
                    }

                    Comment recentComment = comments.OrderByDescending(x => x.CommentDate).First();
                    litCommentblurb.Text = CommunityHelper.FormatString100(recentComment.Body);// Take(100).ToString();
                    litAuthorName.Text = recentComment.AuthorDisplayName;
                    litTimeStamp.Text = recentComment.PublishedDate;
                    hlAddMyComment.HRef = "#" + recentComment.CommentId; //Navigate to comment
                }

            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, GetType());
            }

            hlAllComments.HRef = "#comment-list"; //Navigate to top of comment section
            hlAllComments.InnerText = "See All Comments";
            hlAddMyComment.InnerText = "Add My Comment";
        }
    }
}