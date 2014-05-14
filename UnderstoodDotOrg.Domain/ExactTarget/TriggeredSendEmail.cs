using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
    public class TriggeredSendEmail
    {

        public ETBaseConfig ETBaseConfig { get; set; }
        public ETEmail ETEmail { get; set; }
        public List<ETSubscriber> ETSubscriberList { get; set; }
        
    }
}
