using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Salesforce
{
    public class SalesforceActionResult
    {
        public bool Success  { get; set; }
        public string Message { get; set; }
        public string ID { get; set; }

        public SalesforceActionResult()
        { 
            this.ID = string.Empty;
            this.Message = "No Message.";
            this.Success = true ;
        }
    }
}
