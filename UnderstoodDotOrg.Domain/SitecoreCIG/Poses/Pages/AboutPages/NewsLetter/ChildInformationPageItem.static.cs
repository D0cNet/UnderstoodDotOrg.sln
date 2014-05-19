using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter
{
    public partial class ChildInformationPageItem 
    {
        public static IEnumerable<Item> GetAllIssues()
        {
            var children = Sitecore.Context.Database.GetItem(Constants.IssueContainer.ToString())
                .GetChildren().FilterByContextLanguageVersion();

            // TODO: exclude all
            return from c in children
                   let i = new ChildIssueItem(c)
                   select c;
        }
    }
}