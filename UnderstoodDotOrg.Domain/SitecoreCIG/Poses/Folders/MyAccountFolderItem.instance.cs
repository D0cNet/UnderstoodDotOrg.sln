using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders
{
    public partial class MyAccountFolderItem
    {
        public TermsandConditionsItem GetTermsandConditionsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(TermsandConditionsItem.TemplateId));
        }

        public MyNotificationsPageItem GetMyNotificationsPage()
        {
            return InnerItem.Children.FirstOrDefault(i => i.IsOfType(MyNotificationsPageItem.TemplateId));
        }
    }
}