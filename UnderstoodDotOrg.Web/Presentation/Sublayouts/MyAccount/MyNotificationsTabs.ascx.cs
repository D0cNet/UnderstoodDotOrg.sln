using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyAccount
{
    public partial class MyNotificationsTabs : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<INotification> notifs = new List<INotification>();
            List<Conversation> checkConvos = new List<Conversation>();

            if (IsUserLoggedIn)
            {
                if (!String.IsNullOrEmpty(CurrentMember.ScreenName))
                {
                    if (Notifications != null)
                    {
                        notifs = Notifications;

                    }
                    else
                    {
                        notifs = TelligentService.GetNotifications(CurrentMember.ScreenName);
                        Notifications = notifs;
                    }
                    

                     if (Session["conversations"] is List<Conversation>)
                     {
                         checkConvos = Session["conversations"] as List<Conversation>;
                     }
                     else
                     {
                         checkConvos = TelligentService.GetConversations(CurrentMember.ScreenName);
                         Session["conversations"] = checkConvos;
                     }
				    
                }
            }
           

         

            litNotifsCount.Text = notifs!=null && notifs.Count() >0?notifs.Count().ToString():"0";
            litwhatsHappeningLabel.Text = DictionaryConstants.WhatsHappeningLabel;
            litPrivateMsgsLabel.Text = DictionaryConstants.PrivateMessagesLabel;
            litEmailPrefLabel.Text = DictionaryConstants.EmailPreferencesLabel;
            litPMs.Text = checkConvos.Count().ToString();
            if (!IsPostBack)
            {
                if (Sitecore.Context.Item.TemplateID.ToString() == EmailandAlertPreferencesPageItem.TemplateId)
                {
                    liEmailPreferencesTab.Attributes["class"] += "active";
                }

                if (Sitecore.Context.Item.TemplateID.ToString() == PrivateMessageToolItem.TemplateId)
                {
                    liMessagesTab.Attributes["class"] += "active";
                }

                if (Sitecore.Context.Item.TemplateID.ToString() == MyNotificationsPageItem.TemplateId)
                {
                    liNotificationsTab.Attributes["class"] += "active";
                }

                // TODO: refactor
                hypWhatsHappening.NavigateUrl = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetUrl();
                hypEmailAndAlertPreferences.NavigateUrl = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetEmailAndAlertPreferences().InnerItem.GetUrl();
                hypPrivateMessages.NavigateUrl = MainsectionItem.GetHomePageItem().GetMyAccountFolder().GetMyNotificationsPage().GetPrivateMessageTool().InnerItem.GetUrl();

              
            }
        }
    }
}