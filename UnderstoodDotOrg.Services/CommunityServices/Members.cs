using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Common;
using UnderstoodDotOrg.Services.MemberServices;
namespace UnderstoodDotOrg.Services.CommunityServices
{
    public class Members
    {
        public static MemberCardModel MemberCardModelFactory(string musername)
        {
            MembershipManager memMan = new MembershipManager();

            Member mUser = memMan.GetMemberByScreenName(musername);
            return MemberCardModelFactory(mUser);
        }

        public static MemberCardModel MemberCardModelFactory(Member m)
        {
            MemberCardModel mcModel = new MemberCardModel(); 
             if(m!=null)
             {
                 mcModel = new MemberCardModel(m, User.GetUserBadges);
                 mcModel.UserLocation = m.zipCodeToState();
             }

                 return mcModel;
        }
        public static bool SendThinkingOfYou(string senderScreenName, string recipientScreenName)
        {
            try
            {
                //Grab text for thank you from dictionary
                string strThinkMsg = String.Format(DictionaryConstants.ThinkingOfYouMessage, senderScreenName);

                //Send private message
                string newConvID = TelligentService. TelligentService.CreateConversation(senderScreenName, DictionaryConstants.ThinkingOfYouLabel, strThinkMsg, recipientScreenName);

                if (!String.IsNullOrEmpty(newConvID))
                {
                    //Send email
                    MembershipManager mm = new MembershipManager();
                    Member recipient = mm.GetMemberByScreenName(recipientScreenName);

                    if (recipient != null)
                    {
                        //Send email
                        string myAccountLink = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.MyAccount.ToString()));

                        BaseReply reply = Services.ExactTarget.ExactTargetService.InvokeEM21PrivateMessage(
                                                           new InvokeEM21PrivateMessageRequest
                                                           {
                                                               PreferredLanguage = recipient.PreferredLanguage,
                                                               ///TODO: change url to profile setting link
                                                               ContactSettingsLink = MembershipHelper.GetPublicProfileUrl(senderScreenName),
                                                               ///TODO: change URL to message centre link
                                                               MsgCenterLink = myAccountLink,
                                                               PMText = strThinkMsg,
                                                               ReportInappropriateLink = "flagged@understood.org",
                                                               ToEmail = recipient.Email
                                                           });
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Error.LogError("Error sending thinking of you\n" + ex.Message);
            }

            return false;
        }

        public static bool SendThanks(string senderScreenName, string recipientScreenName)
        {
            try
            {
                //Grab text for thank you from dictionary
                string strThanksMsg = String.Format(DictionaryConstants.ThankYouMessage, senderScreenName);

                //Send private message
                string newConvID = Services.TelligentService.TelligentService.CreateConversation(senderScreenName, DictionaryConstants.ThanksLabel, strThanksMsg, recipientScreenName);

                if (!String.IsNullOrEmpty(newConvID))
                {
                    //Send email
                    MembershipManager mm = new MembershipManager();
                    Member recipient = mm.GetMemberByScreenName(recipientScreenName);

                    if (recipient != null)
                    {
                        string myAccountLink = Sitecore.Links.LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.MyAccount.ToString()));

                        BaseReply reply = Services.ExactTarget.ExactTargetService.InvokeEM21PrivateMessage(
                                                           new InvokeEM21PrivateMessageRequest
                                                           {
                                                               PreferredLanguage = recipient.PreferredLanguage,
                                                               ///TODO: change url to profile setting link
                                                               ContactSettingsLink = MembershipHelper.GetPublicProfileUrl(senderScreenName),
                                                               ///TODO: change URL to message centre link
                                                               MsgCenterLink = myAccountLink,
                                                               PMText = strThanksMsg,
                                                               ReportInappropriateLink = "flagged@understood.org",
                                                               ToEmail = recipient.Email
                                                           });

                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Error.LogError("Error sending thanks\n" + ex.Message);
            }

            return false;
        }
    }
}
