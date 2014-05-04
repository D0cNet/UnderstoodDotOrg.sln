namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools
{
    using System;
    
    using UnderstoodDotOrg.Services.ExactTarget;
    using UnderstoodDotOrg.Domain.ExactTarget;
    using System.Collections.Generic;

    public partial class ExactTargetAdmin : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnETTests_Click(object sender, EventArgs e)
        {


            ETBaseConfig etBaseConfig = new ETBaseConfig();
           // etBaseConfig.ExactTargetWSUsername = "NCLDDEV01";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
           // etBaseConfig.ExactTargetWSPassword = "NCLDDEV01!!";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]

            ETEmail etEmail = new ETEmail();
            etEmail.CustomerKey = "201";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
            etEmail.EmailID = "103";   // This is the "Text Only Test Email" configured within NCLD's ExactTarget system ....  Available in the ET UI [Content > My Emails > Properties]
                                       


            ETSubscriber etSubscriber1 = new ETSubscriber();
            etSubscriber1.Email = "wilsonbri@gmail.com";
            etSubscriber1.Key = "wilsonbri@gmail.com";
            etSubscriber1.FN = "wilsonbri";

            ETSubscriber etSubscriber2 = new ETSubscriber();
            etSubscriber2.Email = "wilsonbri@gmail.com";
            etSubscriber2.Key = "wilsonbri@gmail.com";
            etSubscriber2.FN = "wilsonbri";

            TriggeredSendEmail tse = new TriggeredSendEmail();
            tse.ETBaseConfig = etBaseConfig;
            tse.ETEmail = etEmail;

            
            List<ETSubscriber> etSubscriberList = new List<ETSubscriber>();
            etSubscriberList.Add(etSubscriber1);
            etSubscriberList.Add(etSubscriber2);

            tse.ETSubscriberList = etSubscriberList;

            IExactTargetService etService = new ExactTargetService();
            etService.InvokeTriggeredSendEmail(tse);
        }



        //public const string CONST_ET_WS_USERNAME = "NCLDDEV01";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
        //public const string CONST_ET_WS_PASSWORD = "NCLDDEV01!!";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]

        //public const int CONST_ET_EMAIL_ID = 445;    //Available in the ET UI [Content > My Emails > Properties]
        //public const string CONST_ET_CUSTOMER_KEY = "4201";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]

        //public const string CONST_ET_NEW_SUBSCR_EMAIL = "wilsonbri@gmail.com";
        //public const string CONST_ET_NEW_SUBSCR_KEY = "wilsonbri@gmail.com";
        //public const string CONST_ET_NEW_SUBSCR_FN = "wilsonbri";

        //public const string CONST_ET_NEW_SUBSCR_EMAIL2 = "bwils06@gmail.com";
        //public const string CONST_ET_NEW_SUBSCR_KEY2 = "bwils06@gmail.com";
        //public const string CONST_ET_NEW_SUBSCR_FN2 = "bwils06";
    }
}