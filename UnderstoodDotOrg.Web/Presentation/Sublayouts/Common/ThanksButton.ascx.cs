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
    public partial class ThanksButton : BaseSublayout//System.Web.UI.UserControl
    {
        public string UserName { get { return ViewState["_userName"].ToString(); } set { ViewState["_userName"] = value; } }
        public string Text { get { return this.litThanksLabel.Text; } set {  this.litThanksLabel.Text = value; } }
        public string SentText { get { return DictionaryConstants.SentLabel;} }
      //  protected override void onInit
        protected override void OnInit(EventArgs e)
        {
            this.btnThanks.ServerClick += btnThanks_ServerClick;
            base.OnInit(e);
        }

        protected void btnThanks_ServerClick(object sender, EventArgs e)
        {
            if(IsUserLoggedIn && !String.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                //Grab text for thank you from dictionary
                string strThanksMsg = String.Format(DictionaryConstants.ThankYouMessage, CurrentMember.ScreenName);
            
                //Send private message
                string newConvID = TelligentService.CreateConversation(CurrentMember.ScreenName, DictionaryConstants.ThanksLabel, strThanksMsg, UserName);

                if (!String.IsNullOrEmpty(newConvID))
                {
                    //Send email
                    string memberEmail = TelligentService.GetMemberEmail(UserName);
                    string myAccountLink = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.MyAccount.ToString()));

                    BaseReply reply = ExactTargetService.InvokeEM21PrivateMessage(
                                                       new InvokeEM21PrivateMessageRequest
                                                       {
                                                           PreferredLanguage = CurrentMember.PreferredLanguage,
                                                           ///TODO: change url to profile setting link
                                                           ContactSettingsLink = MemberExtensions.GetMemberPublicProfile(UserName),
                                                           ///TODO: change URL to message centre link
                                                           MsgCenterLink = myAccountLink,
                                                           PMText = strThanksMsg,
                                                           ReportInappropriateLink = "flagged@understood.org",
                                                           ToEmail = memberEmail
                                                       });
                }
                
               
            }
            //set text to sent from dictionary
            Text = DictionaryConstants.SentLabel;
            //Page.Response.Redirect(Page.Request.Url.ToString(), false);
           // Page.ClientScript.RegisterStartupScript(GetType(), "key", "ToggleCursor(0,this);", true);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            litThanksLabel.Text = DictionaryConstants.ThanksLabel;
        }

        public void LoadState(string userName)
        {
            UserName = userName;
        }

    }
}