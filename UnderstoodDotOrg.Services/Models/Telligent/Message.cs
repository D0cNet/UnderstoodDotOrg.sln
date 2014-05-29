using System;
using System.Xml;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class Message
    {
        public string ID { get; set; }

        public string ConversationID { get; set; }

        public string AuthorName{get;set;}

        public string AuthorAvatar { get; set; }
        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime CreatedDate { get; set; }
        public string HowLong { get; set; }
        public string Time { get; set; }
        public Message ()
        {
            
        }
        public Message(XmlNode node)
        {
            if (node != null)
            {
                ID = node.SelectSingleNode("Id").InnerText;
                ConversationID = node.SelectSingleNode("ConversationId").InnerText;
                Subject = node.SelectSingleNode("Subject").InnerText;
                Body = node.SelectSingleNode("Body").InnerText;
                CreatedDate = Convert.ToDateTime(node.SelectSingleNode("CreatedDate").InnerText);
                HowLong = CommunityHelper.FormatDate(node.SelectSingleNode("CreatedDate").InnerText);
                AuthorName = node.SelectSingleNode("Author/Username").InnerText;
                AuthorAvatar = node.SelectSingleNode("Author/AvatarUrl").InnerText;
                Time = CreatedDate.ToString("hh:mm tt");
            }
        }
     }
}