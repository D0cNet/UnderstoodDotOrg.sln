using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle
{
    public partial class SimpleExpertArticleItem
    {
        public IEnumerable<SimpleExpertQuestionAnswerItem> GetSimpleExpertQAList()
        {
            return InnerItem.GetChildren()
                .Where(t => t.TemplateID.ToString() == SimpleExpertQuestionAnswerItem.TemplateId.ToString())
                .Select(x => new SimpleExpertQuestionAnswerItem(x));
        }
    }
}