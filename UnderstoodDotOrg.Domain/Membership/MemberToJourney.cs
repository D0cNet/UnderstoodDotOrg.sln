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
    
    public partial class MemberToJourney
    {
        public System.Guid MemberId { get; set; }
        public System.Guid JourneyId { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Journey Journey { get; set; }
        public virtual Member Member { get; set; }
    }
}
