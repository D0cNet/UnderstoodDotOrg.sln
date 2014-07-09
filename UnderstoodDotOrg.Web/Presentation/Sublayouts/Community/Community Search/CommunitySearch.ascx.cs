namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Community_Search
{
    using System;
    using UnderstoodDotOrg.Services.TelligentService;
    using UnderstoodDotOrg.Common.Extensions;
    using System.Net;
    using System.Text;
    using System.Xml;
    using System.Text.RegularExpressions;

    public partial class CommunitySearch : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {
            string q = string.Empty;
            q = Request.QueryString["q"];
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
                if (!Request.QueryString["a"].IsNullOrEmpty())
                {
                    a = Request.QueryString["a"];
                }
                var dataSource = TelligentService.CommunitySearch(q, a);
                rptResults.DataSource = dataSource;
                rptResults.DataBind();
                litResultCount.Text = dataSource.Count.ToString();
            }
            switch (Request.QueryString["a"])
            {
                case "all":
                    litFilter.Text = "Community";
                    break;
                case "blog":
                    litFilter.Text = "Blogs";
                    break;
                case "group":
                    litFilter.Text = "Groups";
                    break;
                case "question":
                    litFilter.Text = "Q & A";
                    break;
                case "expert":
                    litFilter.Text = "Experts";
                    break;
                default:
                    litFilter.Text = "Community";
                    break;

            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            string url = Request.RawUrl;
            if (Request.RawUrl.Contains("?"))
            {
                string[] u = url.Split('?');
                url = u[0];
            }
            Response.Redirect(url + "?q=" + txtSearch.Value);
        }

        protected void ddlFilterSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ddlFilterSearch.SelectedItem.Value.IsNullOrEmpty())
            {
                if (Request.RawUrl.Contains("?"))
                {
                    string url = Request.RawUrl;
                    if (url.Contains("&a"))
                    {
                        string[] u = Regex.Split(url, "&a");
                        url = u[0];
                        Response.Redirect(url + "&a=" + ddlFilterSearch.SelectedItem.Value);
                    }
                    else
                    {
                        Response.Redirect(url + "&a=" + ddlFilterSearch.SelectedItem.Value);
                    }
                }
            }
        }
    }
}