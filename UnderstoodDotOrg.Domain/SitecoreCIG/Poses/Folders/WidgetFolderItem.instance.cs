using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class WidgetFolderItem
    {
        /// <summary>
        /// Get Contact Us widget.
        /// </summary>
        /// <returns></returns>
        public GenericWidgetItem GetContactUsWidgetItem()
        {
            return InnerItem.GetChildren().Where(i => i.IsOfType(GenericWidgetItem.TemplateId)).Select(i => (GenericWidgetItem)i).FirstOrDefault();
        }

        /// <summary>
        /// Get Donate widget.
        /// </summary>
        /// <returns></returns>
        public DonateWidgetItem GetDonateWidgetItem()
        {
            return InnerItem.GetChildren().Where(i => i.IsOfType(DonateWidgetItem.TemplateId)).Select(i => (DonateWidgetItem)i).FirstOrDefault();
        }
    }
}