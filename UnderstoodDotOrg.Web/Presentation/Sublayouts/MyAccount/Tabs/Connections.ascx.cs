using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Tabs
{
    public partial class Connections : BaseSublayout<MyAccountItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyAccountItem context = (MyAccountItem)Sitecore.Context.Item;
            var item = Sitecore.Context.Database.GetItem(Constants.Pages.MyAccountConnections);

            int totalFriends;

            var friends = TelligentService.GetFriends(this.CurrentMember.ScreenName, 1, Constants.MY_CONNECTIONS_FRIENDS_PER_PAGE, out totalFriends);

            if (friends.Any())
            {
                rptFriends.DataSource = friends;
                rptFriends.DataBind();
            }
        }
    }
}