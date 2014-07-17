namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Q_and_A
{
    using Sitecore.Links;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Helpers;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.Blogs;
    using UnderstoodDotOrg.Domain.TelligentCommunity;

    public partial class QandA : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string query = TextHelper.RemoveHTML(txtSearch.Text);
            Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{B1EFCAA6-C79A-4908-84D0-B4BDFA5E25A3}")) + "?q=" + query + "&a=" + Constants.TelligentSearchParams.Question);

        }
    }
}