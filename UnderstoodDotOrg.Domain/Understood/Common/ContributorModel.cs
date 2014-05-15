using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class ContributorModel : MemberCardModel
    {
        public ContributorModel(): base()
        {
            
        }
        public ContributorModel (Member m):base(m)
        {
            
        }
    }
}
