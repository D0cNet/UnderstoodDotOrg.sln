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

            string childGrade = string.Empty;

            var grade = child.Grades.FirstOrDefault();
            if (grade != null)
            {
                GradeLevelItem gli = Sitecore.Context.Database.GetItem(grade.Key);
                if (gli != null)
                {
                    childGrade = gli.Name.Rendered;
                }
            }

            litChild.Text = String.Format("{0} ({1})", child.Nickname, childGrade);
            
            var articles = SearchHelper.GetArticles(child.Members.FirstOrDefault(), child, DateTime.Now)
                                .Where(i => i.GetItem() != null);
            if (articles.Any())
            {
                rptArticles.DataSource = articles;
                rptArticles.DataBind();
            }

            var issues = child.Issues.Select(i => Sitecore.Context.Database.GetItem(i.Key))
                                .Where(i => i != null)
                                .Select(i => new ChildIssueItem(i));
            if (issues.Any())
            {
                rptIssues.DataSource = issues;
                rptIssues.DataBind();
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
    }
}