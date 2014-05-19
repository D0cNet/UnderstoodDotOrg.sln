namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics
{
    using System;
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
    using UnderstoodDotOrg.Framework.UI;
    using UnderstoodDotOrg.Common.Extensions;

    public partial class SubTopicHeader : BaseSublayout<SubtopicLandingPageItem>
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindContent();
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
        }
    }
}