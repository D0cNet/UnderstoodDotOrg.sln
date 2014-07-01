using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components
{
    public partial class TYCEGradeGroupItem
    {
        public static FolderItem GetTyceGradeGroupsFolder()
        {
            return Sitecore.Context.Database.GetItem("{2D928CD4-E518-4BF3-A3D6-49FEDB1D89F6}");
        }

        public static IEnumerable<TYCEGradeGroupItem> GetTyceGradeGroups()
        {
            var tyceGradeGroupsFolder = GetTyceGradeGroupsFolder();
            return tyceGradeGroupsFolder != null ?
                tyceGradeGroupsFolder.InnerItem.Children
                    .Where(i => i.IsOfType(TYCEGradeGroupItem.TemplateId))
                    .Select(i => (TYCEGradeGroupItem)i) :
                new List<TYCEGradeGroupItem>();
        }
    }
}