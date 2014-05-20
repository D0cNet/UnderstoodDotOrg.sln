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
using Sitecore.Links;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class CommentsSummary : System.Web.UI.UserControl
    {
        BasicArticlePageItem ObjBasicArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            Item currItem = Sitecore.Context.Item;
            if (currItem != null)
            {
                ObjBasicArticle = new BasicArticlePageItem(currItem);
                int numComments = 0;
                Comment recentComment=null;
                if (String.IsNullOrEmpty(ObjBasicArticle.DefaultArticlePage.BlogId.Raw)
                    || String.IsNullOrEmpty(ObjBasicArticle.DefaultArticlePage.BlogPostId.Raw))
                {
                    return;
                }

                try
                {
                    //Retrieve ovveride ID from field of current item
                    string commentId=ObjBasicArticle.DefaultArticlePage.CommentTeaserOverrideID.Text;
                    recentComment = CommunityHelper.ReadComment(commentId);
                    //no override id?
                    if (recentComment==null)
                    {
                        List<Comment> comments = CommunityHelper.ReadComments(
                            ObjBasicArticle.DefaultArticlePage.BlogId.Raw,
                            ObjBasicArticle.DefaultArticlePage.BlogPostId.Raw);

                        if (comments != null)
                        {
                            numComments = comments.Count();
                            if (numComments >= 2)
                            {
                                litNumComments.Text = "(" + numComments + ")";
                            }

                           recentComment = comments.OrderByDescending(x => x.CommentDate).First();
                            

                        }
                        
                    }
                    litCommentblurb.Text = CommunityHelper.FormatString100(recentComment.Body);// Take(100).ToString();
                    litCommentblurb.Text = litCommentblurb.Text + "..." + "<a href='#" + recentComment.CommentId + "'> Read more </a>";
                    litAuthorName.Text = recentComment.AuthorDisplayName;
                    litTimeStamp.Text = recentComment.PublishedDate;

                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Log.Error(ex.Message, GetType());
                }

                hlAllComments.HRef = LinkManager.GetItemUrl(currItem)+ "#comment-list"; //Navigate to top of comment section
                hlAllComments.InnerText = "See All Comments";
                hlAddMyComment.HRef = LinkManager.GetItemUrl(currItem) + "#comment-submit"; 
                hlAddMyComment.InnerText = "Add My Comment";
            }
        }
    }
}