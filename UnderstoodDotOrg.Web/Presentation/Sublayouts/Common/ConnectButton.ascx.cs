using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;
//using UnderstoodDotOrg.Services.AccessControlServices;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class ConnectButton : BaseSublayout//System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string UserName
        {
            get
            {
                return ViewState["_user_name"].ToString();
            }
            set
            {
                ViewState["_user_name"] = value;
            }
        }

        public string Text
        {
            get { return btnConnect.Text; }
            set { btnConnect.Text = value; }
        }

        private Constants.TelligentFriendStatus Status { get; set; }

        public void LoadState(string userName)
        {
            if (!String.IsNullOrEmpty(userName))
            {
                UserName = userName.Trim();
                Text = DictionaryConstants.ConnectBtnText;
                try
                {
                    if (CurrentMember != null)
                    {
                        if (CurrentMember.ScreenName != null)
                        {
                            //Check friendship
                            Status = TelligentService.IsFriend(CurrentMember.ScreenName, UserName);
                            //Set Text Appropriately
                            switch (Status)
                            {
                                case Constants.TelligentFriendStatus.NotSpecified:
                                    Text = DictionaryConstants.ConnectBtnText;
                                    break;
                                case Constants.TelligentFriendStatus.Pending:
                                    Text = DictionaryConstants.RequestSent;
                                    break;
                                case Constants.TelligentFriendStatus.Approved:
                                    Text = DictionaryConstants.ViewActivity;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Sitecore.Diagnostics.Error.LogError("Error in LoadState function.\nError:\n" + ex.Message);
                }
            }
        }
        protected void btnConnect_Click(object sender, EventArgs e)
        {
            //Check community permissions
            //this.ProfileRedirect(Constants.UserPermission.CommunityUser);
            //Check status and perform appropriate action
            switch (Status)
            {
                case Constants.TelligentFriendStatus.NotSpecified:
                    //call service to create connection
                    if(TelligentService.CreateFriendRequest(CurrentMember.ScreenName, UserName, String.Format(DictionaryConstants.ConnectAction, UserName, "REPLACE")))
                    {
                        //Change Text
                        Text = DictionaryConstants.RequestSent;

                        //TODO: send connection email
                    }
                    break;
                case Constants.TelligentFriendStatus.Pending:
                    //Nothing to do but wait until friendship request approved
                    break;
                case Constants.TelligentFriendStatus.Approved:
                    //View user activity

                    break;
                default:
                    break;
            }

        }
    }
}