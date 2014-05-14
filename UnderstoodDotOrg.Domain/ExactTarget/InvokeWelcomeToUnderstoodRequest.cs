using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
    public class InvokeWelcomeToUnderstoodRequest : BaseRequest
    {
        public string FirstName { get; set; }
    }
}
