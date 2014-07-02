using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstoodDotOrg.Domain
{
    /// <summary>
    /// Helpers to get social sharing links
    /// </summary>
    public class SocialHelper
    {
        #region Public
        /// <summary>
        /// Gets the full Facebook share URL for the provided content page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public static string GetFacebookShareUrl(Item pageItem)
        {
            string pageUrl = GetContentPageSharingUrl(pageItem);
            return string.Format("https://facebook.com/sharer.php?u={0}", pageUrl);
        }

        /// <summary>
        /// Gets the full Google+ share URL for the provided content page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public static string GetGooglePlusShareUrl(Item pageItem)
        {
            string pageUrl = GetContentPageSharingUrl(pageItem);
            return string.Format("https://plus.google.com/share?url={0}", pageUrl);
        }

        /// <summary>
        /// Gets the full Twitter share URL for the provided content page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        public static string GetTwitterShareUrl(Item pageItem, string optionalTitle = null)
        {
            string pageUrl = GetContentPageSharingUrl(pageItem);
            string url = string.Format("https://twitter.com/intent/tweet?url={0}", pageUrl);

            if (!string.IsNullOrEmpty(optionalTitle))
            {
                url = string.Format("{0}&text={1}", url, optionalTitle);
            }

            return url;
        }

        public static string GetPinterestShareUrl(Item pageItem)
        {
            string pageUrl = GetContentPageSharingUrl(pageItem);
            return string.Format("http://pinterest.com/pin/create/button/?url={0}", pageUrl);
        }

        #endregion Public

        #region Private helpers

        /// <summary>
        /// Gets the social sharing service friendly URL for the provided content page
        /// </summary>
        /// <param name="pageItem"></param>
        /// <returns></returns>
        private static string GetContentPageSharingUrl(Item pageItem)
        {
            return LinkManager.GetItemUrl(pageItem, new UrlOptions { AlwaysIncludeServerUrl = true });
        }

        #endregion Private helpers
    }
}
