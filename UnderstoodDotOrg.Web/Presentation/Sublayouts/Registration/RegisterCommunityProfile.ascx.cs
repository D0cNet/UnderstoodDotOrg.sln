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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration {
    public partial class RegisterCommunityProfile : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
			//if (this.CurrentMember != null && this.CurrentUser != null)
			//{
			//	Response.Redirect(MyAccountFolderItem.GetMyAccountPage());
			//}
        }

		protected void registerForCommunity_Click(object sender, EventArgs e)
		{
			//this.FlushRegisteringUser();

			////everything's cool
			//if (this.registeringUser == null)
			//{
			//	this.registeringUser = new Domain.Membership.Member();
			//}
		}
    }
}