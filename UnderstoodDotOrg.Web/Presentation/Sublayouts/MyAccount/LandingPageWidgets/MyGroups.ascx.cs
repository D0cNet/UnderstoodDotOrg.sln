using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyGroups : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var item = Sitecore.Configuration.Factory.GetDatabase("master").GetItem(Constants.Pages.MyAccountGroups);
            hypGroupsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);

            List<GroupModel> groupsList = CommunityHelper.GetUserGroups(CurrentMember.ScreenName);
            litCount.Text = groupsList != null ? groupsList.Count.ToString() : "0";
            if ((groupsList != null)&&(groupsList.Count != 0))
            {
                rptGroups.DataSource = groupsList.Count == 1 ? groupsList.GetRange(0, 1) : groupsList.GetRange(0, 2); ;
                rptGroups.DataBind();
            }
        }

        protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (GroupModel)e.Item.DataItem as GroupModel;
            HyperLink hypGroupsLink = (HyperLink)e.Item.FindControl("hypGroupsLink");
            hypGroupsLink.NavigateUrl = ((GroupModel)e.Item.DataItem).Url;
            hypGroupsLink.Text = ((GroupModel)e.Item.DataItem).Title;
        }
    }
}