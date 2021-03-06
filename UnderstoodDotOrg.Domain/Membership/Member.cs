//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UnderstoodDotOrg.Domain.Membership
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        //public Member()
        //{
        //    this.Children = new HashSet<Child>();
        //    this.Interests = new HashSet<Interest>();
        //    this.Journeys = new HashSet<Journey>();
        //}
    
        public System.Guid MemberId { get; set; }
        public System.Guid UserId { get; set; }
        public string ScreenName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ZipCode { get; set; }
        public bool allowConnections { get; set; }
        public bool allowNewsletter { get; set; }
        public bool isPrivate { get; set; }
        public bool hasOtherChildren { get; set; }
        public System.Guid PersonalityType { get; set; }
        public System.Guid Role { get; set; }
        public Nullable<int> Phone { get; set; }
        public bool emailSubscription { get; set; }
        public bool isFacebookUser { get; set; }
        
        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<Journey> Journeys { get; set; }
    }
}
