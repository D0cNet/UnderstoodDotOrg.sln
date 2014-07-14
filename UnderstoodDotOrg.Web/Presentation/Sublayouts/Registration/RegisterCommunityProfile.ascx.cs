using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration
{
    public partial class RegisterCommunityProfile : BaseSublayout<RegisterCommunityProfileItem>//System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnRegister.Text = DictionaryConstants.JoinGroupButtonText;
            txtScreenName.Attributes["placeholder"] = DictionaryConstants.ScreenNameWatermark;
            hypCompleteMyProfile.Text = Model.CompleteMyFullProfileText.Rendered;
            hypCompleteMyProfile.NavigateUrl = MyAccountFolderItem.GetCompleteMyProfileStepOne();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

        }
    }
}