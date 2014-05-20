using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM14ThisWeeksActivityRequest : BaseRequest
	{
		public string UserProfileLink { get; set; }//URL that links back to the user's profile
		public string ProfileImageLink { get; set; }//URL to the source of the user's profile image
		public string ActivityFromThisWeekModule { get; set; }//table with a title for the day and a table for the activity for that day bu user's contacts
		public string ViewMessageLink { get; set; }//URL that links to the user's messages
		public string ContactSettingsLink { get; set; }//URL that links to the user's profile settings
	}
}
