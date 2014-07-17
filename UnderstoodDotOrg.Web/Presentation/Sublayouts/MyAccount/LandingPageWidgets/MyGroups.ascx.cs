using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.LandingPageWidgets
{
    public partial class MyGroups : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<GroupCardModel> groupsList = TelligentService.GetUserGroups(CurrentMember.ScreenName);
            litCount.Text = groupsList != null ? groupsList.Count.ToString() : "0";

            if (string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                pnlNoProfile.Visible = true;
            }
            else
            {
                var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccountGroups);
                MyAccountItem context = (MyAccountItem)Sitecore.Context.Item;
                hypGroupsTab.NavigateUrl = Sitecore.Links.LinkManager.GetItemUrl(item);
                hypGroupsTab.Text = context.SeeAllGroupsLinkText;
                
                if ((groupsList != null) && (groupsList.Count != 0))
                {
                    pnlGroups.Visible = true;
                    rptGroups.DataSource = groupsList.Count < 3 ? groupsList.GetRange(0, groupsList.Count) : groupsList.GetRange(0, 3); ;
                    rptGroups.DataBind();
                }
                else
                {
                    pnlNoGroups.Visible = true;
                }
            }
        }

        protected void rptGroups_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (GroupCardModel)e.Item.DataItem as GroupCardModel;
            HyperLink hypGroupsLink = (HyperLink)e.Item.FindControl("hypGroupsLink");
            hypGroupsLink.NavigateUrl = ((GroupCardModel)e.Item.DataItem).Url;
            hypGroupsLink.Text = ((GroupCardModel)e.Item.DataItem).Title;
        }
    }
}