using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.Users;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepTwo : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NextButton.Text = NextButtonText;

            MyProfileStepTwoItem currentItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Item.ID);

            string grade = string.Empty;
            string pronoun = string.Empty;

            List<ChildModel> children = Session["temp_child"] as List<ChildModel>;
            if (children != null)
            {
                grade = children.First().Grade;
                pronoun = children.First().Pronoun;
            }
            // testing code
            else
            {
                grade = "3";
                pronoun = "he";

                Session["temp_child"] = new List<ChildModel>() { new ChildModel() { Grade = "3", Pronoun = "he" }  };
            }

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
                    new Child() {
                        //Nickname = "Bobby",
                        //IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                        //Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                        Grade = Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"),
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
                    }
                },
                };
            }

            switch (grade)
            {
                case "1":
                    grade += "st";
                    break;
                case "2":
                    grade += "nd";
                    break;
                case "3":
                    grade += "rd";
                    break;
                default:
                    grade += "th";
                    break;
            }

            uxFormTitle.Text = currentItem.FormTitle.Rendered.Replace("$grade$", grade);
            uxTroubleAreasTitle.Text = currentItem.TroubleAreasQuestionTitle.Rendered.Replace("$pronoun$", pronoun);
            uxEvaluatedTitle.Text = currentItem.FormallyEvaluatedQuestionTitle.Rendered.Replace("$pronoun$", pronoun);

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
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            List<ChildModel> children = Session["temp_child"] as List<ChildModel>;
            string redirect = "/";

            // fill in child infomation
            int index = 0;

            for (int i = 0; i < registeringUser.Children.Count; i++)
            {
                if (registeringUser.Children.ElementAt(i).Issues.Count == 0)
                {
                    index = i;
                    break;
                }
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

            registeringUser.Children.ElementAt(index).Issues = issues;
            registeringUser.Children.ElementAt(index).Nickname = ScreenNameTextBox.Text;

            // handle redirects
            if (q2a1.Checked)
            {
                redirect = MembershipHelper.GetNextStepURL(3);
                children[0].Nickname = ScreenNameTextBox.Text;
                Session["temp_child"] = children;
            }
            else
            {
                if (children.Count > 1)
                {
                    redirect = MembershipHelper.GetNextStepURL(2);
                    children.RemoveAt(0);
                    Session["temp_child"] = children;
                }
                else
                {
                    redirect = MembershipHelper.GetNextStepURL(4);
                }
            }

            Response.Redirect(redirect);
            //Response.Write(redirect);
        }
    }
}