using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.Users;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepTwo : BaseRegistration<MyProfileStepTwoItem>
    {
        string status = "cmp"; //"cmp", "edit", "add"
        int index = 0;
        string pronoun = "your child";
        Child singleChild;

        #region Page_Load support
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString[Constants.QueryStrings.Registration.Mode]))
            {
                status = Request.QueryString[Constants.QueryStrings.Registration.Mode];
            }

            if (!string.IsNullOrEmpty(Request.QueryString[Constants.QueryStrings.Registration.ChildIndex]))
            {
                index = int.Parse(Request.QueryString[Constants.QueryStrings.Registration.ChildIndex]);
            }

            this.FillChild();

            if (!IsPostBack)
            {
                //don't do this, and we won't have anything to save...
                this.DoSetup();
            }
        }

        protected void FillChild()
        {
            switch (status)
            {
                case Constants.QueryStrings.Registration.ModeEdit:
                    //fill singleChild with selected child
                    if (CurrentMember != null && CurrentMember.Children != null && CurrentMember.Children.Count > 0)
                    {
                        singleChild = MembershipManager.trimFields(CurrentMember.Children.ElementAt(index));
                    }
                    else
                    {
                        MembershipManagerProxy mmp = new MembershipManagerProxy();
                        singleChild = mmp.GetChild(Guid.Empty);
                    }

                    break;
                case Constants.QueryStrings.Registration.ModeAdd:
                    //just new it up!
                    singleChild = new Child();
                    singleChild.Members.Add(new Member() { MemberId = this.CurrentMember.MemberId });

                    break;
                default:
                    //fill singleChild with next child to work on
                    foreach (var child in this.registeringUser.Children)
                    {
                        //has nickname and grade filled in, but no issues - next to work on
                        if (string.IsNullOrEmpty(child.Nickname) && child.Issues.Count == 0)
                        {
                            singleChild = MembershipManager.trimFields(child);
                            break;
                        }
                    }

                    break;
            }
        }

        protected void DoSetup()
        {
            //cast to ListItem so we can better map over fields for name/value
            var grades = GradeLevelItem.GetGrades().Select(x => new ListItem(x.Name, x.ID.ToString()));
            uxSelectGrade.DataSource = grades;
            uxSelectGrade.DataTextField = "Text";
            uxSelectGrade.DataValueField = "Value";
            uxSelectGrade.DataBind();

            switch (status)
            {
                case Constants.QueryStrings.Registration.ModeEdit:
                    this.SetupChildEdit();

                    break;
                case Constants.QueryStrings.Registration.ModeAdd:
                    this.SetupChildAdd();

                    break;
                default:
                    this.SetupCompleteMyProfile();

                    break;
            }

            NextButton.Text = NextButtonText;

            uxIssues.DataSource = ChildIssueItem.GetIssues();
            uxIssues.DataBind();

            uxTroubleAreasTitle.Text = Model.TroubleAreasQuestionTitle.Rendered.Replace("$pronoun$", pronoun);
            uxEvaluatedTitle.Text = Model.FormallyEvaluatedQuestionTitle.Rendered.Replace("$pronoun$", pronoun);
        }

        private string setPronoun(string gender)
        {
            return gender == "boy" ? "he" : "she";
        }

        protected void SetupCompleteMyProfile()
        {
            string grade = string.Empty;
            string gender = string.Empty;

            singleChild = this.registeringUser.Children.Where(x => x.Issues.Count == 0).FirstOrDefault();

            if (singleChild != null)
            {
                grade = Constants.GradesByGuid[singleChild.Grades.First().Key];
            }

            grade = UnderstoodDotOrg.Common.Helpers.MembershipHelper.AddOrdinalIndicator(grade);

            pronoun = setPronoun(singleChild.Gender);

            uxFormTitle.Text = Model.FormTitle.Rendered.Replace("$grade$", grade);
        }

        protected void SetupChildEdit()
        {
            this.ShowGradeAndGender();

            //fill in gender
            if (singleChild.Gender == "boy")
            {
                uxBoy.Checked = true;
            }
            else
            {
                uxGirl.Checked = true;
            }

            pronoun = setPronoun(singleChild.Gender);

            uxBoy.Enabled = false;
            uxGirl.Enabled = false;

            //fill in grade
            if (uxSelectGrade.Items.FindByText(singleChild.Grades.FirstOrDefault().Value) != null)
            {
                uxSelectGrade.ClearSelection();
                uxSelectGrade.Items.FindByText(singleChild.Grades.FirstOrDefault().Value).Selected = true;    
            }

            //fill in nickname
            ScreenNameTextBox.Text = singleChild.Nickname;
        }

        protected void SetupChildAdd()
        {
            this.ShowGradeAndGender();
        }

        protected void ShowGradeAndGender()
        {
            uxGenderAndGrade.Visible = true;
        }
        #endregion

        #region Save support
        protected void MapSingleChild()
        {
            //add gender, add/update grade
            if (status != "cmp")
            {
                if (status == Constants.QueryStrings.Registration.ModeAdd)
                {
                    //save gender
                    if (uxBoy.Checked)
                    {
                        singleChild.Gender = "boy";
                    }
                    else
                    {
                        singleChild.Gender = "girl";
                    }
                }

                //clear grades
                singleChild.Grades.Clear();

                //save selected grade
                singleChild.Grades.Add(new Grade() { Key = Guid.Parse(uxSelectGrade.SelectedValue) });
            }

            //save nickname
            singleChild.Nickname = ScreenNameTextBox.Text;

            //save eval status
            if (q2a1.Checked)
            {
                singleChild.EvaluationStatus = new Guid(Constants.ChildEvaluation.StatusEvaluationYes);
            }
            else
            {
                if (q2a2.Checked)//BG: Child has not been evaluated
                {
                    singleChild.EvaluationStatus = new Guid(Constants.ChildEvaluation.StatusEvaluationNo);
                }
                else if (q2a3.Checked)//BG: Child evaluation is in progress
                {
                    singleChild.EvaluationStatus = new Guid(Constants.ChildEvaluation.StatusEvaluationInProgress);
                }
            }

            //clear issues
            singleChild.Issues.Clear();

            //save selected issues
            foreach (var item in uxIssues.Items)
            {
                var checkbox = item.FindControl("uxIssueCheckbox") as CheckBox;
                var hidden = item.FindControl("uxIssueHidden") as HiddenField;

                if (checkbox.Checked)
                {
                    //singleChild.Issues.Add(new Issue() { Key = Guid.Parse(checkbox.Attributes["value"]) });
                    singleChild.Issues.Add(new Issue() { Key = Guid.Parse(hidden.Value) });
                }
            }

            SaveSingleChild();
        }

        protected void SaveSingleChild()
        {
            MembershipManager membershipManager = new MembershipManager();
            //MembershipManagerProxy membershipManager = new MembershipManagerProxy();
            if (status == Constants.QueryStrings.Registration.ModeEdit)
            {
                membershipManager.UpdateChild(singleChild);
            }
            else
            {
                membershipManager.AddChild(singleChild, this.CurrentMember.MemberId);
            }
        }

        //protected void SaveCompleteMyProfile()
        //{
        //    var c = this.registeringUser.Children.FirstOrDefault(x => x.ChildId == singleChild.ChildId);
        //    c = singleChild;
        //}

        protected void SetRegisteringUser()
        {
            FlushRegisteringUser();
            this.registeringUser = this.CurrentMember;
            this.registeringUser.Children.Clear();
            this.registeringUser.Children.Add(singleChild);
        }

        protected void DoNextStep()
        {
            string redirect = "/";

            if (singleChild.EvaluationStatus == Guid.Parse(Constants.ChildEvaluation.StatusEvaluationYes))
            {
                //eval = yes, always show page 3
                redirect = MyAccountFolderItem.GetCompleteMyProfileStepThree();

                //add current status to query string if present
                if (!string.IsNullOrEmpty(status))
                {
                    redirect += "?" + Constants.QueryStrings.Registration.Mode + "=" + status;
                }
            }
            else if (status == Constants.QueryStrings.Registration.ModeEdit || status == Constants.QueryStrings.Registration.ModeAdd)
            {
                //go back to my profile
                redirect = MyAccountFolderItem.GetMyProfilePage();
            }
            else
            {
                //CMP process
                if (this.registeringUser.Children.Where(x => x.Issues.Count == 0).Count() > 0)
                {
                    //more children, go to step 2
                    redirect = MyAccountFolderItem.GetCompleteMyProfileStepTwo();
                }
                else
                {
                    //no more children to deal with, go to step 4
                    redirect = MyAccountFolderItem.GetCompleteMyProfileStepFour();
                }
            }

            Response.Redirect(redirect);
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            this.MapSingleChild();

            if (status == Constants.QueryStrings.Registration.ModeEdit || status == Constants.QueryStrings.Registration.ModeAdd)
            {
                this.SetRegisteringUser();
            }

            this.DoNextStep();
        }
        #endregion

        protected void uxIssues_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var checkbox = e.Item.FindControl("uxIssueCheckbox") as CheckBox;
            var hidden = e.Item.FindControl("uxIssueHidden") as HiddenField;
            var item = ((ChildIssueItem)e.Item.DataItem);

            if (checkbox != null && hidden != null)
            {
                //if editing, check to see if this is already selected for the kid
                if (status == Constants.QueryStrings.Registration.ModeEdit)
                {
                    if (singleChild.Issues.ToList().Exists(x => x.Key == Guid.Parse(item.ID.ToString())))
                    {
                        checkbox.Checked = true;
                    }
                }

                //checkbox.Attributes.Add("value", ((ChildIssueItem)e.Item.DataItem).ID.ToString());
                hidden.Value = item.ID.ToString();
            }

        }
    }
}