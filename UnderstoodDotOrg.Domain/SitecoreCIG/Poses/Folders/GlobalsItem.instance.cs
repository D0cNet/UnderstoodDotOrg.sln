using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class GlobalsItem
    {
        /// <summary>
        /// Get Header from global
        /// </summary>
        /// <returns></returns>
        public HeaderFolderItem GetHeader() {
            return (HeaderFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(HeaderFolderItem.TemplateId)).FirstOrDefault();
        }
        /// <summary>
        /// Get Footer from global
        /// </summary>
        /// <returns></returns>
        public FooterFolderItem GetFooter() {
            return (FooterFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(FooterFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get meta data folder Item.
        /// </summary>
        /// <returns></returns>
        public MetadataFolderFolderItem GetMetaDataFolder() {
            return (MetadataFolderFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(MetadataFolderFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get expert live filter folder Item.
        /// </summary>
        /// <returns></returns>
        public ExpertliveFilterFolderItem GetExpertliveFilterFolder() {
            return (ExpertliveFilterFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(ExpertliveFilterFolderItem.TemplateId)).FirstOrDefault();
        }

        /// <summary>
        /// Get More Explore folder Item.
        /// </summary>
        /// <returns></returns>
        public MoreExploreFolderItem GetMoreExploreFolder() {
            return (MoreExploreFolderItem)InnerItem.GetChildren().Where(i => i.IsOfType(MoreExploreFolderItem.TemplateId)).FirstOrDefault();
        }
    }
}
