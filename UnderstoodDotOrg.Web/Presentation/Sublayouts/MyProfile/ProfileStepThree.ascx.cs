using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.Users;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepThree : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                        Nickname = "Bobby",
                        //IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
                        //Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
                        //Grade = Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"),
                        EvaluationStatus = Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"),
                        Issues = new List<Issue>() { 
                            new Issue() {
                                Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
                        //        Value = "Attention or Staying Focused"
                            }  
                        },
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

            NextButton.Text = NextButtonText;

            MyProfileStepThreeItem currentItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Item.ID);

            string nickname = string.Empty;
            string pronoun = string.Empty;

            List<ChildModel> children = Session["temp_child"] as List<ChildModel>;
            if (children != null)
            {
                nickname = children[0].Nickname;
                pronoun = children[0].Pronoun;
            }
            // testing code
            else
            {
                nickname = "bobby";
                pronoun = "he";

                Session["temp_child"] = new List<ChildModel>() { new ChildModel() { Pronoun = "he", Nickname = "bobby" }  };
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

            uxFormTitle.Text = currentItem.FormTitle.Rendered.Replace("$nickname$", nickname);
            uxIEPquestion.Text = currentItem.IEPQuestionTitle.Rendered.Replace("$pronoun$", pronoun);
            ux504question.Text = currentItem.Section504PlanQuestionTitle.Rendered.Replace("$pronoun$", pronoun);

            // TODO: put these somewhere better
            var diagnosis = Sitecore.Context.Database.GetItem("{A3955F76-4D6F-4CC0-8D3F-EECC01479EC7}").Children.ToList();

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

            // TODO: put these somewhere better
            var IEPstatus = Sitecore.Context.Database.GetItem("{D273E040-578D-4B1B-B0B1-E1256CB249EA}").Children.ToList();

            uxIEPStatus.DataSource = IEPstatus;
            uxIEPStatus.DataValueField = "Id";
            uxIEPStatus.DataTextField = "Name";
            uxIEPStatus.DataBind();

            // TODO: put these somewhere better
            var section504status = Sitecore.Context.Database.GetItem("{BDAAB8F1-8FEA-4E3D-AE6A-C436ACAEB366}").Children.ToList();

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
            List<ChildModel> children = Session["temp_child"] as List<ChildModel>;
            string redirect = "/";

            // fill in child infomation
            int index = 0;

            for (int i = 0; i < registeringUser.Children.Count; i++)
            {
                if (registeringUser.Children.ElementAt(i).Nickname == string.Empty)
                {
                    index = i - 1;
                    break;
                }
            }

            if (uxIEPStatus.SelectedValue != string.Empty)
            {
                registeringUser.Children.ElementAt(index).IEPStatus = Guid.Parse(uxIEPStatus.SelectedValue);
                
            }

            if (ux504Status.SelectedValue != string.Empty)
            {
                registeringUser.Children.ElementAt(index).Section504Status = Guid.Parse(ux504Status.SelectedValue);
            }

            foreach (var item in uxLeftList.Items)
            {
                var check = item.FindControl("diagnosis") as CheckBox;
                if (check != null && check.Checked)
                {
                    registeringUser.Children.ElementAt(index).Diagnoses.Add(new Domain.Membership.Diagnosis() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            foreach (var item in uxRightList.Items)
            {
                var check = item.FindControl("diagnosis") as CheckBox;
                if (check != null && check.Checked)
                {
                    registeringUser.Children.ElementAt(index).Diagnoses.Add(new Domain.Membership.Diagnosis() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }
            
            if (children.Count > 1)
            {
                children.RemoveAt(0);
                Session["temp_child"] = children;
                redirect = MembershipHelper.GetNextStepURL(2);
            }
            else
            {
                redirect = MembershipHelper.GetNextStepURL(4);
            }

            Response.Redirect(redirect);

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
    }
}
