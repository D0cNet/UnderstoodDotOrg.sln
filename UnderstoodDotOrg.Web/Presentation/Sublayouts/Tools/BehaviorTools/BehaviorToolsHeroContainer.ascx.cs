using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools
{
    public partial class BehaviorToolsHeroContainer : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindContent();
        }

        private void BindContent()
        {
            Item dataSource = null;

            // Use sublayout's datasource, otherwise look for datasource at parent
            if (this.DataSource != null && this.DataSource != Sitecore.Context.Item)
            {
                dataSource = this.DataSource;
            } 
            else
            {
                BehaviorToolsLandingPageItem currentItem = new BehaviorToolsLandingPageItem(Sitecore.Context.Item);
                if (currentItem.HeroImageDatasource.Item != null)
                {
                    dataSource = currentItem.HeroImageDatasource.Item;
                }
            }

            if (dataSource != null)
            {
                frHeading.Item = frSubheading.Item = frImage.Item = frCta.Item = dataSource;
            }
        }
    }
}