using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Activity
{
    [Table(Name = "dbo.MemberActivity")]
    public class MemberActivity
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid rowId { get; set; }

        [Column]
        public Guid MemberId { get; set; }

        [Column(CanBeNull = true)]
        public Guid? Key { get; set; }

        [Column(CanBeNull = true)]
        public string Value { get; set; }

        [Column]
        public int ActivityType { get; set; }

        [Column]
        public DateTime DateModified { get; set; }

        [Column(DbType = "Bit", CanBeNull = true)]
        public bool? Deleted { get; set; }
    }
}
