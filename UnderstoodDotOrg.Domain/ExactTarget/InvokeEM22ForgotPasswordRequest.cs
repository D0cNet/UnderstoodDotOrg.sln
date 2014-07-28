using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM22ForgotPasswordRequest : BaseRequest
	{
		public string PasswordResetLink { get; set; }//URL to the user's password reset page
	}
}
