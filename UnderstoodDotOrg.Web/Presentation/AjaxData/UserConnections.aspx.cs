using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class UserConnections : BaseAjaxPage
    {
        private string ResultPage
        {
            get { return Request.QueryString["page"] ?? String.Empty; }
        }
        private string ScreenName
        {
            get { return Request.QueryString["screenName"] ?? String.Empty; }
        }
        private string Lang
        {
            get { return Request.QueryString["lang"] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int page;
            Sitecore.Globalization.Language language;

            if (Sitecore.Globalization.Language.TryParse(Lang, out language))
            {
                Sitecore.Context.SetLanguage(language, false);
            }

            // Ensure friendship
            if (!IsUserLoggedIn 
                && !string.IsNullOrEmpty(ScreenName)
                && !TelligentService.IsApprovedFriend(CurrentMember.ScreenName, ScreenName))
            {
                return;
            }

            if (int.TryParse(ResultPage, out page))
            {
                int totalFriends;

                var friends = TelligentService.GetFriends(ScreenName, page, Constants.MY_CONNECTIONS_FRIENDS_PER_PAGE, out totalFriends);

                if (friends.Any())
                {
                    rptConnections.DataSource = friends;
                    rptConnections.DataBind();
                }

                phMoreResults.Visible = ((page - 1) * Constants.MY_CONNECTIONS_FRIENDS_PER_PAGE) + friends.Count() < totalFriends;
            }
        }
    }
}