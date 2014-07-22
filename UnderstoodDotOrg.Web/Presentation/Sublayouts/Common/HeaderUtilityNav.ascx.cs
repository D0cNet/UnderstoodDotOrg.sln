using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Services.TelligentService;
using UnderstoodDotOrg.Domain.Models.TelligentCommunity;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class HeaderUtilityNav : BaseSublayout
    {
        protected HeaderFolderItem HeaderFolder { get; set; }
        protected MyAccountItem MyAccountPageItem { get; set; }
        protected string UserDisplayName { get; set; }
        protected string MainLogoUrl { get; set; }

        protected string SearchPath
        {
            get { return FormHelper.GetSearchResultsUrl(String.Empty, String.Empty); }
        }
        protected string SearchLabel
        {
            get { return DictionaryConstants.SearchLabel; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HeaderFolder = HeaderFolderItem.GetHeader();

            if (IsUserLoggedIn)
            {
				phLoggedIn.Visible = true;
                MyAccountPageItem = MyAccountItem.GetMyAccountPage();

                UserDisplayName = !string.IsNullOrWhiteSpace(CurrentMember.FirstName) ?
                    CurrentMember.FirstName.Trim() :
                    "Guest";


				//sets up the global hero image along with the notifications
                var user = TelligentService.GetUser(CurrentMember.ScreenName);
                if (user != null)
                {
                    imgUserAvatar.ImageUrl = user.AvatarUrl;
                }
                else
                {
                    imgUserAvatar.ImageUrl = Constants.Settings.AnonymousAvatar;
                }
                
                // TODO: review this code if necessary
                List<INotification> notifs = TelligentService.GetNotifications(CurrentMember.ScreenName);
                List<Conversation> checkConvos = TelligentService.GetConversations(CurrentMember.ScreenName);

				int totalNotifications = (notifs != null) ? notifs.Count() : 0;
                int totalConversations = (checkConvos != null) ? checkConvos.Count() : 0;
				lblNotificationNumber.Text = (totalConversations + totalConversations).ToString();
            }
			else
			{
				phNotLoggedIn.Visible = true;
			}

            GetCompanyLogoDetail();
            SetLanguageItemsRepeater();
            GetUtilityNavigationItems();
        }

        private void GetCompanyLogoDetail()
        {
            scLinkSignIn.Item = 
                frSearchLabel1.Item = 
                frSearchLabel2.Item = HeaderFolder;
            hlLogoLink.NavigateUrl = HeaderFolder.LogoLink.Url;
            MainLogoUrl = HeaderFolder.CompanyLogo.MediaItem.GetImageUrl();
            string imgUrl = HeaderFolder.MobileCompanyLogo.MediaItem.GetImageUrl();
            imgMobileLogo.ImageUrl = imgUrl;
            imgMobileLogo.Visible = !string.IsNullOrEmpty(imgUrl);
        }

        private void GetUtilityNavigationItems()
        {
            var utilityNavigationFolder = HeaderFolder.GetUtilityNavigationFolder();
            if (utilityNavigationFolder != null)
            {
                var results = utilityNavigationFolder.GetNavigationLinkItems();
                
                if (results.Any())
                {
                    // NOTE: Signup/Signout link is contained in separate markup from utility nav
                    
                    // Utility nav
                    var utility = results.Where(i => i.IsOfType(NavigationLinkItem.TemplateId));
                    if (utility.Any())
                    {
                        rptNavUtility.DataSource = utility;
                        rptNavUtility.DataBind();
                    }

                    // Sign-in/out
                    var authenticated = results.Where(i => i.IsOfType(AuthenticationNavigationLinkItem.TemplateId))
                                            .Select(i => new AuthenticationNavigationLinkItem(i))
                                            .FirstOrDefault();

                    if (authenticated != null)
                    {
                        scLinkSignIn.Visible = !IsUserLoggedIn;
                        lbSignout.Visible = IsUserLoggedIn;

                        scLinkSignIn.Item = authenticated;
                        lbSignout.Text = authenticated.LogoutText.Rendered;
                    }
                }
            }
        }

        private void SetLanguageItemsRepeater()
        {
            var languageLinks = HeaderFolder.GetLanguageLinks();

            if (languageLinks.Any())
            {
                rptLanguage.DataSource = languageLinks;
                rptLanguage.DataBind();
            }
        }

        protected void rptNavUtility_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var item = e.Item.DataItem as Item;

                Placeholder phMenuItem = e.FindControlAs<Placeholder>("phMenuItem");

                var frUtilityLink = e.FindControlAs<FieldRenderer>("frUtilityLink");

                frUtilityLink.Item = item;
            }
        }

        protected void lbSignout_Click(object sender, EventArgs e)
        {
            Logout();
        }

        protected void rptLanguage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var languageItem = e.Item.DataItem as LanguageLinkItem;
                var hypLanguageLink = e.FindControlAs<HyperLink>("hypLanguageLink");

                if (!languageItem.LanguageName.Raw.IsNullOrEmpty() && !languageItem.SitecoreLanguage.Raw.IsNullOrEmpty())
                {
                    hypLanguageLink.Text = languageItem.MobileAbbreviation.Rendered;
                    hypLanguageLink.Attributes.Add("title", languageItem.LanguageName.Raw);

                    hypLanguageLink.NavigateUrl = languageItem.GetCurrentIsoAwareUrl();

                    if (languageItem.IsoCode == Sitecore.Context.Language.Name)
                    {
                        hypLanguageLink.Attributes.Add("class", "is-active");
                    }
                    else
                    {
                        hypLanguageLink.Attributes.Remove("class");
                    }
                }
            }
        }
    }
}