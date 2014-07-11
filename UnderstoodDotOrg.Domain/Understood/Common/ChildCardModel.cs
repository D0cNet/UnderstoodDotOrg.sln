using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Domain.Understood.Common
{

    public class ChildCardModel
    {
        public class Issue
        {
            public string IssueName  { get; set; }
        }

        public Guid Grade { get; set; }
        public string Gender { get; set; }
        public List<Issue> IssueList { get; set; }

        public static implicit operator ChildCardModel(Child child)
        {
            ChildCardModel chCard = new ChildCardModel();
            chCard.Grade = child.Grades.First().Key;
            chCard.Gender = child.Gender;

            chCard.IssueList = (from i in child.Issues
                                select new Issue { IssueName = i.Value }).ToList<Issue>();
            
            return chCard;
        }
        
    }
}
