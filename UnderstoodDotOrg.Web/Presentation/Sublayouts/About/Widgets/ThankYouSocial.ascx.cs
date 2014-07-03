using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Widgets
{
    public partial class ThankYouSocial : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            SiteSettingsItem settings = SiteSettingsItem.GetSiteSettings();
            if (settings != null)
            {
                litTellAFriend.Text = settings.TellAFriendLabel.Rendered;
                
                hlFacebook.NavigateUrl = settings.Facebook.Url;
                litFacebook.Text = settings.Facebook.Field.Text;

                hlTwitter.NavigateUrl = settings.Twitter.Url;
                litTwitter.Text = settings.Twitter.Field.Text;
            }
        }
    }
}