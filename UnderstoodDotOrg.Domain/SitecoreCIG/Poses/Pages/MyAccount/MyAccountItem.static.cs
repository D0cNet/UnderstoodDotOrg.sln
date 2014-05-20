using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
    public partial class MyAccountItem
    {
        public static MyAccountItem GetMyAccountPage()
        {
            return Sitecore.Context.Database.GetItem(Constants.Pages.MyAccount);
        }
    }
}