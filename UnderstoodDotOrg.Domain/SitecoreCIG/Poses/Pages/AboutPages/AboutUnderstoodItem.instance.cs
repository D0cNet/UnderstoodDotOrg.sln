using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
    public partial class AboutUnderstoodItem
    {
        public IEnumerable<AboutSectionPageItem> GetSectionPages()
        {
            return InnerItem.Children.FilterByContextLanguageVersion()
                        .Where(i => i.InheritsFromType(AboutSectionPageItem.TemplateId))
                        .Select(i => new AboutSectionPageItem(i));
        }
    }
}