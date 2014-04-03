using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile {
    public partial class ProfileStepTwo : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {

            NextButton.Text = DictionaryConstants.NextButtonText;

        }
    }
}