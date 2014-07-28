using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
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

            Item messagePage = Sitecore.Context.Database.GetItem(Constants.Pages.PrivateMessageTool);
            if (messagePage != null)
            {
                Response.Redirect(String.Format("{0}?{1}={2}", messagePage.GetUrl(), Constants.QueryStrings.PrivateMessage.Recipient, TargetScreenName));
            }
            else
            {
                Sitecore.Diagnostics.Log.Error(String.Format("Private Message page not found: {0}", Constants.Pages.PrivateMessageTool), this);
            }
        }

        private void BindContent()
        {
            btnPrivateMessage.Text = DictionaryConstants.PrivateMessageButtonText;
        }
    }
}