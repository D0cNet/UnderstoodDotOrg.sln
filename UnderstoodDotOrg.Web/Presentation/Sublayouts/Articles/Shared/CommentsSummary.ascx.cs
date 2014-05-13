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
            if (ObjBasicArticle != null)
            {
                int blogID = Convert.ToInt32(ObjBasicArticle.DefaultArticlePage.BlogId);
                int blogPostID = Convert.ToInt32(ObjBasicArticle.DefaultArticlePage.BlogPostId);
                
                List<Comment> comments = CommunityHelper.ReadComments(blogID, blogPostID);
                  
                if (comments != null)
                {
                    numComments = comments.Count();
                    if (numComments > 2)
                    {
                        litNumComments.Text = "(" + numComments + ")";
                    }
                    try
                    {
                    Comment recentComment = comments.OrderByDescending(x => x._commentDate).First();
                    litCommentblurb.Text = CommunityHelper.FormatString100(recentComment._body);// Take(100).ToString();
                    litAuthorName.Text = recentComment._authorDisplayName;
                    litTimeStamp.Text = recentComment._publishedDate;
                    hlAddMyComment.HRef = "#" + recentComment._commentId; //Navigate to comment
                    }
                    catch
                    {

                    }
                }
               

            }
            hlAllComments.HRef = "#comment-list"; //Navigate to top of comment section
            hlAllComments.InnerText = "See All Comments";
            hlAddMyComment.InnerText = "Add My Comment";
        }
    }
}