using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter
{
    public partial class ChildInformationPageItem 
    {
        //get Child Issue List
        public static IEnumerable<Item> GetAllGrades()
        {
            return Sitecore.Context.Database.GetItem(Constants.GradeContainer.ToString()).GetChildren().ToList();
        }

        //get Grade list
        public static IEnumerable<Item> GetAllIssues()
        {
            return Sitecore.Context.Database.GetItem(Constants.IssueContainer.ToString()).GetChildren().Where(x => x.DisplayName != "All").ToList();
        }
    }
}