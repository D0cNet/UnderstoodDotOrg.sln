using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter;
using UnderstoodDotOrg.Domain.Understood.Newsletter;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_ParentInterest : BaseSublayout<ParentInterestsPageItem>
    {
        private Submission _submission;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ParentInterestsPageItem.HasValidSession(out _submission))
            {
                Item previous = Sitecore.Context.Database.GetItem(Constants.Pages.NewsletterChildInfo);
                if (previous != null)
                {
                    Response.Redirect(previous.GetUrl());
                }
                // TODO: redirect elsewhere?
                return;
            }
        }


    }
}