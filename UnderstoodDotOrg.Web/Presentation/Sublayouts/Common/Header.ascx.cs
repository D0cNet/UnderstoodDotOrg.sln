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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common {
    public partial class Header : System.Web.UI.UserControl {
		HeaderFolderItem headerFolderItem = GetHeader();

        protected void Page_Load(object sender, EventArgs e) {
            if (headerFolderItem != null) {
                GetCompanyLogoDetail(headerFolderItem);
                SetLanguageItemsRepeater();
                GetMainNavigationItems(headerFolderItem);
                GetUtilityNavigationItems(headerFolderItem);
                GetParentTookKitItems(headerFolderItem);
            }
        }

        private void GetParentTookKitItems(HeaderFolderItem headerFolderItem) {
            ParentToolkitFolderItem parentToolkitFolder = headerFolderItem.GetParentToolkitFolder();
            if (parentToolkitFolder != null) {
                frParentToolKitHeading.Item = parentToolkitFolder;
                var result = parentToolkitFolder.GetNavigationLinkItems();
                if (result != null) {
                    rptParentToolkit.DataSource = result;
                    rptParentToolkit.DataBind();
                }
            }
        }

        private void GetCompanyLogoDetail(HeaderFolderItem headerFolderItem) {
            scLinkSignIn.Item = frSearchLabel1.Item = frSearchLabel2.Item = scLogoImage.Item = headerFolderItem;
            hlLogoLink.NavigateUrl = headerFolderItem.LogoLink.Url;
        }

        /// <summary>
        /// Get header item from global
        /// </summary>
        /// <returns></returns>
        public static HeaderFolderItem GetHeader() {
            MainsectionItem objSiteItem = MainsectionItem.GetSiteRoot();
            HeaderFolderItem objHeaderItem = null;
            if (objSiteItem != null) {
                GlobalsItem objGlobalItem = MainsectionItem.GetGlobals();
                if (objGlobalItem != null) {
                    objHeaderItem = objGlobalItem.GetHeader();
                }
            }
            return objHeaderItem;
        }

        /// <summary>
        /// Get main navigation items.
        /// </summary>
        /// <param name="headerFolderItem"></param>
        private void GetMainNavigationItems(HeaderFolderItem headerFolderItem) {
            MainNavigationFolderItem mainNavigationFolder = headerFolderItem.GetMainNavigationFolder();
            if (mainNavigationFolder != null) {
                var results = mainNavigationFolder.GetNavigationLinkItems();
                if (results != null && results.Any()) {
                    rptMainNavigation.DataSource = results;
                    rptMainNavigation.DataBind();
                }
            }
        }

        /// <summary>
        /// Get utility navigation items.
        /// </summary>
        /// <param name="headerFolderItem"></param>
        private void GetUtilityNavigationItems(HeaderFolderItem headerFolderItem) {
            UtilityNavigationFolderItem utilityNavigationFolder = headerFolderItem.GetUtilityNavigationFolder();
            if (utilityNavigationFolder != null) {
                var results = utilityNavigationFolder.GetNavigationLinkItems();
                if (results != null && results.Any()) {
                    rptNavUtility.DataSource = results;
                    rptNavUtility.DataBind();
                }
            }
        }

        /// <summary>
        /// Get language items.
        /// </summary>
        /// <param name="headerFolderItem"></param>
        private void SetLanguageItemsRepeater() {
			var languageLinks = headerFolderItem.GetLanguageLinks();

			if (languageLinks != null && languageLinks.Any()) {
				rptLanguage.DataSource = languageLinks;
				rptLanguage.DataBind();
			}
        }

        protected void rptNavUtility_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;
                if (item != null) {
                    FieldRenderer frUtilityLink = e.FindControlAs<FieldRenderer>("frUtilityLink");
                    Literal ltRender = e.FindControlAs<Literal>("ltRender");
                    if (frUtilityLink != null) {
                        frUtilityLink.Item = item;
                    }
                }
            }
        }

        protected void rptMainNavigation_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;
                if (item != null) {
                    FieldRenderer frMainNavigationLink = e.FindControlAs<FieldRenderer>("frMainNavigationLink");
                    if (frMainNavigationLink != null) {
                        frMainNavigationLink.Item = item;
                    }

                    var results = GetNavigationLinkItems(item.InnerItem);
                    if (results != null && results.Any()) {
                        Repeater rptPrimaryNav = e.FindControlAs<Repeater>("rptPrimaryNavigation");
                        if (rptPrimaryNav != null) {
                            rptPrimaryNav.DataSource = results;
                            rptPrimaryNav.DataBind();
                        }
                    }
                }
            }
        }

        protected void rptPrimaryNavigation_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;

                if (item != null) {
                    FieldRenderer frPrimaryNavigationLink = e.FindControlAs<FieldRenderer>("frPrimaryNavigationLink");
                    if (frPrimaryNavigationLink != null) {
                        frPrimaryNavigationLink.Item = item;
                    }
                }
            }
        }


        /// <summary>
        /// Get child navigation link item
        /// </summary>
        /// <returns></returns>
        public IEnumerable<NavigationLinkItem> GetNavigationLinkItems(Item innerItem) {
            return innerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(NavigationLinkItem.TemplateId)).Select(i => (NavigationLinkItem)i);
        }

        protected void rptLanguage_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                LanguageLinkItem languageItem = e.Item.DataItem as LanguageLinkItem;
                if (languageItem != null) {
                    HyperLink hypLanguageLink = e.FindControlAs<HyperLink>("hypLanguageLink");
                    if (hypLanguageLink != null) {
                       
                        if (!languageItem.LanguageName.Raw.IsNullOrEmpty() && !languageItem.SitecoreLanguage.Raw.IsNullOrEmpty()) {
                            hypLanguageLink.Text = languageItem.LanguageName.Rendered;

							string currentUrlAndQS = Request.Url.PathAndQuery;

							foreach (var langItem in headerFolderItem.GetLanguageLinks())
							{
								if (currentUrlAndQS.StartsWith("/" + langItem.IsoCode))
								{
									currentUrlAndQS = new string(currentUrlAndQS.Skip(("/" + langItem.IsoCode).Length).ToArray());
								}
							}

							hypLanguageLink.NavigateUrl = string.Format("/{0}{1}", languageItem.IsoCode, currentUrlAndQS);
                        }
                    }
                }
            }
        }

        protected void rptParentToolkit_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                NavigationLinkItem item = e.Item.DataItem as NavigationLinkItem;
                if (item != null) {
                    FieldRenderer frNavLink = e.FindControlAs<FieldRenderer>("frNavLink");
                    Panel pnlParentToolKit = e.FindControlAs<Panel>("pnlParentToolKit");
                    if (frNavLink != null) {
                        frNavLink.Item = item;
                    }

                    if (pnlParentToolKit != null) {
                        pnlParentToolKit.Style.Add("background", item.NavigationImage.MediaUrl);
                    }
                }
            }
        }
    }
}