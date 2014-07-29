using Sitecore.Diagnostics;
using System;
using System.Linq;
using System.Configuration;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Personalization;
using UnderstoodDotOrg.Services.ExactTarget.etAPI;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System.IO;
using System.Xml;
using System.Collections.Generic;

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

		private static TriggeredSendDefinition GetSendDefinition(string strGUID, int etEmailId, string toEmail, string emailName)
		{
			//Create TriggeredSendDefinition object [Messages > Email > Triggered]
			TriggeredSendDefinition tsd = new TriggeredSendDefinition();
			//tsd.Email.HTMLBody
			tsd.Name = strGUID;//required
			tsd.CustomerKey = strGUID;//recommended or the application will assign a number
			tsd.Description = emailName + " to " + toEmail;//recommended or the Description will default to the Name

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
				foreach (TriggeredSendCreateResult tscr in tsResults)
				{
					Log.Info("[EXACTTARGET] Status Message: " + tscr.StatusMessage.ToString(), "");
					sbReturnString.Append("<br />[EXACTTARGET] Status Message: " + tscr.StatusMessage).AppendLine();

                    if (tscr.SubscriberFailures != null)
                    {
                        sbReturnString.Append("<br/>[EXACTTARGET] Subscriber failures: <br/>");

                        foreach (SubscriberResult sr in tscr.SubscriberFailures)
                        {
                            Log.Info(String.Format("[EXACTTARGET] Subscriber failure : ({0}) {1}", sr.ErrorCode, sr.ErrorDescription), "");
                            sbReturnString.Append("<br/>[EXACTTARGET] ErrorDescription: " + sr.ErrorDescription);
                            sbReturnString.Append("<br/>[EXACTTARGET] Error Code: " + sr.ErrorCode + "<br />");
                        }
                    }
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

		//public static string InvokeTriggeredSendEmail(string toEmail, string fullName, string htmlContent)
		//{
		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 216, toEmail);

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
		//				newSub.EmailAddress = toEmail;
		//				newSub.SubscriberKey = toEmail;

		//				ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);
		//			}
		//		}
		//	}
		//	catch (Exception exc)
		//	{
		//		Log.Error("[EXACTTARGET] ERROR: " + exc.Message.ToString(), exc, "something went wrong");
		//	}

		//	return (sbReturnString.ToString());
		//}

		//Transactional Email methods TODO: edit Email ID and confirm which parts of a template are dynamic
		public static BaseReply InvokeEM2ParentToolkit(InvokeEM2ParentToolkitRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
            int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM2ParentToolkitENID, Constants.EmailIDs.EM2ParentToolkitSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Parent Toolkit");

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
		public static BaseReply InvokeWelcomeToUnderstood(InvokeWelcomeToUnderstoodRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM1WelcomeToUnderstoodENID, Constants.EmailIDs.EM1WelcomeToUnderstoodSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Welcome to Understood");

				string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

				if (cStatus == "OK")
				{
					tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
					tsd.TriggeredSendStatusSpecified = true; //required
					tsd.Priority = "High";

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
		public static BaseReply InvokeEM10WebinarConfirmation(InvokeEM10WebinarConfirmationRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM10WebinarConfirmationENID, Constants.EmailIDs.EM10WebinarConfirmationSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Webinar Confirmation");

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

		public static BaseReply InvokeEM11DonationAcknowledgement(InvokeEM11DonationAcknowledgementRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM11DonationAcknowledgementENID, Constants.EmailIDs.EM11DonationAcknowledgementSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Donation Acknowledgement");

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

						newSub.Attributes = new etAPI.Attribute[3];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "fullname";
						newSub.Attributes[0].Value = request.FullName;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "donation_amount";
						newSub.Attributes[1].Value = request.DonationAmount;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "print_donation_records_link";
						newSub.Attributes[2].Value = request.PrintDonationRecordsLink;

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

		//public static BaseReply InvokeEM11DonationAcknowledgement(InvokeEM11DonationAcknowledgementRequest request)
		//{
		//	BaseReply reply = new BaseReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 513, request.ToEmail, "Donation Acknowledgement");

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

		//				newSub.Attributes = new etAPI.Attribute[3];
		//				newSub.Attributes[0] = new etAPI.Attribute();
		//				newSub.Attributes[0].Name = "fullname";
		//				newSub.Attributes[0].Value = request.FullName;

		//				newSub.Attributes[1] = new etAPI.Attribute();
		//				newSub.Attributes[1].Name = "donation_amount";
		//				newSub.Attributes[1].Value = request.DonationAmount;

		//				newSub.Attributes[2] = new etAPI.Attribute();
		//				newSub.Attributes[2].Name = "print_donation_records_link";
		//				newSub.Attributes[2].Value = request.PrintDonationRecordsLink;

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
		public static BaseReply InvokeEM12ThankYouForContactingUs(InvokeEM12ThankYouForContactingUsRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM12ThankYouForContactingUsENID, Constants.EmailIDs.EM12ThankYouForContactingUSSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Thank you for contacting us");

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
						newSub.Attributes[0].Name = "child_age";
						newSub.Attributes[0].Value = request.ChildAge;
						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "time_remaining";
						newSub.Attributes[1].Value = request.TimeRemaining;

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
		public static BaseReply InvokeEM15HappyHolidays(BaseRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM15HappyHolidaysENID, Constants.EmailIDs.EM15HappyHolidaysSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Happy Holidays");

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
		public static BaseReply InvokeEM3ExploreTheCommunity(InvokeEM3ExploreTheCommunityRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM3ExploreTheCommunityENID, Constants.EmailIDs.EM3ExploreTheCommunitySPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Explore the Community");

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

						newSub.Attributes = new etAPI.Attribute[3];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "fullname";
						newSub.Attributes[0].Value = request.FullName;
						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "partner_promo";
						newSub.Attributes[1].Value = request.PartnerPromo;
						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "profile_completion_bar";
						newSub.Attributes[2].Value = request.ProfileCompletionBar;

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
		public static BaseReply InvokeEM4LearnAct(InvokeEM4LearnActRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM4LearnActENID, Constants.EmailIDs.EM4LearnActSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Learn Act");

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
		//public static BaseReply InvokeEM5KeepingAllStudentsSafe(InvokeEM5KeepingAllStudentsSafeRequest request)
		//{
		//	BaseReply reply = new BaseReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 518, request.ToEmail, "Keeping all Students Safe");

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
		//}//This email will be sent from Convio/Luminate.
		public static BaseReply InvokeEM6HolidayDonations(InvokeEM6HolidayDonationsRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM6HolidayDonationsENID, Constants.EmailIDs.EM6HolidayDonationsSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Holiday Donations Request");

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
						newSub.Attributes[0].Value = request.FullName;

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
		public static BaseReply InvokeEM7NewsletterConfirmation(InvokeEM7NewsletterConfirmationRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM7NewsletterConfirmationENID, Constants.EmailIDs.EM7NewsletterConfirmationSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Newsletter Confirmation");

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
		public static BaseReply InvokeEM8SubscriptionConfirmation(InvokeEM8SubscriptionConfirmationRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM8SubscriptionConfirmedENID, Constants.EmailIDs.EM8SubscriptionConfirmedSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Subscription confirmation");

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
						newSub.Attributes[0].Name = "profile_completion_bar";
						newSub.Attributes[0].Value = request.ProfileCompletionBar;

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
		public static BaseReply InvokeEM9GroupWelcome(InvokeEM9GroupWelcomeRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM9GroupWelcomeENID, Constants.EmailIDs.EM9GroupWelcomeSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Group Welcome");

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

                        etAPI.Attribute tempAttribute;
                        List<etAPI.Attribute> AttributeList = new List<etAPI.Attribute>();

                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "group_leader_email";
                        tempAttribute.Value = request.GroupLeaderEmail;

                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "group_link";
                        tempAttribute.Value = request.GroupLink;

                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "group_title";
                        tempAttribute.Value = request.GroupTitle;

                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "group_mod_bio_link";
                        tempAttribute.Value = request.GroupModerator.groupModBioLink;

                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "group_mod_name";
                        tempAttribute.Value = request.GroupModerator.groupModName;

                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "group_mod_img_link";
                        tempAttribute.Value = request.GroupModerator.groupModImgLink;


                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "domain_link";
                        tempAttribute.Value = request.RequestUrl.Scheme + "://" + request.RequestUrl.Authority;



                        newSub.Attributes = AttributeList.ToArray();

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
		public static BaseReply InvokeEM16ContentReminder(InvokeEM16ContentReminderRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM16ContentReminderENID, Constants.EmailIDs.EM16ContentReminderSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Content Reminder");

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

						newSub.Attributes = new etAPI.Attribute[6];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "contact_settings_link";
						newSub.Attributes[0].Value = request.ContactSettingsLink;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "content_helpfulness_and_comments_module";
						newSub.Attributes[1].Value = request.ContentHelpfulnessAndCommentsModule;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "reminder_image";
						newSub.Attributes[2].Value = request.ReminderImage;

						newSub.Attributes[3] = new etAPI.Attribute();
						newSub.Attributes[3].Name = "reminder_link";
						newSub.Attributes[3].Value = request.ReminderLink;

						newSub.Attributes[4] = new etAPI.Attribute();
						newSub.Attributes[4].Name = "reminder_summary";
						newSub.Attributes[4].Value = request.ReminderSummary;

						newSub.Attributes[5] = new etAPI.Attribute();
						newSub.Attributes[5].Name = "reminder_title";
						newSub.Attributes[5].Value = request.ReminderTitle;

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
		public static BaseReply InvokeEM17ObservationLogReminder(InvokeEM17ObservationLogReminderRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM17ObservationLogReminderENID, Constants.EmailIDs.EM17ObservationLogReminderSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Observation log reminder");

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
						newSub.Attributes[0].Name = "child_name";
						newSub.Attributes[0].Value = request.ChildName;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "observational_journal_link";
						newSub.Attributes[1].Value = request.ObservationalJournalLink;

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
		public static BaseReply InvokeEM18UpdateProfileReminder(InvokeEM18UpdateProfileReminderRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM18UpdateProfileReminderENID, Constants.EmailIDs.EM18UpdateProfileReminderSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Update profile reminder");

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

						newSub.EmailAddress = request.ToEmail;
						newSub.SubscriberKey = request.ToEmail;

						newSub.Attributes = new etAPI.Attribute[5];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "child_information_confirmation";
						newSub.Attributes[0].Value = request.ChildInformationConfirmation;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "information_confirmation_link";
						newSub.Attributes[1].Value = request.InformationConfirmLink;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "information_denied_link";
						newSub.Attributes[2].Value = request.InformationDeniedLink;

						newSub.Attributes[3] = new etAPI.Attribute();
						newSub.Attributes[3].Name = "profile_image_link";
						newSub.Attributes[3].Value = request.ProfileImageLink;

						newSub.Attributes[4] = new etAPI.Attribute();
						newSub.Attributes[4].Name = "user_profile_link";
						newSub.Attributes[4].Value = request.UserProfileLink;

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
		public static BaseReply InvokeEM19WebinarReminder(InvokeEM19WebinarReminderRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM19WebinarReminderENID, Constants.EmailIDs.EM19WebinarReminderSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Webinar reminder");

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
		public static BaseReply InvokeEM21PrivateMessage(InvokeEM21PrivateMessageRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM21PrivateMessageENID, Constants.EmailIDs.EM21PrivateMessageSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "private message");

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

						newSub.Attributes = new etAPI.Attribute[4];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "contact_settings_link";
						newSub.Attributes[0].Value = request.ContactSettingsLink;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "msg_center_link";
						newSub.Attributes[1].Value = request.MsgCenterLink;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "pm_text";
						newSub.Attributes[2].Value = request.PMText;

						newSub.Attributes[3] = new etAPI.Attribute();
						newSub.Attributes[3].Name = "report_inappropriate_link";
						newSub.Attributes[3].Value = request.ReportInappropriateLink;

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
		public static BaseReply InvokeEM22ForgotPassword(InvokeEM22ForgotPasswordRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM22ForgotPasswordENID, Constants.EmailIDs.EM22ForgotPasswordSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "forgot password");

				string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

				if (cStatus == "OK")
				{
					tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
					tsd.TriggeredSendStatusSpecified = true; //required
					tsd.Priority = "High";

					string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

					if (uStatus == "OK")
					{
						// *** SEND THE TRIGGER EMAIL
						Subscriber newSub = new Subscriber();
						newSub.EmailAddress = request.ToEmail;
						newSub.SubscriberKey = request.ToEmail;

						newSub.Attributes = new etAPI.Attribute[2];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "password_reset_link";
						newSub.Attributes[0].Value = request.PasswordResetLink;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "user_name";
						newSub.Attributes[1].Value = request.ToEmail;

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
		public static BaseReply InvokeEM23PasswordResetConfirmation(InvokeEM23PasswordResetConfirmationRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM23PasswordResetConfirmationENID, Constants.EmailIDs.EM23PasswordResetConfirmationSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Password reset confirmation");

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

						newSub.Attributes = new etAPI.Attribute[3];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "password_reset_link";
						newSub.Attributes[0].Value = request.ReportChangedPasswordLink;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "user_name";
						newSub.Attributes[1].Value = request.EmailAddress;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "user_password";
						newSub.Attributes[2].Value = request.UserPassword;

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
		public static BaseReply InvokeEM24ContentSharedWithAFriend(InvokeEM24ContentSharedWithAFriendRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM24ContentSharedWithAFriendENID, Constants.EmailIDs.EM24ContentSharedWithAFriendSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "content shared with a friend");

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

						newSub.Attributes = new etAPI.Attribute[7];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "content_helpfulness_and_comments_module";
						newSub.Attributes[0].Value = request.ContentHelpfulnessAndCommentsModule;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "pm_text";
						newSub.Attributes[1].Value = request.PMText;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "reminder_image";
						newSub.Attributes[2].Value = request.ReminderImage;

						newSub.Attributes[3] = new etAPI.Attribute();
						newSub.Attributes[3].Name = "reminder_link";
						newSub.Attributes[3].Value = request.ReminderLink;

						newSub.Attributes[4] = new etAPI.Attribute();
						newSub.Attributes[4].Name = "reminder_summary";
						newSub.Attributes[4].Value = request.ReminderSummary;

						newSub.Attributes[5] = new etAPI.Attribute();
						newSub.Attributes[5].Name = "reminder_title";
						newSub.Attributes[5].Value = request.ReminderTitle;

						newSub.Attributes[6] = new etAPI.Attribute();
						newSub.Attributes[6].Name = "user_contact_first_name";
						newSub.Attributes[6].Value = request.UserContactFirstName;

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
		public static BaseReply InvokeEM25WebinarSharedWithAFriend(InvokeEM25WebinarSharedWithAFriendRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM25WebinarSharedWithAFriendENID, Constants.EmailIDs.EM25WebinarSharedWithAFriendSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "webinar shared with a friend");

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

						newSub.Attributes = new etAPI.Attribute[7];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "pm_text";
						newSub.Attributes[0].Value = request.PMText;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "user_contact_first_name";
						newSub.Attributes[1].Value = request.UserContactFirstName;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "webinar_module";
						newSub.Attributes[2].Value = request.WebinarModule;

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
		public static BaseReply InvokeEM28AppsTechnologySharedWithAFriend(InvokeEM28AppsTechnologySharedWithAFriendRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM28AppsTechnologySharedWithAFriendENID, Constants.EmailIDs.EM28AppsTechnologySharedWithAFriendSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "apps technology shared with friend");

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

						newSub.Attributes = new etAPI.Attribute[11];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "app_description";
						newSub.Attributes[0].Value = request.AppDescription;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "app_good_for";
						newSub.Attributes[1].Value = request.AppGoodFor;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "app_grade";
						newSub.Attributes[2].Value = request.AppGrade;

						newSub.Attributes[3] = new etAPI.Attribute();
						newSub.Attributes[3].Name = "app_learning_link";
						newSub.Attributes[3].Value = request.AppLearningLink;

						newSub.Attributes[4] = new etAPI.Attribute();
						newSub.Attributes[4].Name = "app_link";
						newSub.Attributes[4].Value = request.AppLink;

						newSub.Attributes[5] = new etAPI.Attribute();
						newSub.Attributes[5].Name = "app_logo";
						newSub.Attributes[5].Value = request.AppLogo;

						newSub.Attributes[6] = new etAPI.Attribute();
						newSub.Attributes[6].Name = "app_quality";
						newSub.Attributes[6].Value = request.AppQuality;

						newSub.Attributes[7] = new etAPI.Attribute();
						newSub.Attributes[7].Name = "app_rating_link";
						newSub.Attributes[7].Value = request.AppRatingLink;

						newSub.Attributes[8] = new etAPI.Attribute();
						newSub.Attributes[8].Name = "app_rating_module";
						newSub.Attributes[8].Value = request.AppRatingModule;

						newSub.Attributes[9] = new etAPI.Attribute();
						newSub.Attributes[9].Name = "app_title";
						newSub.Attributes[9].Value = request.AppTitle;

						newSub.Attributes[10] = new etAPI.Attribute();
						newSub.Attributes[10].Name = "user_contact_first_name";
						newSub.Attributes[10].Value = request.UserContactFirstName;

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
		public static BaseReply InvokeEM13ActivityFromToday(InvokeEM13ActivityFromTodayRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM13ActivityFromTodayENID, Constants.EmailIDs.EM13ActivityFromTodaySPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Daily Digest");

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

						newSub.Attributes = new etAPI.Attribute[5];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "activity_from_today_module";
						newSub.Attributes[0].Value = request.ActivityFromTodayModule;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "contact_settings_link";
						newSub.Attributes[1].Value = request.ContactSettingsLink;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "profile_image_link";
						newSub.Attributes[2].Value = request.ProfileImageLink;

						newSub.Attributes[3] = new etAPI.Attribute();
						newSub.Attributes[3].Name = "user_profile_link";
						newSub.Attributes[3].Value = request.UserProfileLink;

						newSub.Attributes[4] = new etAPI.Attribute();
						newSub.Attributes[4].Name = "view_messages_link";
						newSub.Attributes[4].Value = request.ViewMessagesLink;

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
		public static BaseReply InvokeEM14ThisWeeksActivity(InvokeEM14ThisWeeksActivityRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
			int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.EM14ActivityFromThisWeekENID, Constants.EmailIDs.EM14ActivityFromThisWeekSPID);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Weekly Digest");

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

						newSub.Attributes = new etAPI.Attribute[11];
						newSub.Attributes[0] = new etAPI.Attribute();
						newSub.Attributes[0].Name = "activity_from_this_week_module";
						newSub.Attributes[0].Value = request.ActivityFromThisWeekModule;

						newSub.Attributes[1] = new etAPI.Attribute();
						newSub.Attributes[1].Name = "contact_settings_link";
						newSub.Attributes[1].Value = request.ContactSettingsLink;

						newSub.Attributes[2] = new etAPI.Attribute();
						newSub.Attributes[2].Name = "profile_image_link";
						newSub.Attributes[2].Value = request.ProfileImageLink;

						newSub.Attributes[3] = new etAPI.Attribute();
						newSub.Attributes[3].Name = "user_profile_link";
						newSub.Attributes[3].Value = request.UserProfileLink;

						newSub.Attributes[4] = new etAPI.Attribute();
						newSub.Attributes[4].Name = "view_messages_link";
						newSub.Attributes[4].Value = request.ViewMessageLink;

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


		//Newsletter Email methods
        public static BaseReply InvokeE1GeneralNewsLetter(InvokeE1GeneralNewsLetterRequest request)
        {
            BaseReply reply = new BaseReply();

            SoapClient client = ExactTargetService.GetInstance();

            StringBuilder sbReturnString = new StringBuilder();

            Guid preferredLanguage = request.PreferredLanguage;
            int emailTemplateID = GetEmailTemplateId(preferredLanguage, Constants.EmailIDs.E1GeneralNewsLetter, Constants.EmailIDs.E1GeneralNewsLetter);

            try
            {
                //Create a GUID for ESD to ensure a unique name and customer key
                TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Weekly Newsletter");

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


                        etAPI.Attribute tempAttribute;
                        List<etAPI.Attribute> AttributeList = new List<etAPI.Attribute>();

                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "profile_completion_bar";
                        tempAttribute.Value = request.ProfilePercentCompletePlaceholder;
                        AttributeList.Add(tempAttribute);
                        
                        tempAttribute = new etAPI.Attribute();
                        tempAttribute.Name = "fullname";
                        tempAttribute.Value = request.UserName ;
                        AttributeList.Add(tempAttribute);

                        newSub.Attributes = AttributeList.ToArray();
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


		public static BaseReply InvokeE1ATurnAroundBullying(InvokeE1ATurnAroundBullyingRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
            int emailTemplateID = GetEmailTemplateId(preferredLanguage, 1070, 0);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Newsletter 1");

				string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

				if (cStatus == "OK")
				{
					tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
					tsd.TriggeredSendStatusSpecified = true; //required
					tsd.Priority = "High";

					string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

					if (uStatus == "OK")
					{
						// *** SEND THE TRIGGER EMAIL
						Subscriber newSub = new Subscriber();
						newSub.EmailAddress = request.ToEmail;
						newSub.SubscriberKey = request.ToEmail;

                        newSub.Attributes = new etAPI.Attribute[]
                        {
                            new etAPI.Attribute
                            {
                                Name = "personalized_recommended_articles",
                                Value = GetChildPersonalizedArticles(request.Child)    
                            }
                        };

						ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

						reply.Successful = true;
					}
				}
			}
			catch (Exception exc)
			{
				string message = "Unable to send e1a email.";

				reply.Successful = false;
				reply.Message = message;

				Log.Error(exc.ToString(), "something went wrong");
			}

			return reply;
		}
       
        private static string GetChildPersonalizedArticles(Child child)
        {
            StringBuilder sb = new StringBuilder();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new UTF8Encoding(false);
            //settings.OmitXmlDeclaration = true;
            settings.Indent = false;
            settings.NewLineHandling = NewLineHandling.None;

            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                XElement root = new XElement("articles");

                var articles = PersonalizationHelper.GetChildPersonalizedContents(child);
                if (articles.Any())
                {
                    var subset = articles.Take(3);
                    foreach (var s in subset)
                    {
                        // TODO: add absolute url
                        root.Add(new XElement("article",
                                new XElement("title", s.ContentPage.PageTitle.Rendered),
                                new XElement("url", s.GetUrl()),
                                new XElement("img", s.GetArticleThumbnailUrl(160, 90))
                            )
                        );
                    }
                }

                root.Save(writer);
            }

            return sb.ToString();
        }

		public static BaseReply InvokeE1B1TurnAroundBullying(InvokeE1B1TurnAroundBullyingRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
            int emailTemplateID = GetEmailTemplateId(preferredLanguage, 1057, 0);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "e1b newsletter (full profile and following 2 blogs)");

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
		public static BaseReply InvokeE1B2TurnAroundBullying(InvokeE1B2TurnAroundBullyingRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
            int emailTemplateID = GetEmailTemplateId(preferredLanguage, 335, 0);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "e1c newsletter (joined 2 groups)");

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
		public static BaseReply InvokeE1CTurnAroundBullying(InvokeE1CTurnAroundBullyingRequest request)
		{
			BaseReply reply = new BaseReply();

			SoapClient client = ExactTargetService.GetInstance();

			StringBuilder sbReturnString = new StringBuilder();

			Guid preferredLanguage = request.PreferredLanguage;
            int emailTemplateID = GetEmailTemplateId(preferredLanguage, 335, 0);

			try
			{
				//Create a GUID for ESD to ensure a unique name and customer key
				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "e2");

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

        public static BaseReply SendBehaviorToolSuggestion(BaseRequest request, string message)
        {
            BaseReply reply = new BaseReply();

            SoapClient client = ExactTargetService.GetInstance();

            StringBuilder sbReturnString = new StringBuilder();

            Guid preferredLanguage = request.PreferredLanguage;
            int emailTemplateID = Constants.EmailIDs.BehaviorToolSuggestion;

            try
            {
                //Create a GUID for ESD to ensure a unique name and customer key
                TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), emailTemplateID, request.ToEmail, "Parent Toolkit");

                string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

                if (cStatus == "OK")
                {
                    tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
                    tsd.TriggeredSendStatusSpecified = true; //required

                    string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

                    if (uStatus == "OK")
                    {
                        // *** SEND THE TRIGGER EMAIL
                        Subscriber sub = new Subscriber
                        {
                            EmailAddress = request.ToEmail,
                            SubscriberKey = request.ToEmail,
                        };

                        sub.Attributes = new etAPI.Attribute[]
                        {
                            new etAPI.Attribute
                            {
                                Name = "HTML_CONTENT",
                                Value = message   
                            }
                        };

                        ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, sub);

                        reply.Successful = true;
                    }
                }
            }
            catch (Exception ex)
            {
                reply.Successful = false;
                reply.Message = "Unable to send Behavior Suggestion email."; ;

                Log.Error("Error sending behavior suggestion", ex);
            }

            return reply;
        }

        private static int GetEmailTemplateId(Guid preferredLanguage, int defaultId, int spanishId)
        {
            if (preferredLanguage == Constants.Language_Spanish) 
            {
                return spanishId;
            }
            return defaultId;
        }

		#region phase 2
		//public static BaseReply InvokeEM20SupportPlanReminder(InvokeEM20SupportPlanReminderRequest request)
		//		{
		//			BaseReply reply = new BaseReply();

		//			SoapClient client = ExactTargetService.GetInstance();

		//			StringBuilder sbReturnString = new StringBuilder();

		//			try
		//			{
		//				//Create a GUID for ESD to ensure a unique name and customer key
		//				TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335, request.ToEmail, "Support plan reminder");

		//				string cStatus = ExactTargetService.GetCreateResult(ref client, tsd, ref sbReturnString);

		//				if (cStatus == "OK")
		//				{
		//					tsd.TriggeredSendStatus = TriggeredSendStatusEnum.Active; //necessary to set the TriggeredSendDefinition to "Running"
		//					tsd.TriggeredSendStatusSpecified = true; //required

		//					string uStatus = ExactTargetService.GetUpdateResult(ref client, tsd, ref sbReturnString);

		//					if (uStatus == "OK")
		//					{
		//						// *** SEND THE TRIGGER EMAIL
		//						Subscriber newSub = new Subscriber();
		//						newSub.EmailAddress = request.ToEmail;
		//						newSub.SubscriberKey = request.ToEmail;


		//						ExactTargetService.SendEmail(ref client, tsd, ref sbReturnString, newSub);

		//						reply.Successful = true;
		//					}
		//				}
		//			}
		//			catch (Exception exc)
		//			{
		//				string message = "Unable to send welcome email.";

		//				reply.Successful = false;
		//				reply.Message = message;

		//				Log.Error(exc.ToString(), "something went wrong");
		//			}

		//			return reply;
		//		}

		//public static BaseReply InvokeEM26JournalSharedWithAFriend(InvokeEM26JournalSharedWithAFriendRequest request)
		//{
		//	BaseReply reply = new BaseReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335, request.ToEmail, "jornal shared with a friend");

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


		//public static BaseReply InvokeEM27SupportPlan(InvokeEM27SupportPlanRequest request)
		//{
		//	BaseReply reply = new BaseReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335, request.ToEmail, "support plan request");

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




		//public static BaseReply InvokeEM29SchoolSharedWithAFriend(InvokeEM29SchoolSharedWithAFriendRequest request)
		//{
		//	BaseReply reply = new BaseReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335, request.ToEmail, "school shared with a friend");

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
		//public static BaseReply InvokeEM30ReengagementStream1(InvokeEM30ReengagementStream1Request request)
		//{
		//	BaseReply reply = new BaseReply();

		//	SoapClient client = ExactTargetService.GetInstance();

		//	StringBuilder sbReturnString = new StringBuilder();

		//	try
		//	{
		//		//Create a GUID for ESD to ensure a unique name and customer key
		//		TriggeredSendDefinition tsd = ExactTargetService.GetSendDefinition(Guid.NewGuid().ToString(), 335, request.ToEmail, "Reengagement stream1");

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
		#endregion
	}
}