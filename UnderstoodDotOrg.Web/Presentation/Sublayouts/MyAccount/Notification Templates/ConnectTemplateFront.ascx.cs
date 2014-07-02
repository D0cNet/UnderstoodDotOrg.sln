using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount.Notification_Templates
{
    public partial class ConnectTemplateFront : BaseSublayout
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
            // btnAccept.Click += ConnectionObj.OnAccept;
            // btnDecline.Click += ConnectionObj.OnDecline;
            base.OnInit(e);
        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            ConnectionObj.OnDecline(sender, e);
            ConnectionObj = null;
            Notifications = null;
            Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            ConnectionObj.OnAccept(sender, e);
            ConnectionObj = null;
            Notifications = null;
            Page.Response.Redirect(Page.Request.Url.ToString(), false);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}