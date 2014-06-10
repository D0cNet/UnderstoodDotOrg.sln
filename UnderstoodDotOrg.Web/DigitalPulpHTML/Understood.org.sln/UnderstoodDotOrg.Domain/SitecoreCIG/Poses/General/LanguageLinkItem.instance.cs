using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General {
    public partial class LanguageLinkItem {
        /// <summary>
        /// The fully-qualified Iso code for the target Sitecore language item
        /// </summary>
        public string IsoCode {
            get {
                if (SitecoreLanguage.Item == null)
                    return string.Empty;

                // get the Regional Iso Code if it's defined for this language
                string iso = SitecoreLanguage.Item["Regional Iso Code"];

                // fallback to the Iso if there's no Regional Iso Code
                if (iso.IsNullOrEmpty()) {
                    iso = SitecoreLanguage.Item["Iso"];
                }

                return iso;
            }
        }
    }
}
