using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM13ActivityFromTodayRequest : BaseRequest
	{
		public string UserProfileLink { get; set; }//URL that links to the user's profile
		public string ProfileImageLink { get; set; }//URL that links to the source of the user's profile image
		public string ActivityFromTodayModule { get; set; }//HTML table that displays the activity that occured the day the Email was sent
		public string ViewMessagesLink { get; set; }//URL that links to the user's messages
		public string ContactSettingsLink { get; set; }//URL that links to the user's contact settings
	}
}
