using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates
{
    public partial class ConnectTemplate : BaseSublayout
    {
        public ConnectNotification ConnectionObj
        {
            get { return ViewState["connection_object"] as ConnectNotification; }
            set { ViewState["connection_object"] = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            btnAccept.Text = DictionaryConstants.AcceptText;
            btnDecline.Text = DictionaryConstants.DeclineText;
          
            base.OnInit(e);
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            //Send decline or ignore request
            string friendshipstate = "NotSpecified";
            if (TelligentService.UpdateFriendRequest(ConnectionObj.UserName, CurrentMember.ScreenName, friendshipstate))
            {

            }
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
          
            //Send connection confirmation
            string friendshipstate = "Approved";
            if (TelligentService.UpdateFriendRequest(ConnectionObj.UserName, CurrentMember.ScreenName, friendshipstate))
            {
                //Push some Javascript notification that process complete
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowAcceptMessage", "alert('Request Accepted!');", true);
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
           // btnAccept.Click += btnAccept_Click; //this.ConnectionObj.OnAccept;
           //btnDecline.Click += btnDecline_Click;
           //ConnectNotification connection = this.ConnectionObj;
           
        }
    }
}