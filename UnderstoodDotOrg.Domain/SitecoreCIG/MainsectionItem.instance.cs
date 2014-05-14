using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;

namespace UnderstoodDotOrg.Domain.SitecoreCIG
{
    public partial class MainsectionItem
    {

        /// <summary>
        /// Get website root item
        /// </summary>
        /// <returns></returns>
        public static MainsectionItem GetSiteRoot()
        {
            MainsectionItem objSiteItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath);
            if (objSiteItem != null && objSiteItem.InnerItem.HasContextLanguageVersion())
            {
                return objSiteItem;
            }
            else
            {
                Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath, Sitecore.Data.Managers.LanguageManager.GetLanguage("en"));
                return objSiteItem;
            }
        }

        /// <summary>
        /// Get first instance(item) of GlobalsItem template under the site root
        /// </summary>
        /// <returns></returns>
        public static GlobalsItem GetGlobals()
        {
            GlobalsItem firstGlobals = null;
            var siteChildren = GetSiteRoot().InnerItem.GetChildren();
            if (siteChildren != null)
            {
                firstGlobals = siteChildren.Where(i => i.IsOfType(GlobalsItem.TemplateId)).FirstOrDefault();
            }
            return (GlobalsItem)firstGlobals;
        }


        /// <summary>
        /// Get First Globals item
        /// </summary>
        /// <returns></returns>
        public static GlobalsItem GetGlobalItem()
        {
            MainsectionItem objSiteItem = GetSiteRoot();
            GlobalsItem objGlobalItem = null;
            if (objSiteItem != null)
            {
                objGlobalItem = GetGlobals();
            }
            return objGlobalItem;
        }

        /// <summary>
        /// Get home page item
        /// </summary>
        /// <returns></returns>
        public static HomePageItem GetHomePageItem()
        {
            MainsectionItem objSiteItem = GetSiteRoot();
            HomePageItem objHomepageItem = null;
            if (objSiteItem != null)
            {
                objHomepageItem = GetHomeItem();
            }
            return objHomepageItem;
        }

        /// <summary>
        /// Get first instance(item) of Homepage Item under the site root
        /// </summary>
        /// <returns></returns>
        public static HomePageItem GetHomeItem()
        {
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            if (homeItem != null)
            {
                return (HomePageItem)homeItem;
            }
            else
            {
                homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath, Sitecore.Data.Managers.LanguageManager.GetLanguage("en"));
                return homeItem;
            }
        }
    }
}
