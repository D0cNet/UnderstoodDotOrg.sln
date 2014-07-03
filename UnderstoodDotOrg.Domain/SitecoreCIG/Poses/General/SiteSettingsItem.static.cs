using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General
{
    public partial class SiteSettingsItem
    {
        public static SiteSettingsItem GetSiteSettings()
        {
            var global = MainsectionItem.GetGlobals();
            if (global != null)
            {
                return global.InnerItem.Children.Where(i => i.InheritsTemplate(SiteSettingsItem.TemplateId))
                            .Select(i => new SiteSettingsItem(i))
                            .FirstOrDefault();
            }

            return null;
        }
    }
}