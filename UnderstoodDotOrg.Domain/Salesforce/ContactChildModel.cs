using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.Salesforce
{
    public class ContactChildModel
    {
        private Children__c _child;


        public string Nickname
        {
            get
            {
                return _child.Nickname__c;

            }
            set
            {
                _child.Nickname__c = value;
            }
        }
        public string Grade
        {
            get
            {
                return _child.Grade__c;

            }
            set
            {
                _child.Grade__c = value;
            }
        }
 
        //issues
        
        //dianosis
        public string IEPStatus
        {
            get
            {
                return _child.IEPStatus__c;

            }
            set
            {
                _child.IEPStatus__c = value;
            }
        }

        public string Section504Status
        {
            get
            {
                return _child.Section504Status__c ;

            }
            set
            {
                _child.Section504Status__c  = value;
            }
        }
       //remember when you save that in salesforce that the issues arent actually a "part" of the child
       public virtual ICollection<string> Issues { get; set; }


        public ContactChildModel()
        {
            _child = new Children__c ();
            Issues  = new List<string >();
        }

    }
}
