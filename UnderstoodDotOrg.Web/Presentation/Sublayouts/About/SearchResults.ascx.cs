﻿namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
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

            Handlers.SearchResultsService svc = new Handlers.SearchResultsService();

            ResultSet searchResults = svc.SearchAllArticles(query, "", 1);

            if (searchResults.Articles.Any()) 
            {
                rptResults.DataSource = searchResults.Articles;
                rptResults.DataBind();

                phMoreResults.Visible = searchResults.HasMoreResults;
            } 
            else 
            {
                phNoResults.Visible = true;
                phResults.Visible = false;
            }
            litSearchTerm.Text = litSearchTermNoResults.Text = System.Net.WebUtility.HtmlEncode(query);
            litResultCount.Text = searchResults.TotalMatches.ToString();
        }

        private void BindEvents()
        {
            btnSearch.Click += btnSearch_Click;
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