using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM8SubscriptionConfirmationRequest : BaseRequest
	{
		public string ProfileCompletionBar { get; set; }//HTML table containing a profile completion bar
	}
}
