using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Users;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepOne : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NextButton.Text = NextButtonText;

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

            uxSelectGrade2.Items.AddRange(gradeList.ToArray());
            uxSelectGrade2.DataBind();

            uxSelectGrade3.Items.AddRange(gradeList.ToArray());
            uxSelectGrade3.DataBind();

            uxSelectGrade4.Items.AddRange(gradeList.ToArray());
            uxSelectGrade4.DataBind();

            uxSelectGrade5.Items.AddRange(gradeList.ToArray());
            uxSelectGrade5.DataBind();

            uxSelectGrade6.Items.AddRange(gradeList.ToArray());
            uxSelectGrade6.DataBind();
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            var children = new List<ChildModel>();

            if ((uxBoy1.Checked || uxGirl1.Checked) && uxSelectGrade1.SelectedValue != string.Empty)
            {
                registeringUser.Children.Add(new Domain.Membership.Child() { Grade = MembershipHelper.GetGrade(uxSelectGrade1.SelectedValue) });
                children.Add(new ChildModel() { Grade = uxSelectGrade1.SelectedValue, Pronoun = uxBoy1.Checked ? "he" : "she" });
            }

            if ((uxBoy2.Checked || uxGirl2.Checked) && uxSelectGrade2.SelectedValue != string.Empty)
            {
                registeringUser.Children.Add(new Domain.Membership.Child() { Grade = MembershipHelper.GetGrade(uxSelectGrade2.SelectedValue) });
                children.Add(new ChildModel() { Grade = uxSelectGrade2.SelectedValue, Pronoun = uxBoy2.Checked ? "he" : "she" });
            }

            if ((uxBoy3.Checked || uxGirl3.Checked) && uxSelectGrade3.SelectedValue != string.Empty)
            {
                registeringUser.Children.Add(new Domain.Membership.Child() { Grade = MembershipHelper.GetGrade(uxSelectGrade3.SelectedValue) });
                children.Add(new ChildModel() { Grade = uxSelectGrade3.SelectedValue, Pronoun = uxBoy3.Checked ? "he" : "she" });
            }

            if ((uxBoy4.Checked || uxGirl4.Checked) && uxSelectGrade4.SelectedValue != string.Empty)
            {
                registeringUser.Children.Add(new Domain.Membership.Child() { Grade = MembershipHelper.GetGrade(uxSelectGrade4.SelectedValue) });
                children.Add(new ChildModel() { Grade = uxSelectGrade4.SelectedValue, Pronoun = uxBoy4.Checked ? "he" : "she" });
            }

            if ((uxBoy5.Checked || uxGirl5.Checked) && uxSelectGrade5.SelectedValue != string.Empty)
            {
                registeringUser.Children.Add(new Domain.Membership.Child() { Grade = MembershipHelper.GetGrade(uxSelectGrade5.SelectedValue) });
                children.Add(new ChildModel() { Grade = uxSelectGrade5.SelectedValue, Pronoun = uxBoy5.Checked ? "he" : "she" });
            }

            if ((uxBoy6.Checked || uxGirl6.Checked) && uxSelectGrade6.SelectedValue != string.Empty)
            {
                registeringUser.Children.Add(new Domain.Membership.Child() { Grade = MembershipHelper.GetGrade(uxSelectGrade6.SelectedValue) });
                children.Add(new ChildModel() { Grade = uxSelectGrade6.SelectedValue, Pronoun = uxBoy6.Checked ? "he" : "she" });
            }

            Session["temp_child"] = children;

            Response.Redirect(MembershipHelper.GetNextStepURL(2));
        }
    }
}