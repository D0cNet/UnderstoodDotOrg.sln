using System;
using System.Collections.Generic;

namespace UnderstoodDotOrg.Domain.Membership
{
    /// <summary>
    /// Provides custom constructor for Child, which ensures ChildId is populated when new instance is created
    /// </summary>
    public partial class Child
    {
        /// <summary>
        /// Creates a new instance of Child, and ensures ChildId is populated
        /// </summary>
        public Child()
        {
            this.ChildId = Guid.NewGuid();

            this.Diagnoses = new HashSet<Diagnosis>();
            this.Issues = new HashSet<Issue>();
            this.Members = new HashSet<Member>();
            this.Grades = new HashSet<Grade>();
        }
    }

    /// <summary>
    /// Provides custom constructor for Member, which ensures MemberId is populated when new instance is created
    /// </summary>
    public partial class Member
    {
        /// <summary>
        /// Creates a new instance of Member, and ensures MemberId is populated
        /// </summary>
        public Member()
        {
            this.MemberId = Guid.NewGuid();

            this.Children = new HashSet<Child>();
            this.Interests = new HashSet<Interest>();
            this.Journeys = new HashSet<Journey>();
        }
    }
}
