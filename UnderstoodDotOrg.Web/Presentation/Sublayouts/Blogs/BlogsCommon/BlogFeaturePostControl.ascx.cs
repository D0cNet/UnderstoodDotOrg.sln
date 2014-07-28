using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs
{
    public partial class BlogFeaturePostControl : BaseSublayout
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BlogPageItem blogPage = Sitecore.Context.Item;
            //Try to get the blog ID from querystring
            string id = blogPage.BlogId;
            if (id != null)
                follBtn.LoadState(id, UnderstoodDotOrg.Common.Constants.TelligentContentType.Blog);

                Blog b = TelligentService.ReadBlog(id);
                litBlogtitle.Text = b.Title;
                litBlogDescription.Text = b.Description;
        }
    }
}