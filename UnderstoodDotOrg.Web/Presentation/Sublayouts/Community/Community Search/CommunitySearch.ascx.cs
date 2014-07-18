namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Community_Search
{
    using System;
    using UnderstoodDotOrg.Services.TelligentService;
    using UnderstoodDotOrg.Common.Extensions;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Text.RegularExpressions;
    using UnderstoodDotOrg.Framework.UI;
    using UnderstoodDotOrg.Common;
    using UnderstoodDotOrg.Common.Helpers;

    public partial class CommunitySearch : BaseSublayout
    {
        private void Page_Load(object sender, EventArgs e)
        {

            ddlFilterSearch.Items[0].Text = DictionaryConstants.FilterByFragment;
            ddlFilterSearch.Items[0].Value = Constants.TelligentSearchParams.All;
            ddlFilterSearch.Items[1].Text = DictionaryConstants.ShowAllFragment;
            ddlFilterSearch.Items[1].Value = Constants.TelligentSearchParams.All;
            ddlFilterSearch.Items[2].Text = DictionaryConstants.BlogsFragment;
            ddlFilterSearch.Items[2].Value = Constants.TelligentSearchParams.Blog;
            ddlFilterSearch.Items[3].Text = DictionaryConstants.GroupsFragment;
            ddlFilterSearch.Items[3].Value = Constants.TelligentSearchParams.Group;
            ddlFilterSearch.Items[4].Text = DictionaryConstants.QAFragment;
            ddlFilterSearch.Items[4].Value = Constants.TelligentSearchParams.Question;
            ddlFilterSearch.Items[5].Text = DictionaryConstants.ExpertsFragment;
            ddlFilterSearch.Items[5].Value = Constants.TelligentSearchParams.Expert;

            string q = string.Empty;
            q = Request.QueryString[Constants.QueryStrings.CommunitySearch.Query];
            litResultName.Text = q;

            if (q.IsNullOrEmpty())
            {
                divResults.Visible = false;
                divResultsList.Visible = false;
                searchFilter.Visible = false;
            }

            if (!q.IsNullOrEmpty())
            {
                var a = string.Empty;
                if (Request.QueryString[Constants.QueryStrings.CommunitySearch.SearchLocation] != null)
                {
                    a = Request.QueryString[Constants.QueryStrings.CommunitySearch.SearchLocation];
                }

                var dataSource = TelligentService.CommunitySearch(q, a);
                rptResults.DataSource = dataSource;
                rptResults.DataBind();
                litResultCount.Text = dataSource.Count.ToString();
            }

            switch (Request.QueryString[Constants.QueryStrings.CommunitySearch.SearchLocation])
            {
                case Constants.TelligentSearchParams.All:
                    litFilter.Text = DictionaryConstants.CommunityLabel;
                    break;
                case Constants.TelligentSearchParams.Blog:
                    litFilter.Text = DictionaryConstants.BlogsFragment;
                    break;
                case Constants.TelligentSearchParams.Group:
                    litFilter.Text = DictionaryConstants.GroupsFragment;
                    break;
                case Constants.TelligentSearchParams.Question:
                    litFilter.Text = DictionaryConstants.QAFragment;
                    break;
                case "expert":
                    litFilter.Text = DictionaryConstants.ExpertsFragment;
                    break;
                default:
                    litFilter.Text = DictionaryConstants.CommunityLabel;
                    break;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string query = TextHelper.RemoveHTML(txtSearch.Text);
            string url = Request.RawUrl;
            if (Request.RawUrl.Contains("?"))
            {
                string[] u = url.Split('?');
                url = u[0];
            }

            Response.Redirect(string.Format("{0}?{1}={2}", url, Constants.QueryStrings.CommunitySearch.Query, query));
        }

        protected void ddlFilterSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFilterSearch.SelectedItem.Value != null)
            {
                if (Request.RawUrl.Contains("?"))
                {
                    string url = Request.RawUrl;
                    if (url.Contains("&a"))
                    {
                        string[] u = Regex.Split(url, "&a");
                        url = u[0];
                        Response.Redirect(string.Format("{0}?{1}={2}", url, Constants.QueryStrings.CommunitySearch.SearchLocation, ddlFilterSearch.SelectedItem.Value));

                    }
                    else
                    {
                        Response.Redirect(string.Format("{0}?{1}={2}", url, Constants.QueryStrings.CommunitySearch.SearchLocation, ddlFilterSearch.SelectedItem.Value));
                    }
                }
            }
        }
    }
}