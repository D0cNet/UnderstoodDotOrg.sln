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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About.Newsletter_Signup
{
    public partial class Newsletter_ChildInfo : BaseSublayout<ChildInformationPageItem>
    {
        private decimal _columnCount = 2;
        private int _entriesPerColumn;
        private IEnumerable<Item> _issues;

        protected void Page_Load(object sender, EventArgs e)
        {
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

        }

        void cvChildIssues_ServerValidate(object source, ServerValidateEventArgs args)
        {
            foreach (RepeaterItem ri in rptChildIssue.Items)
            {
                Repeater rptIssueCol = (Repeater)ri.FindControl("rptIssueCol");
                foreach (RepeaterItem issue in rptIssueCol.Items)
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

            rptChildIssue.DataSource = columns;
            rptChildIssue.DataBind();
        }

        protected void rptChildIssue_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                int columnIndex = e.Item.ItemIndex * _entriesPerColumn;

                Repeater rptIssueCol = e.FindControlAs<Repeater>("rptIssueCol");
                rptIssueCol.DataSource = _issues.Skip(columnIndex).Take(_entriesPerColumn).ToList();
                rptIssueCol.DataBind();
            }
        }



        protected void rptIssueCol_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ChildIssueItem issue = new ChildIssueItem((Item)e.Item.DataItem);
                Literal litChildIssue = e.FindControlAs<Literal>("litChildIssue");
                HiddenField hfChildIssue = e.FindControlAs<HiddenField>("hfChildIssue");
                litChildIssue.Text = issue.DisplayName;
                hfChildIssue.Value = issue.ID.ToString();
            }
        }
    }
}