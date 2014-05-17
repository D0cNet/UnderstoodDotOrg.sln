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
    public partial class DidYouFindThisHelpful : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltlDidYouFindThisHelpful.Text = ltlDidYouFindThisHelpfulSmall.Text = DictionaryConstants.DidYouFindThisHelpful;
            ltlNo.Text = ltlNoSmall.Text = DictionaryConstants.NoButtonText;
            ltlYes.Text = ltlYesSmall.Text = DictionaryConstants.YesButtonText;
        }
    }
}