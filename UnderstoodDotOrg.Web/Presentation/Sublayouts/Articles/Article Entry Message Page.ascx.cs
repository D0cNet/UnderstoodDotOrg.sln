using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Domain.Membership;
using System.Web.UI.HtmlControls;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Article_Entry_Message_Page : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            frContent.Item = DataSource;
            frChildEnrolledLabel.Item = DataSource;
            frChildNeedsHelpLabel.Item = DataSource;
            frChildsNameIs.Item = DataSource;
            frChildsNameLabel.Item = DataSource;
            frCloseLabel.Item = DataSource;
            frContent.Item = DataSource;
            frNoThanksButtonLabel.Item = DataSource;
            frPersonalizeLabel.Item = DataSource;
            frPersonalizeLabel2.Item = DataSource;
            frSubmitButtonLabel.Item = DataSource;
            frYesButtonLabel.Item = DataSource;

            var childIssues = FormHelper.GetIssues();
            rptChildIssues.Visible = true;
            rptChildIssues.DataSource = childIssues;
            rptChildIssues.DataBind();

            var grades = FormHelper.GetGrades();
            ddlGrade.DataSource = grades.Select(g => new ListItem
            {
                Text = g.Name.Raw,
                Value = g.ID.ToString()
            });
            ddlGrade.DataTextField = "Text";
            ddlGrade.DataValueField = "Value";
            ddlGrade.DataBind();
        }

        protected void rptChildIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ChildIssueItem childIssueItem = e.Item.DataItem as ChildIssueItem;

                HtmlInputCheckBox inputIssue = e.FindControlAs<HtmlInputCheckBox>("inputIssue");
                Literal litIssueName = e.FindControlAs<Literal>("litIssueName");
                inputIssue.Attributes.Add("data-id", childIssueItem.ID.ToString());
                litIssueName.Text = childIssueItem.IssueName.Raw;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string selectedGrade = ddlGrade.SelectedValue;

            if (String.IsNullOrEmpty(selectedGrade))
            {
                return;
            }

            // TODO: verify if it's ok to clear out unauthenticated user
            Member member = new Member();

            Child child = new Child();
            // TODO: replace child name
            child.Nickname = txtChildName.Text;

            child.ChildId = Guid.NewGuid();

            if (!string.IsNullOrEmpty(hfIssues.Value))
            {
                string[] IDs = hfIssues.Value.Split('|');

                foreach (string s in IDs)
                {
                    ChildIssueItem cii = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(s));
                    if (cii != null)
                    {
                        child.Issues.Add(new Issue
                        {
                            Key = Guid.Parse(cii.ID.ToString()),
                            Value = cii.IssueName.Raw
                        });
                    }
                }
            }

            GradeLevelItem gradeItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(selectedGrade));
            if (gradeItem != null)
            {
                child.Grades.Add(new Grade
                {
                    Key = Guid.Parse(selectedGrade),
                    Value = gradeItem.Name.Raw
                });
            }

            member.Children.Add(child);
            UnauthenticatedSessionMember = member;

            // TODO: return unauthenticated users to different results page
            Response.Redirect(FormHelper.GetRecommendationUrl());
        }
    }
}