using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Diagnostics;
using UnderstoodDotOrg.Services.ExactTarget;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Services.ExactTarget.etAPI;
using System.ServiceModel;


namespace UnderstoodDotOrg.Services.ExactTarget
{
    public class ExactTargetService : IExactTargetService
    {

        private etAPI.SoapClient client;

        //constructor
        public ExactTargetService()
        {


            // Create the binding
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Name = "UserNameSoapBinding";
            binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.ReceiveTimeout = new TimeSpan(0, 5, 0);
            binding.OpenTimeout = new TimeSpan(0, 5, 0);
            binding.CloseTimeout = new TimeSpan(0, 5, 0);
            binding.SendTimeout = new TimeSpan(0, 5, 0);

            // Set the transport security to UsernameOverTransport for Plaintext usernames
            EndpointAddress endpoint = new EndpointAddress("https://webservice.s6.exacttarget.com/Service.asmx");

            //// Create the SOAP Client (and pass in the endpoint and the binding)
            //SoapClient etFramework = new SoapClient(binding, endpoint);

            //// Set the username and password
            //etFramework.ClientCredentials.UserName.UserName = "NCLDDEV01";
            //etFramework.ClientCredentials.UserName.Password = "NCLDDEV01!@";

            // Create the SOAP Client (and pass in the endpoint and the binding)
            client = new SoapClient(binding, endpoint);

            // Set the username and password
            client.ClientCredentials.UserName.UserName = "bmedulan@agencyoasis.com";
            client.ClientCredentials.UserName.Password = "Hm6@5G!tT";
            //client.ClientCredentials.UserName.UserName = "NCLDDEV01";
            //client.ClientCredentials.UserName.Password = "NCLDDEV01!@";

        }

       

        public string InvokeTriggeredSendEmail(TriggeredSendEmail triggeredSendEmail)
        {

            StringBuilder sbReturnString = new StringBuilder();


            try
            {

                 //client = new SoapClient();

                //Authenticate
                //client.ClientCredentials.UserName.UserName = triggeredSendEmail.ETBaseConfig.ExactTargetWSUsername;
                //client.ClientCredentials.UserName.Password = triggeredSendEmail.ETBaseConfig.ExactTargetWSPassword;

                //Create a GUID for ESD to ensure a unique name and customer key
                string strGUID = System.Guid.NewGuid().ToString();

                //Create TriggeredSendDefinition object [Messages > Email > Triggered]
                TriggeredSendDefinition tsd = new TriggeredSendDefinition();
                tsd.Name = "TSD_Name_" + strGUID;//required
                tsd.CustomerKey = strGUID;//recommended or the application will assign a number
                tsd.Description = "TSD_Description_" + strGUID;//recommended or the Description will default to the Name

                //Set to delivery both Text and HTML versions.
                tsd.IsMultipart = true;//recommended as a best practice
                tsd.IsMultipartSpecified = true;//required

                //Set to track the links found in the email
                tsd.IsWrapped = true;//recommended to take advantage of ExactTarget's tracking
                tsd.IsWrappedSpecified = true;//required

                //Create Email object to refer to pre-create Email
                UnderstoodDotOrg.Services.ExactTarget.etAPI.Email em = new UnderstoodDotOrg.Services.ExactTarget.etAPI.Email();
                em.ID = Convert.ToInt16(triggeredSendEmail.ETEmail.EmailID);
                //em.ID = 620046;//required //Available in the ET UI [Content > My Emails > Properties]
                em.IDSpecified = true;//required

                //Apply Email object to the TriggeredSendDefinition object
                tsd.Email = em;//required

                //Create SendClassification
                tsd.SendClassification = new SendClassification();
               // tsd.SendClassification.CustomerKey = "4201";//required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
                tsd.SendClassification.CustomerKey = triggeredSendEmail.ETEmail.CustomerKey;//required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]

                
                string cRequestID = String.Empty;
                string cStatus = String.Empty;

                    try
                    {
                        //Call the Create method on the TriggeredSendDefinition object
                        CreateResult[] cResults = client.Create(new CreateOptions(), new APIObject[] { tsd }, out cRequestID, out cStatus);

                       Log.Info("[EXACTTARGET] Overall Create Status: " + cStatus, this);
                       Log.Info("[EXACTTARGET] Number of Results: " + cResults.Length, this);
                       sbReturnString.Append("[EXACTTARGET] Overall Create Status: " + cStatus).AppendLine();
                       sbReturnString.Append("[EXACTTARGET] Number of Results: " + cResults.Length).AppendLine();


                        ////Display Results
                       //lblMessage.Text += "Overall Create Status: " + cStatus;
                       //lblMessage.Text += "<br/>";
                       //lblMessage.Text += "Number of Results: " + cResults.Length;
                       //lblMessage.Text += "<br/>";
                        
                        //Loop through each object returned and display the StatusMessage
                        foreach (CreateResult cr in cResults)
                        {
                            Log.Info("[EXACTTARGET] Status Message: " + cr.StatusMessage, this);
                            sbReturnString.Append("[EXACTTARGET] Status Message: " + cr.StatusMessage).AppendLine();

                            //lblMessage.Text += "Status Message: " + cr.StatusMessage;
                            //lblMessage.Text += "<br/>";
                        }
                    }
                    catch (Exception exCreate)
                    {
                        //Set Message
                        Log.Error("[EXACTTARGET] CREATE TSD ERROR: " + exCreate.Message.ToString(), exCreate, this);
                        //lblMessage.Text += "<br/><br/>CREATE TSD ERROR:<br/>" + exCreate.Message;
                        // sbReturnString.Append("[EXACTTARGET] CREATE TSD ERROR: " + exCreate.Message.ToString()).AppendLine();
                        throw;
                    }

                    //Preceed if the above Create call was successful
                    if (cStatus == "OK")
                    {

                        // *** MAKE TRIGGERED SEND DEFINITION ACTIVE  
                        tsd = new TriggeredSendDefinition();
                        tsd.CustomerKey = strGUID;//required
                        tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active;//necessary to set the TriggeredSendDefinition to "Running"
                        tsd.TriggeredSendStatusSpecified = true;//required

                        string uRequestID = String.Empty;
                        string uStatus = String.Empty;

                        try
                        {
                            //Call the Create method on the EmailSendDefinition object
                            UpdateResult[] uResults = client.Update(new UpdateOptions(), new APIObject[] { tsd }, out uRequestID, out uStatus);

                            //Display Results
                           Log.Info("[EXACTTARGET] Overall Create Status: " + cStatus, this);
                           Log.Info("[EXACTTARGET] Number of Results: " + uResults.Length, this);
                           sbReturnString.Append("[EXACTTARGET] Overall Create Status: " + cStatus).AppendLine();
                           sbReturnString.Append("[EXACTTARGET] Number of Results: " + uResults.Length).AppendLine();
                            //lblMessage.Text += "Overall Update Status: " + uStatus;
                            //lblMessage.Text += "<br/>";
                            //lblMessage.Text += "Number of Results: " + uResults.Length;
                            //lblMessage.Text += "<br/>";

                            //Loop through each object returned and display the StatusMessage
                            foreach (UpdateResult ur in uResults)
                            {
                                Log.Info("[EXACTTARGET] Status Message: " + ur.StatusMessage, this);
                                sbReturnString.Append("[EXACTTARGET] Status Message: " + ur.StatusMessage).AppendLine();
                                //lblMessage.Text += "Status Message: " + ur.StatusMessage;
                                //lblMessage.Text += "<br/>";
                            }
                        }
                        catch (Exception exCreate)
                        {
                            //Set Message
                            Log.Error("[EXACTTARGET] UPDATE TSD ERROR: " + exCreate.Message.ToString(), exCreate, this);
                            throw;
                            //sbReturnString.Append("[EXACTTARGET] UPDATE TSD ERROR: " + exCreate.Message).AppendLine();
                            //lblMessage.Text += "<br/><br/>UPDATE TSD ERROR:<br/>" + exCreate.Message;
                            
                        }

                        //Preceed if the above Update call was successful
                        if (uStatus == "OK")
                        {
                            // *** SEND THE TRIGGER EMAIL

                            //Create a new Subscriber to send the Trigger to
                            Subscriber newSub = new Subscriber();
                            newSub.EmailAddress = triggeredSendEmail.ETSubscriberList[0].Email;
                            newSub.SubscriberKey = triggeredSendEmail.ETSubscriberList[0].Key;


                            //Create Subscriber Attributes
                            newSub.Attributes = new etAPI.Attribute[2];//Attributes are available in the ET UI [Subscribers > Profile Management]
                            //1
                            newSub.Attributes[0] = new etAPI.Attribute();
                            newSub.Attributes[0].Name = "FromName";//Account Specific
                            newSub.Attributes[0].Value = "From " + triggeredSendEmail.ETSubscriberList[0].FN;//Subscriber Specific
                            //2
                            newSub.Attributes[1] = new etAPI.Attribute();
                            newSub.Attributes[1].Name = "HTML__Content";//Account Specific
                            newSub.Attributes[1].Value = "This is a test <a href=\"httpgetwrap|http://google.com\" alias=\"Google Link\">link</a>"; //httpgetwrap| must be before the http for ExactTarget to track this URL //Subscriber Specific

                            //Create a new Subscriber to send the Trigger to
                            Subscriber newSub2 = new Subscriber();
                            newSub2.EmailAddress = triggeredSendEmail.ETSubscriberList[1].Email;
                            newSub2.SubscriberKey = triggeredSendEmail.ETSubscriberList[1].Key;

                            //Create Subscriber Attributes
                            newSub2.Attributes = new etAPI.Attribute[2];//Attributes are available in the ET UI [Subscribers > Profile Management]
                            //1
                            newSub2.Attributes[0] = new etAPI.Attribute();
                            newSub2.Attributes[0].Name = "FromName";//Account Specific
                            newSub2.Attributes[0].Value = "From " + triggeredSendEmail.ETSubscriberList[1].FN;//Subscriber Specific
                            //2
                            newSub2.Attributes[1] = new etAPI.Attribute();
                            newSub2.Attributes[1].Name = "HTML__Content";//Account Specific
                            newSub2.Attributes[1].Value = "This is a test <a href=\"httpgetwrap|http://exacttarget.com\" alias=\"ET Link\">link</a>"; //httpgetwrap| must be before the http for ExactTarget to track this URL //Subscriber Specific

                            //Create a TriggeredSend object to referrence the earlier created TriggeredSendDefinition
                            TriggeredSend ts = new TriggeredSend();
                            ts.TriggeredSendDefinition = new TriggeredSendDefinition();
                            ts.TriggeredSendDefinition.CustomerKey = strGUID;//This is the External Key from the UI

                            ts.Subscribers = new Subscriber[] { newSub, newSub2 };//Add the Subscriber objects to the TriggeredSend object

                            string tsRequestID = "";
                            string tsStatus = "";

                            try
                            {
                                //Call the Create method on the TriggeredSend object
                                CreateResult[] tsResults = client.Create(new CreateOptions(), new APIObject[] { ts }, out tsRequestID, out tsStatus);

                                //Display Results
                               Log.Info("[EXACTTARGET] Overall Create Status: " + tsResults, this);
                               Log.Info("[EXACTTARGET] Number of Results: " + tsResults.Length, this);
                               sbReturnString.Append("[EXACTTARGET] Overall Create Status: " + tsResults).AppendLine();
                               sbReturnString.Append("[EXACTTARGET] Number of Results: " + tsResults.Length).AppendLine();
                                //lblMessage.Text += "Overall Update Status: " + tsStatus;
                                //lblMessage.Text += "<br/>";
                                //lblMessage.Text += "Number of Results: " + tsResults.Length;
                                //lblMessage.Text += "<br/>";

                                //Loop through each object returned and display the StatusMessage
                                foreach (CreateResult tscr in tsResults)
                                {
                                    Log.Info("[EXACTTARGET] Status Message: " + tscr.StatusMessage.ToString(), this);
                                    sbReturnString.Append("[EXACTTARGET] Status Message: " + tscr.StatusMessage).AppendLine();
                                    //lblMessage.Text += "Status Message: " + tscr.StatusMessage;
                                    //lblMessage.Text += "<br/>";
                                }
                            }
                            catch (Exception exCreate)
                            {

                                Log.Error("[EXACTTARGET] CREATE TS ERROR: " + exCreate.Message.ToString(), exCreate, this);
                                //sbReturnString.Append("[EXACTTARGET] CREATE TS ERROR: " + exCreate.Message).AppendLine();
                                //lblMessage.Text += "<br/><br/>CREATE TS ERROR:<br/>" + exCreate.Message;
                                throw;
                            }
                        }
                    }
            }
            catch (Exception exc)
            {
                //Set Message
                //lblMessage.Text += "<br/><br/><h3>ERROR</h3><br/>" + exc.Message;
                Log.Error("[EXACTTARGET] ERROR: " + exc.Message.ToString(), exc, this);
                //sbReturnString.Append("[EXACTTARGET] ERROR: " + exc.Message).AppendLine();
                throw;
            }


            return (sbReturnString.ToString());

            
        }
        
    }
}
