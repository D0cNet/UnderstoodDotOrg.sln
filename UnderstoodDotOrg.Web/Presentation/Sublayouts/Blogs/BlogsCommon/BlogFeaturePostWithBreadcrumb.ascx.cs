using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogFeaturePostWithBreadcrumb : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            Blog b = TelligentService.ReadBlog(CurrentItem.BlogId.Text);
            litBackLink.Text = b.Title;
            hrefBackLink.HRef = UnderstoodDotOrg.Services.CommunityServices.Blogs.GetBlogUrlFromID(CurrentItem.BlogId.Text);
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //Try to get the blog ID from querystring/BlogPostItem

            if (!String.IsNullOrEmpty(CurrentItem.BlogId.Text))
            {
                string id = CurrentItem.BlogId.Text;
                if (id != null)
                    follBtn.LoadState(id, UnderstoodDotOrg.Common.Constants.TelligentContentType.Blog);
            }
        }
        BlogsPostPageItem CurrentItem
        {
            get
            {   
                BlogsPostPageItem blogPostItem = null;
                //if (!(Session["current_item"] is BlogsPostPageItem))
                //{
                    var currItem = Sitecore.Context.Item;
                    if (currItem != null)
                    {
                        blogPostItem = new BlogsPostPageItem(currItem);
                    //    Session["current_item"] = blogPostItem;
                    }
                //}
                //else
                //{
                //    blogPostItem= Session["current_item"] as BlogsPostPageItem;
                //}
                return blogPostItem;
            }
        }
    }
}