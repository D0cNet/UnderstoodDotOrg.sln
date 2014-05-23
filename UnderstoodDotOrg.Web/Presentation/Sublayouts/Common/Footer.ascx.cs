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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Footer : BaseSublayout<FooterFolderItem>
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
                GetPartnerLinksItems();
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
        private void GetPartnerLinksItems()
        {
            Item item = Sitecore.Context.Database.GetItem(Constants.Pages.Partners);
            hlViewAllPartners.Visible = item != null;
            if (item != null)
            {
                hlViewAllPartners.NavigateUrl = item.GetUrl();
            }
            
            List<PartnerInfoItem> partners = Model.GetPartnerLinks();
            if (partners.Any())
            {
                rptPartnerships.DataSource = partners;
                rptPartnerships.DataBind();
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
                PartnerInfoItem navItem = (PartnerInfoItem)e.Item.DataItem;

                HyperLink hlLink = e.FindControlAs<HyperLink>("hlLink");
                Sitecore.Web.UI.WebControls.Image scImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("scImage");
                hlLink.NavigateUrl = navItem.GetUrl();

                scImage.Item = navItem;
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

                HyperLink hypSocialLink = e.FindControlAs<HyperLink>("hypSocialLink");
                FieldRenderer frSocialImage = e.FindControlAs<FieldRenderer>("frSocialImage");

                if (socialMediaItem != null)
                {
                    hypSocialLink.NavigateUrl = socialMediaItem.Link.Url;
                    hypSocialLink.Attributes.Add("class", "icon icon-" + socialMediaItem.MediaName.Text.ToLower());
                }
            }
        }

        protected void rptFooterUtilityNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item navItem = (Item)e.Item.DataItem;
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