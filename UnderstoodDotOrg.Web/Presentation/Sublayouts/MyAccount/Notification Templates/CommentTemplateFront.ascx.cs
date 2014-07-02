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
    public partial class CommentTemplateFront : BaseSublayout
    {
        public CommentNotification CommentObj
        {
            get { return ViewState["comment_object"] as CommentNotification; }
            set { ViewState["comment_object"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}