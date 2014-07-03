using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.Search.JSON;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.Widgets.Base;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class SearchResults : BaseSublayout<SearchResultsItem>
    {
        protected string SearchTerm { get; set; }
        protected string ResultCount { get; set; }
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

        private void Page_Init(object sender, EventArgs e)
        {
            BindEvents();
            BindCopy();
            BindControls();
        }

        private void Page_Load(object sender, EventArgs e)
        {
            // Parse query string
            string query = HttpHelper.GetQueryString(Constants.SEARCH_TERM_QUERY_STRING);
            string type = HttpHelper.GetQueryString(Constants.SEARCH_TYPE_FILTER_QUERY_STRING);

            // TODO: refactor
            // Process postback due to article type filter
            if (IsPostBack)
            {
                string target = Request.Params.Get("__EVENTTARGET") ?? String.Empty;

                // Check controls
                if (string.IsNullOrEmpty(target))
                {
                    Control sourceControl = null;
                    foreach (string ctl in Request.Form)
                    {
                        Control foundControl = Page.FindControl(ctl);

                        if (foundControl is Button)
                        {
                            sourceControl = foundControl;
                            break;
                        }
                    }

                    // Allow widget postback
                    if ((sourceControl != null && sourceControl.ID != btnSearch.ID)
                        || sourceControl == null)
                    {
                        return;
                    }
                }

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

            ResultSet searchResults = svc.SearchAllArticles(query, type, 1, Sitecore.Context.Language.Name);

            List<string> suggestions = SearchHelper.GetSpellCheckSuggestions(query);
            litMisspellings.Text = AssembleSuggestions(suggestions);

            bool hasSuggestions = suggestions.Any();
            bool hasResults = searchResults.Articles.Any();

            pnlResultsMisspelling.Visible = hasSuggestions;
            pnlResultsNoMisspelling.Visible = !hasSuggestions;

            if (hasResults || hasSuggestions) 
            {
                if (hasResults)
                {
                    rptResults.DataSource = searchResults.Articles;
                    rptResults.DataBind();
                }
                else
                {
                    ddlSearchFilter.Visible = false;
                }

                phMoreResults.Visible = searchResults.HasMoreResults;
            } 
            else 
            {
                pnlNoResults.Visible = true;
                pnlResults.Visible = false;
            }
            SearchTerm = litSearchTermNoResults.Text = System.Net.WebUtility.HtmlEncode(query);
            ResultCount = searchResults.TotalMatches.ToString();
        }

        private string AssembleSuggestions(List<string> suggestions)
        {
            var pairs = (from s in suggestions
                         select String.Format("<a href=\"{0}\">{1}</a>", 
                            FormHelper.GetSearchResultsUrl(s, String.Empty), 
                            System.Net.WebUtility.HtmlEncode(s))).ToArray();

            return String.Join(", ", pairs);
        }

        private void BindEvents()
        {
            rptWidgets.ItemDataBound += rptWidgets_ItemDataBound;
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

        private void BindControls()
        {
            IEnumerable<Item> items = Model.ToolWidgets.ListItems.FilterByContextLanguageVersion()
                                        .Take(Constants.SUBTOPIC_WIDGETS_ENTRIES);
            if (items.Any())
            {
                rptWidgets.DataSource = items;
                rptWidgets.DataBind();
            }
        }

        void rptWidgets_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item item = (Item)e.Item.DataItem;

                Sublayout slWidget = e.FindControlAs<Sublayout>("slWidget");
                slWidget.DataSource = item.ID.ToString();

                slWidget.Path = ToolWidgetItem.GetWidgetSublayoutPath(item);
            }
        }
    }
}