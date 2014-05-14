using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.NewsLetter
{
public partial class Newsletter_ChildInfoItem 
{
    //get Child Issue List
    public static IEnumerable<Item> GetAllGrades()
    {
        return Sitecore.Context.Database.GetItem(Constants.GradeContainer.ToString()).GetChildren().ToList();
    }

       //get Grade list
    public static IEnumerable<Item> GetAllIssues()
    {
        return Sitecore.Context.Database.GetItem(Constants.IssueContainer.ToString()).GetChildren().Where(x => x.DisplayName!= "All").ToList();
    }
}
}