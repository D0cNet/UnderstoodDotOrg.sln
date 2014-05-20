using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM24ContentSharedWithAFriendRequest : BaseRequest
	{
		public string UserContactFirstName { get; set; }//first name of the contact who shared the content with the user
		public string PMText { get; set; }//message from the contact of the user
		public string ReminderLink { get; set; }//URL to the content the contact is recommended
		public string ReminderImage { get; set; }//image for the content the user is being recommended
		public string ContentHelpfulnessAndCommentsModule { get; set; }//HTML table displaying how many users either commented on the content or thought it was helpful
		public string ReminderTitle { get; set; }//title for content the user is being recommended
		public string ReminderSummary { get; set; }//summary of the content the user is being recommended
	}
}
