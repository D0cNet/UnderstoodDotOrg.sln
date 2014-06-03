using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive.Base;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Cards
{
    public partial class ExpertEvent : BaseSublayout
    {
        protected string EventUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            if (DataSource != null && DataSource.InheritsTemplate(BaseEventDetailPageItem.TemplateId))
            {
                BaseEventDetailPageItem item = (BaseEventDetailPageItem)DataSource;

                frPageTitle.Item = item;

                EventUrl = item.GetUrl();
                litEventDate.Text = item.GetFormattedEventStartDate();

                ExpertDetailPageItem expert = item.Expert.Item;
                if (expert != null)
                {
                    imgThumbnail.ImageUrl = expert.GetThumbnailUrl(150, 150);
                    litExpertType.Text = expert.GetExpertType();
                } 
            }
        }
    }
}