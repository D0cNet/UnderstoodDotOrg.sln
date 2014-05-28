using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class DidYouFindThisHelpfulOther : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltlDidYouFindThisHelpful.Text = DictionaryConstants.DidYouFindThisHelpful;
            ltlNo.Text = DictionaryConstants.NoButtonText;
            ltlYes.Text = DictionaryConstants.YesButtonText;
        }
    }
}