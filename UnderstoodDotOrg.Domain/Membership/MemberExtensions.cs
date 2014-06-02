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
        private bool _dataIsDirty = false;
        
        // private string _comment;
        // private string _email;
        // private string _password;
        private Guid _preferedLangugage;
        private bool _agreedToSignUpTerms;
        private string _mobilePhoneNumber;
        
        //bg: i would like to be able to flag if values need to be updated, inserted, or ignored on a field by field basis but we're going to regenerate later anyways.. but entitiy doesn't do a great job either so.. review 

        public bool ExtendedPropertiesAreDirty
        {
            get
            {
                return _dataIsDirty;
            }
        }

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
        public Guid PreferedLanguage 
        { 
            get
            {
                return _preferedLangugage ;
            }
            set 
            {
                //data is never dirty if it is *being intialized from the db*
                _preferedLangugage = value;
                _dataIsDirty = true;
            }
        }

        /// <summary>
        /// Bool here, remember to save as bit to sql db
        /// Used to track if a website member has agreed to the terms and services agreement
        /// </summary>
        public bool AgreedToSignUpTerms 
        { 
            get
            {
                return _agreedToSignUpTerms;
            }
            set 
            {
                _agreedToSignUpTerms = value;
                _dataIsDirty = true;
            }
       }
        
        /// <summary>
        /// Cell phone number
        /// </summary>
        public string MobilePhoneNumber 
        {
            get
            {
                return _mobilePhoneNumber;
            }
            set
            {
                _mobilePhoneNumber = value;
                _dataIsDirty = true;
            }
        }
        

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
