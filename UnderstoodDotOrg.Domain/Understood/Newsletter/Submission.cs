using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Newsletter
{
    public class Submission
    {
        public string Email;
        public List<Child> Children;
        public string Language;
        public List<Guid> Interests;
    }
}
