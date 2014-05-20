using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class Notification
    {
        public string Username { get; set; }
        public string Author { get; set; }
        public string NotificationId { get; set; }
        public string ContentId { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }

        public Notification() { }
    }
}
