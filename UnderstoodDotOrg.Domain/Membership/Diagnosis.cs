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
    
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            this.Children = new HashSet<Child>();
        }
    
        public System.Guid rowId { get; set; }
        public System.Guid Key { get; set; }
        public string Value { get; set; }
    
        public virtual ICollection<Child> Children { get; set; }
    }
}
