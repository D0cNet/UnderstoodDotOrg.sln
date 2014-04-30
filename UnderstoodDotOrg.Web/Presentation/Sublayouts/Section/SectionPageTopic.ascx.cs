using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG;
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Section {
    public partial class SectionPageTitle : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            SectionLandingPageItem contextItem = Sitecore.Context.Item;
            Item homePage = MainsectionItem.GetHomeItem();
            if (homePage != null) {
                hlBackLink.NavigateUrl = homePage.GetUrl();
            }
            if(contextItem != null){
                scTopicTitle.Text = contextItem.DisplayName;
            }
        }

        
    }
}