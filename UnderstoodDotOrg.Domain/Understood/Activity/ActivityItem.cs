using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Activity
{
    class ActivityItem
    {
        public Guid ContentId { get; set; }
        public Guid MemberId { get; set; }
        public string ActivityValue { get; set; }
        public int ActivityType  { get; set; }
        public DateTime DateModified { get; set; }
    }
}
