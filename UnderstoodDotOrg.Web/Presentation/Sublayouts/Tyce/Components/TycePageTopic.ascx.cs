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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TycePageTopic : BaseSublayout
    {
        protected BasePageNEWItem PreviousPageItem { get; set; }
        protected TyceBasePageItem PageItem { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: Look into and/or implement mobile version of header
            PreviousPageItem = Sitecore.Context.Item.IsOfType(TyceOverviewPageItem.TemplateId) ?
                MainsectionItem.GetHomeItem().InnerItem :
                Sitecore.Context.Item.Parent;
            PageItem = (TyceBasePageItem)Sitecore.Context.Item;
        }
    }
}