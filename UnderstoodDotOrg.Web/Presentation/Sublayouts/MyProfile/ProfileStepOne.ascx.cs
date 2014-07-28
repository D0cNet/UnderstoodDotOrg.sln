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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepOne : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NextButton.Text = NextButtonText;

            FlushRegisteringUser();
            this.registeringUser = new Member();

            var gradeList = new List<ListItem>();
            
            foreach (var grade in GradeLevelItem.GetGrades())
            {
                gradeList.Add(new ListItem() { Text = grade.Name.Raw, Value = grade.ID.ToString() });
            }

            uxSelectGrade1.Items.AddRange(gradeList.ToArray());
            uxSelectGrade1.DataBind();
            uxSelectGrade1.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));

            uxSelectGrade2.Items.AddRange(gradeList.ToArray());
            uxSelectGrade2.DataBind();
            uxSelectGrade2.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));

            uxSelectGrade3.Items.AddRange(gradeList.ToArray());
            uxSelectGrade3.DataBind();
            uxSelectGrade3.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));

            uxSelectGrade4.Items.AddRange(gradeList.ToArray());
            uxSelectGrade4.DataBind();
            uxSelectGrade4.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));

            uxSelectGrade5.Items.AddRange(gradeList.ToArray());
            uxSelectGrade5.DataBind();
            uxSelectGrade5.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));

            uxSelectGrade6.Items.AddRange(gradeList.ToArray());
            uxSelectGrade6.DataBind();
            uxSelectGrade6.Items.Insert(0, new ListItem(DictionaryConstants.SelectGradeLabel, string.Empty));
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            if ((uxBoy1.Checked || uxGirl1.Checked) && uxSelectGrade1.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Guid.Parse(uxSelectGrade1.SelectedValue) });
                child.Gender = uxBoy1.Checked ? "boy" : "girl";
                registeringUser.Children.Add(child);
            }

            if ((uxBoy2.Checked || uxGirl2.Checked) && uxSelectGrade2.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Guid.Parse(uxSelectGrade2.SelectedValue) });
                child.Gender = uxBoy2.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy3.Checked || uxGirl3.Checked) && uxSelectGrade3.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Guid.Parse(uxSelectGrade3.SelectedValue) });
                child.Gender = uxBoy3.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy4.Checked || uxGirl4.Checked) && uxSelectGrade4.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Guid.Parse(uxSelectGrade4.SelectedValue) });
                child.Gender = uxBoy4.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy5.Checked || uxGirl5.Checked) && uxSelectGrade5.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Guid.Parse(uxSelectGrade5.SelectedValue) });
                child.Gender = uxBoy5.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy6.Checked || uxGirl6.Checked) && uxSelectGrade6.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Guid.Parse(uxSelectGrade6.SelectedValue) });
                child.Gender = uxBoy6.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if (registeringUser.Children.Count > 0)
            {
                // get info for each child
                Response.Redirect(MembershipHelper.GetNextStepURL(2));
            }
            else
            {
                // hey, you said you didn't have any children...
                Response.Redirect(MembershipHelper.GetNextStepURL(4));
            }
        }
    }
}