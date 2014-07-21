using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Data;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems
{
    public partial class DefaultArticlePageItem 
    {
        public static string GetArticleType(ID templateId)
        {
            var container = Sitecore.Context.Database.GetItem(Constants.ArticleTypesContainer);
            if (container != null)
            {
                var match = container.Children.FilterByContextLanguageVersion()
                            .Select(i => new ArticleTypeItem(i))
                            .Where(i => i.ArticleTypeTemplate.Item != null
                                   && i.ArticleTypeTemplate.Item.ID == templateId)
                            .FirstOrDefault();

                if (match != null)
                {
                    return match.ArticleTypeName.Rendered;
                }
            }

            return string.Empty;
        }
    }
}