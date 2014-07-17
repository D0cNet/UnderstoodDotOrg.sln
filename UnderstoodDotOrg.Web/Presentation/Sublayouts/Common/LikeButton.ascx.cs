using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class LikeButton : System.Web.UI.UserControl
    {
        public string ContentId { get { return (string)ViewState["_contentId"]; } set { ViewState["_contentId"] = value; } }
        public string ContentTypeId { get { return (string)ViewState["_contentTypeId"]; } set { ViewState["_contentTypeId"] = value; } }
        protected string ContentServicePath
        {
            get { return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.ContentServiceEndpoint); }
        }
        protected string Text { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadState(string contentId,string contentTypeId)
        {
            ContentId = contentId;
            ContentTypeId = contentTypeId;
            Text = TelligentService.GetTotalLikes(contentId).ToString();
        }
    }
}