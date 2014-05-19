using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ExpertLive;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic 
{
    public partial class TopicPageHeader : BaseSublayout<TopicLandingPageItem> 
    {
        protected void Page_Load(object sender, EventArgs e) 
        {
            BindContent();
            BindControls();
        }

        private void BindContent()
        {
            litTitle.Text = Model.ContentPage.PageTitle.Rendered;

            if (Model.InnerItem.Parent != null)
            {
                SectionLandingPageItem parent = Model.InnerItem.Parent;
                hlBreadcrumbNav.NavigateUrl = parent.GetUrl();
                litPreviousLink.Text = parent.ContentPage.BasePageNEW.NavigationTitle.Rendered;
            }
        }

        private void BindControls()
        {
            var subTopicItems = Model.GetSubTopicLandingPages().ToList();
            if (subTopicItems != null && subTopicItems.Any())
            {
                // Add overview
                subTopicItems.Insert(0, new SubtopicLandingPageItem(Sitecore.Context.Item));

                rptTopicHeader.DataSource = subTopicItems;
                rptTopicHeader.DataBind();
            }
        }

        protected void rptTopicHeader_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                SubtopicLandingPageItem subTopicItem = e.Item.DataItem as SubtopicLandingPageItem;
                HyperLink hlNavigationTitle = e.FindControlAs<HyperLink>("hlNavigationTitle");
                BasePageNEWItem basePageNewItem = new BasePageNEWItem(subTopicItem);
                if (hlNavigationTitle != null)
                {
                    hlNavigationTitle.NavigateUrl = subTopicItem.InnerItem.GetUrl();

                    // Handle overview link
                    if (subTopicItem.InnerItem == Sitecore.Context.Item)
                    {
                        hlNavigationTitle.Text = UnderstoodDotOrg.Common.DictionaryConstants.OverviewButtonText;
                        hlNavigationTitle.CssClass = "selected";
                    }
                    else
                    {
                        hlNavigationTitle.Text = basePageNewItem.NavigationTitle.Rendered;
                    }
                }
            }
        }
    }
}