using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM11DonationAcknowledgementRequest : BaseRequest
	{
		public string FullName { get; set; }//full name of the user recieving the email
		public string DonationAmount { get; set; }//the amount the user donated to Poses
		public string PrintDonationRecordsLink { get; set; }//custom URL for the user to see their donation records

	}
}
