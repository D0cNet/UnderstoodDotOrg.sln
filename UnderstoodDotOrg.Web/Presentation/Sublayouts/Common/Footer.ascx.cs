using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected string NewsletterSignUpUrl
        {
            get
            {
                Item item = Sitecore.Context.Database.GetItem(Constants.Pages.NewsletterSignup);
                if (item != null)
                {
                    return item.GetUrl();
                }

                return String.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FooterFolderItem footerFolderItem = GetFooter();
            if (footerFolderItem != null)
            {
                GetFooterDetails(footerFolderItem);
                GetMainNavigationItems(footerFolderItem);
                GetUtilityNavigationItems(footerFolderItem);
                GetPartnerLinksItems(footerFolderItem);
                GetSocialMediaItems(footerFolderItem);
            }
        }

        /// <summary>
        /// Gets footer detail
        /// </summary>
        /// <param name="footerFolderItem"></param>
        private void GetFooterDetails(FooterFolderItem footerFolderItem)
        {
            frPartnership.Item = frHeading.Item = frEmailAbstract.Item = frCopyrightText.Item = frAbstract.Item = scLogoImage.Item = footerFolderItem;
        }

        /// <summary>
        /// Gets social media item.
        /// </summary>
        /// <param name="footerFolderItem"></param>
        private void GetSocialMediaItems(FooterFolderItem footerFolderItem)
        {
            SocialMediaFolderItem socialMediaFolder = footerFolderItem.GetSocialMediaFolder();
            if (socialMediaFolder != null)
            {
                var results = socialMediaFolder.GetSocialMediaItem();
                if (results != null && results.Any())
                {
                    rptSocialMedias.DataSource = results;
                    rptSocialMedias.DataBind();
                }
            }
        }

        /// <summary>
        /// Gets partners link item
        /// </summary>
        /// <param name="footerFolderItem"></param>
        private void GetPartnerLinksItems(FooterFolderItem footerFolderItem)
        {
            PartnerFolderItem partnerFolder = footerFolderItem.GetPartnerFolder();
            if (partnerFolder != null)
            {
                var results = partnerFolder.GetNavLinkItems();
                if (results != null && results.Any())
                {
                    rptPartnerships.DataSource = results;
                    rptPartnerships.DataBind();
                }
            }
        }

        /// <summary>
        /// Gets footer item from global
        /// </summary>
        /// <returns></returns>
        public static FooterFolderItem GetFooter()
        {
            MainsectionItem objSiteItem = MainsectionItem.GetSiteRoot();
            FooterFolderItem objFooterLinkFolderItem = null;
            if (objSiteItem != null)
            {
                GlobalsItem objGlobalItem = MainsectionItem.GetGlobals();
                if (objGlobalItem != null)
                {
                    objFooterLinkFolderItem = objGlobalItem.GetFooter();
                }
            }
            return objFooterLinkFolderItem;
        }

        /// <summary>
        /// Get main navigation items.
        /// </summary>
        /// <param name="footerFolderItem"></param>
        private void GetMainNavigationItems(FooterFolderItem footerFolderItem)
        {
            MainNavigationFolderItem mainNavigationFolder = footerFolderItem.GetMainNavigationFolder();
            if (mainNavigationFolder != null)
            {
                var results = mainNavigationFolder.GetNavigationLinkItems();
                if (results != null && results.Any())
                {
                    rptFooterNav.DataSource = results;
                    rptFooterNav.DataBind();
                }
            }
        }

        /// <summary>
        /// Get utility navigation items.
        /// </summary>
        /// <param name="headerFolderItem"></param>
        private void GetUtilityNavigationItems(FooterFolderItem footerFolderItem)
        {

            UtilityNavigationFolderItem utilityNavigationFolder = footerFolderItem.GetUtilityNavigationFolder();
            if (utilityNavigationFolder != null)
            {
                var results = utilityNavigationFolder.GetNavigationLinkItems();
                if (results != null && results.Any())
                {
                    rptFooterUtilityNav.DataSource = results;
                    rptFooterUtilityNav.DataBind();
                }
            }

        }

        protected void rptPartnerships_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem navItem = e.Item.DataItem as NavigationLinkItem;

                if (navItem != null)
                {
                    HyperLink hlLink = e.FindControlAs<HyperLink>("hlLink");
                    Sitecore.Web.UI.WebControls.Image scImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scImage");
                    if (hlLink != null)
                    {
                        hlLink.NavigateUrl = navItem.Link.Url;
                    }

                    if (scImage != null)
                    {
                        scImage.Item = navItem;
                    }
                }
            }
        }

        protected void rptFooterNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem navItem = e.Item.DataItem as NavigationLinkItem;

                if (navItem != null)
                {
                    FieldRenderer frLink = e.FindControlAs<FieldRenderer>("frLink");
                    if (frLink != null)
                    {
                        frLink.Item = navItem;
                    }
                }
            }
        }

        protected void rptSocialMedias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                SocialMediaItem socialMediaItem = e.Item.DataItem as SocialMediaItem;
                if (socialMediaItem != null)
                {

                }
            }
        }

        protected void rptFooterUtilityNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem navItem = e.Item.DataItem as NavigationLinkItem;
                if (navItem != null)
                {
                    FieldRenderer frLink = e.FindControlAs<FieldRenderer>("frLink");
                    if (frLink != null)
                    {
                        frLink.Item = navItem;
                    }
                }
            }
        }
    }
}