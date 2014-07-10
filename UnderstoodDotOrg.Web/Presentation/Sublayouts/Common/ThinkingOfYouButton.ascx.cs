using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Services.ExactTarget;
using UnderstoodDotOrg.Services.TelligentService;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class ThinkingOfYouButton : BaseSublayout//System.Web.UI.UserControl
    {
         public string UserName { get { return ViewState["_userName"].ToString(); } set { ViewState["_userName"] = value; } }
        public string Text { get { return this.litThinkingOfYou.Text; } set {  this.litThinkingOfYou.Text = value; } }
        public string SentText { get { return DictionaryConstants.SentLabel;} }
      //  protected override void onInit
        protected override void OnInit(EventArgs e)
        {
            this.btnThinkingOfYou.ServerClick += btnThanks_ServerClick;
            base.OnInit(e);
        }

        protected void btnThanks_ServerClick(object sender, EventArgs e)
        {
            if(IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                Services.CommunityServices.Members.SendThinkingOfYou(CurrentMember.ScreenName, UserName);
            }
            //set text to sent from dictionary
            Text = DictionaryConstants.SentLabel;
           // Page.Response.Redirect(Page.Request.Url.ToString(), false);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            litThinkingOfYou.Text = DictionaryConstants.ThinkingOfYouLabel;
        }

        public void LoadState(string userName)
        {
            UserName = userName;
        }

    
    }
}