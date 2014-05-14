using Sitecore.Diagnostics;
using System;
using System.Configuration;
using System.ServiceModel;
using System.Text;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Services.ExactTarget.etAPI;

namespace UnderstoodDotOrg.Services.ExactTarget
{
	public static class ExactTargetService
	{
		private static SoapClient GetInstance()
		{
			// Create the binding
			BasicHttpBinding binding = new BasicHttpBinding();
			binding.Name = "UserNameSoapBinding";
			binding.Security.Mode = BasicHttpSecurityMode.TransportWithMessageCredential;
			binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

			TimeSpan timespan = new TimeSpan(0, 5, 0);
			binding.ReceiveTimeout = timespan;
			binding.OpenTimeout = timespan;
			binding.CloseTimeout = timespan;
			binding.SendTimeout = timespan;

			// Set the transport security to UsernameOverTransport for Plaintext usernames
			EndpointAddress endpoint = new EndpointAddress("https://webservice.s6.exacttarget.com/Service.asmx");

			// Create the SOAP Client (and pass in the endpoint and the binding)
			SoapClient client = new SoapClient(binding, endpoint);

			// Set the username and password
			client.ClientCredentials.UserName.UserName = "bmedulan@agencyoasis.com";
			client.ClientCredentials.UserName.Password = "Hm6@5G!tT";

			return client;
		}

		private static string GetCustomerKey()
		{
			return ConfigurationManager.AppSettings["ExactTargetCustomerKey"];
		}

		private static TriggeredSendDefinition GetSendDefinition(string strGUID, int etEmailId)
		{
			//Create TriggeredSendDefinition object [Messages > Email > Triggered]
			TriggeredSendDefinition tsd = new TriggeredSendDefinition();
			//tsd.Email.HTMLBody
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
			Email em = new Email();
			em.ID = etEmailId;
			//em.ID = 620046;//required //Available in the ET UI [Content > My Emails > Properties]
			em.IDSpecified = true;//required

			//Apply Email object to the TriggeredSendDefinition object
			tsd.Email = em;//required
			tsd.Email.IsHTMLPaste = true;

			//Create SendClassification
			tsd.SendClassification = new SendClassification();
			// tsd.SendClassification.CustomerKey = "4201";//required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
			tsd.SendClassification.CustomerKey = ConfigurationManager.AppSettings["ExactTargetCustomerKey"]; // triggeredSendEmail.ETEmail.CustomerKey;//required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]

			return tsd;
		}

		private static string GetCreateResult(ref SoapClient client, TriggeredSendDefinition tsd, ref StringBuilder sbReturnString)
		{
			string cRequestID = String.Empty;
			string cStatus = String.Empty;

			try
			{
				//Call the Create method on the TriggeredSendDefinition object
				CreateResult[] cResults = client.Create(new CreateOptions(), new APIObject[] { tsd }, out cRequestID, out cStatus);

				Log.Info("[EXACTTARGET] Overall Create Status: " + cStatus, "");
				Log.Info("[EXACTTARGET] Number of Results: " + cResults.Length, "");
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
					Log.Info("[EXACTTARGET] Status Message: " + cr.StatusMessage, "");
					sbReturnString.Append("[EXACTTARGET] Status Message: " + cr.StatusMessage).AppendLine();

					//lblMessage.Text += "Status Message: " + cr.StatusMessage;
					//lblMessage.Text += "<br/>";
				}
			}
			catch (Exception exCreate)
			{
				//Set Message
				Log.Error("[EXACTTARGET] CREATE TSD ERROR: " + exCreate.Message.ToString(), exCreate, "");
				//lblMessage.Text += "<br/><br/>CREATE TSD ERROR:<br/>" + exCreate.Message;
				// sbReturnString.Append("[EXACTTARGET] CREATE TSD ERROR: " + exCreate.Message.ToString()).AppendLine();
				throw;
			}

			return cStatus;
		}

		private static string GetUpdateResult(ref SoapClient client, TriggeredSendDefinition tsd, ref StringBuilder sbReturnString)
		{
			string uRequestID = String.Empty;
			string uStatus = String.Empty;

			try
			{
				//Call the Create method on the EmailSendDefinition object
				UpdateResult[] uResults = client.Update(new UpdateOptions(), new APIObject[] { tsd }, out uRequestID, out uStatus);

				//Display Results
				Log.Info("[EXACTTARGET] Overall Create Status: " + uStatus, "");
				Log.Info("[EXACTTARGET] Number of Results: " + uResults.Length, "");
				sbReturnString.Append("[EXACTTARGET] Overall Create Status: " + uStatus).AppendLine();
				sbReturnString.Append("[EXACTTARGET] Number of Results: " + uResults.Length).AppendLine();
				//lblMessage.Text += "Overall Update Status: " + uStatus;
				//lblMessage.Text += "<br/>";
				//lblMessage.Text += "Number of Results: " + uResults.Length;
				//lblMessage.Text += "<br/>";

				//Loop through each object returned and display the StatusMessage
				foreach (UpdateResult ur in uResults)
				{
					Log.Info("[EXACTTARGET] Status Message: " + ur.StatusMessage, "");
					sbReturnString.Append("[EXACTTARGET] Status Message: " + ur.StatusMessage).AppendLine();
					//lblMessage.Text += "Status Message: " + ur.StatusMessage;
					//lblMessage.Text += "<br/>";
				}
			}
			catch (Exception exCreate)
			{
				//Set Message
				Log.Error("[EXACTTARGET] UPDATE TSD ERROR: " + exCreate.Message.ToString(), exCreate, "");
				throw;
				//sbReturnString.Append("[EXACTTARGET] UPDATE TSD ERROR: " + exCreate.Message).AppendLine();
				//lblMessage.Text += "<br/><br/>UPDATE TSD ERROR:<br/>" + exCreate.Message;

			}

			return uStatus;
		}

		private static void SendEmail(ref SoapClient client, TriggeredSendDefinition tsd, ref StringBuilder sbReturnString, Subscriber newSub)
		{
			TriggeredSend ts = new TriggeredSend();
			ts.TriggeredSendDefinition = tsd;
			ts.Subscribers = new Subscriber[] { newSub };

			string tsRequestID = "";
			string tsStatus = "";

			try
			{
				//Call the Create method on the TriggeredSend object
				CreateResult[] tsResults = client.Create(new CreateOptions(), new APIObject[] { ts }, out tsRequestID, out tsStatus);

				//Display Results
				Log.Info("[EXACTTARGET] Overall Create Status: " + tsResults, "");
				Log.Info("[EXACTTARGET] Number of Results: " + tsResults.Length, "");
				sbReturnString.Append("<br />[EXACTTARGET] Overall Create Status: " + tsResults).AppendLine();
				sbReturnString.Append("<br />[EXACTTARGET] Number of Results: " + tsResults.Length).AppendLine();
				//lblMessage.Text += "Overall Update Status: " + tsStatus;
				//lblMessage.Text += "<br/>";
				//lblMessage.Text += "Number of Results: " + tsResults.Length;
				//lblMessage.Text += "<br/>";

				//Loop through each object returned and display the StatusMessage
				foreach (CreateResult tscr in tsResults)
				{
					Log.Info("[EXACTTARGET] Status Message: " + tscr.StatusMessage.ToString(), "");
					sbReturnString.Append("<br />[EXACTTARGET] Status Message: " + tscr.StatusMessage).AppendLine();
					//lblMessage.Text += "Status Message: " + tscr.StatusMessage;
					//lblMessage.Text += "<br/>";
				}
			}
			catch (Exception exCreate)
			{

				Log.Error("<br />[EXACTTARGET] CREATE TS ERROR: " + exCreate.Message.ToString(), exCreate, "");
				//sbReturnString.Append("[EXACTTARGET] CREATE TS ERROR: " + exCreate.Message).AppendLine();
				//lblMessage.Text += "<br/><br/>CREATE TS ERROR:<br/>" + exCreate.Message;
				throw;
			}
		}

		//triggers send of test email based on Email ID
		public static string InvokeTriggeredSendEmail(string toEmail, string fullName, string htmlContent)
		{
			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 216);

				string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

				if (cStatus == "OK")
				{
					tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
					tsd.TriggeredSendStatusSpecified = true; //required

					string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

					if (uStatus == "OK")
					{
						// *** SEND THE TRIGGER EMAIL
						Subscriber newSub = new Subscriber();
						newSub.EmailAddress = toEmail;
						newSub.SubscriberKey = toEmail;

						ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);
					}
				}
			}
			catch (Exception exc)
			{
				Log.Error("[EXACTTARGET] ERROR: " + exc.Message.ToString(), exc, "");
			}

			return (sbReturnString.ToString());
		}

		//Transactional Email methods
		public static InvokeEM2ParentToolkitReply InvokeEM2ParentToolkit(InvokeEM2ParentToolkitRequest request)
		{
			InvokeEM2ParentToolkitReply reply = new InvokeEM2ParentToolkitReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 216);

				string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

				if (cStatus == "OK")
				{
					tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
					tsd.TriggeredSendStatusSpecified = true; //required

					string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

					if (uStatus == "OK")
					{
						// *** SEND THE TRIGGER EMAIL
						Subscriber newSub = new Subscriber();
						newSub.EmailAddress = request.ToEmail;
						newSub.SubscriberKey = request.ToEmail;

						ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

						reply.Successful = true;
					}
				}
			}
			catch (Exception exc)
			{
				string message = "Unable to send Parent Toolkit email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "");
			}

			return reply;
		}

		public static InvokeWelcomeToUnderstoodReply InvokeWelcomeToUnderstood(InvokeWelcomeToUnderstoodRequest request)
		{
			InvokeWelcomeToUnderstoodReply reply = new InvokeWelcomeToUnderstoodReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 312);

				string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

				if (cStatus == "OK")
				{
					tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
					tsd.TriggeredSendStatusSpecified = true; //required

					string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

					if (uStatus == "OK")
					{
						// *** SEND THE TRIGGER EMAIL
						Subscriber newSub = new Subscriber();
						newSub.EmailAddress = request.ToEmail;
						newSub.SubscriberKey = request.ToEmail;

						newSub.Attributes = new etAPI.Attribute[1];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "fullname";
						newSub.Attributes[0].Value = request.FirstName;

						ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

						reply.Successful = true;
					}
				}
			}
			catch (Exception exc)
			{
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "");
			}

			return reply;
		}

		public static void InvokeEM10WebinarCinfirmation(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM11DonationAcknowledgement(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM12ThankYouForContactingUs(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM15HappyHolidays(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM3ExploreTheCommunity(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM4LearnAct(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM5KeepingAllStudentsSafe(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM6HolidayDonations(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM7NewsletterConfirmation(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM8SubscriptionConfirmation(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM9GroupWelcome(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}



		//Newsletter Email methods
		public static void InvokeE1ATurnAroundBullying(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeE1B1TurnAroundBullying(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeE1B2TurnAroundBullying(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeE1CTurnAroundBullying(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM13ActivityFromToday(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
		public static void InvokeEM14ThisWeeksActivity(string EmailAddress)
		{
			SoapClient client = ExactTargetService.GetInstance();

			string customerKey = ExactTargetService.GetCustomerKey();

			// ID of email in ExactTarget (ETEmail.EmailID): 216

			//client.
		}
	}
}