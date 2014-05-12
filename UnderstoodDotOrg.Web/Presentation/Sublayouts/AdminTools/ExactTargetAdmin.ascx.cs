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

            if (!IsPostBack)
            {
                // initialize text boxes
                tbxSubscriberEmail1.Text = "bwilson@agencyoasis.com";
                tbxSubscriberKey1.Text = "bwilson@agencyoasis.com";
                tbxSubscriberFN1.Text = "Brian";

                tbxSubscriberEmail2.Text = "jtesta@agencyoasis.com";
                tbxSubscriberKey2.Text = "jtesta@agencyoasis.com";
                tbxSubscriberFN2.Text = "Joe";

                tbxCustomerKey.Text = "201"; //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
                tbxEmailID.Text = "177";   // This is the "Text Only Test Email" configured within NCLD's ExactTarget system ....  Available in the ET UI [Content > My Emails > Properties]

                lblMessage.Text = "Email Test has not started ...";
            }
        }

        protected void btnETTests_Click(object sender, EventArgs e)
        {


            ETBaseConfig etBaseConfig = new ETBaseConfig();
           // etBaseConfig.ExactTargetWSUsername = "NCLDDEV01";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
           // etBaseConfig.ExactTargetWSPassword = "NCLDDEV01!!";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
             
            ETEmail etEmail = new ETEmail();
            //etEmail.CustomerKey = "201";   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
            //etEmail.EmailID = "103";   // This is the "Text Only Test Email" configured within NCLD's ExactTarget system ....  Available in the ET UI [Content > My Emails > Properties]
            etEmail.CustomerKey = tbxCustomerKey.Text;   //required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
            etEmail.EmailID = tbxEmailID.Text;   // This is the "Text Only Test Email" configured within NCLD's ExactTarget system ....  Available in the ET UI [Content > My Emails > Properties]                                     

            ETSubscriber etSubscriber1 = new ETSubscriber();
            etSubscriber1.Email = tbxSubscriberEmail1.Text;
            etSubscriber1.Key = tbxSubscriberKey1.Text;
            etSubscriber1.FN = tbxSubscriberFN1.Text;           
            //etSubscriber1.Email = "wilsonbri@gmail.com";
            //etSubscriber1.Key = "wilsonbri@gmail.com";
            //etSubscriber1.FN = "wilsonbri";

            ETSubscriber etSubscriber2 = new ETSubscriber();
            etSubscriber2.Email = tbxSubscriberEmail2.Text;
            etSubscriber2.Key = tbxSubscriberKey2.Text;
            etSubscriber2.FN = tbxSubscriberFN2.Text; 
            //etSubscriber2.Email = "bwilson@agnecyoasis.com";
            //etSubscriber2.Key = "bwilson@agnecyoasi.com";
            //etSubscriber2.FN = "Brian";

            TriggeredSendEmail tse = new TriggeredSendEmail();
            tse.ETBaseConfig = etBaseConfig;
            tse.ETEmail = etEmail;

            
            List<ETSubscriber> etSubscriberList = new List<ETSubscriber>();
            etSubscriberList.Add(etSubscriber1);
            etSubscriberList.Add(etSubscriber2);

            tse.ETSubscriberList = etSubscriberList;

            IExactTargetService etService = new ExactTargetService();
            lblMessage.Text = etService.InvokeTriggeredSendEmail(tse);
        }        
    }
}