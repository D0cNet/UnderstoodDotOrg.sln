using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.AdminTools
{
    public partial class PersonalizationAdmin : System.Web.UI.UserControl
    {
        private List<Guid> _childIssues = new List<Guid>();
        private Guid? _childGuidId;
        private List<Guid> _parentInterests = new List<Guid>();

        private void Page_Load(object sender, EventArgs e)
        {
            BindEvents();
        }

        private void BindEvents()
        {
            btnSubmit.Click += btnSubmit_Click;
            btnSearch.Click += btnSearch_Click;
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            MembershipManager mm = new MembershipManager();
            Child child = mm.GetChild(Guid.Parse(ddlChildren.SelectedValue));

            _parentInterests = child.Members.FirstOrDefault().Interests.Select(i => Sitecore.Context.Database.GetItem(i.Key))
                                    .Where(i => i != null)
                                    .Select(i => i.ID.ToGuid())
                                    .ToList();

            string childGrade = string.Empty;

            var grade = child.Grades.FirstOrDefault();
            if (grade != null)
            {
                GradeLevelItem gli = Sitecore.Context.Database.GetItem(grade.Key);
                if (gli != null)
                {
                    // store value for data bound match
                    _childGuidId = grade.Key;

                    childGrade = gli.Name.Rendered;
                }
            }

            litChild.Text = String.Format("{0} ({1})", child.Nickname, childGrade);

            var issues = child.Issues.Select(i => Sitecore.Context.Database.GetItem(i.Key))
                                .Where(i => i != null)
                                .Select(i => new ChildIssueItem(i));
            if (issues.Any())
            {
                // store lookup values for data bound match
                _childIssues = issues.Select(i => i.ID.ToGuid()).ToList();

                rptIssues.DataSource = issues;
                rptIssues.DataBind();
            }

            DateTime specifiedDate = DateTime.Parse(txtDate.Text).Date;

            var articles = SearchHelper.GetArticles(child.Members.FirstOrDefault(), child, specifiedDate)
                                .Where(i => i.GetItem() != null);
            if (articles.Any())
            {
                rptArticles.DataSource = articles;
                rptArticles.DataBind();
            }
        }

        void btnSubmit_Click(object sender, EventArgs e)
        {
            pnlResults.Update();

            MembershipManager mm = new MembershipManager();
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                var member = mm.GetMember(txtEmail.Text);
                if (member != null)
                {
                    bool hasChildren = member.Children.Any();
                    pnlChildren.Visible = hasChildren;

                    if (hasChildren)
                    {
                        ddlChildren.DataSource = member.Children;
                        ddlChildren.DataTextField = "Nickname";
                        ddlChildren.DataValueField = "ChildId";
                        ddlChildren.DataBind();
                    }

                    if (member.Interests.Any())
                    {
                        rptInterests.DataSource = member.Interests;
                        rptInterests.DataBind();
                    }
                }
            }
        }

        protected void rptIssues_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ChildIssueItem issue = (ChildIssueItem)e.Item.DataItem;

                Literal litIssue = e.FindControlAs<Literal>("litIssue");

                litIssue.Text = issue.IssueName.Rendered;
            }
        }

        protected void rptInterests_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Interest interest = (Interest)e.Item.DataItem;

                Literal litInterest = e.FindControlAs<Literal>("litInterest");
                ParentInterestItem pii = Sitecore.Context.Database.GetItem(interest.Key);
                if (pii != null)
                {
                    litInterest.Text = pii.InterestName.Rendered;
                }
            }
        }

        protected void rptArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Article article = (Article)e.Item.DataItem;

                DefaultArticlePageItem item = article.GetItem();

                HyperLink hlTitle = e.FindControlAs<HyperLink>("hlTitle");
                hlTitle.NavigateUrl = item.GetUrl();

                Literal litTitle = e.FindControlAs<Literal>("litTitle");
                litTitle.Text = item.ContentPage.PageTitle.Rendered;

                Repeater rptArticleIssues = e.FindControlAs<Repeater>("rptArticleIssues");
                var issues = article.ChildIssues.Select(i => Sitecore.Context.Database.GetItem(i.Guid))
                                    .Where(i => i != null)
                                    .Select(i => new ChildIssueItem(i));
                if (issues.Any())
                {
                    rptArticleIssues.DataSource = issues;
                    rptArticleIssues.DataBind();
                }

                Repeater rptArticleGrades = e.FindControlAs<Repeater>("rptArticleGrades");
                var grades = article.ChildGrades.Select(i => Sitecore.Context.Database.GetItem(i.Guid))
                                    .Where(i => i != null)
                                    .Select(i => new GradeLevelItem(i));
                if (grades.Any())
                {
                    rptArticleGrades.DataSource = grades;
                    rptArticleGrades.DataBind();
                }

                Repeater rptArticleInterests = e.FindControlAs<Repeater>("rptArticleInterests");
                var interests = article.ParentInterests.Select(i => Sitecore.Context.Database.GetItem(i.Guid))
                                    .Where(i => i != null)
                                    .Select(i => new ParentInterestItem(i));
                if (interests.Any())
                {
                    rptArticleInterests.DataSource = interests;
                    rptArticleInterests.DataBind();
                }
            }
        }

        protected void rptArticleIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ChildIssueItem item = (ChildIssueItem)e.Item.DataItem;

                Literal litIssue = e.FindControlAs<Literal>("litIssue");

                litIssue.Text = (_childIssues.Contains(item.ID.ToGuid())) 
                    ? HighlightMatch(item.IssueName.Rendered) : item.IssueName.Rendered;

            }
        }

        protected void rptArticleGrades_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                GradeLevelItem item = (GradeLevelItem)e.Item.DataItem;

                Literal litGrade = e.FindControlAs<Literal>("litGrade");

                litGrade.Text = (_childGuidId == item.ID.ToGuid()) 
                    ? HighlightMatch(item.Name.Rendered) : item.Name.Rendered;
            }
        }

        private string HighlightMatch(string input)
        {
            return String.Format("<b>{0}</b>", input);
        }

        protected void rptArticleInterests_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ParentInterestItem item = (ParentInterestItem)e.Item.DataItem;

                Literal litInterest = e.FindControlAs<Literal>("litInterest");

                litInterest.Text = (_parentInterests.Contains(item.ID.ToGuid()))
                    ? HighlightMatch(item.InterestName.Rendered) : item.InterestName.Rendered;
            }
        }
    }
}