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
            }

            PerformSearch(query);
        }

        private void PerformSearch(string query)
        {
            if (String.IsNullOrEmpty(query))
            {
                return;
            }

            int resultCount;

            lvResults.DataSource = SearchHelper.GetSearchResultArticles(query, "", out resultCount);
            lvResults.DataBind();

            litSearchTerm.Text = System.Net.WebUtility.HtmlEncode(query);
            litResultCount.Text = resultCount.ToString();
        }

        private void BindEvents()
        {
            btnSearch.Click += btnSearch_Click;

            lvResults.ItemDataBound += lvResults_ItemDataBound;
        }

        void lvResults_ItemDataBound(object sender, System.Web.UI.WebControls.ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Article article = (Article)e.Item.DataItem;
                Item item = article.GetItem();

                HyperLink hlArticlePage = (HyperLink)e.Item.FindControl("hlArticlePage");
                hlArticlePage.NavigateUrl = item.GetUrl();

                hlArticlePage.Text = item.Name;

                // TODO: determine video type
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
    }
}