using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Membership
{
    class MembershipManagerProxy : IMembershipManager
    {
        public Member AuthenticateUser(string Username, string Password)
        {
            return new Member();
        }

        public Member AddMember(Member Member)
        {
            return new Member();
        }

        public Child AddChild(Child Child, Guid MemberId)
        {
            return new Child();
        }

        public Member UpdateMember(Member Member)
        {
            return new Member();
        }

        public Child UpdateChild(Child Child)
        {
            return new Child();
        }

        public Member GetMember(Guid MemberId)
        {
            return new Member();
        }

        public Member GetMember(string MemberId)
        {
            return new Member();
        }
    }
}
