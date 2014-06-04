using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class QuizTryMoreQuizzes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item context = Sitecore.Context.Item;

            rptTryMoreQuizzes.DataSource = context.Parent.Children.Where(i => i.IsOfType(AssessmentQuizArticleItem.TemplateId) || i.IsOfType(KnowledgeQuizQuestionArticlePageItem.TemplateId)).Take(2).ToList();
            rptTryMoreQuizzes.DataBind();
        }

        protected void rptTryMoreQuizzes_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item context = (Item)e.Item.DataItem;

                FieldRenderer frQuizImage = e.FindControlAs<FieldRenderer>("frQuizImage");
                FieldRenderer frQuizName = e.FindControlAs<FieldRenderer>("frQuizName");
                HyperLink hypMoreLink = e.FindControlAs<HyperLink>("hypMoreLink");

                if (context != null) 
                {
                    frQuizImage.Item = context;
                    frQuizName.Item = context;

                    hypMoreLink.NavigateUrl = context.GetUrl();
                }
            }
        }
    }
}