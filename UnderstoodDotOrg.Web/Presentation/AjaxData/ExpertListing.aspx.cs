using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class ExpertListing : System.Web.UI.Page
    {
        private string ResultPage
        {
            get { return Request.QueryString["page"] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int page;

            if (int.TryParse(ResultPage, out page))
            {
                bool hasMoreResults;
                var results = ExpertLandingPageItem.GetExperts(page, out hasMoreResults);

                if (results.Any())
                {
                    expertListing.Experts = results;
                }

                phMoreResults.Visible = hasMoreResults;
            }
        }
    }
}