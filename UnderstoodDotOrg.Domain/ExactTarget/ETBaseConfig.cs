using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain.ExactTarget
{
    public class ETBaseConfig
    {


        private static string _SenderProfileExternalKey = "201";
        private static string _ExactTargetWSUsername = "NCLDDEV01";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
        private static string _ExactTargetWSPassword = "NCLDDEV01!@"; //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]


        public const int CONST_ET_EMAIL_ID = 103;    //Available in the ET UI [Content > My Emails > Properties]
        public const string CONST_ET_CUSTOMER_KEY = "201";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]



        public string ExactTargetWSPassword
        {
            get
            {
                return _ExactTargetWSPassword;
            }
        }
        public string ExactTargetWSUsername
        {
            get
            {
                return _ExactTargetWSUsername;
            }
        }
        public string SenderProfileExternalKey
        {
            get
            {
                return _SenderProfileExternalKey;
            }
        }



    }
}
