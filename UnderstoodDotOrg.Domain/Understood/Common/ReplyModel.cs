using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Understood.Common
{
    public class ReplyModel
    {
        public string Author { get; set; }
        public string Body { get; set; }
        public string ReplyDate { get; set; } 
        public DateTime Date { get; set; }
    }
}
