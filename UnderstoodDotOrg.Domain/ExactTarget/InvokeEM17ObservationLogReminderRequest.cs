using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM17ObservationLogReminderRequest : BaseRequest
	{
		public string ObservationalJournalLink { get; set; }//URL to the user's observational journal
		public string ChildName { get; set; }//user's child's name
	}
}
