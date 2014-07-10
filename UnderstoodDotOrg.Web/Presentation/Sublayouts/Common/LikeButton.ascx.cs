using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class LikeButton : System.Web.UI.UserControl
    {
        public string ContentId { get { return ViewState["_contentId"].ToString(); } set { ViewState["_contentId"] = value; } }
        public string Text { get { return this.litNumber.Text; } set { this.litNumber.Text = value; } }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadState(string contentId)
        {
            ContentId = contentId;
            Text = TelligentService.GetTotalLikes(contentId).ToString();
        }
    }
}