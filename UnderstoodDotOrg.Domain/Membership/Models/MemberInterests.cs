using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Membership.Models
{
    class MemberInterests
    {
        public MemberInterests()
        {
        }

        public virtual List<Guid> SchoolIssues { get; set; }
        public virtual List<Guid> WaysToHelp { get; set; }
        public virtual List<Guid> HomeLife { get; set; }
        public virtual List<Guid> GrowingUp { get; set; }
        public virtual List<Guid> SocialEmotionalIssues { get; set; }
        public virtual List<Guid> JourneyStatus { get; set; }

    }
}
