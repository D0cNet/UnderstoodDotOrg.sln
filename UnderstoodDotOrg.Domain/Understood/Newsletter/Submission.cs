using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Newsletter
{
    public class Submission
    {
        private List<Child> _children = new List<Child>();
        private List<Guid> _interests = new List<Guid>();

        public string Email;
        public List<Child> Children
        {
            get { return _children; }
            set { _children = value; }
        }
        public string Language;
        public List<Guid> Interests
        {
            get { return _interests; }
            set { _interests = value; }
        }
    }
}
