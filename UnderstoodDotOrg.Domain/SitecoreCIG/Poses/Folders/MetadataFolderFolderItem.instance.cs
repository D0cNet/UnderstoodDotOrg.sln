using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class MetadataFolderFolderItem
    {
        /// <summary>
        /// Get Welcome Tour folder Item.
        /// </summary>
        /// <returns></returns>
        public WelcomeTourFolderItem GetWelcomeTourFolder()
        {
            return (WelcomeTourFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(WelcomeTourFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get expert live filter folder Item.
        /// </summary>
        /// <returns></returns>
        public ExpertliveFilterFolderItem GetExpertliveFilterFolder()
        {
            return (ExpertliveFilterFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(ExpertliveFilterFolderItem.TemplateId)).FirstOrDefault();
        }
    }
}