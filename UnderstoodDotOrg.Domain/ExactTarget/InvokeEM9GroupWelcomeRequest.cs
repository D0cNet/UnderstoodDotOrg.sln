using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM9GroupWelcomeRequest : BaseRequest
	{
		public string GroupTitle { get; set; }//name of the group
		public string GroupLink { get; set; }//url to the group page
		public string GroupLeaderEmail { get; set; }//group leader's email address
		public string GroupLeaderModule { get; set; }//HTML table containing the group leader's information
		public Moderator GroupModerator = new Moderator();
	}
}
