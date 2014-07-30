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

        #region Exception Text

            public static string YouAreNotLoggedOnErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "You Are Not Logged On Error Message");
            }
        }

        public static string DiscussionCriticalErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Discussion Critical Error Message");
            }
        }

        public static string ErrorSelectingForumMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Error Selecting Forum Message");
            }
        }

        public static string FailedToCreateDiscussionError
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Failed To Create Discussion Error");
            }
        }

        public static string Account_ThisUserIsNotConnectingMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Account_This User Is Not Connecting Message");
            }
        }

        public static string MyProfile_SelectIEPText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "MyProfile_Select IEP Text");
            }
        }

        public static string MyProfile_SelectDiagnosisText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "MyProfile_Select Diagnosis Text");
            }
        }

        public static string MyProfile_Select504Text
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "MyProfile_Select 504 Text");
            }
        }

        public static string TellGenderofChildText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Tell Gender of Child Text");
            }
        }

        public static string HasChildBeenEvaluatedText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Has Child Been Evaluated Text");
            }
        }

        public static string GiveChildNicknameText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Give Child Nickname Text");
            }
        }

        public static string GiveChildGradeText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Give Child Grade Text");
            }
        }

        #endregion Exception Text

        #region Button Text

        public static string SearchButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Search Button Text");
            }
        }

        public static string ShowAllMembersButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Show All Members Button Text");
            }
        }

        public static string RSSFeedButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "RSS Feed Button Text");
            }
        }

        public static string EmailButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Button Text");
            }
        }

		public static string SendButtonText
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Send Button Text");
			}
		}

		public static string ViewGlossaryButtonText
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "View Glossary Button Text");
			}
		}

        public static string ShareButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Share Button Text");
            }
        }

        public static string PrevButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Prev Button Text");
            }
        }

        public static string LastButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Last Button Text");
            }
        }

        public static string Articles_CloseTranscriptButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Close Transcript Button Text");
            }
        }

        public static string WhytheserecommendationsButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Why these recommendations Button Text");
            }
        }

        public static string EditthislistButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Edit this list Button Text");
            }
        }

        public static string RemindButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Remind Button Text");
            }
        }

        public static string SkipButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Skip Button Text");
            }
        }

        public static string PrintButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Print Button Text");
            }
        }

        public static string FalseButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "False Button Text");
            }
        }

        public static string TrueButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "True Button Text");
            }
        }

        public static string Articles_EmbedText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Embed Text");
            }
        }


        public static string DownloadButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Download Button Text");
            }
        }

        public static string CopyText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Copy Text");
            }
        }

        public static string Articles_ZoomOutText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Zoom Out Text");
            }
        }

        public static string Articles_ZoomInText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Zoom In Text");
            }
        }

        public static string Articles_SearchbyKeywordText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Search by Keyword Text");
            }
        }

        public static string Articles_BrowsebyLetterText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Browse by Letter Text");
            }
        }

        public static string Articles_BacktoTopText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Back to Top Text");
            }
        }

        public static string MyAccount_BackToHomePageLinkText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "MyAccount_Back To Home Page Link Text");
            }
        }

        public static string MyArticle_ForgotPasswordLink
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "MyArticle_Forgot Password Link");
            }
        }

        public static string Community_RSVPButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community_RSVP Button Text");
            }
        }

        public static string Community_SkipThisButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community_Skip This Button Text");
            }
        }

        public static string YesButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Yes Button Text");
            }
        }

        public static string Quizzes_ShowResults
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Quizzes_Show Results");
            }
        }

        public static string Quizzes_TakeQuizAgain
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Quizzes_Take Quiz Again");
            }
        }

        public static string Quizzes_NextQuestion
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Quizzes_Next Question");
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
        public static string EmailSubscribeText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Subscribe Text");
            }
        }
        public static string ShareandSaveText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Share and Save Text");
            }
        }
        public static string ShareandSaveEmail
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Share and Save Email Text");
            }
        }
        public static string ShareandSavePrint
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Share and Save Print Text");
            }
        }
        public static string RecommendationIcons
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Recommended for");
            }
        }

        #endregion

        #region Input Placeholders

        public static string Community_EnterConversation
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community_Enter Conversation");
            }
        }

        public static string Articles_AddCommentText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Add Comment Text");
            }
        }

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

        public static string SelectChallengeLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Select Challenge Label");
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

        public static string EnterOldPasswordWatermark { get { return Translate.TextByDomain(PosesDictionary, "Enter Old Password Watermark"); } }


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

        public static string EnterSearchTermWatermark
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Enter Search Term Watermark");
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

        public static string CommunityQuestionMinimumLength
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community Question Minimum Length");
            }
        }

        public static string CommunityQuestionMaximumLength
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community Question Maximum Length");
            }
        }
        
        public static string CommunityQuestionTitleMinimumLength
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community Question Title Minimum Length");
            }
        }

        public static string CommunityQuestionTitleMaximumLength
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community Question Title Maximum Length");
            }
        }

        public static string ConfirmPasswordErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Confirm Password Error Message");
            }
        }

        public static string UnderstoodText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Understood Text");
            }
        }

        public static string EmailAddressErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Address Error Message");
            }
        }

        public static string CommentErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Please enter a comment above.");
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

        public static string SomethingFailedError
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Something Failed Error");
            }
        }

        public static string PasswordMatchError
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Password Match Error");
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

        #region Submit Review Error Messages

        public static string ReviewSelectGradeErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Select Grade Error Message");
            }
        }

        public static string ReviewIThinkItIsErrorMessaage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "I Think It Is Error Message");
            }
        }

        public static string ReviewWhatYouThinkErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "What You Think Error Message");
            }
        }

        public static string ReviewGiveTitleErrorMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Give Title Error Message");
            }
        }

        #endregion

        #region Fragments

        public static string OutOfFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Out Of Fragment");
            }
        }

        public static string ForFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "For Fragment");
            }
        }

        public static string HeFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "He Fragment");
            }
        }

        public static string SheFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "She Fragment");
            }
        }

        public static string ByFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "By Fragment");
            }
        }

        public static string ofFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "of Fragment");
            }
        }

		public static string MoreFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "More Fragment");
			}
		}

		public static string SeeAllFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "See All Fragment");
			}
		}

		public static string ShowAllFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Show All Fragment");
			}
		}

		public static string GroupsFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Groups Fragment");
			}
		}

		public static string QAFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "QA Fragment");
			}
		}

		public static string ExpertsFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Experts Fragment");
			}
		}

		public static string FilterByFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Filter By Fragment");
			}
		}

		public static string BlogsFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Blogs Fragment");
			}
		}

		public static string MenuFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Menu Fragment");
			}
		}

        public static string SecondFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Second Fragment");
            }
        }

        public static string ProgressFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Progress Fragment");
            }
        }

        public static string FindFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Find Fragment");
            }
        }

        public static string DoneFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Done Fragment");
            }
        }

        public static string OneFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "1 Fragment");
            }
        }

        public static string TwoFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "2 Fragment");
            }
        }

        public static string ThreeFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "3 Fragment");
            }
        }

        public static string EditFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Edit Fragment");
            }
        }

        public static string CancelFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Cancel Fragment");
            }
        }

        public static string ClickHereFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Click Here Fragment");
            }
        }


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

        public static string HostsFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Hosts Fragment");
            }
        }


        public static string OrFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Or Fragment");
            }
        }

		public static string BestFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Best Fragment");
			}
		}

		public static string VeryGoodfragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Very Good Fragment");
			}
		}

		public static string Goodfragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Good Fragment");
			}
		}

		public static string Fairfragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Fair Fragment");
			}
		}

		public static string NotForLearningfragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Not For Learning Fragment");
			}
		}

		public static string Onfragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "On Fragment");
			}
		}

		public static string OffFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Off Fragment");
			}
		}

		public static string Pausefragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Pause Fragment");
			}
		}

		public static string Learningfragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Learning Fragment");
			}
		}

		public static string WelcomeFragment
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Welcome Fragment");
			}
		}

        public static string AtFragment
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "At Fragment");
            }
        }

        #endregion

        #region Core Labels

            public static string MyAccount_PreferencesSavedLabel
		{
			get
			{
                return Translate.TextByDomain(PosesDictionary, "MyAccount_Preferences Saved Label");
			}
		}

        public static string MoreResultsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "More Results Label");
            }
        }

		public static string Core_EmailSentLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Core_Email Sent Label");
			}
		}

		public static string Core_SendtoafriendLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Core_Send to a friend Label");
			}
		}

        public static string Core_ParentLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Core_Parent Label");
            }
        }

        #endregion

        #region Submit Review Labels

        public static string QualityLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Quality Label");
            }
        }

		public static string MoreInformationLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "More Information Label");
			}
		}

		public static string SeeRatingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "See Rating Label");
			}
		}

		public static string RelatedArticlesLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Related Articles Label");
			}
		}

		public static string ContentIsAppropriateLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Content Is Appropriate Label");
			}
		}

		public static string KnowYourChildLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Know Your Child Label");
			}
		}

		public static string NotAppropriateLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Not Appropriate Label");
			}
		}

		public static string LearningRatingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Learning Rating Label");
			}
		}

		public static string JustFineLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Just Fine Label");
			}
		}

		public static string ReallyEngagingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Really Engaging Label");
			}
		}

		public static string EngagingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Engaging Label");
			}
		}

		public static string PrettyEngagingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Pretty Engaging Label");
			}
		}

		public static string SomewhatEngagingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Somewhat Engaging Label");
			}
		}

		public static string NotRecommendedLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Not Recommended Label");
			}
		}

		public static string NotAgeAppropriateLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Not Age Appropriate Label");
			}
		}

		public static string WhatParentsAreSayingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "What parents are saying Label");
			}
		}

        public static string GoodForLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Good For Label");
            }
        }

        public static string WriteYourOwnReviewLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Write Your Own Review Label");
            }
        }

        public static string ReviewReportLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Review Report Label");
            }
        }

        public static string ForLearningIssuesLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "For Learning Issues Label");
            }
        }

		public static string QualityRatingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Quality Rating Label");
			}
		}

		public static string ReallyGoodLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Really Good Label");
			}
		}

		public static string TheBestLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "The Best Label");
			}
		}

		public static string WhatYouNeedToKnowLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "What You Need to Know Label");
			}
		}

		public static string ParentReviewsLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Parent Reviews Label");
			}
		}

		public static string SearchByLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Search By Label");
			}
		}

		public static string BrowseByLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Browse By Label");
			}
		}

		public static string BackToResultsLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Back To Results Label");
			}
		}

        public static string RateThisAppLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Rate This App Label");
            }
        }

        public static string IsItAnyGoodLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Is It Any Good Label");
            }
        }

        public static string ForKidsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "For Kids Label");
            }
        }

        public static string IThinkItIsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "I Think It Is Label");
            }
        }

        public static string ItIsGoodForLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "It Is Good For Label");
            }
        }

        public static string TellOtherFamiliesLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Tell Other Families Label");
            }
        }

        public static string GiveReviewTitleLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Give Review Title Label");
            }
        }

		public static string DisappointingLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Disappointing Label");
			}
		}

		public static string DontBotherLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Dont Bother Label");
			}
		}

        #endregion

        #region Article 

        public static string ShareLabelText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Share Label Text");
            }
        }

        public static string IncorrectText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Incorrect Text");
            }
        }

        public static string CorrectText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Correct Text");
            }
        }

        public static string CloseText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Close Text");
            }
        }

        public static string Articles_MorePostsbythisAuthorText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_More Posts by this Author Text");
            }
        }
        public static string Articles_AbouttheAuthorText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_About the Author Text");
            }
        }

        public static string Articles_BackText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Back Text");
            }
        }
        public static string Articles_TryAnotherQuizText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Try Another Quiz Text");
            }
        }

        public static string Articles_TaketheQuizText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Take the Quiz Text");
            }
        }

        public static string Articles_SeeAllCommentsText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_See All Comments Text");
            }
        }

        public static string Articles_AddMyCommentText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Add My Comment Text");
            }
        }
        public static string Articles_AnswersSavedText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Answers Saved Text");
            }
        }

        public static string Articles_SomethingWentWrongText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Something Went Wrong Text");
            }
        }

        public static string Articles_DownloadasPDFButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Articles_Download as PDF Button Text");
            }
        }



        #endregion Article Labels

        #region MyAccount Labels

        public static string InterestsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Interests Label");
            }
        }

        public static string ChildrenLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Children Label");
            }
        }

        public static string MyCommentsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Comments Label");
            }
        }

        public static string MyAccount_EnterAScreenName
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "MyAccount_Enter A Screen Name");
            }
        }

        public static string MyAccount_MyAccount_ZipCode
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "MyAccount_Zip Code");
            }
        }



        #endregion MyAccount Labels

        public static string SelectLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Select Label");
            }
        }

        public static string SelectStateLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Select State Label");
            }
        }

        public static string TitleLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Title Label");
            }
        }

		public static string WhatIsItAboutLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "What Is It About Label");
			}
		}

		public static string HowParentsCanHelpLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "How Parents Can Help Label");
			}
		}

		public static string WhatKidsCanLearnLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "What Kids Can Learn Label");
			}
		}

		public static string SubjectsLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Subjects Label");
			}
		}

        public static string SeeAllQuestionsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "See All Questions Label");
            }
        }


        public static string SearchThisBoardLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Search This Board Label");
            }
        }

        public static string StartedByLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Started By Label");
            }
        }

        public static string PartnerLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Partner Label");
            }
        }

        public static string StateLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "State Label");
            }
        }


        public static string PriceLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Price Label");
            }
        }

        public static string PurchaseLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Purchase Label");
            }
        }

        public static string ReviewsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Reviews Label");
            }
        }

        public static string RatingLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Rating Label");
            }
        }

        public static string SeeAllModeratorsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "See All Moderators Label");
            }
        }

		public static string SeeAllExpertLiveEventsLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "See All Expert Live Events Label");
			}
		}

		public static string AllParentsLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "All Parents Label");
			}
		}

		public static string JustShowParentsLikeMeLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Just Show Parents Like Me Label");
			}
		}

		public static string MilesWithinZipLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Miles Within Zip Label");
			}
		}

        

		public static string NoneOfTheseLabel
		{
			get
			{
                return Translate.TextByDomain(PosesDictionary, "None of These Label");
			}
		}

		public static string GradeRangeLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Grade Range Label");
			}
		}

		public static string UpcomingEventsLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Upcoming Events events Label");
			}
		}

        public static string CommunityModeratorsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Community Moderators Label");
            }
        }

        public static string JoinThisDiscussionLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Join This Discussion Label");
            }
        }

        public static string ParentsInThisDiscussionLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Parents In This Discussion Label");
            }
        }

        public static string JoinDiscussionLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Join Discussion Label");
            }
        }

        public static string DoYouHaveSomethingToAddLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Do You Have Something To Add Label");
            }
        }


        public static string SeeAllMembersLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "See All Members Label");
            }
        }

        public static string MyFriendsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My Friends Label");
            }
        }

        public static string TheAnswersLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "The Answers Label");
            }
        }

        public static string MostHelpfulLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Most Helpful Label");
            }
        }

        public static string MoreBloggersLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "More Bloggers Label");
            }
        }


        public static string Featured
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Featured");
            }
        }

        
        public static string HowCanHelp
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "How can we help");
            }
        }
        public static string ChildStruggles
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "My child struggles");
            }
        }

        public static string EmailInvalidUser
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Invalid User Email");
            }
        }

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



        // Share with a friend email
        public static string EnterNameLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Enter Name Label");
            }
        }

        public static string EnterEmailLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Enter Email Label");
            }
        }

        public static string FriendsEmailLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Friends Email Label");
            }
        }

        public static string EmailTextPlaceholder
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Text Placeholder");
            }
        }

        public static string EmailValidationMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Validation Message");
            }
        }

        public static string EmailThankYouMessage
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Email Thank You Message");
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

        public static string TextTipsRestartLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Text Tips Restart Label");
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

		public static string OnlyMembersCanSeeLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Only Members Can See Label");
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
                return Translate.TextByDomain(PosesDictionary, "Key Takeaways");
            }
        }

        public static string ReadMoreLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Read More Label");
            }
        }

		public static string AboutOurRatingSystemLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "About our rating system label");
			}
		}

        public static string GradeLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Grade Label");
            }
        }

        public static string TopicLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Topic Label");
            }
        }

        public static string ChildIssuesLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Child Issues Label");
            }
        }

        public static string EventDetailsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Event Details Label");
            }
        }

        public static string LanguageLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Language Label");
            }
        }

        public static string AllTechnologyLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "All Technology Label");
            }
        }

        public static string AllPlatformsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "All Platforms Label");
            }
        }

        public static string PauseLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Pause Label");
            }
        }

        public static string FooterNewsletterButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Footer Newsletter Button Text");
            }
        }

        public static string MoreLikeThisLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "More Like This Label");
            }
        }

        public static string InThisVideoLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "In This Video Label");
            }
        }

        public static string WhatYouCanDoLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "What You Can Do Label");
            }
        }

        public static string WhatYouCanSayLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "What You Can Say Label");
            }
        }

        public static string WhyThisWillHelpLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Why This Will Help Label");
            }
        }

        public static string SeeMyRecommendationsButtonText
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "See My Recommendations Button Text");
            }
        }

        public static string CommentsLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Comments Label");
            }
        }

        public static string ReplyLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Reply Label");
            }
        }

        public static string ThisHelpedLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "This Helped Label");
            }
        }

        public static string ReportAsInappropriateLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Report As Inappropriate Label");
            }
        }

        public static string LikesLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Likes Label");
            }
        }

        public static string UnderReviewLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Under Review Label");
            }
        }

        public static string SortByLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Sort By Label");
            }
        }

        public static string MostRecentLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Most Recent Label");
            }
        }

        public static string OldestToNewestLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Oldest To Newest Label");
            }
        }

        public static string RecommendedForYouLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Recommended Header");
            }
        }

        public static string ReviewedByLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Reviewed By Label");
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
        public static string NotNowLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Not Now Label");
            }
        }

        public static string BacktoLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Back to Label");
            }
        }

        public static string GuestExpertLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Guest Expert Label");
            }
        }

        public static string ExpertLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Expert Label");
            }
        }

        public static string WebinarLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Webinar Label");
            }
        }

        public static string ChatLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Chat Label");
            }
        }

        public static string DaysAgoLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Days ago Label");
            }
        }

        public static string SeeArchiveLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "See Archive Label");
            }
        }

        public static string OfficeHoursWithLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Office hours with Label");
            }
        }

        public static string SeeHerOfficeHoursLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "See her office hours Label");
            }

        }

        public static string MeetLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Meet Label");
            }

        }

        public static string OnlineOfficeHours
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Online Office Hours:");
            }
        }

        public static string ShowMoreLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Show More");
            }
        }

        public static string CloseTranscriptLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Close Transcript Label");
            }
        }

        public static string ViewTranscriptLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "View Transcript Label");
            }
        }

        public static string SelectBehaviorLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Select Behavior Label");
            }
        }

		public static string DidYouFindThisHelpfulLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Did You Find This Helpful Label");
			}
		}

        public static string SelectGradeLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Select Grade Label");
            }
        }

        public static string ChildsGradeLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Childs Grade Label");
            }
        }

        public static string QuestionTopicLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Question Topic Label");
            }
        }

        public static string ChatWithLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "Chat With Label");
            }
        }

        public static string SeeMyBioLabel
        {
            get
            {
                return Translate.TextByDomain(PosesDictionary, "See My Bio Label");
            }
        }

		public static string SelectTechnologyLabel
		{
			get
			{
				return Translate.TextByDomain(PosesDictionary, "Select Technology Label");
			}
		}

        #endregion

        public static string ViewAllLabel { get { return Translate.TextByDomain(PosesDictionary, "View All Label"); } }

        #region Community Labels
        public static string GroupRecommendedBackLink { get { return Translate.TextByDomain(PosesDictionary, "Group Recommended Back Link"); } }
        public static string RecommendedHeader { get { return Translate.TextByDomain(PosesDictionary, "Recommended Header"); } }

        public static string GroupPrivacyStatement { get { return Translate.TextByDomain(PosesDictionary, "Group Privacy Statement"); } }

        public static string ViewProfileLink1 { get { return Translate.TextByDomain(PosesDictionary, "View Profile Link1"); } }
        public static string EmptyGroupsListText { get { return Translate.TextByDomain(PosesDictionary, "Empty Groups Text"); } }

        //Blog Labels
        public static string BackToAllBlogs { get { return Translate.TextByDomain(PosesDictionary, "Blog Back Link"); } }

        public static string ForumCreateConfirmation { get { return Translate.TextByDomain(PosesDictionary, "Forum Created Successfully Message"); } }
        public static string ForumValidationConfirmation { get { return Translate.TextByDomain(PosesDictionary, "Forum Validation Confirmation Message"); } }

        public static string ViewDiscussionsLabel { get { return Translate.TextByDomain(PosesDictionary, "View Discussions Label"); } }
        public static string JoinThisGroupLabel { get { return Translate.TextByDomain(PosesDictionary, "Join this Group Label"); } }

		public static string APrivateParentCommunityLabel { get { return Translate.TextByDomain(PosesDictionary, "A Private Parent Community Label"); } }
		public static string WeAskForAScreenname { get { return Translate.TextByDomain(PosesDictionary, "We Ask For A Screenname Label"); } }
		public static string SelectATopicLabel { get { return Translate.TextByDomain(PosesDictionary, "Select A Topic Label"); } }
		public static string SoOtherParentsLabel { get { return Translate.TextByDomain(PosesDictionary, "So Other Parents Label"); } }
		public static string UnderstoodMakesItEasyLabel { get { return Translate.TextByDomain(PosesDictionary, "Understood Makes It Easy Label"); } }
		public static string YesIWouldLikeToSignUpLabel { get { return Translate.TextByDomain(PosesDictionary, "Yes I Would Like To Sign Up Label"); } }
		public static string WhyDoWeAskLabel { get { return Translate.TextByDomain(PosesDictionary, "Why Do We Ask Label"); } }
		public static string OrCompleteMyProfileLabel { get { return Translate.TextByDomain(PosesDictionary, "Or Complete My Profile Label"); } }
		public static string JoinGroupButtonText { get { return Translate.TextByDomain(PosesDictionary, "Join Group Button Text"); } }

		#endregion

        #region Community Messages
        public static string ThinkingOfYouMessage { get { return Translate.TextByDomain(PosesDictionary, "Thinking Of You Message"); } }
        public static string ThankYouMessage { get { return Translate.TextByDomain(PosesDictionary, "Thank You Message"); } }
        #endregion

        #region Community Roles

        public static string CommunityEveryone { get { return Translate.TextByDomain(PosesDictionary, "Everyone Role"); } }
        public static string CommunityMember { get { return Translate.TextByDomain(PosesDictionary, "Member Role"); } }
        public static string CommunityModerator { get { return Translate.TextByDomain(PosesDictionary, "Moderator Role"); } }
        public static string CommunityAdministrator { get { return Translate.TextByDomain(PosesDictionary, "Administrator Role"); } }
        public static string CommunityExpert { get { return Translate.TextByDomain(PosesDictionary, "Expert Role"); } }
        public static string CommunityBlogger { get { return Translate.TextByDomain(PosesDictionary, "Blogger Role"); } }

        #endregion


        public static string SelectAll { get { return Translate.TextByDomain(PosesDictionary, "SelectAll"); } }

        public static string ChildEnrolled { get { return Translate.TextByDomain(PosesDictionary, "ChildEnrolled"); } }

        public static string CompleteMyProfile { get { return Translate.TextByDomain(PosesDictionary, "CompleteMyProfile"); } }

        //TODO: create matching labels in sitecore
        #region Notification Labels
        /// <summary>
        /// Use string.format, has two placeholders (0=Username, 1=URL)
        /// </summary>
        public static string ConnectAction { get { return Translate.TextByDomain(PosesDictionary, "Wants To Connect Text"); } }
        public static string ConnectLink { get { return Translate.TextByDomain(PosesDictionary, "Parent Connection Text"); } }
        public static string CommentAction { get { return Translate.TextByDomain(PosesDictionary, "Comment Action Text"); } }
        public static string AcceptText { get { return Translate.TextByDomain(PosesDictionary, "Accept Text"); } }
        public static string CommentFrontAction { get { return Translate.TextByDomain(PosesDictionary, "Comment Action Landing Text"); } }
        public static string DeclineText { get { return Translate.TextByDomain(PosesDictionary, "Decline Text"); } }
        public static string CommentHeader { get { return Translate.TextByDomain(PosesDictionary, "Comment Header Text"); } }
        public static string EmptyNotifications { get { return Translate.TextByDomain(PosesDictionary, "Empty Notifications Text"); } }
        public static string WhatsHappeningLabel { get { return Translate.TextByDomain(PosesDictionary, "Whats Happening Text"); } }

        public static string PrivateMessagesLabel { get { return Translate.TextByDomain(PosesDictionary, "Private Messages Text"); } }

        public static string EmailPreferencesLabel { get { return Translate.TextByDomain(PosesDictionary, "Email Alert Preferences Text"); } }

        public static string NotificationsButtonLabel { get { return Translate.TextByDomain(PosesDictionary, "Notifications Text"); } }

        public static string SeeAllNotificationsLabel { get { return Translate.TextByDomain(PosesDictionary, "All Notifications Text"); } }
        public static string ForumReplyHeader { get { return Translate.TextByDomain(PosesDictionary, "Forum Reply Header Text"); } }
        #endregion




        public static string FollowBlog { get { return Translate.TextByDomain(PosesDictionary, "FollowBlog"); } }

        public static string FollowingBlog { get { return Translate.TextByDomain(PosesDictionary, "FollowingBlog"); } }

        public static string FollowBlogPost { get { return Translate.TextByDomain(PosesDictionary, "FollowBlogPost"); } }

        public static string FollowingBlogPost { get { return Translate.TextByDomain(PosesDictionary, "FollowingBlogPost"); } }

        public static string AnswerQuestionLabel { get { return Translate.TextByDomain(PosesDictionary, "Answer Question Label"); } }

        public static string FollowThisQuestionLabel { get { return Translate.TextByDomain(PosesDictionary, "Follow This Question Label"); } }

        public static string AskedByLabel { get { return Translate.TextByDomain(PosesDictionary, "Asked By Label"); } }

        public static string OpenQuestionLabel { get { return Translate.TextByDomain(PosesDictionary, "Open Question Label"); } }

        public static string InLabel { get { return Translate.TextByDomain(PosesDictionary, "In Label"); } }

        public static string AnsweredByLabel { get { return Translate.TextByDomain(PosesDictionary, "Answered By Label"); } }

        public static string ModeratorLabel { get { return Translate.TextByDomain(PosesDictionary, "Moderator Label"); } }

        public static string SubmitAnswerLabel { get { return Translate.TextByDomain(PosesDictionary, "Submit Answer Label"); } }

        public static string AskLabel { get { return Translate.TextByDomain(PosesDictionary, "Ask Label"); } }

        public static string AnswersLabel { get { return Translate.TextByDomain(PosesDictionary, "Answers Label"); } }

        public static string AnswerLabel { get { return Translate.TextByDomain(PosesDictionary, "Answer Label"); } }

        public static string NeedAnswersLabel { get { return Translate.TextByDomain(PosesDictionary, "Need Answers Label"); } }

        public static string AnsweredLabel { get { return Translate.TextByDomain(PosesDictionary, "Answered Label"); } }

        public static string DiscoverLabel { get { return Translate.TextByDomain(PosesDictionary, "Discover Label"); } }

        public static string SubmitYourQuestionLabel { get { return Translate.TextByDomain(PosesDictionary, "Submit Your Question Label"); } }

        public static string SeeOpenQuestionsLabel { get { return Translate.TextByDomain(PosesDictionary, "See Open Questions Label"); } }

        public static string SeeAnsweredQuestionsLabel { get { return Translate.TextByDomain(PosesDictionary, "See Answered Questions Label"); } }

        public static string FeaturedParentQuestionsLabel { get { return Translate.TextByDomain(PosesDictionary, "Featured Parent Questions Label"); } }

        public static string TheUnderstoodBlogLabel { get { return Translate.TextByDomain(PosesDictionary, "The Understood Blog Label"); } }

        public static string ReadTheUnderstoodBlogButtonLabel { get { return Translate.TextByDomain(PosesDictionary, "Read The Understood Blog Button Label"); } }

        public static string MoreBlogsLabel { get { return Translate.TextByDomain(PosesDictionary, "More Blogs Label"); } }

        public static string FromOurBlogsLabel { get { return Translate.TextByDomain(PosesDictionary, "From Our Blogs Label"); } }

        public static string SeeAllBlogsLabel { get { return Translate.TextByDomain(PosesDictionary, "See All Blogs Label"); } }

        public static string SeeMoreLabel { get { return Translate.TextByDomain(PosesDictionary, "See More Label"); } }

        public static string PostedByLabel { get { return Translate.TextByDomain(PosesDictionary, "Posted By Label"); } }

        public static string MostReadLabel { get { return Translate.TextByDomain(PosesDictionary, "Most Read Label"); } }

        public static string MostSharedLabel { get { return Translate.TextByDomain(PosesDictionary, "Most Shared Label"); } }

        public static string MostTalkedLabel { get { return Translate.TextByDomain(PosesDictionary, "Most Talked Label"); } }

        public static string MostSharedThisWeekLabel { get { return Translate.TextByDomain(PosesDictionary, "Most Shared This Week Label"); } }

        public static string ParentsAreTalkingAboutLabel { get { return Translate.TextByDomain(PosesDictionary, "Parents Are Talking About Label"); } }

        public static string PostACommentLabel { get { return Translate.TextByDomain(PosesDictionary, "Post A Comment Label"); } }

        public static string SearchThisBlogLabel { get { return Translate.TextByDomain(PosesDictionary, "Search This Blog Label"); } }

        public static string ReadBlogLabel { get { return Translate.TextByDomain(PosesDictionary, "Read Blog Label"); } }

        public static string RepliesLabel { get { return Translate.TextByDomain(PosesDictionary, "Replies Label"); } }

        public static string RecommendedLabel { get { return Translate.TextByDomain(PosesDictionary, "Recommended Label"); } }

        #region Connect Button Labels
        public static string ConnectBtnText { get { return Translate.TextByDomain(PosesDictionary, "Connect Button Text"); } }
        public static string ViewActivity { get { return Translate.TextByDomain(PosesDictionary, "View Activity Button Text"); } }
        public static string RequestRecieved { get { return Translate.TextByDomain(PosesDictionary, "Request Recieved Button Text"); } }
        public static string RequestSent { get { return Translate.TextByDomain(PosesDictionary, "Request Sent Button Text"); } }
        public static string UnconnectButtonText { get { return Translate.TextByDomain(PosesDictionary, "Unconnect Button Text"); } }
        public static string PrivateMessageButtonText { get { return Translate.TextByDomain(PosesDictionary, "Private Message Button Text"); } }
        #endregion

        public static string InitialDropDownText { get { return Translate.TextByDomain(PosesDictionary, "Select Forum Label"); } }

        public static string InitialTextBoxText { get { return Translate.TextByDomain(PosesDictionary, "Create New Forum Label"); } }

        public static string ThanksLabel { get { return Translate.TextByDomain(PosesDictionary, "Thanks Label"); } }
        public static string ThinkingOfYouLabel { get { return Translate.TextByDomain(PosesDictionary, "Thinking Of You Label"); } }
        public static string SentLabel { get { return Translate.TextByDomain(PosesDictionary, "Sent Label"); } }

        public static string StartDiscussion { get { return Translate.TextByDomain(PosesDictionary, "Start a Discussion Label"); } }

        public static string JumpToText { get { return Translate.TextByDomain(PosesDictionary, "JumpTo Label"); } }

        public static string DiscussionLabel { get { return Translate.TextByDomain(PosesDictionary, "Discussion Label"); } }

        public static string LatestPostLabel { get { return Translate.TextByDomain(PosesDictionary, "Latest Post Label"); } }

        public static string MembersOnlyDiscussionLabel { get { return Translate.TextByDomain(PosesDictionary, "Members Privacy Label"); } }

        public static string FindAConversationLabel { get { return Translate.TextByDomain(PosesDictionary, "Find Conversation Label"); } }

        public static string DiscussionsLabel { get { return Translate.TextByDomain(PosesDictionary, "Discussions Label"); } }

        public static string GotAQuestionLabel { get { return Translate.TextByDomain(PosesDictionary, "Got a Question Label"); } }

        public static string WantToTalkLabel { get { return Translate.TextByDomain(PosesDictionary, "Want To Talk Label"); }}

        public static string MembersLabel { get { return Translate.TextByDomain(PosesDictionary, "Members Label"); } }

        public static string ViewProfileLabel { get { return Translate.TextByDomain(PosesDictionary, "View Profile Label"); } }
        public static string SeeActivityLabel { get { return Translate.TextByDomain(PosesDictionary, "See Activity Label"); } }
        public static string GradeLevelLabel { get { return Translate.TextByDomain(PosesDictionary, "Grade Level Label"); } }
        public static string AdditionalInformationLabel { get { return Translate.TextByDomain(PosesDictionary, "Additional Information Label"); } }

        public static string MostActiveGroupsLabel { get { return Translate.TextByDomain(PosesDictionary, "Most Active Group Label"); } }

        public static string SeeAllGroupsLabel { get { return Translate.TextByDomain(PosesDictionary, "See All Group Label"); } }

        public static string SkipThisLabel { get { return Translate.TextByDomain(PosesDictionary, "Skip This Label"); } }
        public static string PostsLabel { get { return Translate.TextByDomain(PosesDictionary, "Posts Label"); } }

        public static string MyGroupsLabel {  get { return Translate.TextByDomain(PosesDictionary, "My Groups Label"); } }

        public static string ShowYourSupportLabel { get { return Translate.TextByDomain(PosesDictionary, "Show Your Support Label"); } }
        public static string ProfileLabel { get { return Translate.TextByDomain(PosesDictionary, "Profile Label"); } }
        public static string ConnectionsLabel { get { return Translate.TextByDomain(PosesDictionary, "Connections Label"); } }

        public static string RecommendedGroupsLabel { get { return Translate.TextByDomain(PosesDictionary, "Recommended Groups Label"); } }
        public static string LastUpdatedLabel { get { return Translate.TextByDomain(PosesDictionary, "Last Updated Label"); } }

        public static string GroupsPrivacyLabel { get { return Translate.TextByDomain(PosesDictionary, "Groups Privacy Label"); } }

        public static string ParentGroupsLabel { get { return Translate.TextByDomain(PosesDictionary, "Parent Groups Label"); } }

        public static string ShowMatchingGroupsLabel { get { return Translate.TextByDomain(PosesDictionary, "Matching Groups Label"); } }

        public static string TopicsLabel { get { return Translate.TextByDomain(PosesDictionary, "Topics Label"); } }

        public static string GradesLabel { get { return Translate.TextByDomain(PosesDictionary, "Grades Label"); } }

        public static string StatesLabel { get { return Translate.TextByDomain(PosesDictionary, "States Label"); } }

        public static string PartnersLabel { get { return Translate.TextByDomain(PosesDictionary, "Partners Label"); } }

        public static string BetterRecommendations { get { return Translate.TextByDomain(PosesDictionary, "Better Recommendations Label"); } }

        public static string AllLabel { get { return Translate.TextByDomain(PosesDictionary, "All Label"); } }

        public static string PopularLabel { get { return Translate.TextByDomain(PosesDictionary, "Popular Label"); } }




        public static string InboxLabel { get { return Translate.TextByDomain(PosesDictionary, "Inbox Label"); } }

        public static string NewMessageLabel { get { return Translate.TextByDomain(PosesDictionary, "New Message Label"); } }

        public static string DeleteButtonLabel { get { return Translate.TextByDomain(PosesDictionary, "Delete Button Label"); } }

        public static string SubmitReplyButtonLabel { get { return Translate.TextByDomain(PosesDictionary, "Submit Reply Label"); } }
         
        public static string DeleteConfirmationLabel {get { return Translate.TextByDomain(PosesDictionary, "Delete Button Confirmation Label"); } }


        public static string SendMessageButtonLabel { get { return Translate.TextByDomain(PosesDictionary, "Send Message Button Label"); } }


        public static string SendPrivateMessageLabel { get { return Translate.TextByDomain(PosesDictionary, "Send Private Message Title"); } }

        public static string TopicsCoveredLabel { get { return Translate.TextByDomain(PosesDictionary, "Topics Covered Label"); } }
        public static string RecommendedForLabel { get { return Translate.TextByDomain(PosesDictionary, "Recommended For Child Label"); } }


        public static string RecommendedQuestionsLabel { get { return Translate.TextByDomain(PosesDictionary, "Recommended Questions Label"); } }

        public static string RecommendedBlogsLabel { get { return Translate.TextByDomain(PosesDictionary, "Recommended Blogs Label"); } }
        
        public static string AnswerThisQuestionLabel { get { return Translate.TextByDomain(PosesDictionary, "Answer This Question Label"); } }
        
        public static string AllBlogsLabel { get { return Translate.TextByDomain(PosesDictionary, "All Blogs Label"); } }
        
        public static string AnswerFragment { get { return Translate.TextByDomain(PosesDictionary, "Answer Fragment"); } }
        
        public static string AllQuestionsLabel { get { return Translate.TextByDomain(PosesDictionary, "All Questions Label"); } }

        public static string BlogDateStampLabel { get { return Translate.TextByDomain(PosesDictionary, "Blog Date Stamp Label"); } }

        public static object ExpertLiveArchiveLabel { get { return Translate.TextByDomain(PosesDictionary, "Expert Live Archive Label"); } }

        public static object SuggestWebinarLabel { get { return Translate.TextByDomain(PosesDictionary, "Suggest A Webinar Label"); } }

        public static object EnterTopicLabel { get { return Translate.TextByDomain(PosesDictionary, "Enter Topic Label"); } }

        public static object EnterTopicWaterMarkLabel { get { return Translate.TextByDomain(PosesDictionary, "Enter Your Topic Watermark"); } }

        public static string BlogsIFollow { get { return Translate.TextByDomain(PosesDictionary, "Blogs I Follow Label"); } }

        public static string RecentBlogPostsLabel { get { return Translate.TextByDomain(PosesDictionary, "Recent Blog Posts Label"); } }

        public static string RecentQuestionsLabel { get { return Translate.TextByDomain(PosesDictionary, "Recent Questions Label"); } }

        public static string YouAreFollowingLabel { get { return Translate.TextByDomain(PosesDictionary, "You Are Following Label"); } }

        public static object InFragment { get { return Translate.TextByDomain(PosesDictionary, "In Fragment"); } }

        public static string ViewCalendarLabel { get { return Translate.TextByDomain(PosesDictionary, "View Calendar Label"); } }
    }
}
