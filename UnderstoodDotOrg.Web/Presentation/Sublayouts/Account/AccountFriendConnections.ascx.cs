using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account
{
    public partial class AccountFriendConnections : System.Web.UI.UserControl
    {
        public Member ProfileMember;

        protected string AjaxPath
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.UserConnectionsEndpoint);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ProfileMember == null)
            {
                return;
            }

            PopulateContent();
        }

        private void PopulateContent()
        {
            int totalFriends;

            var friends = TelligentService.GetFriends(ProfileMember.ScreenName, 1, Constants.MY_CONNECTIONS_FRIENDS_PER_PAGE, out totalFriends);

            if (friends.Any())
            {
                rptConnections.DataSource = friends;
                rptConnections.DataBind();
            }

            pnlShowMore.Visible = friends.Count() < totalFriends;
        }
    }
}