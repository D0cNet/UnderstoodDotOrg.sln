using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Users;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Modals;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Modals
{
    public partial class AddAChild : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NextButtonStep1.InnerText = NextButtonText;
            AddAChildModalItem currentItem = Sitecore.Context.Item;
            NextButton.Text = NextButtonText;
            litBoy.Text = BoyButton;
            litGirl.Text = GirlButton;
            litYesButton.Text = YesButton;
            litNoButton.Text = NoButton;
            litInProgressText.Text = InProgressText;

            var gradeList = new List<ListItem>();

            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.SelectGrade, Value = null, Selected = true });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade1, Value = "1" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade2, Value = "2" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade3, Value = "3" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade4, Value = "4" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade5, Value = "5" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade6, Value = "6" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade7, Value = "7" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade8, Value = "8" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade9, Value = "9" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade10, Value = "10" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade11, Value = "11" });
            gradeList.Add(new ListItem() { Text = DictionaryConstants.Grades.Grade12, Value = "12" });

            uxSelectGrade1.Items.AddRange(gradeList.ToArray());
            uxSelectGrade1.DataBind();
            
            uxTroubleAreasTitle.Text = currentItem.TroubleAreasQuestionTitle.Rendered;
            uxEvaluatedTitle.Text = currentItem.FormallyEvaluatedQuestionTitle.Rendered;

            uxQ1a1.Text = Constants.Issues.ElementAt(0).Value;
            uxQ1a2.Text = Constants.Issues.ElementAt(1).Value;
            uxQ1a3.Text = Constants.Issues.ElementAt(2).Value;
            uxQ1a4.Text = Constants.Issues.ElementAt(3).Value;
            uxQ1a5.Text = Constants.Issues.ElementAt(4).Value;
            uxQ1a6.Text = Constants.Issues.ElementAt(5).Value;
            uxQ1a7.Text = Constants.Issues.ElementAt(6).Value;
            uxQ1a8.Text = Constants.Issues.ElementAt(7).Value;
            uxQ1a9.Text = Constants.Issues.ElementAt(8).Value;
            uxQ1a10.Text = Constants.Issues.ElementAt(9).Value;

            uxIEPquestion.Text = currentItem.IEPQuestionTitle.Rendered;
            ux504question.Text = currentItem.Section504PlanQuestionTitle.Rendered;

            var diagnosis = Sitecore.Context.Database.GetItem(Constants.DiagnosisContainer.ToString()).Children.ToList();

            // remove "All"
            diagnosis.RemoveAt(0);

            int split = (diagnosis.Count / 2);

            // make sure we get more on the left column if it's not exactly balanced
            if (diagnosis.Count % 2 == 1)
            {
                split++;
            }

            var leftList = diagnosis.Take(split);
            var rightList = diagnosis.Skip(split);

            uxLeftList.DataSource = leftList;
            uxLeftList.DataBind();

            uxRightList.DataSource = rightList;
            uxRightList.DataBind();

            var IEPstatus = Sitecore.Context.Database.GetItem(Constants.IEPStatusContainer.ToString()).Children.ToList();

            uxIEPStatus.DataSource = IEPstatus;
            uxIEPStatus.DataValueField = "Id";
            uxIEPStatus.DataTextField = "Name";
            uxIEPStatus.DataBind();

            var section504status = Sitecore.Context.Database.GetItem(Constants.Section504StatusContainer.ToString()).Children.ToList();

            ux504Status.DataSource = section504status;
            ux504Status.DataValueField = "Id";
            ux504Status.DataTextField = "Name";
            ux504Status.DataBind();

            // TODO: change to pull from dictionary
            var def = new ListItem() { Selected = true, Text = "Select One", Value = "" };

            uxIEPStatus.Items.Insert(0, def);
            ux504Status.Items.Insert(0, def);
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            var child = new Child();

            if ((uxBoy1.Checked || uxGirl1.Checked) && uxSelectGrade1.SelectedValue != string.Empty)
            {
                child.Grades.Add(new Grade() { Key = Constants.GradesByValue[uxSelectGrade1.SelectedValue] });
                child.Gender = uxBoy1.Checked ? "boy" : "girl";
                //CurrentMember.Children.Add(child);
            }
            
            var issues = new List<Issue>();

            if (q1a1.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(0).Key, Value = Constants.Issues.ElementAt(0).Value }); }
            if (q1a2.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(1).Key, Value = Constants.Issues.ElementAt(1).Value }); }
            if (q1a3.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(2).Key, Value = Constants.Issues.ElementAt(2).Value }); }
            if (q1a4.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(3).Key, Value = Constants.Issues.ElementAt(3).Value }); }
            if (q1a5.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(4).Key, Value = Constants.Issues.ElementAt(4).Value }); }
            if (q1a6.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(5).Key, Value = Constants.Issues.ElementAt(5).Value }); }
            if (q1a7.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(6).Key, Value = Constants.Issues.ElementAt(6).Value }); }
            if (q1a8.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(7).Key, Value = Constants.Issues.ElementAt(7).Value }); }
            if (q1a9.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(8).Key, Value = Constants.Issues.ElementAt(8).Value }); }
            if (q1a10.Checked) { issues.Add(new Issue() { Key = Constants.Issues.ElementAt(9).Key, Value = Constants.Issues.ElementAt(9).Value }); }

            child.Issues = issues;
            child.Nickname = ScreenNameTextBox.Text;
            // handle redirects
            if (!q2a1.Checked) // Has (child) been formally evauluated for ...
            {
                //BG: Set alternative child evaulation status
                if (q2a2.Checked)//BG: Child has not been evaluated
                {
                    child.EvaluationStatus = new Guid(Constants.ChildEvaluation.StatusEvaluationNo);
                }
                else if (q2a3.Checked)//BG: Child evaluation is in progress
                {
                    child.EvaluationStatus = new Guid(Constants.ChildEvaluation.StatusEvaluationInProgress);
                }
            }
            else
            {
                child.EvaluationStatus = new Guid(Constants.ChildEvaluation.StatusEvaluationYes);

                if (uxIEPStatus.SelectedValue != string.Empty)
                {
                    child.IEPStatus = Guid.Parse(uxIEPStatus.SelectedValue);
                }

                if (ux504Status.SelectedValue != string.Empty)
                {
                    child.Section504Status = Guid.Parse(ux504Status.SelectedValue);
                }

                foreach (var item in uxLeftList.Items)
                {
                    var check = item.FindControl("diagnosis") as CheckBox;
                    if (check != null && check.Checked)
                    {
                        child.Diagnoses.Add(new Domain.Membership.Diagnosis() { Key = Guid.Parse(check.Attributes["guid"]) });
                    }
                }

                foreach (var item in uxRightList.Items)
                {
                    var check = item.FindControl("diagnosis") as CheckBox;
                    if (check != null && check.Checked)
                    {
                        child.Diagnoses.Add(new Domain.Membership.Diagnosis() { Key = Guid.Parse(check.Attributes["guid"]) });
                    }
                }
            }

            CurrentMember.Children.Add(child);
            
            var membershipManager = new MembershipManager();

            membershipManager.UpdateMember(CurrentMember);

            Response.Redirect(MyProfileItem.GetMyProfilePage().InnerItem.GetUrl());
        }

        protected void ListItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var check = e.Item.FindControl("diagnosis") as CheckBox;
            var item = e.Item.DataItem as Sitecore.Data.Items.Item;

            if (check != null && item != null)
            {
                check.Attributes.Add("guid", item.ID.ToString());
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}