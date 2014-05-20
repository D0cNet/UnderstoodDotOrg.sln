
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM25WebinarSharedWithAFriendRequest : BaseRequest
	{
		public string UserContactFirstName { get; set; }//first name of the contact sending the user the webinar information
		public string PMText { get; set; }//message from the user's contact describing the webinar share
		public string WebinarModule { get; set; }//HTML tabls where the webinar information will go
	}
}
