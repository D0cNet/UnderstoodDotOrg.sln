using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Membership;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeE1ATurnAroundBullyingRequest : BaseRequest
	{
        public Member Member { get; set; }
        public Child Child { get; set; }
	}
}
