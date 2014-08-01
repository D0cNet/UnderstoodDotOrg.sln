namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Framework.UI;
    using UnderstoodDotOrg.Services.TelligentService;
    using UnderstoodDotOrg.Common.Extensions;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.GroupsTemplate;
    using System.Web;
    using UnderstoodDotOrg.Services.Models.Telligent;
    using UnderstoodDotOrg.Services.CommunityServices;
    using System.Web.UI.WebControls;
    using Sitecore.Links;
    using System.Text.RegularExpressions;

    public partial class Groups_Search : BaseSublayout
    {
        public List<SearchResult> dataSource { get; set; }
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
                    dataSource = TelligentService.GroupSearch(query, Constants.TelligentSearchParams.Group, groupId, group);
                    Session["groupSearch"] = dataSource;
                    rptResults.DataSource = dataSource.Take(10).ToList();
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
            Response.Redirect(String.Format("{0}?{1}", Request.Path, qs));
        }

        protected void btnShowMore_Click(object sender, EventArgs e)
        {
            if (Session["groupSearch"] is List<SearchResult>)
            {
                var dataSource = (List<SearchResult>)Session["groupSearch"];
                rptResults.DataSource = dataSource;
                rptResults.DataBind();
            }
        }

        protected void rptResults_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item != null)
            {
                SearchResult item = ((SearchResult)e.Item.DataItem);

                if (item != null)
                {
                    if (!item.ThreadId.IsNullOrEmpty())
                    {
                        Thread thread = TelligentService.GetThreadData(item.ThreadId);

                        Literal litStartedBy = (Literal)e.Item.FindControl("litStartedBy");
                        if (litStartedBy != null)
                        {
                            litStartedBy.Text = thread.StartedBy;
                        }
                        Literal litReplies = (Literal)e.Item.FindControl("litReplies");
                        if (litReplies != null)
                        {
                            litReplies.Text = thread.ReplyCount;
                        }
                        HyperLink hypStartedBy = (HyperLink)e.Item.FindControl("hypStartedBy");
                        if (hypStartedBy != null)
                        {
                            hypStartedBy.NavigateUrl = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{DF854D0A-C127-42CB-90A5-806A695013B1}")), ".aspx", "/") + thread.StartedBy;
                        }
                    }
                    HyperLink hypBoard = (HyperLink)e.Item.FindControl("hypBoard");
                    if (hypBoard != null)
                    {
                        hypBoard.NavigateUrl = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{40726696-1FD7-41CC-A662-A618C7BEEE0A}")), ".aspx", "/") + item.GroupName.Trim() + "/" + item.Board.Trim();
                    }
                    HyperLink hypDiscussion = (HyperLink)e.Item.FindControl("hypDiscussion");
                    if (hypDiscussion != null)
                    {
                        hypDiscussion.NavigateUrl = Regex.Replace(LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem("{40726696-1FD7-41CC-A662-A618C7BEEE0A}")), ".aspx", "/") + item.GroupName.Trim() + "/" + item.Board.Trim() + "/" + Regex.Replace(item.BestMatchTitle, "RE:", "").Trim();
                    }
                }
            }
        }
    }
}