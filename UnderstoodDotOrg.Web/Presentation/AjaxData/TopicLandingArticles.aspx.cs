using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class TopicLandingArticles : System.Web.UI.Page
    {
        private string Topic
        {
            get { return Request.QueryString["topic"] ?? String.Empty; }
        }
        private string ResultPage
        {
            get { return Request.QueryString["page"] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid topic;
            int page;

            if (Guid.TryParse(Topic, out topic) && int.TryParse(ResultPage, out page))
            {
                Item item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(topic));
                if (item != null && item.InheritsTemplate(TopicLandingPageItem.TemplateId))
                {
                    TopicLandingPageItem topicItem = item;
                    bool hasMoreResults;
                    articleListing.Articles = topicItem.GetTopicArticles(page, out hasMoreResults);
                    phMoreResults.Visible = hasMoreResults;
                }
            }
            else
            {
                articleListing.Visible = false;
            }
        }
    }
}