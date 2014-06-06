using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
    public partial class LanguageLinkItem
    {
        /// <summary>
        /// The fully-qualified Iso code for the target Sitecore language item
        /// </summary>
        public string IsoCode
        {
            get
            {
                if (SitecoreLanguage.Item == null)
                {
                    return string.Empty;
                }

                // get the Regional Iso Code if it's defined for this language
                string iso = SitecoreLanguage.Item["Regional Iso Code"];

                // fallback to the Iso if there's no Regional Iso Code
                if (iso.IsNullOrEmpty())
                {
                    iso = SitecoreLanguage.Item["Iso"];
                }

                return iso;
            }
        }

        public string GetCurrentIsoAwareUrl()
        {
            string currentPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery.ToLower();
            string currentPath = HttpContext.Current.Request.Url.AbsolutePath.ToLower();
            string currentLang = Sitecore.Context.Language.Name.ToLower();

            // Strip existing iso code
            if (currentPath.EndsWith("/" + currentLang)
                || currentPath.StartsWith("/" + currentLang + "/"))
            {
                currentPathAndQuery = currentPathAndQuery.TrimStart('/').Substring(currentLang.Length);
            }

            return string.Format("/{0}{1}", IsoCode.ToLower(), currentPathAndQuery);
        }

    }
}
