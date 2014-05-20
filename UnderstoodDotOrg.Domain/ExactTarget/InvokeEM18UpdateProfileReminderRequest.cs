using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM18UpdateProfileReminderRequest : BaseRequest
	{
		public string UserProfileLink { get; set; }//URL to the user's profile
		public string ProfileImageLink { get; set; }//source URL to user's profile image
		public string ChildInformationConfirmation { get; set; }//table filled with questions about changes that may have occured in the user/child's information
		public string InformationConfirmLink { get; set; }//URL to confirm that all information presented in ChildInformationConfirmation is true
		public string InformationDeniedLink { get; set; }//URL to a place where the user can update the information presented in ChildInformationConfirmation
	}
}
