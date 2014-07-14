using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Common
{
    public partial class PrivateMessageButton : BaseSublayout
    {
        public string TargetScreenName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TargetScreenName))
            {
                BindEvents();
                BindContent();
            }
            else
            {
                this.Visible = false;
            }
        }

        private void BindEvents()
        {
            btnPrivateMessage.Click += btnPrivateMessage_Click;
        }

        void btnPrivateMessage_Click(object sender, EventArgs e)
        {
            // TODO: redirect to final private message page with screen name passed via query string
        }

        private void BindContent()
        {
            btnPrivateMessage.Text = DictionaryConstants.PrivateMessageButtonText;
        }
    }
}