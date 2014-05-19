using Sitecore.Data.Items;
using Sitecore.Globalization;
using Sitecore.Web;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Header : BaseSublayout
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            GetGoogleAnalyticsDetails();
        }

        protected void GetGoogleAnalyticsDetails()
        {
            var ObjGloalItem = new GlobalsItem(Sitecore.Context.Item);
            if (ObjGloalItem != null)
            {
                frGlobalGoogleAnalytics.Item = ObjGloalItem;
            }
            var ObjBasePageNew = new BasePageNEWItem(Sitecore.Context.Item);
            if (ObjBasePageNew != null)
            {
                frPageGoogleAnalytics.Item = ObjBasePageNew;
            }
        }
    }
}