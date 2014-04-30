using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages
{
public partial class AboutExpertsItem 
{
    /// <summary>
    /// Get All partners List
    /// </summary>
    /// <param name="ObjSlideArticle"></param>
    /// <returns></returns>
    public static IEnumerable<ExpertPersonItem> GetAllExperts(AboutExpertsItem ObjExperts)
    {
        IEnumerable<ExpertPersonItem> AllExperts = ObjExperts.AllExperts;
        return AllExperts;
    }
    private IEnumerable<ExpertPersonItem> _allexperts;
    private IEnumerable<ExpertPersonItem> AllExperts
    {
        get
        {
            if (_allexperts == null)
            {
                _allexperts = this.InnerItem.GetChildren()
                    .Where(t => t.TemplateID.ToString() == ExpertPersonItem.TemplateId.ToString())
                    .Select(x => new ExpertPersonItem(x));
            }

            return _allexperts;
        }
    }
}
}