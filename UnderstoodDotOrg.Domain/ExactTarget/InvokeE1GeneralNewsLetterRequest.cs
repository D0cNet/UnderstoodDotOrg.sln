using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
    public class InvokeE1GeneralNewsLetterRequest : BaseRequest
    {
        public string ToEmail { get; set; }//URL to the user's password reset page
        public string UserName { get; set; }//URL to the user's password reset page
        public string ProfilePercentCompletePlaceholder { get; set; }
    }
}
