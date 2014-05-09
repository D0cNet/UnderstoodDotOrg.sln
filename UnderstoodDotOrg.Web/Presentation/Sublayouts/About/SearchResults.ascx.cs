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
    using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
    using UnderstoodDotOrg.Domain.Understood.Helper;
    using System.Web.UI;

    public partial class SearchResults : System.Web.UI.UserControl
    {
        private void Page_Init(object sender, EventArgs e)
        {
            BindEvents();
        }

        private void Page_Load(object sender, EventArgs e)
        {
            BindCopy();

            // Parse query string
            string query = HttpHelper.GetQueryString(Constants.SEARCH_TERM_QUERY_STRING);
            string type = HttpHelper.GetQueryString(Constants.SEARCH_TYPE_FILTER_QUERY_STRING);

            if (IsPostBack)
            {
                string target = Request.Params.Get("__EVENTTARGET") ?? String.Empty;

                if (!String.IsNullOrEmpty(txtSearch.Text.Trim()))
                {
                    query = txtSearch.Text.Trim();
                }

                if (target == ddlSearchFilter.UniqueID)
                {
                    type = ddlSearchFilter.SelectedValue;      
                }
                else
                {
                    // Empty out type
                    type = String.Empty;
                }

                Response.Redirect(FormHelper.GetSearchResultsUrl(query, type));
                return;
            }
            else
            {
                BindControls(type);
            }

            PerformSearch(query, type);
        }

        private void BindControls(string selectedState)
        {
            // Populate dropdown
            ddlSearchFilter.DataSource = FormHelper.GetSearchArticleTypes();
            ddlSearchFilter.DataTextField = "Text";
            ddlSearchFilter.DataValueField = "Value";
            ddlSearchFilter.DataBind();

            // Re-select choice based on query string;
            ListItem li = ddlSearchFilter.Items.FindByValue(selectedState);
            if (li != null)
            {
                li.Selected = true;
            }
        }

        private void PerformSearch(string query, string type)
        {
            if (String.IsNullOrEmpty(query))
            {
                return;
            }

            Handlers.SearchResultsService svc = new Handlers.SearchResultsService();

            ResultSet searchResults = svc.SearchAllArticles(query, type, 1);

            SearchHelper.GetSpellCheckSuggestions(query);

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

        private void BindCopy()
        {
            txtSearch.Attributes.Add("placeholder", DictionaryConstants.SearchWatermark);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim();

            if (!String.IsNullOrEmpty(term))
            {
                Response.Redirect(FormHelper.GetSearchResultsUrl(term, String.Empty));
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
                return System.Web.HttpUtility.HtmlAttributeEncode(HttpHelper.GetQueryString(Constants.SEARCH_TYPE_FILTER_QUERY_STRING));
            }
        }
    }
}