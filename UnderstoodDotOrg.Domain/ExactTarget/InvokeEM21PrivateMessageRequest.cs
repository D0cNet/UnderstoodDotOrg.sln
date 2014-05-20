using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM21PrivateMessageRequest : BaseRequest
	{
		public string PMText { get; set; }//text for the private message
		public string MsgCenterLink { get; set; }//URL to the message center where the user can reply to the private message
		public string ContactSettingsLink { get; set; }//URL to the user's contact settings
		public string ReportInappropriateLink { get; set; }//URL to a place where the message can be reported as inappropriate
	}
}
