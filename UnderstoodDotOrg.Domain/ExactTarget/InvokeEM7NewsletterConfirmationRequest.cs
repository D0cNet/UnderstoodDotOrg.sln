using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM7NewsletterConfirmationRequest : BaseRequest
	{
		public string WeekDay { get; set; } //day of the week the newsletters will be sent to the user
		public string ConfirmSubscriptionLink { get; set; } //URL that leads to a page where the user can confirm their subscription
	}
}
