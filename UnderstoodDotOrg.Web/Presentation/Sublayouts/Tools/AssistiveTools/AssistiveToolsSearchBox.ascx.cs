using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.AssisitiveToolsPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.AssistiveTools
{
    public partial class AssistiveToolsSearchBox : BaseSublayout<AssistiveToolsBasePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var keyword = Request.QueryString[Constants.QueryStrings.LearningTool.Keyword];
            if (!string.IsNullOrEmpty(keyword))
            {
                //TODO: set "search by" to active and populate textbox
            }
            else
            {
                var issueId = Request.QueryString[Constants.QueryStrings.LearningTool.IssueId];
                var gradeLevel = Request.QueryString[Constants.QueryStrings.LearningTool.GradeLevel];
                var typeId = Request.QueryString[Constants.QueryStrings.LearningTool.TypeId];

                if (!string.IsNullOrEmpty(issueId) && !string.IsNullOrEmpty(gradeLevel) && !string.IsNullOrEmpty(typeId))
                {
                    //TODO: set dropdown values
                }
            }
        }

        protected void btnFindSubmit_Click(object sender, EventArgs e)
        {
            //TODO: wire up for response.redirect call
        }
    }
}