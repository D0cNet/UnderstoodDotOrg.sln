using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM16ContentReminderRequest : BaseRequest
	{
		public string ReminderLink { get; set; }//URL to the page of the reminder content in understood
		public string ReminderImage { get; set; }//URL to the source of the image
		public string ContentHelpfulnessAndCommentsModule { get; set; }//module containing the number of people who either commented or thought it was helpful
		public string ReminderTitle { get; set; }//the ame of the reminder
		public string ReminderSummary { get; set; }//breif summary of the reminder
		public string ContactSettingsLink { get; set; }//URL to the user's contact settings
	}
}
