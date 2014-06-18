using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class MostRecentBlogsPage : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string blogId = Request.QueryString["BlogId"];
            List<UnderstoodDotOrg.Domain.TelligentCommunity.BlogPost> dataSource = CommunityHelper.ListBlogPosts(blogId, "6");
            foreach (var item in dataSource)
            {
                BlogsPostPageItem blogPost = Sitecore.Context.Database.GetItem("/Sitecore/Content/Home/Community and Events/Blogs/" + item.BlogName + "/" + item.Title);
                item.Author = blogPost.Author;
                item.Body = CommunityHelper.FormatString100(CommunityHelper.FormatRemoveHtml(blogPost.Body.Raw));
                item.AuthorUrl = "/Community and Events/Blogs/Author/" + item.Author;
            }

            lbBlogName.Text = dataSource[0].BlogName;
        }

        protected void MostRecent_Click(object sender, EventArgs e)
        {
            sbMostRecent.Visible = true;
            sbMostRead.Visible = sbMostShared.Visible = sbMostTalkedAbout.Visible = false;
            
        }

        protected void MostRead_Click(object sender, EventArgs e)
        {
            sbMostRead.Visible = true;
            sbMostRecent.Visible = sbMostShared.Visible = sbMostTalkedAbout.Visible = false;
        }

        protected void MostShared_Click(object sender, EventArgs e)
        {
            sbMostShared.Visible = true;
            sbMostRead.Visible = sbMostRecent.Visible = sbMostTalkedAbout.Visible = false;
        }

        protected void MostTalkedAbout_Click(object sender, EventArgs e)
        {
            sbMostTalkedAbout.Visible = true;
            sbMostRead.Visible = sbMostShared.Visible = sbMostRecent.Visible = false;
        }
    }
}