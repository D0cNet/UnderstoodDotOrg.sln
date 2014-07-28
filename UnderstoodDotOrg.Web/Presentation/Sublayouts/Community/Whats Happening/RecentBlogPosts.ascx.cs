using Sitecore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class RecentBlogPosts : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BlogPost> dataSource = TelligentService.ListBlogPosts(Settings.GetSetting(Constants.Settings.TelligentBlogIds), "6");
            foreach (var item in dataSource)
            {
                string[] s = item.Title.Split('{');
                item.Title = s[0].Trim();
            }
            BlogsRepeater.DataSource = dataSource;
            BlogsRepeater.DataBind();
        }
    }
}