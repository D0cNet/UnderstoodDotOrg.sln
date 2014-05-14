using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
   public class ThreadModel
    {
       private object childNode;

       public ThreadModel(XmlNode childNode){
           if (childNode != null)
           {
               ThreadID = childNode.SelectSingleNode("Id").InnerText;
               ForumID = childNode.SelectSingleNode("ForumId").InnerText;
               Initialize(childNode);
           }
        }
       public ThreadModel(string forumID,string threadID)
       {
           ForumID = forumID;
           ThreadID = threadID;
           XmlNode node = CommunityHelper.ReadThread(forumID, threadID);
           Initialize(node);
        }
       public void Initialize(XmlNode childNode)
       {
           // TODO: Complete member initialization
           //this.childNode = childNode;
           Subject = childNode.SelectSingleNode("Subject").InnerText;
           ReplyCount = childNode.SelectSingleNode("ReplyCount").InnerText;
           LastPostTime=CommunityHelper.FormatDate(childNode.SelectSingleNode("LatestPostDate").InnerText);
           LastPostUser = Replies.OrderByDescending(x => x.Date).First().Author;
           LastPostBody = Replies.OrderByDescending(x => x.Date).First().Body;
           StartedBy = childNode.SelectSingleNode("Author/Username").InnerText;
           Snippet = CommunityHelper.FormatString100(childNode.SelectSingleNode("Body").InnerText);
           
       }

       public string Subject { get; set; }
       public string LastPostTime { get; set; }
       public string LastPostUser { get; set; }
       public string StartedBy { get; set; }
       public string Snippet { get; set; }
       public string ThreadID { get; set; }
       public string ForumID { get; set; }
       public string ReplyCount { get; set; }
       private List<ReplyModel> _replies =null;
       public List<ReplyModel> Replies
       {
           get
           {
               if (_replies == null)
               {
                _replies =  CommunityHelper.ReadReplies(ForumID, ThreadID);
                   return _replies;
               }else
                    return _replies;
            }
       }

       public string LastPostBody { get; set; }
    }
}
