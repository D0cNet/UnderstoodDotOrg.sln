using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnderstoodDotOrg.Domain.Salesforce
{
    public class SalesforceContactModel
    {
        private Contact _contact;

          public string MemberId
        {
            get
            {
                return _contact.member_MemberId__c ;
            }
            set
            {
                _contact.member_MemberId__c = value;
            }
        }
        public string UserId 
        { 
            get
            {
                return _contact.member_UserId__c;

            }
            set
            {
                _contact.member_UserId__c = value;
            }
       }
       public string ScreenName 
        { 
            get
            {
                return _contact.member_ScreenName__c;

            }
            set
            {
                _contact.member_ScreenName__c = value;
            }
       }

         public string FirstName
        {
            get
            {
                return _contact.member_FirstName__c;

            }
            set
            {
                _contact.member_FirstName__c = value;
            }
        }


        public string LastName
        {
            get
            {
                return _contact.member_LastName__c;

            }
            set
            {
                _contact.member_LastName__c = value;
            }
        }

         public string HomeLife
        {
            get
            {
                return _contact.member_HomeLife__c;

            }
            set
            {
                _contact.member_HomeLife__c = value;
            }
        }

        public string Personality
        {
            get
            {
                return _contact.member_Personality__c;

            }
            set
            {
                _contact.member_Personality__c = value;
            }
        }

        public string Role
        {
            get
            {
                return _contact.member_Role__c;

            }
            set
            {
                _contact.member_Role__c = value;
            }
        }

        public string ZipCode
        {
            get
            {
                return _contact.member_ZipCode__c;

            }
            set
            {
                _contact.member_ZipCode__c = value;
            }
        }

        public bool? AllowConnections
        {
            get
            {
                return _contact.member_allowConnections__c;

            }
            set
            {
                _contact.member_allowConnections__c = value;
            }
        }
    
        public bool? AllowNewsletter
        {
            get
            {
                return _contact.member_allowNewsletter__c;

            }
            set
            {
                _contact.member_allowNewsletter__c = value;
            }
        }
        public bool? HasOtherChildren
        {
            get
            {
                return _contact.member_hasOtherChildren__c;

            }
            set
            {
                _contact.member_hasOtherChildren__c = value;
            }
        }
     
        public bool? IsPrivate
        {
            get
            {
                return _contact.member_isPrivate__c;

            }
            set
            {
                _contact.member_isPrivate__c = value;
            }
        }

        public virtual ICollection<ContactChildModel> Children { get; set; }
        public SalesforceContactModel()
        {
            _contact = new Contact();
            Children = new List<ContactChildModel>();

        }
  
    }
}
