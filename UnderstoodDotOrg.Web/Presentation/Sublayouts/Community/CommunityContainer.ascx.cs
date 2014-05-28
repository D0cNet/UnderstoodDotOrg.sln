using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community
{
    public partial class CommunityContainer : BaseSublayout
    {
        private Item model = Sitecore.Context.Item;

        protected string ArchiveCssClass { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (model.InheritsTemplate(BaseEventDetailPageItem.TemplateId))
            {
                ArchiveCssClass = ((BaseEventDetailPageItem)model).IsUpcoming() ? "upcoming" : "past";
            }
        }
    }


}