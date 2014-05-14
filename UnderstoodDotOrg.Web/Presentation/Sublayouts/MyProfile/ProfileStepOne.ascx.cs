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

            // testing code
            if (registeringUser == null)
            {
                registeringUser = new Member()
                {
                    FirstName = "Testing",
                    LastName = "User",
                    ScreenName = "JustTesting",
                    ZipCode = "12345",
                    //Role = Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}"),
                    //HomeLife = Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"),
                    //PersonalityType = Guid.Parse("{8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983}"),
                    //hasOtherChildren = false,
                    //allowConnections = false,
                    //allowNewsletter = false,
                    //isPrivate = false,
                    //Interests = new List<Interest>() {
                    //new Interest() {
                    //    Key = Guid.Parse("{26A98810-4539-4BB7-8D6F-43CFE075AED3}"),
                    //    CategoryName = "Technologies and Apps",
                    //    Value = "Apps",
                    //  }
                    //},
                    Children = new List<Child>() { 
                    //new Child() {
                        //Nickname = "Bobby",
                        //IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                        //Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                        //Grade = Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"),
                        //EvaluationStatus = Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"),
                        //Issues = new List<Issue>() { 
                        //    new Issue() {
                        //        Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
                        //        Value = "Attention or Staying Focused"
                        //    }  
                        //},
                        //Diagnoses = new List<Diagnosis>() { 
                        //    new Diagnosis() {
                        //        Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
                        //        Value = "ADHD"
                        //    }
                        //},                
                    //}
                },
                };
            }

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
           
            if ((uxBoy1.Checked || uxGirl1.Checked) && uxSelectGrade1.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Constants.GradesByValue[uxSelectGrade1.SelectedValue] });
                child.Gender = uxBoy1.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy2.Checked || uxGirl2.Checked) && uxSelectGrade2.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Constants.GradesByValue[uxSelectGrade2.SelectedValue] });
                child.Gender = uxBoy2.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy3.Checked || uxGirl3.Checked) && uxSelectGrade3.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Constants.GradesByValue[uxSelectGrade3.SelectedValue] });
                child.Gender = uxBoy3.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy4.Checked || uxGirl4.Checked) && uxSelectGrade4.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Constants.GradesByValue[uxSelectGrade4.SelectedValue] });
                child.Gender = uxBoy4.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy5.Checked || uxGirl5.Checked) && uxSelectGrade5.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Constants.GradesByValue[uxSelectGrade5.SelectedValue] });
                child.Gender = uxBoy5.Checked ? "boy" : "girl";

                registeringUser.Children.Add(child);
            }

            if ((uxBoy6.Checked || uxGirl6.Checked) && uxSelectGrade6.SelectedValue != string.Empty)
            {
                var child = new Child();

                child.Grades.Add(new Grade() { Key = Constants.GradesByValue[uxSelectGrade6.SelectedValue] });
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