using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.NewsLetter;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_SignUp : System.Web.UI.UserControl
    {
        Newsletter_SignUpItem ObjSignupPage;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjSignupPage = new Newsletter_SignUpItem(Sitecore.Context.Item);
            if (ObjSignupPage != null)
            {
                if (ObjSignupPage.LinktoPrivacyPage.Url != null)
                    lbPrivacyPageLink.PostBackUrl = ObjSignupPage.LinktoPrivacyPage.Url;
                if (ObjSignupPage.NextpagetoShow.Url != null)
                    btnSignup.PostBackUrl = ObjSignupPage.NextpagetoShow.Url;
            }
        }
    }
}