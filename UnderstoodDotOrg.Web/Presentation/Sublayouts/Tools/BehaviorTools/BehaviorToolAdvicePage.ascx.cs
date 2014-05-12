using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolAdvicePage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            BehaviorToolsAdvicePageItem item = new BehaviorToolsAdvicePageItem(Sitecore.Context.Item);
            
            frTitle.Item = frWhatYouCanDo.Item = frWhatYouCanSay.Item = frWhyThisWillHelp.Item = item;
        }
    }
}