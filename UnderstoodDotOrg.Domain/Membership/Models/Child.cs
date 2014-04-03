using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Membership.Models
{
    class Child
    {
        public Child()
        {

        }

        public Guid ChildID { get; set; }
        public string Nickname { get; set; }
        public Guid IEPStatus { get; set; }
        public Guid Section504Status { get; set; }
        public Guid Grade { get; set; }
        public Guid EvaluationStatus { get; set; }

        public virtual List<Guid> Diagnosis { get; set; }
        public virtual List<Guid> Issues { get; set; }

    }
}
