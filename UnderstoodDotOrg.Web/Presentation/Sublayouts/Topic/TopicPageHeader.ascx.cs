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
            else 
            {
                hlBreadcrumbNav.Visible = false;
                txtBreadcrumbNav.Visible = false;
            }

            // Navigation should only display on Experts Live and Subtopic pages
            if (topicPage != null)
            {
                // Display nav for Topic page
                if (Sitecore.Context.Item.IsOfType(TopicLandingPageItem.TemplateId))
                {
                    var subTopicItems = topicPage.GetSubTopicLandingPageItem().ToList();
                    if (subTopicItems != null && subTopicItems.Any())
                    {
                        // Add overview
                        subTopicItems.Insert(0, new SubtopicLandingPageItem(Sitecore.Context.Item));
                    
                        rptTopicHeader.DataSource = subTopicItems;
                        rptTopicHeader.DataBind();
                    }
                }

                // NOTE: This control is primarily meant for Articles section
                // It's being reused in Community which appears to be displaying the wrong nav elements
                // DP HTML shows that Experts Live page should show navigation matching the Community landing page
                // Current function is pulling links from children below, this should probably be corrected.

                if (IsExpertsLivePage()) 
                {
                    var subTopicItems = topicPage.GetSubTopicLandingPageItem();
                    if (subTopicItems != null && subTopicItems.Any()) 
                    {
                       rptTopicHeader.DataSource = subTopicItems;
                       rptTopicHeader.DataBind();
                    }
                }
            }
        }

        private bool IsExpertsLivePage()
        {
            return Sitecore.Context.Item.IsOfType(ExpertLandingPageItem.TemplateId)
                || Sitecore.Context.Item.IsOfType(ExpertDetailPageItem.TemplateId);
        }

        protected TopicLandingPageItem GetTopicLandingPageItem() 
        {
            Item contextItem = Sitecore.Context.Item;
            Item topicLandingPageItem = contextItem;
            while (contextItem != null && !contextItem.IsOfType(TopicLandingPageItem.TemplateId)) 
            {
                if (contextItem.Parent != null && contextItem.Parent.IsOfType(TopicLandingPageItem.TemplateId)) 
                {
                    topicLandingPageItem = contextItem.Parent;
                    break;
                }
                contextItem = contextItem.Parent;
            }

            return topicLandingPageItem;
        }

        protected void rptTopicHeader_ItemDataBound(object sender, RepeaterItemEventArgs e) 
        {
            if (e.IsItem()) 
            {
                SubtopicLandingPageItem subTopicItem = e.Item.DataItem as SubtopicLandingPageItem;
                if (subTopicItem != null) 
                {
                    HyperLink hlNavigationTitle = e.FindControlAs<HyperLink>("hlNavigationTitle");
                    BasePageNEWItem basePageNewItem = new BasePageNEWItem(subTopicItem);
                    if (hlNavigationTitle != null) 
                    {
                        hlNavigationTitle.NavigateUrl = subTopicItem.InnerItem.GetUrl();
                        
                        // Handle overview link
                        if (subTopicItem.InnerItem == Sitecore.Context.Item)
                        {
                            hlNavigationTitle.Text = UnderstoodDotOrg.Common.DictionaryConstants.OverviewButtonText;
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
}