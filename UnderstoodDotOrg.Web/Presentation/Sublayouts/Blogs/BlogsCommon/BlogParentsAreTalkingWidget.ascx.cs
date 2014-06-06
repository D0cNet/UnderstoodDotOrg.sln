using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogParentsAreTalkingWidget : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var commentsList = CommunityHelper.ReadComments("1,2,3");
            litAuthor.Text = commentsList[0].AuthorDisplayName;
            litCommentSnippet.Text = CommunityHelper.FormatString100(commentsList[0].Body);
            litDateTime.Text = commentsList[0].PublishedDate;
            litTitle.Text = commentsList[0].ParentTitle;
            linkReadMore.HRef = linkTitle.HRef = commentsList[0].Url;
        }
    }
}