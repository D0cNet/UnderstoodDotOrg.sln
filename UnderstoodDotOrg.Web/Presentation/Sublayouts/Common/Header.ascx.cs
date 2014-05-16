using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Web;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Header : System.Web.UI.UserControl
    {
        HeaderFolderItem headerFolderItem = GetHeader();

        public string SearchPath
        {
            get { return FormHelper.GetSearchResultsUrl(String.Empty, String.Empty); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (headerFolderItem != null)
            {
                GetCompanyLogoDetail(headerFolderItem);
                SetLanguageItemsRepeater();
                GetMainNavigationItems(headerFolderItem);
                GetUtilityNavigationItems(headerFolderItem);
                GetParentTookKitItems(headerFolderItem);
                GetGoogleAnalyticsDetails();
            }
        }

        protected void GetGoogleAnalyticsDetails()
        {
            GlobalsItem ObjGloalItem = new GlobalsItem(Sitecore.Context.Item);
            if (ObjGloalItem != null)
            {
                frGlobalGoogleAnalytics.Item = ObjGloalItem;
            }
            BasePageNEWItem ObjBasePageNew = new BasePageNEWItem(Sitecore.Context.Item);
            if (ObjBasePageNew != null)
            {
                frPageGoogleAnalytics.Item = ObjBasePageNew;
            }
        }


        private void GetParentTookKitItems(HeaderFolderItem headerFolderItem)
        {
            ParentToolkitFolderItem parentToolkitFolder = headerFolderItem.GetParentToolkitFolder();
            if (parentToolkitFolder != null)
            {
                frParentToolKitHeading.Item = parentToolkitFolder;
                var result = parentToolkitFolder.GetNavigationLinkItems();
                if (result != null)
                {
                    rptParentToolkit.DataSource = result;
                    rptParentToolkit.DataBind();
                }
            }
        }

        private void GetCompanyLogoDetail(HeaderFolderItem headerFolderItem)
        {
            scLinkSignIn.Item = frSearchLabel1.Item = frSearchLabel2.Item = scLogoImage.Item = headerFolderItem;
            hlLogoLink.NavigateUrl = headerFolderItem.LogoLink.Url;
        }

        /// <summary>
        /// Get header item from global
        /// </summary>
        /// <returns></returns>
        public static HeaderFolderItem GetHeader()
        {
            MainsectionItem objSiteItem = MainsectionItem.GetSiteRoot();
            HeaderFolderItem objHeaderItem = null;
            if (objSiteItem != null)
            {
                GlobalsItem objGlobalItem = MainsectionItem.GetGlobals();
                if (objGlobalItem != null)
                {
                    objHeaderItem = objGlobalItem.GetHeader();

                }
            }
            return objHeaderItem;
        }

        /// <summary>
        /// Get main navigation items.
        /// </summary>
        /// <param name="headerFolderItem"></param>
        private void GetMainNavigationItems(HeaderFolderItem headerFolderItem)
        {
            MainNavigationFolderItem mainNavigationFolder = headerFolderItem.GetMainNavigationFolder();
            if (mainNavigationFolder != null)
            {
                var results = mainNavigationFolder.GetNavigationLinkItems();
                if (results != null && results.Any())
                {
                    rptMainNavigation.DataSource = results;
                    rptMainNavigation.DataBind();
                }
            }
        }

        /// <summary>
        /// Get utility navigation items.
        /// </summary>
        /// <param name="headerFolderItem"></param>
        private void GetUtilityNavigationItems(HeaderFolderItem headerFolderItem)
        {
            UtilityNavigationFolderItem utilityNavigationFolder = headerFolderItem.GetUtilityNavigationFolder();
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

        /// <summary>
        /// Get language items.
        /// </summary>
        /// <param name="headerFolderItem"></param>
        private void SetLanguageItemsRepeater()
        {
            var languageLinks = headerFolderItem.GetLanguageLinks();

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
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;
                if (item != null)
                {
                    FieldRenderer frUtilityLink = e.FindControlAs<FieldRenderer>("frUtilityLink");

                    if (frUtilityLink != null)
                    {
                        frUtilityLink.Item = item;
                    }
                }
            }
        }

        protected void rptMainNavigation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;
                if (item != null)
                {
                    FieldRenderer frMainNavigationLink = e.FindControlAs<FieldRenderer>("frMainNavigationLink");
                    if (frMainNavigationLink != null)
                    {
                        frMainNavigationLink.Item = item;
                    }

                    var results = GetNavigationLinkItems(item.InnerItem);
                    if (results != null && results.Any())
                    {
                        Repeater rptPrimaryNav = e.FindControlAs<Repeater>("rptPrimaryNavigation");
                        if (rptPrimaryNav != null)
                        {
                            rptPrimaryNav.DataSource = results;
                            rptPrimaryNav.DataBind();
                        }
                    }
                }
            }
        }

        protected void rptPrimaryNavigation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;

                if (item != null)
                {
                    FieldRenderer frPrimaryNavigationLink = e.FindControlAs<FieldRenderer>("frPrimaryNavigationLink");
                    if (frPrimaryNavigationLink != null)
                    {
                        frPrimaryNavigationLink.Item = item;
                    }
                }
            }
        }


        /// <summary>
        /// Get child navigation link item
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NavigationLinkItem> GetNavigationLinkItems(Item innerItem)
        {
            return innerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(NavigationLinkItem.TemplateId)).Select(i => (NavigationLinkItem)i);
        }

        protected void rptLanguage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                LanguageLinkItem languageItem = e.Item.DataItem as LanguageLinkItem;
                if (languageItem != null)
                {
                    HyperLink hypLanguageLink = e.FindControlAs<HyperLink>("hypLanguageLink");
                    if (hypLanguageLink != null)
                    {

                        if (!languageItem.LanguageName.Raw.IsNullOrEmpty() && !languageItem.SitecoreLanguage.Raw.IsNullOrEmpty())
                        {

                            hypLanguageLink.Text = languageItem.LanguageName.Rendered;
                            hypLanguageLink.Attributes.Add("title", languageItem.LanguageName.Rendered);

                            string currentUrlAndQS = Request.Url.PathAndQuery;
                            string language = currentUrlAndQS;
                            foreach (var langItem in headerFolderItem.GetLanguageLinks())
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

        protected void rptParentToolkit_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;
                if (item != null)
                {
                    FieldRenderer frNavLink = e.FindControlAs<FieldRenderer>("frNavLink");
                    Panel pnlParentToolKit = e.FindControlAs<Panel>("pnlParentToolKit");
                    if (frNavLink != null)
                    {
                        frNavLink.Item = item;
                    }

                    if (pnlParentToolKit != null && item.Image != null && item.Image.MediaItem != null)
                    {
                        pnlParentToolKit.Style.Add("background", string.Format("url('{0}') no-repeat scroll 0 0 / 100px 100px rgba(0, 0, 0, 0); background-size:40px 40px; height:180px; background-color:#ffffff; background-position:50% 10px; position:relative;", item.Image.MediaUrl));
                    }
                }
            }
        }
    }
}