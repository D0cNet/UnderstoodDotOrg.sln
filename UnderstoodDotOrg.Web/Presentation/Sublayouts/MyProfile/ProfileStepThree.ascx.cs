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
    public partial class ProfileStepThree : BaseRegistration<MyProfileStepThreeItem>
    {
        string status = "cmp";
        Child singleChild;

        protected void Page_Load(object sender, EventArgs e)
        {
            NextButton.Text = NextButtonText;

            if (!string.IsNullOrEmpty(Request.QueryString[Constants.QueryStrings.Registration.Mode]))
            {
                status = Request.QueryString[Constants.QueryStrings.Registration.Mode];
            }

            //MyProfileStepThreeItem Model = Sitecore.Context.Database.GetItem(Sitecore.Context.Item.ID);            
            this.FillChild();

            if (!IsPostBack)
            {
                //don't do this, and we won't have anything to save...
                this.DoSetup();
            }
            
        }

        protected void FillChild()
        {
            singleChild = this.registeringUser.Children.Where(x => !string.IsNullOrEmpty(x.Nickname)).Last();
        }

        protected void DoSetup()
        {
            string nickname = string.Empty;
            string gender = string.Empty;


            if (singleChild != null)
            {
                nickname = singleChild.Nickname;
                gender = singleChild.Gender;
            }

            //add possession!
            if (nickname.EndsWith("s"))
            {
                nickname += "'";
            }
            else
            {
                nickname += "'s";
            }

            var pronoun = gender == "boy" ? "he" : "she";

            uxFormTitle.Text = Model.FormTitle.Rendered.Replace("$nickname$", nickname);
            uxIEPquestion.Text = Model.IEPQuestionTitle.Rendered.Replace("$pronoun$", pronoun);
            ux504question.Text = Model.Section504PlanQuestionTitle.Rendered.Replace("$pronoun$", pronoun);

            //var diagnosis = Sitecore.Context.Database.GetItem(Constants.DiagnosisContainer.ToString()).Children.ToList();
            var diagnosis = ChildDiagnosisItem.GetDiagnoses();

            int split = (diagnosis.Count() / 2);

            // make sure we get more on the left column if it's not exactly balanced
            if (diagnosis.Count() % 2 == 1)
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

            if (status == Constants.QueryStrings.Registration.ModeEdit)
            {
                //trust me, I hate that I have to stringify this to make it work...
                try
                {
                    var IEP = uxIEPStatus.Items.FindByValue("{" + singleChild.IEPStatus.ToString().ToUpper() + "}");
                    if (IEP != null)
                    {
                        //only clear selection if we have a match
                        uxIEPStatus.ClearSelection();
                        IEP.Selected = true;
                    }
                }
                catch (Exception)
                { }

                try
                {
                    var s504 = ux504Status.Items.FindByValue("{" + singleChild.Section504Status.ToString().ToUpper() + "}");
                    if (s504 != null)
                    {
                        ux504Status.ClearSelection();
                        s504.Selected = true;
                    }
                }
                catch (Exception)
                { }

            }
        }

        protected void DoNextStep()
        {
            string redirect = "/";

            //if here via edit OR add
            if (status == Constants.QueryStrings.Registration.ModeAdd || status == Constants.QueryStrings.Registration.ModeEdit)
            {
                redirect = MyAccountFolderItem.GetMyProfilePage();
            }
            else if (this.registeringUser.Children.Where(x => x.Issues.Count == 0).Count() > 0)
            {
                redirect = MyAccountFolderItem.GetCompleteMyProfileStepTwo();
            }
            else
            {
                redirect = MyAccountFolderItem.GetCompleteMyProfileStepFour();
            }

            //move onto next step
            Response.Redirect(redirect);
        }

        protected void SaveChild()
        {
            //if (status == Constants.QueryStrings.Registration.ModeAdd || status == Constants.QueryStrings.Registration.ModeEdit)
            //{
            //    singleChild = registeringUser.Children.FirstOrDefault();
            //}
            //else
            //{
            //    // fill in child infomation
            //    int index = 0;

            //    for (int i = 0; i < registeringUser.Children.Count; i++)
            //    {
            //        if (registeringUser.Children.ElementAt(i).Nickname == string.Empty)
            //        {
            //            index = i - 1;
            //            break;
            //        }
            //    }

            //    singleChild = registeringUser.Children.ElementAt(index);
            //}

            if (uxIEPStatus.SelectedValue != string.Empty)
            {
                singleChild.IEPStatus = Guid.Parse(uxIEPStatus.SelectedValue);

            }

            if (ux504Status.SelectedValue != string.Empty)
            {
                singleChild.Section504Status = Guid.Parse(ux504Status.SelectedValue);
            }

            singleChild.Diagnoses.Clear();

            foreach (var item in uxLeftList.Items)
            {
                var check = item.FindControl("diagnosis") as CheckBox;
                var hidden = item.FindControl("diagnosisHidden") as HiddenField;
                
                if (check != null && check.Checked && hidden != null)
                {
                    singleChild.Diagnoses.Add(new Domain.Membership.Diagnosis() { Key = Guid.Parse(hidden.Value) });
                }
            }

            foreach (var item in uxRightList.Items)
            {
                var check = item.FindControl("diagnosis") as CheckBox;
                var hidden = item.FindControl("diagnosisHidden") as HiddenField;

                if (check != null && check.Checked && hidden != null)
                {
                    singleChild.Diagnoses.Add(new Domain.Membership.Diagnosis() { Key = Guid.Parse(hidden.Value) });
                }
            }

            var membershipManager = new MembershipManager();

            // update the member
            membershipManager.UpdateChild(singleChild);
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            this.SaveChild();
            this.DoNextStep();
        }

        protected void ListItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var check = e.Item.FindControl("diagnosis") as CheckBox;
            var hidden = e.Item.FindControl("diagnosisHidden") as HiddenField;
            var item = e.Item.DataItem as UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child.ChildDiagnosisItem;

            if (check != null && item != null && hidden != null)
            {
                if (status == Constants.QueryStrings.Registration.ModeEdit)
                {
                    if (singleChild.Diagnoses.ToList().Exists(x => x.Key == Guid.Parse(item.ID.ToString())))
                    {
                        check.Checked = true;
                    }
                }
                
                //check.Attributes.Add("guid", item.ID.ToString());
                hidden.Value = item.ID.ToString();
            }
        }
    }
}
