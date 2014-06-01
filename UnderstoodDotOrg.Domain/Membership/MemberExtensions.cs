using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Membership
{
    using System;
    using System.Collections.Generic;

    public partial class Member
    {
        /// <summary>
        /// bg: added in to track our Unauthorized Member flag.
        // .Net Membership already has a Comment column in the db.
        /// </summary>
        public string Comment { get; set; }

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

        /// <summary>
        /// Bool here, remember to save as bit to sql db
        /// Used to track if a website member has agreed to the terms and services agreement
        /// </summary>
        public bool AgreedToSignUpTerms { get; set; }

        /// <summary>
        /// Cell phone number
        /// </summary>
        public string MobilePhoneNumber { get; set; }

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
