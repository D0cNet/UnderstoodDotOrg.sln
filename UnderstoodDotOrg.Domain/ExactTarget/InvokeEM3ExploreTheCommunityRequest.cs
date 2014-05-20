using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM3ExploreTheCommunityRequest : BaseRequest
	{
		public string FullName { get; set; }//user's full name
		public string PartnerPromo { get; set; }//HTML module promotion for partners of Poses
		public string ProfileCompletionBar { get; set; }
	}
}
