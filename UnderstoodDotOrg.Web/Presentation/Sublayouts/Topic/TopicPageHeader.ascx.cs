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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic {
    public partial class TopicPageHeader : System.Web.UI.UserControl {
        protected void Page_Load(object sender, EventArgs e) {
            TopicLandingPageItem topicPage = GetTopicLandingPageItem();
            
            //Page Title
            scTopicTitle.Text = topicPage.ContentPage.PageTitle.Rendered;
            
            Item parentItem = topicPage.InnerItem.Parent;

            //Parent Item Navigation
            if (!parentItem.IsOfType(FolderItem.TemplateId))
            {
                hlBreadcrumbNav.NavigateUrl = parentItem.GetUrl();
                txtBreadcrumbNav.Text = parentItem.DisplayName;
            }
            else {
                hlBreadcrumbNav.Visible = false;
                txtBreadcrumbNav.Visible = false;
            }

            // Navigation should only display on Experts Live and Subtopic pages
            if (topicPage != null
                && (IsExpertsLivePage() || Sitecore.Context.Item.IsOfType(TopicLandingPageItem.TemplateId)))
            {
                var subTopicItems = topicPage.GetSubTopicLandingPageItem();
                if (subTopicItems != null && subTopicItems.Any()) {
                   rptTopicHeader.DataSource = subTopicItems;
                   rptTopicHeader.DataBind();
                }
            }

            //apply css class to outerDiv in case of expert landing and detail page
            if (IsExpertsLivePage()) {
                outerDiv.Attributes.Add("class", "container page-topic about-back-pagetopic");
            }
        }

        private bool IsExpertsLivePage()
        {
            return Sitecore.Context.Item.IsOfType(ExpertLandingPageItem.TemplateId)
                || Sitecore.Context.Item.IsOfType(ExpertDetailPageItem.TemplateId);
        }

        protected TopicLandingPageItem GetTopicLandingPageItem() {
            Item contextItem = Sitecore.Context.Item;
            Item topicLandingPageItem = contextItem;
            while (contextItem != null && !contextItem.IsOfType(TopicLandingPageItem.TemplateId)) {

                if (contextItem.Parent != null && contextItem.Parent.IsOfType(TopicLandingPageItem.TemplateId)) {
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