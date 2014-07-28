using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals
{
    public partial class Assessment_Quiz_Modal : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AssessmentQuizModalItem modal = (AssessmentQuizModalItem)DataSource;

            frButtton.Item = modal;
            frContent.Item = modal;
            frTitle.Item = modal;
        }
    }
}