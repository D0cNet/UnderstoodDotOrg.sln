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
    }
}
