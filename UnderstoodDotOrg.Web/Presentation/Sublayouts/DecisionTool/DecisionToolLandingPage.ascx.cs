using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders.DecisionTool;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool
{
    public partial class DecisionToolLandingPage : BaseSublayout<DecisionToolLandingPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var categories = Model.GetDecisionQuestionCategories();

            rptrCategories.DataSource = categories;
            rptrCategories.ItemDataBound += rptrCategories_ItemDataBound;
            rptrCategories.DataBind();
        }

        protected void rptrCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var categoryFolderItem = e.Item.DataItem as DecisionQuestionCategoryFolderItem;
                var questions = categoryFolderItem.GetDecisionQuestions();

                var rptrQuestions = e.FindControlAs<Repeater>("rptrQuestions");
                rptrQuestions.DataSource = questions;
                rptrQuestions.DataBind();
            }
        }
    }
}