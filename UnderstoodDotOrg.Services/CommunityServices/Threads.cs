using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Services.CommunityServices
{
    public static class Threads
    {
        public static ThreadModel ThreadModelFactory(string forumId, string threadId)
        {
           
           XmlNode node =TelligentService.TelligentService.ReadThread(forumId, threadId);

           ThreadModel th = new ThreadModel(node,TelligentService.TelligentService.FormatDate,TelligentService.TelligentService.FormatString100,TelligentService.TelligentService.ReadReplies);

           return th;

        }
    }
}
