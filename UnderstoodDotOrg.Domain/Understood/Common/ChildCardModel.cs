using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Common
{

    public class ChildCardModel
    {
        public class Issue
        {
            public string IssueName  { get; set; }
        }

        public string Grade { get; set; }
        public string Gender { get; set; }
        public List<Issue> IssueList { get; set; }

    }
}
