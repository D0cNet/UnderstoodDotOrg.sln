using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Personalization
{
    [Table(Name = "dbo.PersonalizedContent")]
    public class PersonalizedContent
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public Guid rowId { get; set; }

        [Column(CanBeNull = true)]
        public Guid? MemberId { get; set; }

        [Column]
        public Guid ChildId { get; set; }

        [Column]
        public Guid ContentId { get; set; }

        [Column]
        public int DisplayOrder { get; set; }

        [Column]
        public DateTime DateModified { get; set; }

        [Column]
        public int Type { get; set; }
    }
}
