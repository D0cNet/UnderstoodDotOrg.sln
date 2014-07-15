using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount
{
    public partial class SignUpPageItem
    {
        public static SignUpPageItem GetSignUpPage()
        {
            return Sitecore.Context.Database.GetItem(Constants.Pages.SignUp);
        }
    }
}