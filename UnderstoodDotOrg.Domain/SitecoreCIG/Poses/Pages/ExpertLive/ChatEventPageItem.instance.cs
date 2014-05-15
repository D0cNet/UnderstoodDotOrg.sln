using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive {
    public partial class ChatEventPageItem {
        /// <summary>
        /// Get Page Resource Folder Item.
        /// </summary>
        /// <returns></returns>
        public PageResourceFolderItem GetPageResourceFolderItem() {
            return InnerItem.GetChildren().FilterByContextLanguageVersion().Where(i => i.IsOfType(PageResourceFolderItem.TemplateId)).Select(i => (PageResourceFolderItem)i).FirstOrDefault();
        }

    }
}