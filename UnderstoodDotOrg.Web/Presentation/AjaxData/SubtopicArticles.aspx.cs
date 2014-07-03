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

        protected void Page_Load(object sender, EventArgs e)
        {
            Guid topic;
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
                    articleListing.Articles = topicItem.GetArticles(page, out hasMoreResults);
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