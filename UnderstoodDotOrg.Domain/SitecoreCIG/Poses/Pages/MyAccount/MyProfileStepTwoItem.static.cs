using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
    public partial class MyProfileStepTwoItem
    {
        public static MyProfileStepTwoItem GetCompleteMyProfileStepTwo()
        {
            return Sitecore.Context.Database.GetItem(Constants.Pages.Registration2);
        }

        public static string GetChildEditLink(int childIndex)
        {
            string ret = MyProfileStepTwoItem.GetCompleteMyProfileStepTwo().GetUrl()
                + '?' + UnderstoodDotOrg.Common.Constants.QueryStrings.Registration.Mode + '=' + UnderstoodDotOrg.Common.Constants.QueryStrings.Registration.ModeEdit
                + "&" + UnderstoodDotOrg.Common.Constants.QueryStrings.Registration.ChildIndex + "=" + childIndex;

            return ret;
        }
    }
}