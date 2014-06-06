using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.Understood.Quiz;

namespace UnderstoodDotOrg.Domain.Membership
{
    using System;
    using System.Collections.Generic;

    public partial class Member
    {
       //private bool _dataIsDirty = false;
        


        /// <summary>
        /// bg: added in to track our Unauthorized Member flag.
        // .Net Membership already has a Comment column in the db.
        /// </summary>
        public string Comment { get ; set; }

        /// <summary>
        /// bg: I wanted to keep the email address inside the member instead of passing it around as a parameter
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// bg: 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        //    bg: sitecore GUID for english/spanish/etc.
        //    currently only being set when a user subscribes for a personalized newsletter
        /// </summary>
        public Guid PreferedLanguage { get; set; }
        public bool AgreedToSignUpTerms { get; set; }
        public string MobilePhoneNumber { get; set; }
        public bool SupportPlanReminders { get; set; }
        public bool ObservationLogReminders { get; set; }
        public bool EventReminders { get; set; }
        public bool ContentReminders { get; set; }
        public bool AdvocacyAlerts { get; set; }
        public bool PrivateMessageAlerts { get; set; }
        public bool NotificationsDigest { get; set; }

        public bool Subscribed_DailyDigest { get; set; }
        public bool Subscribed_WeeklyDigest { get; set; }

        public virtual ICollection<Quiz> CompletedQuizes {get; set;}


        //new member properties keep popping up. 
        /* In case of emergency implement operation key/value them all
        private Dictionary<string, string> _extendedMemberProperties;
        public Dictionary<string, string> ExtendedMemberProperties
        {
            get
            {
                return _extendedMemberProperties;
            }
            set 
            {
                _extendedMemberProperties = value; 
            }
        }
        */

    }
}
