using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.Models.Telligent;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class MyFriends : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {
            if (IsUserLoggedIn && !string.IsNullOrEmpty(CurrentMember.ScreenName)) 
            {
                PopulateContent();
            }
        }

        private void PopulateContent()
        {
            int totalFriends = 0;
            List<User> friends = TelligentService.GetFriends(CurrentMember.ScreenName, 1, Constants.WHATS_HAPPENING_MY_FRIENDS_ENTRIES, out totalFriends);

            if (friends.Any())
            {
                rptFriends.DataSource = friends;
                rptFriends.DataBind();
                if (totalFriends <= 4)
                {
                    arrowLeft.Visible = arrowRight.Visible = false;
                }
            }
            if (!friends.Any())
            {
                divFriends.Visible = false;
            }
        }
    }
}