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


       public ThreadModel(XmlNode childNode){
           
              
               Initialize(childNode);
         
        }
       public  ThreadModel(string forumID,string threadID)
       {
          
           XmlNode node = CommunityHelper.ReadThread(forumID, threadID);
           Initialize(node);

        }
       public void Initialize(XmlNode childNode)
       {
           if (childNode != null)
           {
               ThreadID = childNode.SelectSingleNode("Id").InnerText;
               ForumID = childNode.SelectSingleNode("ForumId").InnerText;
               // TODO: Complete member initialization
               //this.childNode = childNode;
               Subject = childNode.SelectSingleNode("Subject").InnerText;
               ReplyCount = childNode.SelectSingleNode("ReplyCount").InnerText??"0";
               LastPostTime = CommunityHelper.FormatDate(childNode.SelectSingleNode("LatestPostDate").InnerText);
               if ( !ReplyCount.Equals("0"))
               {
                   LastPostUser = Replies.OrderByDescending(x => x.Date).First().AuthorName;
                   LastPostBody = Replies.OrderByDescending(x => x.Date).First().Body;
               }
               StartedBy = childNode.SelectSingleNode("Author/Username").InnerText??"admin";
               Snippet = CommunityHelper.FormatString100(childNode.SelectSingleNode("Body").InnerText);
               Body = childNode.SelectSingleNode("Body").InnerText;
           }
           else
           {
               throw new Exception("Null object");
           }
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
       private MemberCardModel _author = null;
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
       public MemberCardModel Author
       {
           get
           {
               if (_author == null)
               {
                   _author = new MemberCardModel(StartedBy);
                   return _author;
               }
               else return _author;
            }
        }
       public string LastPostBody { get; set; }
       public static string TemplateID { get { return UnderstoodDotOrg.Common.Constants.Threads.ThreadTemplateID; } }
       public string Body { get; set; }
       public List<MemberCardModel> Members { get; set; }
      
    }
}
