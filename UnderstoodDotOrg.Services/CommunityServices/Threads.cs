using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Understood.Common;

namespace UnderstoodDotOrg.Services.CommunityServices
{
    public static class Threads
    {
        public static Item ConvertThreadtoSitecoreItem(string forumid,string threadid)
        {
            Item threadItem = null;
            Database masterDb = global:: Sitecore.Configuration.Factory.GetDatabase("master");
            threadItem = masterDb.SelectSingleItem("fast:/sitecore/content/Home//*[@@templateid = '" + Constants.Threads.ThreadTemplateID + "' and @ForumID = '" + forumid + "' and @ThreadID='" + threadid + "' ]");

            return threadItem;
        }
        public static ThreadModel ThreadModelFactory(string forumId, string threadId)
        {
           
           XmlNode node =TelligentService.TelligentService.ReadThread(forumId, threadId);

           ThreadModel th = new ThreadModel(node, Common.Helpers.DataFormatHelper.FormatDate,TelligentService.TelligentService.FormatString100,TelligentService.TelligentService.ReadReplies);

           return th;

        }
    }
}
