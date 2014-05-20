using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM28AppsTechnologySharedWithAFriendRequest : BaseRequest
	{
		public string UserContactFirstName { get; set; }//first name of the contact that sent the app to the user
		public string AppLink { get; set; }//links to the app's page
		public string AppTitle { get; set; }//name of the app
		public string AppDescription { get; set; }//description of the app
		public string AppGoodFor { get; set; }//line character(|) delimited list of links of school subjects the app is good for
		public string AppGrade { get; set; }//HTML table of grade level(s) the app is good for children in
		public string AppQuality { get; set; }//HTML table/number bar displaying quality of the app on a scale of 1-5
		public string AppLearningLink { get; set; }//HTML table/number bar indicating learning level of the app on a scale of 1-5
		public string AppLogo { get; set; }//logo of the app
		public string AppRatingModule { get; set; }//interactive HTML component that allows the user to rate the app
		public string AppRatingLink { get; set; }//URL where the user's rating can be sent and included with all other app ratings
	}
}
