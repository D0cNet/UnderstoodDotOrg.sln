using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Common
{
    public partial class ConnectButton : BaseSublayout
    {
        public string TargetScreenName { get; set; }

        private UnderstoodDotOrg.Common.Constants.TelligentFriendStatus _friendStatus;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();

            ToggleButtons();
                
            // Logged in members
            if (IsUserLoggedIn
                && !string.IsNullOrEmpty(CurrentMember.ScreenName)
                && !string.IsNullOrEmpty(TargetScreenName))
            {
                // Don't display if user is viewing own profile
                if (CurrentMember.ScreenName == TargetScreenName)
                {
                    this.Visible = false;
                    return;
                }

                _friendStatus = TelligentService.IsFriend(CurrentMember.ScreenName, TargetScreenName);
            }

            BindContent();
        }

        private void ToggleButtons()
        {
            btnAnonConnect.Visible = !IsUserLoggedIn;
            pnlLoggedIn.Visible = IsUserLoggedIn;
        }

        private void BindEvents()
        {
            btnConnect.Click += btnConnect_Click;
            btnAnonConnect.Click += btnAnonConnect_Click;
        }

        void btnAnonConnect_Click(object sender, EventArgs e)
        {
            // TODO: implement redirect manager
            Response.Redirect(MyAccountFolderItem.GetSignInPage());
        }

        private void BindContent()
        {
            string buttonLabel = DictionaryConstants.ConnectBtnText;

            switch (_friendStatus)
            {
                case Constants.TelligentFriendStatus.Pending:
                    btnConnect.Attributes.Add("disabled", "disabled");
                    buttonLabel = DictionaryConstants.RequestSent;
                    break;
                case Constants.TelligentFriendStatus.Approved:
                    buttonLabel = DictionaryConstants.UnconnectButtonText;
                    break;
            }

            btnAnonConnect.Text = btnConnect.Text = buttonLabel;
        }

        void btnConnect_Click(object sender, EventArgs e)
        {
            switch (_friendStatus)
            {
                case Constants.TelligentFriendStatus.NotSpecified:
                    if (TelligentService.CreateFriendRequest(CurrentMember.ScreenName, TargetScreenName, String.Format(DictionaryConstants.ConnectAction, TargetScreenName, "REPLACE")))
                    {
                        //Change Text
                        btnConnect.Text = DictionaryConstants.RequestSent;

                        //TODO: send connection email
                    }
                    break;
                case Constants.TelligentFriendStatus.Approved:
                    if (TelligentService.DeleteFriendRequest(CurrentMember.ScreenName, TargetScreenName))
                    {
                        btnConnect.Text = DictionaryConstants.ConnectBtnText;
                    }
                    break;
            }
        } 
    }
}