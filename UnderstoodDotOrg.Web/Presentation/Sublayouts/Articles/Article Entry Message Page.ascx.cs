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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Article_Entry_Message_Page : BaseSublayout
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Entry Message"] == null && CameFromOutsideSite() && Sitecore.Context.Item.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                Item content = MainsectionItem.GetGlobals().GetArticleEntryMessagesFolder().GetArticleEntryMessageContentItem();
                frContent.Item = content;
                frChildEnrolledLabel.Item = content;
                frChildNeedsHelpLabel.Item = content;
                frChildsNameIs.Item = content;
                frChildsNameLabel.Item = content;
                frCloseLabel.Item = content;
                frContent.Item = content;
                frNoThanksButtonLabel.Item = content;
                frPersonalizeLabel.Item = content;
                frPersonalizeLabel2.Item = content;
                frSubmitButtonLabel.Item = content;
                frYesButtonLabel.Item = content;

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

                setCookie("Entry Message", "viewed");
            }
            else
                this.Visible = false;
        }

        private bool CameFromOutsideSite()
        {
            if (Request.UrlReferrer != null)
            {
                return !Request.UrlReferrer.ToString().Contains(HttpContext.Current.Request.Url.Host);
            }
            return true;
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
            // Response.Redirect(FormHelper.GetRecommendationUrl());
        }
    }
}