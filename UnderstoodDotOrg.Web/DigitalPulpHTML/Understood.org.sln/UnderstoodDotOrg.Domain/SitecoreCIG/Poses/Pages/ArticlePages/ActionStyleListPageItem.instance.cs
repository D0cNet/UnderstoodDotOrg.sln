using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.ActionStyleListArticle;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages
{
public partial class ActionStyleListPageItem 
{
    public static IEnumerable<ActionPageItem> GetAllAction(ActionStyleListPageItem ObjActionArticle)
    {
        IEnumerable<ActionPageItem> AllActionItems = ObjActionArticle.AllActions;//.OrderByDescending(x => x.ActionNumber);
        return AllActionItems;
    }
    private IEnumerable<ActionPageItem> _allActions;
    private IEnumerable<ActionPageItem> AllActions
    {
        get
        {
            if (_allActions == null)
            {
                _allActions = this.InnerItem.GetChildren()
                    .Where(t => t.TemplateID.ToString() == ActionPageItem.TemplateId.ToString())
                    .Select(x => new ActionPageItem(x));
            }

            return _allActions;
        }
    }
}
}