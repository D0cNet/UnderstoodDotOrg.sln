using System;
using System.Web;
using System.Linq;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using System.Collections.Specialized;
using System.Collections.Generic;
using Sitecore.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics
{
    public partial class SubTopicHeader : BaseSublayout<SubtopicLandingPageItem>
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
            BindContent();
        }

        private void BindEvents()
        {
            rptFilters.ItemDataBound += rptFilters_ItemDataBound;
        }

        private void BindContent()
        {
            litTitle.Text = Model.ContentPage.PageTitle.Rendered;

            if (Model.InnerItem.Parent != null)
            {
                TopicLandingPageItem topic = Model.InnerItem.Parent;
                hlBreadcrumbNav.NavigateUrl = topic.GetUrl();
                litPreviousLink.Text = topic.ContentPage.BasePageNEW.NavigationTitle.Rendered;
            }

            Dictionary<string,string> filters = Model.GetArticleFilters();
            if (filters.Count > 0)
            {
                rptFilters.DataSource = filters;
                rptFilters.DataBind();

                litFirstFilter.Text = filters.First().Value;
            }
        }

        void rptFilters_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var kvp = (KeyValuePair<string, string>)e.Item.DataItem;

                HyperLink hlFilter = e.FindControlAs<HyperLink>("hlFilter");
                hlFilter.Text = kvp.Value;
                hlFilter.Attributes.Add("data-filter", kvp.Key);

                if (e.Item.ItemIndex == 0)
                {
                    hlFilter.CssClass = "selected";
                }
            }
        }
    }
}