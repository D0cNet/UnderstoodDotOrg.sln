using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class Moderator
	{
		public string groupModBioLink { get; set; }//url to the bio page for the moderator
		public string groupModName { get; set; }//name of the group moderator
		public string groupModImgLink { get; set; }//url image source for the moderator's profile picture
	}
}
