using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.DeepDiveArticle;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;
namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class DeepDiveArticlePageItem 
{
    public List<DeepDiveSectionInfoPageItem> GetSectionData()
    {
        return InnerItem.GetChildren()
            .Where(i => i.TemplateID.ToString() == DeepDiveSectionInfoPageItem.TemplateId.ToString() &&
                i.Parent.ID.ToString() == ID.ToString())
            .Select(i => (DeepDiveSectionInfoPageItem)i).ToList();
    }
}
}