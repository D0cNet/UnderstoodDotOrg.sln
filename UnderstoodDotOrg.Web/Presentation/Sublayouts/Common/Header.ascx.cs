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
using UnderstoodDotOrg.Domain.SitecoreCIG;
using System.Text;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Header : BaseSublayout
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            InitGoogleAnalytics();
        }

        protected void InitGoogleAnalytics()
        {
            StringBuilder sb = new StringBuilder();

            GlobalsItem global = MainsectionItem.GetGlobals();
            if (global != null)
            {
                sb.AppendLine(global.GoogleAnalytics.Raw);
            }

            BasePageNEWItem basePage = Sitecore.Context.Item;
            if (basePage.GoogleAnalytics.Field != null)
            {
                sb.AppendLine(basePage.GoogleAnalytics.Raw);
            }

            string output = sb.ToString().Trim();
            if (!string.IsNullOrEmpty(output))
            {
                litAnalytics.Text = String.Format(@"<script type=""text/javascript"">{0}</script>", output);
            }
        }
    }
}