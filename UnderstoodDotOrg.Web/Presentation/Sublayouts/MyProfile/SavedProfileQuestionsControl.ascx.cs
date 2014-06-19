using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class SavedProfileQuestionsControl : System.Web.UI.UserControl
    {
        public string GoNow { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var Model = new MyProfileStepFiveItem(Sitecore.Context.Item);

            lvParentTools.DataSource = Model.ToolkitItems.ListItems.Take(3).Select(x => new NavigationLinkItem(x));
            lvParentTools.DataBind();

            this.GoNow = Model.GoNowText;
        }
    }
}