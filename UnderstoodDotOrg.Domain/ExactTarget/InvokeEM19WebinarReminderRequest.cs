﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
	public class InvokeEM19WebinarReminderRequest : BaseRequest
	{
		public string WebinarModule { get; set; }//HTML table with webinar information
	}
}
