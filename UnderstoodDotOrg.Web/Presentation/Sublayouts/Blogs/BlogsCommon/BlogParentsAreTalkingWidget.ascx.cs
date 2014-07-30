using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogParentsAreTalkingWidget : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var commentsList = TelligentService.ReadComments(Settings.GetSetting(Constants.Settings.TelligentBlogIds));
            if (commentsList.Any())
            {
                litAuthor.Text = commentsList[0].AuthorDisplayName;
                litCommentSnippet.Text = CommunityHelper.FormatString100(commentsList[0].Body);
                litDateTime.Text = commentsList[0].PublishedDate;
                string[] s = commentsList[0].ParentTitle.Split('{');
                litTitle.Text = s[0];
                linkReadMore.HRef = linkTitle.HRef = commentsList[0].Url;
            }
            else
            {
                this.Visible = false;
            }
        }
    }
}