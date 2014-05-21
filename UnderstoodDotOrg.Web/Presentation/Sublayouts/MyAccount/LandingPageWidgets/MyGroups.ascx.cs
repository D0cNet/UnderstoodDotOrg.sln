using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyGroups : BaseSublayout
    {
        private class GroupModel
        {
            public string Title { get; set; }
            public string TitleUrl { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccountGroups);
            hypGroupsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            //TO-DO Add call to get Groups and cast them as GroupModel objects

            //Stub for one link
            List<GroupModel> stubDataSource = new List<GroupModel>();
            GroupModel stubGroup = new GroupModel();
            stubGroup.Title = "ADHD";
            stubGroup.TitleUrl = "/";

            stubDataSource.Add(stubGroup);

            stubGroup = new GroupModel();
            stubGroup.Title = "Parents of kids with Attention issues";
            stubGroup.TitleUrl = "/";

            stubDataSource.Add(stubGroup);

            litCount.Text = stubDataSource.Count.ToString();

            rptGroups.DataSource = stubDataSource;
            rptGroups.DataBind();
        }

        protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (GroupModel)e.Item.DataItem as GroupModel;
            HyperLink hypGroupsLink = (HyperLink)e.Item.FindControl("hypGroupsLink");
            hypGroupsLink.NavigateUrl = ((GroupModel)e.Item.DataItem).TitleUrl;
            hypGroupsLink.Text = ((GroupModel)e.Item.DataItem).Title;
        }
    }
}