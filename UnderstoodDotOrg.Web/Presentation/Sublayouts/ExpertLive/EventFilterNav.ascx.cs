using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Domain.Understood.Helper;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive
{
    public partial class EventFilterNav : System.Web.UI.UserControl
    {
        public bool IsFeatured { get; set; }
        public string Issue { get; set; }
        public string Grade { get; set; }
        public string Topic { get; set; }
        public bool IsRecommended { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindEvents();

            string featured = HttpHelper.GetQueryString(Constants.EVENT_FEATURED_FILTER_QUERY_STRING).Trim();
            IsFeatured = featured.ToLower() == "true";
            string recommended = HttpHelper.GetQueryString(UnderstoodDotOrg.Common.Constants.EVENT_RECOMMENDED_FILTER_QUERY_STRING);
            IsRecommended = recommended.ToLower() == "true";
            Issue = HttpHelper.GetQueryString(Constants.EVENT_ISSUE_FILTER_QUERY_STRING).Trim();
            Grade = HttpHelper.GetQueryString(Constants.EVENT_GRADE_FILTER_QUERY_STRING).Trim();
            Topic = HttpHelper.GetQueryString(Constants.EVENT_TOPIC_FILTER_QUERY_STRING).Trim();
            litSelectedMenu.Text = DictionaryConstants.FilterByLabel;
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindEvents()
        {
            rptFilter.ItemDataBound += rptFilter_ItemDataBound;

            ddlGrade.SelectedIndexChanged += ddlGrade_SelectedIndexChanged;
            ddlIssue.SelectedIndexChanged += ddlIssue_SelectedIndexChanged;
            ddlTopics.SelectedIndexChanged += ddlTopics_SelectedIndexChanged;
        }

        private void BindControls()
        {
            // Nav
            Item container = Sitecore.Context.Database.GetItem(Constants.ExpertsLiveFilterContainer);
            var filters = container.Children.FilterByContextLanguageVersion()
                            .Where(i => i.IsOfType(NavigationLinkItem.TemplateId))
                            .Select(i => (NavigationLinkItem)i);
            if (filters.Any())
            {
                rptFilter.DataSource = filters;
                rptFilter.DataBind();
            }

            // Filters
            var childIssues = FormHelper.GetIssues(DictionaryConstants.ChildIssuesLabel);
            var grades = FormHelper.GetGrades(DictionaryConstants.GradeLabel);
            var topics = FormHelper.GetParentInterests(DictionaryConstants.TopicLabel);

            PopulateFilter(ddlIssue, childIssues, Issue);
            PopulateFilter(ddlGrade, grades, Grade);
            PopulateFilter(ddlTopics, topics, Topic);
        }

        private void PopulateFilter(DropDownList ddl, List<ListItem> options, string selectedState)
        {
            if (options.Any())
            {
                ddl.DataSource = options;
                ddl.DataTextField = "Text";
                ddl.DataValueField = "Value";
                ddl.DataBind();

                if (!String.IsNullOrEmpty(selectedState))
                {
                    ListItem li = ddl.Items.FindByValue(selectedState);
                    if (li != null)
                    {
                        li.Selected = true;
                    }
                }
            }
        }

        protected void rptFilter_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                NavigationLinkItem navItem = e.Item.DataItem as NavigationLinkItem;

                FieldRenderer frLink = e.FindControlAs<FieldRenderer>("frLink");

                if (frLink != null)
                {
                    frLink.Item = navItem;
                }

                LinkField lf = navItem.InnerItem.Fields["Link"];

                if (Sitecore.Context.Item.ID == lf.TargetItem.ID)
                {
                    bool hasMatch = false;
         
                    // Selected state of filter item
                    if (string.IsNullOrEmpty(lf.QueryString))
                    {
                        hasMatch = true;
                    }
                    else
                    {
                        // Handle featured
                        //string assembledUrl = String.Format("{0}?{1}", lf.TargetItem.GetUrl(), lf.QueryString);
                        //hasMatch = Request.Url.PathAndQuery.StartsWith(assembledUrl);
                        hasMatch = Request.Url.PathAndQuery.Contains(lf.QueryString);
                    }

                    if (hasMatch)
                    {
                        litSelectedMenu.Text = lf.Text;
                    }
                  
                     
                }
                
            }
        }

        private void ddlIssue_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGrade.SelectedValue = String.Empty;
            ddlTopics.SelectedValue = String.Empty;
            //if (!String.IsNullOrEmpty(ddlIssue.SelectedValue))
            //{
                Redirect(new Dictionary<string, string>
            {
                { Constants.EVENT_ISSUE_FILTER_QUERY_STRING, ddlIssue.SelectedValue }
            });
           // }
        }

        private void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlIssue.SelectedValue = String.Empty;
            ddlTopics.SelectedValue = String.Empty;
            //if (!String.IsNullOrEmpty(ddlGrade.SelectedValue))
            //{
                Redirect(new Dictionary<string, string>
            {
                { Constants.EVENT_GRADE_FILTER_QUERY_STRING, ddlGrade.SelectedValue }
            });
          //  }
        }

        private void ddlTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlGrade.SelectedValue = String.Empty;
            ddlIssue.SelectedValue = String.Empty;
            //if (!String.IsNullOrEmpty(ddlTopics.SelectedValue))
            //{
                Redirect(new Dictionary<string, string>
            {
                { Constants.EVENT_TOPIC_FILTER_QUERY_STRING, ddlTopics.SelectedValue }
            });
          //  }
        }

        private void Redirect(Dictionary<string, string> keys)
        {
            string baseUrl = String.Concat(Request.Url.AbsolutePath, "?");

           
                string vars =keys.Count >0? String.Join("&",
                    keys.Where(x => !String.IsNullOrEmpty(x.Value))
                        .Select(x => String.Format("{0}={1}", x.Key, x.Value))
                        ):String.Empty;
            
            string parameters = 
                (IsFeatured  )
                ? String.Format("{0}=true"+ (String.IsNullOrEmpty(vars) ? "": "&{1}"), Constants.EVENT_FEATURED_FILTER_QUERY_STRING, vars)
                : (IsRecommended) ? String.Format("{0}=true" + (String.IsNullOrEmpty(vars) ? "" : "&{1}"), Constants.EVENT_RECOMMENDED_FILTER_QUERY_STRING, vars) : vars;

            Response.Redirect(String.Concat(baseUrl, parameters));
        }
    }
}