using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class HeaderFolderItem
    {
        public static HeaderFolderItem GetHeader()
        {
            var siteItem = MainsectionItem.GetSiteRoot();
            if (siteItem != null)
            {
                GlobalsItem objGlobalItem = MainsectionItem.GetGlobals();
                if (objGlobalItem != null)
                {
                    return objGlobalItem.GetHeader();
                }
            }
            return null;
        }
    }
}