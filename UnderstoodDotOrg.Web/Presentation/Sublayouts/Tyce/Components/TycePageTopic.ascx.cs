using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TycePageTopic : BaseSublayout
    {
        protected HomePageItem HomePageItem { get; set; }
        protected TyceBasePageItem PageItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            HomePageItem = MainsectionItem.GetHomeItem();
            PageItem = (TyceBasePageItem)Sitecore.Context.Item;
        }
    }
}