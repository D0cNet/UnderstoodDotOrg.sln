using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM23PasswordResetConfirmationRequest : BaseRequest
	{
		public string EmailAddress { get; set; }//user's emailaddress
		public string UserPassword { get; set; }//user's password
		public string ReportChangedPasswordLink { get; set; }//URL for the user to report that their password was reset without their knowledge
	}
}
