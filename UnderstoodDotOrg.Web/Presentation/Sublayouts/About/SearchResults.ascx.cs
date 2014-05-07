namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    using Sitecore.Data.Items;
    using System;
    using System.Web.UI.WebControls;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Helpers;
    using UnderstoodDotOrg.Domain.Search;
    using UnderstoodDotOrg.Common.Extensions;
    using Sitecore.ContentSearch.Linq;
    using Sitecore.ContentSearch.Linq.Solr;
    using System.Web.Services;
    using System.Collections.Generic;
    using System.Linq;

    public partial class SearchResults : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();

            // Parse query string
            string query = HttpHelper.GetQueryString(Constants.SEARCH_TERM_QUERY_STRING);

            if (IsPostBack)
            {
                query = txtSearch.Text.Trim();
                Response.Redirect(SearchHelper.GetSearchResultsUrl(query));
            }

            PerformSearch(query);
        }

        private void PerformSearch(string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                return;
            }

            int totalMatches;

            List<Article> results = SearchHelper.GetSearchResultArticles(query, "", 1, out totalMatches);

            if (results.Any()) 
            {
                rptResults.DataSource = results;
                rptResults.DataBind();

                if (totalMatches <= Constants.SEARCH_RESULTS_ENTRIES_PER_PAGE)
                {
                    phMoreResults.Visible = false;
                }
            } 
            else 
            {
                phNoResults.Visible = true;
                phResults.Visible = false;
            }

            litSearchTerm.Text = litSearchTermNoResults.Text = System.Net.WebUtility.HtmlEncode(query);
            litResultCount.Text = totalMatches.ToString();
        }

        private void BindEvents()
        {
            btnSearch.Click += btnSearch_Click;

            rptResults.ItemDataBound += rptResults_ItemDataBound;
        }

        void rptResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem()) 
            {
                Article article = (Article)e.Item.DataItem;
                Item item = article.GetItem();

                HyperLink hlArticlePage = (HyperLink)e.Item.FindControl("hlArticlePage");
                hlArticlePage.NavigateUrl = item.GetUrl();

                hlArticlePage.Text = item.Name;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim();

            if (!String.IsNullOrEmpty(term))
            {
                Response.Redirect(SearchHelper.GetSearchResultsUrl(term));
            }
            else
            {
                // TODO: display error?
            }
            
        }

        protected string AjaxUrl
        {
            get
            {
                return Sitecore.Configuration.Settings.GetSetting(Constants.Settings.SearchResultsEndpoint);
            }
        }

        protected string AjaxTerm
        {
            get
            {
                return System.Web.HttpUtility.HtmlAttributeEncode(HttpHelper.GetQueryString(Constants.SEARCH_TERM_QUERY_STRING));
            }
        }

        protected string AjaxType
        {
            get
            {
                return String.Empty;
            }
        }
    }
}