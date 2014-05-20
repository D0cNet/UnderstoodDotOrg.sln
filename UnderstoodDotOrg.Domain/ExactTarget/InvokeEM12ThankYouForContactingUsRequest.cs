using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM12ThankYouForContactingUsRequest : BaseRequest
	{
		public string ChildAge { get; set; }//age of the child of the user being referenced
		public string TimeRemaining { get; set; }//the estimated amount of time it will take for a Poses representative to get back to the user contacting them
	}
}
