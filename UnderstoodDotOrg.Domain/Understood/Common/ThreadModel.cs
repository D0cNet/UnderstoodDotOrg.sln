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


       public ThreadModel()
       {
        
        }
       public ThreadModel(XmlNode childNode)
       {
           // TODO: Complete member initialization
           //this.childNode = childNode;
           Subject = childNode.SelectSingleNode("Subject").InnerText;
           Replies = childNode.SelectSingleNode("ReplyCount").InnerText;
         LastPostTime=CommunityHelper.FormatDate(childNode.SelectSingleNode("LatestPostDate").InnerText);

       }

       public string Subject { get; set; }
       public string Replies { get; set; }
       public string LastPostTime { get; set; }
       public string LastPostUser { get; set; }


    }
}
