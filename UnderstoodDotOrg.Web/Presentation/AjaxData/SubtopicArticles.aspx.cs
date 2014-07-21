using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;

namespace UnderstoodDotOrg.Web.Presentation.AjaxData
{
    public partial class SubtopicArticles : System.Web.UI.Page
    {
        private string Topic
        {
            get { return Request.QueryString["topic"] ?? String.Empty; }
        }
        private string ResultPage
        {
            get { return Request.QueryString["page"] ?? String.Empty; }
        }
        private string Lang
        {
            get { return Request.QueryString["lang"] ?? String.Empty; }
        }
        private string Featured
        {
            get { return Request.QueryString["featured"] ?? String.Empty; }
        }
        private string Type
        {
            get { return Request.QueryString["type"] ?? String.Empty; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid topic;
            Guid? typeId = null;
            bool hasFeatured = false;

            bool.TryParse(Featured, out hasFeatured);

            if (!string.IsNullOrEmpty(Type))
            {
                try
                {
                    typeId = Guid.Parse(Type);
                }
                catch { }
            }

            int page;
            Sitecore.Globalization.Language language;

            if (Sitecore.Globalization.Language.TryParse(Lang, out language))
            {
                Sitecore.Context.SetLanguage(language, false);
            }

            if (Guid.TryParse(Topic, out topic) && int.TryParse(ResultPage, out page))
            {
                Item item = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(topic));
                if (item != null && item.InheritsTemplate(SubtopicLandingPageItem.TemplateId))
                {
                    SubtopicLandingPageItem topicItem = item;
                    bool hasMoreResults;

                    // Handle featured search
                    if (!typeId.HasValue && hasFeatured)
                    {
                        articleListing.Articles = topicItem.GetFeaturedArticles(page, out hasMoreResults);
                    }
                    else
                    {
                        articleListing.Articles = topicItem.GetArticles(page, typeId, out hasMoreResults);
                    }

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