using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Page_Topic : BaseSublayout
    {
        public string AdditionalCssClass
        {
            get
            {
                return this.GetParameter("AdditionalCSSClass");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}