using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class CommentNotification : BaseNotification
    {

        public CommentNotification()
        {
            
        }

        public CommentNotification(XmlNode node)
        {
         
            if(node!=null)
            {
                Type = Constants.NotificationElements.NotificationType.Comment;
                BlogTitle= node.SelectSingleNode("Content/Application/HtmlName").InnerText;
                Text= ""; //TODO: grab comment text using filter comment REST API by contentID,UserName and lastUpdatedDate of notification = CreatedDate of Comment
                UserName = node.SelectSingleNode("Actors/RestNotificationActor[last()]/User/DisplayName").InnerText; // Multiple actors so sort and get lastest based on notificatoin lastupdatedDate
                NotificationDate = Convert.ToDateTime(node.SelectSingleNode("LastUpdatedDate").InnerText);
                TimeStamp = NotificationDate.ToString("hh:mm:tt");
            }
        }

        public string FriendlyDate { get { return NotificationDate.ToString("MMMM dd yyyy"); } }
        public string BlogTitle {get;set;}
        public string BlogUrl { get; set; }
        public override string Action
        {
            get
            {
                return (String.Format(DictionaryConstants.CommentAction, UserName, "REPLACE"));

            }
           
        }
        public string ActionFront
        {
            get
            {
                return (String.Format(DictionaryConstants.CommentFrontAction, UserName, "REPLACE",BlogTitle));
            }
        }
        public string Text
        {
            get;
            set;
        }

       
        public override string NotificationLink
        {
            get { return BlogUrl; }
        }

       

    }
}
