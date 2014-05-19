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
using System;
using Sitecore.Links;
using System.Web.UI.HtmlControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Expert_LIve
{
    public partial class CommunitySubHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e) {
            ExpertLivePageItem expertLivePageItem = GetExpertLivePageItem();

            Item parentItem = expertLivePageItem.InnerItem.Parent;

            //Page Title
            ContentPageItem contentPage = new ContentPageItem(parentItem);
            if (contentPage != null) {
                scTopicTitle.Text = contentPage.SectionTitle.Rendered;
            }
            
            //Parent Item Navigation
            if (!parentItem.IsOfType(FolderItem.TemplateId)) {
                hlBreadcrumbNav.NavigateUrl = parentItem.GetUrl();
                txtBreadcrumbNav.Text = parentItem.DisplayName;
            }
            else {
                hlBreadcrumbNav.Visible = false;
                txtBreadcrumbNav.Visible = false;
            }

            if (expertLivePageItem != null) {

                var subTopicItems = parentItem.GetChildren();
                if (subTopicItems != null && subTopicItems.Any()) {
                      rptTopicHeader.DataSource = subTopicItems;
                      rptTopicHeader.DataBind();
                }
                else {
                    rptTopicHeader.Visible = false;
                }
            }
        }

        protected ExpertLivePageItem GetExpertLivePageItem() {
            Item contextItem = Sitecore.Context.Item;
            Item topicLandingPageItem = contextItem;
            while (contextItem != null && !contextItem.IsOfType(ExpertLivePageItem.TemplateId)) {

                if (contextItem.Parent != null && contextItem.Parent.IsOfType(ExpertLivePageItem.TemplateId)) {
                    topicLandingPageItem = contextItem.Parent;
                    break;
                }
                contextItem = contextItem.Parent;
            }

            return topicLandingPageItem;
        }

        protected void rptTopicHeader_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                Item subTopicItem = e.Item.DataItem as Item;
               
                if (subTopicItem != null) {
                    HyperLink hlNavigationTitle = e.FindControlAs<HyperLink>("hlNavigationTitle");
                    HtmlGenericControl listItem = e.FindControlAs<HtmlGenericControl>("listItem");
                    listItem.Visible = false;
                    BasePageNEWItem basePageNewItem = new BasePageNEWItem(subTopicItem);
                    if (hlNavigationTitle != null) {
                        if (subTopicItem.GetUrl().Contains(Request.RawUrl)) {
                            hlNavigationTitle.Attributes.Add("class","selected");
                        }

                        hlNavigationTitle.NavigateUrl = LinkManager.GetItemUrl(subTopicItem);
                        if (!basePageNewItem.IncludeinNavigation.Raw.IsNullOrEmpty()) {
                            hlNavigationTitle.Text = basePageNewItem.NavigationTitle.Rendered;
                            listItem.Visible = true;
                        }
                    }
                }
            }
        }
    }
}