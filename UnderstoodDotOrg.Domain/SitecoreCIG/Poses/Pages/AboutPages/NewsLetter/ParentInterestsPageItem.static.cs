using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Understood.Newsletter;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter
{
    public partial class ParentInterestsPageItem 
    {
        public static bool HasValidSession(out Submission submission)
        {
            // Run previous step validation
            if (ChildInformationPageItem.HasValidSession(out submission)) 
            {
                // Ensure child exists
                if (submission.Children.Any())
                {
                    return true;
                }
            }

            submission = null;
            return false;
        }
    }
}