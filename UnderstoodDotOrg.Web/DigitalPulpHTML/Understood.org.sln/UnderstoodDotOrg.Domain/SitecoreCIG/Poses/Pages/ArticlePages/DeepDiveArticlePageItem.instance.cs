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
    public static List<DeepDiveSectionInfoPageItem> GetSectionData(DeepDiveArticlePageItem ObjDeepDiveArt)
    {
        IEnumerable<Item> AllSections = ObjDeepDiveArt.InnerItem.GetChildren().Where(t => t.TemplateID.ToString() == DeepDiveSectionInfoPageItem.TemplateId.ToString() && t.Parent.ID.ToString()==ObjDeepDiveArt.ID.ToString() );
        List<DeepDiveSectionInfoPageItem> FinalSections = new List<DeepDiveSectionInfoPageItem>();
        if (AllSections != null)
        {
            foreach (DeepDiveSectionInfoPageItem SectionItem in AllSections)
            {
                FinalSections.Add(SectionItem);
            }
        }
        return FinalSections;
    }
}
}