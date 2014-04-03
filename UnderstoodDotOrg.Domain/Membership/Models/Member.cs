using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Membership.Models
{
    class Member
    {
        public Member()
        {

        }

        public Guid MemberID { get; set; }
        public string ScreenName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid PersonalityType { get; set; }
        public string ZipCode { get; set; }


        public bool allowConnections { get; set; }
        public bool allowNewsletter { get; set; }
        public bool isPrivate { get; set; }
        public bool hasOtherChildren { get; set; }

        public Guid HomeLife { get; set; }
        public Guid Role { get; set; }

        public virtual List<Child> Children { get; set; }
        public virtual MemberInterests Interests { get; set; }


    }
}
