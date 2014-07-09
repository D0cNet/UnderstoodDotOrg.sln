using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class ForumReplyNotification : BaseNotification
    {

        public ForumReplyNotification()
        {
            
        }

        public ForumReplyNotification( XmlNode node)
        {
            if(node!=null)
            {
                Type = Constants.NotificationElements.NotificationType.ForumReply;
                ForumTitle = node.SelectSingleNode("Content/Application/HtmlName").InnerText;
                Text = ""; //TODO: grab comment text using filter comment REST API by contentID,UserName and lastUpdatedDate of notification = CreatedDate of Comment
                UserName = node.SelectSingleNode("Actors/RestNotificationActor[last()]/User/DisplayName").InnerText; // Multiple actors so sort and get lastest based on notificatoin lastupdatedDate
                NotificationDate = Convert.ToDateTime(node.SelectSingleNode("LastUpdatedDate").InnerText);
                TimeStamp = NotificationDate.ToString("hh:mm:tt");
               
            }
            
        }
        public string FriendlyDate { get { return NotificationDate.ToString("MMMM dd yyyy"); } }
        public override string Action
        {
            get
            {
                return (String.Format(DictionaryConstants.CommentAction, UserName, MemberExtensions.GetMemberPublicProfile(UserName)));

            }

        }
        public string ActionFront
        {
            get
            {
                return (String.Format(DictionaryConstants.CommentFrontAction, UserName, "REPLACE", ForumTitle));
            }
        }

        public override string NotificationLink
        {

            get { return ForumUrl; }
        }
        public string ForumReplyHeading { get { return String.Format(DictionaryConstants.ForumReplyHeader, ForumTitle); } }
        public string Text { get; set; }

        public string ForumTitle { get; set; }

        public string ForumUrl { get; set; }
    }
}
