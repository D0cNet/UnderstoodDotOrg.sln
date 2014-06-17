using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Blogs.BlogsCommon
{
    public partial class BlogFeaturePostWithBreadcrumb : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            litBackLink.Text = DictionaryConstants.BackToAllBlogs;
            hrefBackLink.HRef = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.AllBlogs.ToString()));
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}