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
			client.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["ExactTargetUserName"]; 
			client.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["ExactTargetPassword"];

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
			// tsd.SendClassification.CustomerKey = "201";//required //Available in the ET UI [Admin > Send Management > Send Classifications > Edit Item > External Key]
			tsd.SendClassification.CustomerKey = ConfigurationManager.AppSettings["ExactTargetCustomerKey"];

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
				Log.Error("[EXACTTARGET] CREATE TSD ERROR: " + exCreate.Message.ToString(), exCreate, "something went wrong");
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
				Log.Error("[EXACTTARGET] UPDATE TSD ERROR: " + exCreate.Message.ToString(), exCreate, "something went wrong");
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

				Log.Error("<br />[EXACTTARGET] CREATE TS ERROR: " + exCreate.Message.ToString(), exCreate, "something went wrong");
				//sbReturnString.Append("[EXACTTARGET] CREATE TS ERROR: " + exCreate.Message).AppendLine();
				//lblMessage.Text += "<br/><br/>CREATE TS ERROR:<br/>" + exCreate.Message;
				throw;
			}
		}

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
				Log.Error("[EXACTTARGET] ERROR: " + exc.Message.ToString(), exc, "something went wrong");
			}

			return (sbReturnString.ToString());
		}

		//Transactional Email methods TODO: edit Email ID and confirm which parts of a template are dynamic
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

				Log.Error(exc.ToString(), "something went wrong");
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
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 352);

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

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM10WebinarConfirmationReply InvokeEM10WebinarConfirmation(InvokeEM10WebinarConfirmationRequest request)
		{
			InvokeEM10WebinarConfirmationReply reply = new InvokeEM10WebinarConfirmationReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
						newSub.Attributes[0].Name = "webinar_module";
						newSub.Attributes[0].Value = request.WebinarModule;

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

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM11DonationAcknowledgementReply InvokeEM11DonationAcknowledgement(InvokeEM11DonationAcknowledgementRequest request) {
			InvokeEM11DonationAcknowledgementReply reply = new InvokeEM11DonationAcknowledgementReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}//This email will be sent from Convio/Luminate.
		public static InvokeEM12ThankYouForContactingUsReply InvokeEM12ThankYouForContactingUs(InvokeEM12ThankYouForContactingUsRequest request) {
			InvokeEM12ThankYouForContactingUsReply reply = new InvokeEM12ThankYouForContactingUsReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM15HappyHolidaysReply InvokeEM15ThankYouForContactingUs(InvokeEM15HappyHolidaysRequest request)
		{
			InvokeEM15HappyHolidaysReply reply = new InvokeEM15HappyHolidaysReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM3ExploreTheCommunityReply InvokeEM3ExploreTheCommunity(InvokeEM3ExploreTheCommunityRequest request)
		{
			InvokeEM3ExploreTheCommunityReply reply = new InvokeEM3ExploreTheCommunityReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM4LearnActReply InvokeEM4LearnAct(InvokeEM4LearnActRequest request) {
			InvokeEM4LearnActReply reply = new InvokeEM4LearnActReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}//This email will be sent from Convio/Luminate.
		public static InvokeEM5KeepingAllStudentsSafeReply InvokeEM5KeepingAllStudentsSafe(InvokeEM5KeepingAllStudentsSafeRequest request) {
			InvokeEM5KeepingAllStudentsSafeReply reply = new InvokeEM5KeepingAllStudentsSafeReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}//This email will be sent from Convio/Luminate.
		public static InvokeEM6HolidayDonationsReply InvokeEM6HolidayDonations(InvokeEM6HolidayDonationsRequest request) {
			InvokeEM6HolidayDonationsReply reply = new InvokeEM6HolidayDonationsReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM7NewsletterConfirmationReply InvokeEM7NewsletterConfirmation(InvokeEM7NewsletterConfirmationRequest request) {
			InvokeEM7NewsletterConfirmationReply reply = new InvokeEM7NewsletterConfirmationReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 447);

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

						newSub.Attributes = new etAPI.Attribute[2];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "week_day";
						newSub.Attributes[0].Value = request.WeekDay;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "confirm_subscription_link";
						newSub.Attributes[1].Value = request.WeekDay;

						

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

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM8SubscriptionConfirmationReply InvokeEM8SubscriptionConfirmation(InvokeEM8SubscriptionConfirmationRequest request) {
			InvokeEM8SubscriptionConfirmationReply reply = new InvokeEM8SubscriptionConfirmationReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM9GroupWelcomeReply InvokeEM9GroupWelcome(InvokeEM9GroupWelcomeRequest request) {
			InvokeEM9GroupWelcomeReply reply = new InvokeEM9GroupWelcomeReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		
		//#region
		//public static InvokeEM16ContentReminderReply InvokeEM16ContentReminder(InvokeEM16ContentReminderRequest request)
		//{
		//	InvokeEM16ContentReminderReply reply = new InvokeEM16ContentReminderReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM17ObservationLogReminderReply InvokeEM17ObservationLogReminder(InvokeEM17ObservationLogReminderRequest request)
		//{
		//	InvokeEM17ObservationLogReminderReply reply = new InvokeEM17ObservationLogReminderReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM18UpdateProfileReminderReply InvokeEM18UpdateProfileReminder(InvokeEM18UpdateProfileReminderRequest request)
		//{
		//	InvokeEM18UpdateProfileReminderReply reply = new InvokeEM18UpdateProfileReminderReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM19WebinarReminderReply InvokeEM19WebinarReminder(InvokeEM19WebinarReminderRequest request)
		//{
		//	InvokeEM19WebinarReminderReply reply = new InvokeEM19WebinarReminderReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM20SupportPlanReminderReply InvokeEM20SupportPlanReminder(InvokeEM20SupportPlanReminderRequest request)
		//{
		//	InvokeEM20SupportPlanReminderReply reply = new InvokeEM20SupportPlanReminderReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM21PrivateMessageReply InvokeEM21PrivateMessage(InvokeEM21PrivateMessageRequest request)
		//{
		//	InvokeEM21PrivateMessageReply reply = new InvokeEM21PrivateMessageReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM22ForgotPasswordReply InvokeEM22ForgotPassword(InvokeEM22ForgotPasswordRequest request)
		//{
		//	InvokeEM22ForgotPasswordReply reply = new InvokeEM22ForgotPasswordReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM23PasswordResetConfirmationReply InvokeEM23PasswordResetConfirmation(InvokeEM23PasswordResetConfirmationRequest request)
		//{
		//	InvokeEM23PasswordResetConfirmationReply reply = new InvokeEM23PasswordResetConfirmationReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM24ContentSharedWithAFriendReply InvokeEM24ContentSharedWithAFriend(InvokeEM24ContentSharedWithAFriendRequest request)
		//{
		//	InvokeEM24ContentSharedWithAFriendReply reply = new InvokeEM24ContentSharedWithAFriendReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM25WebinarSharedWithAFriendReply InvokeEM25WebinarSharedWithAFriend(InvokeEM25WebinarSharedWithAFriendRequest request)
		//{
		//	InvokeEM25WebinarSharedWithAFriendReply reply = new InvokeEM25WebinarSharedWithAFriendReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM26JournalSharedWithAFriendReply InvokeEM26JournalSharedWithAFriend(InvokeEM26JournalSharedWithAFriendRequest request)
		//{
		//	InvokeEM26JournalSharedWithAFriendReply reply = new InvokeEM26JournalSharedWithAFriendReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM27SupportPlanReply InvokeEM27SupportPlan(InvokeEM27SupportPlanRequest request)
		//{
		//	InvokeEM27SupportPlanReply reply = new InvokeEM27SupportPlanReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM28AppsTechnologySharedWithAFriendReply InvokeEM28AppsTechnologySharedWithAFriend(InvokeEM28AppsTechnologySharedWithAFriendRequest request)
		//{
		//	InvokeEM28AppsTechnologySharedWithAFriendReply reply = new InvokeEM28AppsTechnologySharedWithAFriendReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM29SchoolSharedWithAFriendReply InvokeEM29SchoolSharedWithAFriend(InvokeEM29SchoolSharedWithAFriendRequest request)
		//{
		//	InvokeEM29SchoolSharedWithAFriendReply reply = new InvokeEM29SchoolSharedWithAFriendReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}
		//public static InvokeEM30ReengagementStream1Reply InvokeEM30ReengagementStream1(InvokeEM30ReengagementStream1Request request)
		//{
		//	InvokeEM30ReengagementStream1Reply reply = new InvokeEM30ReengagementStream1Reply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

		//		string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//		if (cStatus == "OK")
		//		{
		//			tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//			tsd.TriggeredSendStatusSpecified = true; //required

		//			string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//			if (uStatus == "OK")
		//			{
		//				// *** SEND THE TRIGGER EMAIL
		//				Subscriber newSub = new Subscriber();
		//				newSub.EmailAddress = request.ToEmail;
		//				newSub.SubscriberKey = request.ToEmail;


		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//				reply.Successful = true;
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		string message = "Unable to send welcome email.";

		//		reply.Successful = false;
		//		reply.Message = message;

		//		Log.Error(exc.ToString(), "something went wrong");
		//	}

		//	return reply;
		//}


		//Newsletter Email methods

		public static InvokeE1ATurnAroundBullyingReply InvokeE1ATurnAroundBullying(InvokeE1ATurnAroundBullyingRequest request) {
			InvokeE1ATurnAroundBullyingReply reply = new InvokeE1ATurnAroundBullyingReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeE1B1TurnAroundBullyingReply InvokeE1B1TurnAroundBullying(InvokeE1B1TurnAroundBullyingRequest request) {
			InvokeE1B1TurnAroundBullyingReply reply = new InvokeE1B1TurnAroundBullyingReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeE1B2TurnAroundBullyingReply InvokeE1B2TurnAroundBullying(InvokeE1B2TurnAroundBullyingRequest request) {
			InvokeE1B2TurnAroundBullyingReply reply = new InvokeE1B2TurnAroundBullyingReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeE1CTurnAroundBullyingReply InvokeE1CTurnAroundBullying(InvokeE1CTurnAroundBullyingRequest request) {
			InvokeE1CTurnAroundBullyingReply reply = new InvokeE1CTurnAroundBullyingReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM13ActivityFromTodayReply InvokeEM13ActivityFromToday(InvokeEM13ActivityFromTodayRequest request) {
			InvokeEM13ActivityFromTodayReply reply = new InvokeEM13ActivityFromTodayReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
		public static InvokeEM14ThisWeeksActivityReply InvokeEM14ThisWeeksActivity(InvokeEM14ThisWeeksActivityRequest request){
			InvokeEM14ThisWeeksActivityReply reply = new InvokeEM14ThisWeeksActivityReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335);

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
				string message = "Unable to send welcome email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}


	}
}