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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class HeaderUtilityNav : BaseSublayout
    {
        protected HeaderFolderItem HeaderFolder { get; set; }
        protected MyAccountItem MyAccountPageItem { get; set; }
        protected string UserDisplayName { get; set; }

        protected string SearchPath
        {
            get { return FormHelper.GetSearchResultsUrl(String.Empty, String.Empty); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HeaderFolder = HeaderFolderItem.GetHeader();

            if (IsUserLoggedIn)
            {
                MyAccountPageItem = MyAccountItem.GetMyAccountPage();

                UserDisplayName = CurrentMember.FirstName != null ? CurrentMember.FirstName + " " : string.Empty;
                UserDisplayName = CurrentMember.LastName != null ? UserDisplayName + CurrentMember.LastName : UserDisplayName;
                UserDisplayName = UserDisplayName != string.Empty ? UserDisplayName.Trim() : CurrentMember.ScreenName;
            }

            GetCompanyLogoDetail();
            SetLanguageItemsRepeater();
            GetUtilityNavigationItems();
        }

        private void GetCompanyLogoDetail()
        {
            scLinkSignIn.Item = 
                frSearchLabel1.Item = 
                frSearchLabel2.Item = 
                scLogoImage.Item = HeaderFolder;
            hlLogoLink.NavigateUrl = HeaderFolder.LogoLink.Url;
        }

        private void GetUtilityNavigationItems()
        {
            var utilityNavigationFolder = HeaderFolder.GetUtilityNavigationFolder();
            if (utilityNavigationFolder != null)
            {
                var results = utilityNavigationFolder.GetNavigationLinkItems();
                if (results != null && results.Any())
                {
                    rptNavUtility.DataSource = results;
                    rptNavUtility.DataBind();
                }
            }
        }

        private void SetLanguageItemsRepeater()
        {
            var languageLinks = HeaderFolder.GetLanguageLinks();

            if (languageLinks != null && languageLinks.Any())
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

                if (item.IsOfType(AuthenticationNavigationLinkItem.TemplateId))
                {
                    var authenticationItem = new AuthenticationNavigationLinkItem(item);

                    if (IsUserLoggedIn)
                    {
                        LinkButton lbSignout = e.FindControlAs<LinkButton>("lbSignout");
                        lbSignout.Text = authenticationItem.LogoutText.Rendered;
                        lbSignout.Visible = true;
                    }
                    else
                    {
                        var frUtilityLink = e.FindControlAs<FieldRenderer>("frUtilityLink");

                        if (frUtilityLink != null)
                        {
                            frUtilityLink.Item = item;
                            frUtilityLink.FieldName = authenticationItem.LoginLink.Field.InnerField.Name;
                            frUtilityLink.Visible = true;
                        }
                    }
                }
                else
                {
                    var frUtilityLink = e.FindControlAs<FieldRenderer>("frUtilityLink");

                    if (frUtilityLink != null)
                    {
                        frUtilityLink.Item = item;
                        frUtilityLink.Visible = true;
                    }
                }
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
                if (languageItem != null)
                {
                    var hypLanguageLink = e.FindControlAs<HyperLink>("hypLanguageLink");
                    if (hypLanguageLink != null)
                    {

                        if (!languageItem.LanguageName.Raw.IsNullOrEmpty() && !languageItem.SitecoreLanguage.Raw.IsNullOrEmpty())
                        {

                            hypLanguageLink.Text = languageItem.LanguageName.Rendered;
                            hypLanguageLink.Attributes.Add("title", languageItem.LanguageName.Rendered);

                            var currentUrlAndQS = Request.Url.PathAndQuery;
                            var language = currentUrlAndQS;
                            foreach (var langItem in HeaderFolder.GetLanguageLinks())
                            {
                                if (currentUrlAndQS.StartsWith("/" + langItem.IsoCode))
                                {
                                    currentUrlAndQS = new string(currentUrlAndQS.Skip(("/" + langItem.IsoCode).Length).ToArray());
                                }
                            }

                            hypLanguageLink.NavigateUrl = string.Format("/{0}{1}", languageItem.IsoCode, currentUrlAndQS);

                            if (hypLanguageLink.NavigateUrl.Contains(Sitecore.Context.Language.Name))
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
    }
}