using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Globalization;

namespace UnderstoodDotOrg.Common
{
    public class DictionaryConstants
    {
        private static string PosesDictionary = "Poses Dictionary";

        #region Button Text

        public static string YesButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Yes Button Text");
            }
        }

        public static string NoButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "No Button Text");
            }
        }

        public static string BoyButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Boy Button Text");
            }
        }

        public static string GirlButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Girl Button Text");
            }
        }

        public static string InProgressButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "In Progress Button Text");
            }
        }

        public static string SubmitButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Submit Button Text");
            }
        }

        public static string MomButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Mom Button Text");
            }
        }

        public static string DadButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Dad Button Text");
            }
        }

        public static string NextButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Next Button Text");
            }
        }

        public static string SignUpButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Sign Up Button Text");
            }
        }

        public static string GoButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Go Button Text");
            }
        }

        public static string CloseButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Close Button Text");
            }
        }

        public static string CloseWindowButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Close Window Button Text");
            }
        }

        public static string SendSuggestionButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Send Suggestion Button Text");
            }
        }

        public static string SignInButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Sign In Button Text");
            }
        }

        public static string CancelButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Cancel Button Text");
            }
        }

        public static string SaveButtonText 
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Save Button Text");
            }
        }

        public static string SaveThisButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Save This Button Text");
            }
        }

        public static string RemindMeButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Remind Me Button Text");
            }
        }

        public static string ViewTipButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "View Tip Button Text");
            }
        }

        public static string ShowMoreButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Show More Button Text");
            }
        }

        public static string NextTipButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Next Tip Button Text");
            }
        }

        public static string PrevTipButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Prev Tip Button Text");
            }
        }

        public static string LastTipButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Last Tip Button Text");
            }
        }

        public static string OverviewButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Overview Button Text");
            }
        }

        public static string MenuButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Menu Button Text");
            }
        }

        public static string MoreButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "More Button Text");
            }
        }

        public static string SubscribeButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Subscribe Button Text");
            }
        }

        #endregion

        #region Input Placeholders

        public static string ScreenNameWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Screen Name Watermark");
            }
        }

        public static string ZipCodeWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Zip Code Watermark");
            }
        }

        public static string ParentRoleDefault
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Parent List Watermark");
            }
        }

        public static string SelectChallenge
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Select Challenge");
            }
        }

        public static string ConfirmPasswordWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Confirm Password Watermark");
            }
        }

        public static string EnterEmailAddressWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Enter Email Address Watermark");
            }
        }

        public static string EnterNewPasswordWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Enter New Password Watermark");
            }
        }

        public static string EnterPasswordWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Enter Password Watermark");
            }
        }

        public static string EnterSuggestionWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Enter Suggestion Watermark");
            }
        }

        public static string FirstNameWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "First Name Watermark");
            }
        }

        public static string ReEnterNewPasswordWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Re-enter New Password Watermark");
            }
        }

        public static string SearchWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Search Watermark");
            }
        }

        #endregion

        #region My Profile

        public static string AboutMeLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "About Me Label");
            }
        }

        public static string CommunityLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community Label");
            }
        }

        public static string ContactLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Contact Label");
            }
        }

        public static string ContactReminderText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Contact Reminder Text");
            }
        }

        public static string EmailAndPasswordLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email and Password Label");
            }
        }

        public static string EmailLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Label");
            }
        }

        public static string MobilePhoneLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Mobile Phone Label");
            }
        }

        public static string MyChildrenLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Children Label");
            }
        }

        public static string MyConnectionsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Connections Label");
            }
        }

        public static string MyInterestsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Interests Label");
            }
        }

        public static string MyJourneyLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Journey Label");
            }
        }

        public static string MyLocationLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Location Label");
            }
        }

        public static string MyPublicViewLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Public View Label");
            }
        }

        public static string MyRoleLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Role Label");
            }
        }

        public static string MyScreenNameLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Screen Name Label");
            }
        }

        public static string NicknameReminderText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Nickname Reminder Text");
            }
        }

        public static string PasswordLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Password Label");
            }
        }

        public static string PrivacyLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Privacy Label");
            }
        }

        public static string ZipcodeReminderText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Zipcode Reminder Text");
            }
        }

        public static string NotOpenToConnect
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Not Open To Connect Description");
            }
        }

        public static string OpenToConnect
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Open To Connect Description");
            }
        }

        #endregion

        #region Registration/Validation

        public static string ConfirmPasswordErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Confirm Password Error Message");
            }
        }

        public static string EmailAddressErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Address Error Message");
            }
        }

        public static string FirstNameErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "First Name Error Message");
            }
        }

        public static string FirstNameMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "First Name Message");
            }
        }

        public static string OptionalMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Optional Message");
            }
        }

        public static string PasswordErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Password Error Message");
            }
        }

        public static string PasswordMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Password Message");
            }
        }

        public static string ZipCodeErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Zip Code Error Message");
            }
        }

        #endregion

        #region Fragments

        public static string RecommendationsMatchFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Recommendations Match Fragment");
            }
        }

        public static string WorkOnFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Work On Fragment");
            }
        }

        public static string BackToFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Back To Fragment");
            }
        }

        #endregion

        public static string EmailException
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Exception");
            }
        }

        public static string SocialSharingFacebook
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Social Sharing Facebook");
            }
        }

        public static string SocialSharingGooglePlus
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Social Sharing Google Plus");
            }
        }

        public static string SocialSharingShareAndSaveLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Social Sharing Share and Save Label");
            }
        }

        public static string SocialSharingShareDropdown
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Social Sharing Share Dropdown");
            }
        }

        public static string SocialSharingTwitter
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Social Sharing Twitter");
            }
        }


        
        public static string PluralCommentLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Plural Comment Label");
            }
        }

        public static string SingleCommentLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Single Comment Label");
            }
        }

        public static string FoundThisHelpful
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Found This Helpful");
            }
        }

        public static string DidYouFindThisHelpful
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Did You Find This Helpful");
            }
        }

        public static string SlideshowRestartLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Slideshow Restart Label");
            }
        }

        public static string SlideshowRestartAlternateLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Slideshow Restart Alternate Label");
            }
        }

        public static string SearchLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Search Label");
            }
        }

        public static string FilterByLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Filter By Label");
            }
        }
        public static string AtAGlanceText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "At a Glance");
            }
        }
        public static string KeyTakeAwayText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Key take-away");
            }
        }

        public static class Grades
        {
            public static string SelectGrade
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Select Grade");
                }
            }

            public static string Grade1
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 1");
                }
            }

            public static string Grade2
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 2");
                }
            }
            public static string Grade3
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 3");
                }
            }
            public static string Grade4
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 4");
                }
            }
            public static string Grade5
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 5");
                }
            }
            public static string Grade6
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 6");
                }
            }
            public static string Grade7
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 7");
                }
            }
            public static string Grade8
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 8");
                }
            }
            public static string Grade9
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 9");
                }
            }
            public static string Grade10
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 10");
                }
            }
            public static string Grade11
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 11");
                }
            }
            public static string Grade12
            {
                get
                {
                    return Translate.TextByDomain(PosesDictionary, "Grade 12");
                }
            }

            
        }

        #region Expert Live
        public static string NotNowLabel{
            get {
                return Translate.TextByDomain(PosesDictionary, "Not Now Label");
            }
        }

        public static string BacktoLabel{
            get {
                return Translate.TextByDomain(PosesDictionary, "Back to Label");
            }
        }

        public static string GuestExpertLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Guest Expert Label");
            }
        }

        public static string ExpertLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Expert Label");
            }
        }

        public static string WebniarLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Webinar Label");
            }
        }

        public static string ChatLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Chat Label");
            }
        }

        public static string DaysagoLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Days ago Label");
            }
        }

        public static string SeeArchiveLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "See Archive Label");
            }
        }

        public static string OfficeHoursWithLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Office hours with Label");
            }
        }

        public static string SeeHerOfficeHoursLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "See her office hours Label");
            }

        }

        public static string MeetLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Meet Label");
            }

        }

        public static string OnlineOfficeHours {
            get {
                return Translate.TextByDomain(PosesDictionary, "Online Office Hours:");
            }
        }

        public static string ShowMoreLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Show More");
            }
        }

       public static string CloseTranscriptLabel {
            get {
                return Translate.TextByDomain(PosesDictionary, "Close Transcript Label");
            }
        }

       public static string SelectBehaviorLabel {
           get {
               return Translate.TextByDomain(PosesDictionary, "Select Behavior Label");
           }
       }

       public static string SelectGradeLabel {
           get {
               return Translate.TextByDomain(PosesDictionary, "Select Grade Label");
           }
       }

        #endregion
    }
}
