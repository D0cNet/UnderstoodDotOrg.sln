using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Services.Models.Telligent
{
    public class User
    {
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string PrivateEmail { get; set; }
        public bool AllowSiteToContact { get; set; }
        public DateTime Birthday { get; set; }
        public string EditorType { get; set; }
        public bool ReceiveEmails { get; set; }
        public bool EnableTracking { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public string Location { get; set; }
        public double TimeZone { get; set; }
        public string WebUrl { get; set; }

        public User()
        {

        }
    }
}
