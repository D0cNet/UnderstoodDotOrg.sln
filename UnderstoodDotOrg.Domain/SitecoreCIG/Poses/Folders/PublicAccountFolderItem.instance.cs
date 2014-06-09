using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount.PublicAccount;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class PublicAccountFolderItem
    {
        public PublicAccountItem GetPublicAccountPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(PublicAccountItem.TemplateId));
        }
    }
}