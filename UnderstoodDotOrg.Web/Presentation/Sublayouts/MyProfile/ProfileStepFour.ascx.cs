using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Globalization;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile {
    public partial class ProfileStepFour : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {

            ScreenNameTextField.Text = DictionaryConstants.ScreenNameWatermark;
            ZipCodeTextField.Text = DictionaryConstants.ZipCodeWatermark;
            SubmitButton.Text = DictionaryConstants.SubmitButtonText;

        }
    }
}