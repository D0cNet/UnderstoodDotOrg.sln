using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UnderstoodDotOrg.Domain.Models.TelligentCommunity
{
    public class ForumReplyNotification : BaseNotification
    {

        public ForumReplyNotification()
        {
            
        }

        public ForumReplyNotification( XmlNode node)
        {
            
        }
        public override string Action
        {
            
            get { throw new NotImplementedException(); }
        }

        public override string NotificationLink
        {
            get { throw new NotImplementedException(); }
        }
    }
}
