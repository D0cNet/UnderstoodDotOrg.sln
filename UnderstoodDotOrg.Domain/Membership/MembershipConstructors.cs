using System;
using System.Collections.Generic;

namespace UnderstoodDotOrg.Domain.Membership
{
    public partial class Child
    {
        public Child()
        {
            this.ChildId = Guid.NewGuid();

            this.Diagnoses = new HashSet<Diagnosis>();
            this.Issues = new HashSet<Issue>();
            this.Members = new HashSet<Member>();
        }
    }

    public partial class Member
    {
        public Member()
        {
            this.MemberId = Guid.NewGuid();

            this.Children = new HashSet<Child>();
            this.Interests = new HashSet<Interest>();
        }
    }
}
