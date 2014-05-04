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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic {
    public partial class TopicPageHeader : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            TopicLandingPageItem topicPage = GetTopicLandingPageItem();
            
            //Page Title
            scTopicTitle.Text = topicPage.DisplayName;
            
            Item parentItem = topicPage.InnerItem.Parent;

            //Parent Item Navigation
            hlBreadcrumbNav.NavigateUrl = parentItem.GetUrl();
            txtBreadcrumbNav.Text = parentItem.DisplayName;

            if (topicPage != null) {

                var subTopicItems = topicPage.GetSubTopicLandingPageItem();
                if (subTopicItems != null && subTopicItems.Any()) {
                    rptTopicHeader.DataSource = subTopicItems;
                    rptTopicHeader.DataBind();
                }
            }
        }

        protected TopicLandingPageItem GetTopicLandingPageItem() {
            Item contextItem = Sitecore.Context.Item;
            Item topicLandingPageItem = contextItem;
            while (!contextItem.IsOfType(TopicLandingPageItem.TemplateId)) {

                if (contextItem.Parent.IsOfType(TopicLandingPageItem.TemplateId)) {
                    topicLandingPageItem = contextItem.Parent;
                    break;
                }
                contextItem = contextItem.Parent;
            }

            return topicLandingPageItem;
        }

        protected void rptTopicHeader_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                SubtopicLandingPageItem subTopicItem = e.Item.DataItem as SubtopicLandingPageItem;
                if (subTopicItem != null) {
                    HyperLink hlNavigationTitle = e.FindControlAs<HyperLink>("hlNavigationTitle");
                    BasePageNEWItem basePageNewItem = new BasePageNEWItem(subTopicItem);
                    if (hlNavigationTitle != null) {
                        hlNavigationTitle.NavigateUrl = subTopicItem.InnerItem.GetUrl();
                        hlNavigationTitle.Text = basePageNewItem.NavigationTitle.Rendered;
                    }
                }
            }
        }
    }
}