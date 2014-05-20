using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages.Newsletter;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.Understood.Newsletter;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_ChildInfo : BaseSublayout<ChildInformationPageItem>
    {
        private decimal _columnCount = 2;
        private int _entriesPerColumn;
        private IEnumerable<Item> _issues;
        private Submission _submission;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!ChildInformationPageItem.HasValidSession(out _submission))
            {
                Item previous = Sitecore.Context.Database.GetItem(Constants.Pages.NewsletterSignup);
                if (previous != null)
                {
                    Response.Redirect(previous.GetUrl());
                }
                // TODO: redirect elsewhere?
                return;
            }
            BindContent();
            BindEvents();

            if (!IsPostBack)
            {
                PopulateRepeaters();
            }
        }

        private void BindEvents()
        {
            cvChildIssues.ServerValidate += cvChildIssues_ServerValidate;
            btnNext.Click += btnNext_Click;
        }

        private void BindContent()
        {
            btnNext.Text = DictionaryConstants.NextButtonText;
            rfvGrades.Text = Model.RequiredGradeError.Rendered;
            rfvNickname.Text = Model.RequiredNicknameError.Rendered;
            cvChildIssues.Text = Model.RequiredIssuesError.Rendered;
        }

        void btnNext_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            List<Guid> issues = new List<Guid>();
            foreach (RepeaterItem ci in rptColumns.Items)
            {
                Repeater rptChildIssues = (Repeater)ci.FindControl("rptChildIssues");
                foreach (RepeaterItem ic in rptChildIssues.Items)
                {
                    CheckBox cbChildIssue = (CheckBox)ic.FindControl("cbChildIssue");
                    HiddenField hfChildIssue = (HiddenField)ic.FindControl("hfChildIssue");
                    if (cbChildIssue.Checked)
                    {
                        issues.Add(Guid.Parse(hfChildIssue.Value));
                    }
                }
            }

            _submission.Children.Add(new Child
            {
                Nickname = txtNickname.Text.Trim(),
                Grade = Guid.Parse(ddlGrades.SelectedValue),
                Issues = issues
            });

            Item next = Sitecore.Context.Database.GetItem(Constants.Pages.NewsletterParentInterests);
            if (next == null) 
            {
                // TODO: handle error
                return;
            }

            // If another child, redirect to same form
            string destination = cbAnotherChild.Checked ? Model.GetUrl() : next.GetUrl();

            Response.Redirect(destination);
        }

        void cvChildIssues_ServerValidate(object source, ServerValidateEventArgs args)
        {
            foreach (RepeaterItem ri in rptColumns.Items)
            {
                Repeater rptChildIssues = (Repeater)ri.FindControl("rptChildIssues");
                foreach (RepeaterItem issue in rptChildIssues.Items)
                {
                    CheckBox cbChildIssue = (CheckBox)issue.FindControl("cbChildIssue");
                    if (cbChildIssue.Checked)
                    {
                        args.IsValid = true;
                        return;
                    }
                }
            }

            args.IsValid = false;
        }

        private void PopulateRepeaters()
        {
            // Grades
            ddlGrades.DataSource = FormHelper.GetGrades();
            ddlGrades.DataTextField = "Text";
            ddlGrades.DataValueField = "Value";
            ddlGrades.DataBind();

            // Create empty data set to create columns
            List<string> columns = new List<string>();
            for (int i = 0; i < _columnCount; i++)
            {
                columns.Add(String.Empty);
            }

            _issues = ChildInformationPageItem.GetAllIssues();
            _entriesPerColumn = (int)Math.Ceiling(_issues.Count() / _columnCount);

            rptColumns.DataSource = columns;
            rptColumns.DataBind();
        }

        protected void rptColumns_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                int columnIndex = e.Item.ItemIndex * _entriesPerColumn;

                Repeater rptChildIssues = e.FindControlAs<Repeater>("rptChildIssues");
                rptChildIssues.DataSource = _issues.Skip(columnIndex).Take(_entriesPerColumn).ToList();
                rptChildIssues.DataBind();
            }
        }



        protected void rptChildIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ChildIssueItem issue = new ChildIssueItem((Item)e.Item.DataItem);
                Literal litChildIssue = e.FindControlAs<Literal>("litChildIssue");
                HiddenField hfChildIssue = e.FindControlAs<HiddenField>("hfChildIssue");
                litChildIssue.Text = issue.IssueName;
                hfChildIssue.Value = issue.ID.ToString();
            }
        }
    }
}