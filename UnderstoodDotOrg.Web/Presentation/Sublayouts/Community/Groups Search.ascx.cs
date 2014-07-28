namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    using System;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Framework.UI;
    using UnderstoodDotOrg.Services.TelligentService;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
    using System.Web;

    public partial class Groups_Search : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            var query = Request.QueryString["q"];
            var groupId = Request.QueryString["g"];

            if (!groupId.IsNullOrEmpty())
            {
                GroupItem group = Sitecore.Context.Database.GetItem(groupId);
                var telligentGroup = TelligentService.ReadGroup(group.GroupID);
                if (telligentGroup != null)
                {
                    litMemberCount.Text = telligentGroup["TotalMembers"].InnerText;
                    litDiscussionCount.Text = "5";
                }

                litGroupName.Text = group.Name;
                litGroupDesc.Text = group["Body Content"];


                if (!query.IsNullOrEmpty())
                {
                    var dataSource = TelligentService.GroupSearch(query, Constants.TelligentSearchParams.Group, groupId, group);
                    rptResults.DataSource = dataSource;
                    rptResults.DataBind();

                    litSearchItem.Text = query;
                    litResultCount.Text = dataSource.Count.ToString();
                }
            }
            else { litGroupName.Text = "Group Search"; }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var qs = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            qs.Set("q", txtSearch.Text);
            Response.Redirect(String.Format("{0}?{1}",Request.Path, qs));
        }
    }
}