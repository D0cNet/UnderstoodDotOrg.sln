using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
    public class BaseRequest
    {
        public string ToEmail { get; set; }
		public Guid PreferredLanguage { get; set; }
        public Uri RequestUrl { get; set; }

    }
}
