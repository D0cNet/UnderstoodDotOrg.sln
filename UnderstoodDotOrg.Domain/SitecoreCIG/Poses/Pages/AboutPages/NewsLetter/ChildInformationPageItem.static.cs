using System;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.Understood.Newsletter;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter
{
    public partial class ChildInformationPageItem 
    {
        public static IEnumerable<Item> GetAllIssues()
        {
            var children = Sitecore.Context.Database.GetItem(Constants.IssueContainer.ToString())
                .GetChildren().FilterByContextLanguageVersion();

            return from c in children
                   let i = new ChildIssueItem(c)
                   where !i.ExcludeFromWebsiteDisplay.Checked
                   select c;
        }

        public static bool HasValidSession(out Submission submission)
        {
            if (HttpContext.Current.Session[Constants.SessionNewsletterKey] != null) 
            {
                submission = (Submission)HttpContext.Current.Session[Constants.SessionNewsletterKey];
                if (!String.IsNullOrEmpty(submission.Email))
                {
                    return true;
                }
            }

            submission = null;
            return false;
        }
    }
}