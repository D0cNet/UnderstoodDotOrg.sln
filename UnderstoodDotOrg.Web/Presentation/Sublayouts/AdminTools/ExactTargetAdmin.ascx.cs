﻿namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools
{
	using System;
	using UnderstoodDotOrg.Services.ExactTarget;
	using UnderstoodDotOrg.Domain.ExactTarget;
	using System.Collections.Generic;
    using UnderstoodDotOrg.Domain.Membership;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;

	public partial class ExactTargetAdmin : System.Web.UI.UserControl
	{
		private void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				// initialize text boxes
				tbxSubscriberEmail1.Text = "jtesta@agencyoasis.com";
				tbxSubscriberKey1.Text = "jtesta@agencyoasis.com";
				tbxSubscriberFN1.Text = "Joe";
				lblMessage.Text = "Email Test has not started ...";
				txtHtmlContent.Text = "<p><b>This is a test!</b></p>";
				txtWebinarCode.Text = "<p><b>This is a test!</b></p>";

                var header = HeaderFolderItem.GetHeader();
                ddlLanguages.DataSource = header.GetLanguageLinks();
                ddlLanguages.DataValueField = "ID";
                ddlLanguages.DataTextField = "Name";
                ddlLanguages.DataBind();
			}
		}

		protected void btnETTests_Click(object sender, EventArgs e)
		{
			//InvokeEM2ParentToolkitReply reply = ExactTargetService.InvokeEM2ParentToolkit(new InvokeEM2ParentToolkitRequest { ToEmail = tbxSubscriberEmail1.Text });
			//BaseReply reply = ExactTargetService.InvokeWelcomeToUnderstood(new InvokeWelcomeToUnderstoodRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text, FirstName = tbxSubscriberFN1.Text });
			BaseReply reply = ExactTargetService.SendBehaviorToolSuggestion(new BaseRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text }, "Hello, world!");
			//BaseReply reply = ExactTargetService.InvokeEM10WebinarConfirmation(new InvokeEM10WebinarConfirmationRequest { ToEmail = tbxSubscriberEmail1.Text, WebinarModule = txtWebinarCode.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM2_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM2ParentToolkit(new InvokeEM2ParentToolkitRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text });//new Guid(ddlLanguages.SelectedValue)
			lblMessage.Text = reply.Message;
		}

		protected void btnEM3_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM3ExploreTheCommunity(new InvokeEM3ExploreTheCommunityRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), FullName = tbxSubscriberFN1.Text, PartnerPromo = "<table><tr><td><p>Thia is a partner promo!</p></td></tr></table>", ProfileCompletionBar = "20%!", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM4_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM4LearnAct(new InvokeEM4LearnActRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		//protected void btnEM5_Click(object sender, EventArgs e)
		//{
		//	BaseReply reply = ExactTargetService.InvokeEM5KeepingAllStudentsSafe(new InvokeEM5KeepingAllStudentsSafeRequest { ToEmail = tbxSubscriberEmail1.Text });
		//	lblMessage.Text = reply.Message;
		//}

		protected void btnEM6_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM6HolidayDonations(new InvokeEM6HolidayDonationsRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), FullName = tbxSubscriberFN1.Text, ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM7_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM7NewsletterConfirmation(new InvokeEM7NewsletterConfirmationRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text, ConfirmSubscriptionLink = "www.google.com", WeekDay = "sunday" });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM8_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM8SubscriptionConfirmation(new InvokeEM8SubscriptionConfirmationRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM9_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM9GroupWelcome(new InvokeEM9GroupWelcomeRequest
			{
				PreferredLanguage = new Guid(ddlLanguages.SelectedValue),
				GroupLeaderEmail = "groupleader@donotreply.com",
				GroupLink = "www.google.com",
				GroupTitle = "People testing Emails",
				ToEmail = tbxSubscriberEmail1.Text,

				GroupModerator = new Moderator
				{
					groupModBioLink = "www.google.com",
					groupModImgLink = "images.google.com",
					groupModName = "Bob Smith"
				}
			});	
		
			lblMessage.Text = reply.Message;
		}

		protected void btnEM10_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM10WebinarConfirmation(new InvokeEM10WebinarConfirmationRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text, WebinarModule = "<table><tr><td><p>Test Webinar Module!</p></td></tr></table>" });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM11_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM11DonationAcknowledgement(new InvokeEM11DonationAcknowledgementRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text, DonationAmount = "1 Billion Dollars", FullName = tbxSubscriberFN1.Text, PrintDonationRecordsLink = "www.google.com" });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM12_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM12ThankYouForContactingUs(new InvokeEM12ThankYouForContactingUsRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ChildAge = "5", TimeRemaining = "10", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM13_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM13ActivityFromToday(new InvokeEM13ActivityFromTodayRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ActivityFromTodayModule = "<table><tr><td><p>Activity from today module test!</p></td></tr></table>", ContactSettingsLink = "www.google.com", ViewMessagesLink = "www.gmail.com", UserProfileLink = "www.facebook.com", ProfileImageLink = "www.photobucket.com", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM14_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM14ThisWeeksActivity(new InvokeEM14ThisWeeksActivityRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ActivityFromThisWeekModule = "<table><tr><td><p>Activity from today module test!</p></td></tr><td>TUESDAY</td></tr><td>WEDNESDAY</td></tr></table>", ContactSettingsLink = "www.google.com", ProfileImageLink = "photobucket.com", ToEmail = tbxSubscriberEmail1.Text, UserProfileLink = "www.facebook.com", ViewMessageLink = "www.gmail.com" });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM15_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM15HappyHolidays(new BaseRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM16_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM16ContentReminder(new InvokeEM16ContentReminderRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ContactSettingsLink = "www.google.com", ContentHelpfulnessAndCommentsModule = "<table><tr><td>15 people thought this was helpful</td></tr><tr><td>20 people commented</td></tr></table>", ReminderImage = "www.photobucket.com", ReminderLink = "www.google.com", ReminderSummary = "This is a reminder summary!", ReminderTitle = "This is a reminder title!", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM17_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM17ObservationLogReminder(new InvokeEM17ObservationLogReminderRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ChildName = "optimus", ObservationalJournalLink = "www.google.com", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM18_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM18UpdateProfileReminder(new InvokeEM18UpdateProfileReminderRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ChildInformationConfirmation = "Is your child still 5 years old?", InformationConfirmLink = "google.com", InformationDeniedLink = "www.yahoo.com", ProfileImageLink = "www.photobucket.com", ToEmail = tbxSubscriberEmail1.Text, UserProfileLink = "www.facebook.com" });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM19_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM19WebinarReminder(new InvokeEM19WebinarReminderRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text, WebinarModule = "webinar Module!" });
			lblMessage.Text = reply.Message;
		}

		//protected void btnEM20_Click(object sender, EventArgs e)
		//{
		//	BaseReply reply = ExactTargetService.
		//}

		protected void btnEM21_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM21PrivateMessage(new InvokeEM21PrivateMessageRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ContactSettingsLink = "www.google.com", MsgCenterLink = "www.gmail.com", PMText = "This is a private message!", ReportInappropriateLink = "www.google.com", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM22_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM22ForgotPassword(new InvokeEM22ForgotPasswordRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), PasswordResetLink = "www.google.com", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM23_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM23PasswordResetConfirmation(new InvokeEM23PasswordResetConfirmationRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), EmailAddress = tbxSubscriberEmail1.Text, ReportChangedPasswordLink = "www.google.com", ToEmail = tbxSubscriberEmail1.Text, UserPassword = "**********" });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM24_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM24ContentSharedWithAFriend(new InvokeEM24ContentSharedWithAFriendRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ContentHelpfulnessAndCommentsModule = "<p>15 people thought this was helpful.</p><p>10 comments</p>", PMText = "this is a private message!", ReminderImage = "www.photobucket.com", ReminderLink = "www.google.com", ReminderSummary = "This is a summary of the reminder", ReminderTitle = "reminder title", ToEmail = tbxSubscriberEmail1.Text, UserContactFirstName = tbxSubscriberFN1.Text });
			lblMessage.Text = reply.Message;
		}

		protected void btnEM25_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM25WebinarSharedWithAFriend(new InvokeEM25WebinarSharedWithAFriendRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), PMText = "private message text!", ToEmail = tbxSubscriberEmail1.Text, UserContactFirstName = tbxSubscriberFN1.Text, WebinarModule = "webinar module" });
			lblMessage.Text = reply.Message;
		}

		//protected void btnEM26_Click(object sender, EventArgs e)
		//{
		//	BaseReply reply = ExactTargetService.
		//}

		//protected void btnEM27_Click(object sender, EventArgs e)
		//{

		//}

		protected void btnEM28_Click(object sender, EventArgs e)
		{
			BaseReply reply = ExactTargetService.InvokeEM28AppsTechnologySharedWithAFriend(new InvokeEM28AppsTechnologySharedWithAFriendRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), UserContactFirstName = "user1", AppTitle = "app title", AppRatingModule = "app rating module", AppRatingLink = "www.google.com", AppQuality = "4.5 stars", AppLogo = "www.photobucket.com", AppLink = "www.google.com", AppLearningLink = "www.google.com", AppGrade = "6, 7, 8", AppGoodFor = "English | Math", AppDescription = "app description", ToEmail = tbxSubscriberEmail1.Text });
			lblMessage.Text = reply.Message;
		}

        protected void btnE1_Click(object sender, EventArgs e)
        {
            MembershipManager mm = new MembershipManager();
			Member mem = new Member();
            BaseReply reply = ExactTargetService.InvokeE1ATurnAroundBullying(new InvokeE1ATurnAroundBullyingRequest
            {
                Child = mm.GetChild(new Guid("1DC558DE-8E46-4973-980A-08F582EAE6D5")),
				ToEmail = tbxSubscriberEmail1.Text,
				Member = mem,
				PreferredLanguage = new Guid(ddlLanguages.SelectedValue)
            });

            lblMessage.Text = reply.Message;
        }

		protected void newsletter_sp_Click(object sender, EventArgs e)
		{
			//BaseReply reply = ExactTargetService.InvokeNewsletterSendEN(new BaseRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text });
			//lblMessage.Text = reply.Message;
		}

		protected void newsletter_en_Click(object sender, EventArgs e)
		{
			//BaseReply reply = ExactTargetService.InvokeNewsletterSendSP(new BaseRequest { PreferredLanguage = new Guid(ddlLanguages.SelectedValue), ToEmail = tbxSubscriberEmail1.Text });
			//lblMessage.Text = reply.Message;
		}

        protected void btnRunGeneralNewsletter_Click(object sender, EventArgs e)
        {
            UnderstoodDotOrg.Services.ExactTarget.ScheduledJobs.WeeklyGeneralNewsLetter();

        }



	}
}