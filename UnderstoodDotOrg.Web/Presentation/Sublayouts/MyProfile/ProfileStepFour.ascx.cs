using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Globalization;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Salesforce;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Services.ExactTarget;
using UnderstoodDotOrg.Domain.TelligentCommunity;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepFour : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (registeringUser == null)
            //{
            //    registeringUser = new Member()
            //    {
            //        FirstName = "Testing",
            //        LastName = "User",
            //        ScreenName = "JustTesting",
            //        ZipCode = "12345",
            //        //Role = Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}"),
            //        //HomeLife = Guid.Parse("{8FFA90D9-F2DA-402D-9AC4-7C203769C810}"),
            //        //PersonalityType = Guid.Parse("{8B7EB70D-64B2-45B9-B06E-6AA5CB6FE983}"),
            //        //hasOtherChildren = false,
            //        //allowConnections = false,
            //        //allowNewsletter = false,
            //        //isPrivate = false,
            //        //Interests = new List<Interest>() {
            //        //new Interest() {
            //        //    Key = Guid.Parse("{26A98810-4539-4BB7-8D6F-43CFE075AED3}"),
            //        //    CategoryName = "Technologies and Apps",
            //        //    Value = "Apps",
            //        //  }
            //        //},
            //        Children = new List<Child>() { 
            //        new Child() {
            //            Nickname = "Bobby",
            //            IEPStatus = Guid.Parse("{73842143-B6CA-4B6A-A94F-BA59C475A6D7}"),
            //            Section504Status = Guid.Parse("{82102C70-B526-47FB-BD99-5F71A33C3C87}"),
            //            //Grade = Guid.Parse("{DFF0FA84-B68E-4259-A107-274B5694247D}"),
            //            EvaluationStatus = Guid.Parse("{F6849A63-C841-4D79-BF53-AA68DA6D6EEB}"),
            //            Issues = new List<Issue>() { 
            //                new Issue() {
            //                    Key = Guid.Parse("{FFB5F34E-5A5F-43C6-A987-9AFF713C66C9}"),
            //            //        Value = "Attention or Staying Focused"
            //                }  
            //            },
            //            Diagnoses = new List<Diagnosis>() { 
            //                new Diagnosis() {
            //                    Key = Guid.Parse("{7A035CC2-D6BD-4332-9518-7AB22083F652}"),
            //            //        Value = "ADHD"
            //                }
            //            },                
            //        }
            //    },
            //    };
            //}
            if (!IsPostBack)
            {
                ScreenNameTextField.Text = DictionaryConstants.ScreenNameWatermark;
                ZipCodeTextField.Text = DictionaryConstants.ZipCodeWatermark;
                SubmitButton.Text = DictionaryConstants.SubmitButtonText;
            }
            
            string schoolIssueContainer = Constants.SchoolIssueContainer.ToString();
            string homeLifeContainer = Constants.HomeLifeContainer.ToString();
            string growingUpContainer = Constants.GrowingUpContainer.ToString();
            string socialEmotionalContainer = Constants.SocialEmotionalContainer.ToString();
            string techAppsContainer = Constants.TechAppsContainer.ToString();
            string waysToHelpContainer = Constants.WaysToHelpContainer.ToString();
            string parentRolesContainer = "{E5F45505-9153-4AA3-BFCC-04F3808E8AC5}";
            string parentJourneyContainer = "{40D1F458-746D-4649-A03E-E3729F6C9117}";

            var schoolIssues = Sitecore.Context.Database.GetItem(schoolIssueContainer).Children.ToList();

            uxSchoolLeft.DataSource = schoolIssues.Take(schoolIssues.Count / 2);
            uxSchoolLeft.DataBind();

            uxSchoolRight.DataSource = schoolIssues.Skip(schoolIssues.Count / 2);
            uxSchoolRight.DataBind();

            var homeLife = Sitecore.Context.Database.GetItem(homeLifeContainer).Children.ToList();

            uxHomeLife.DataSource = homeLife;
            uxHomeLife.DataBind();

            var growingUp = Sitecore.Context.Database.GetItem(growingUpContainer).Children.ToList();

            uxGrowingUp.DataSource = growingUp;
            uxGrowingUp.DataBind();

            var socialEmotional = Sitecore.Context.Database.GetItem(socialEmotionalContainer).Children.ToList();

            uxSocialEmotional.DataSource = socialEmotional;
            uxSocialEmotional.DataBind();

            var techApps = Sitecore.Context.Database.GetItem(techAppsContainer).Children.ToList();
            var waysToHelp = Sitecore.Context.Database.GetItem(waysToHelpContainer).Children.ToList();

            uxWaysToHelp.DataSource = waysToHelp;
            uxWaysToHelp.DataBind();

            var parentJourney = Sitecore.Context.Database.GetItem(parentJourneyContainer).Children.ToList();

            uxJourney.DataSource = parentJourney;
            uxJourney.DataBind();

            var parentRoles = Sitecore.Context.Database.GetItem(parentRolesContainer).Children.ToList();
            uxFather.Text = parentRoles[0].Fields["Role Name"].Value;
            uxMother.Text = parentRoles[1].Fields["Role Name"].Value;

            uxParentList.DataSource = parentRoles.Skip(2);
            uxParentList.DataTextField = "Fields[Role Name]";
            uxParentList.DataValueField = "Id";
            uxParentList.DataBind();

            uxParentList.Items.Insert(0, new ListItem() { Text = DictionaryConstants.ParentRoleDefault, Value = null });
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            foreach (var item in uxSchoolLeft.Items)
            {
                var check = item.FindControl("interest") as CheckBox;
                if (check != null && check.Checked)
                {
                    this.registeringUser.Interests.Add(new Domain.Membership.Interest() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            foreach (var item in uxSchoolRight.Items)
            {
                var check = item.FindControl("interest") as CheckBox;
                if (check != null && check.Checked)
                {
                    this.registeringUser.Interests.Add(new Domain.Membership.Interest() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            foreach (var item in uxWaysToHelp.Items)
            {
                var check = item.FindControl("interest") as CheckBox;
                if (check != null && check.Checked)
                {
                    registeringUser.Interests.Add(new Domain.Membership.Interest() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            foreach (var item in uxGrowingUp.Items)
            {
                var check = item.FindControl("interest") as CheckBox;
                if (check != null && check.Checked)
                {
                    this.registeringUser.Interests.Add(new Domain.Membership.Interest() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            foreach (var item in uxHomeLife.Items)
            {
                var check = item.FindControl("interest") as CheckBox;
                if (check != null && check.Checked)
                {
                    this.registeringUser.Interests.Add(new Domain.Membership.Interest() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            foreach (var item in uxSocialEmotional.Items)
            {
                var check = item.FindControl("interest") as CheckBox;
                if (check != null && check.Checked)
                {
                    this.registeringUser.Interests.Add(new Domain.Membership.Interest() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            foreach (var item in uxJourney.Items)
            {
                var check = item.FindControl("interest") as RadioButton;
                if (check != null && check.Checked)
                {
                    //registeringUser.Interests.Add(new Domain.Membership.Interest() { Key = Guid.Parse(check.Attributes["guid"]) });
                    this.registeringUser.Journeys.Add(new Journey() { Key = Guid.Parse(check.Attributes["guid"]) });
                }
            }

            if (uxMotherButton.Checked || uxFatherButton.Checked || uxParentList.SelectedIndex > 0)
            {
                if (uxMotherButton.Checked)
                {
                    this.registeringUser.Role = Guid.Parse("{890F06AF-284E-43E1-9647-0EFEEB000526}");
                }
                else
                {
                    if (uxFatherButton.Checked)
                    {
                        this.registeringUser.Role = Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}");
                    }
                    else
                    {
                        this.registeringUser.Role = Guid.Parse(uxParentList.SelectedValue);
                    }
                }
            }

            //bg: verify that this is working:
            this.registeringUser.ScreenName = ScreenNameTextField.Text;

            if (string.IsNullOrEmpty(registeringUser.ZipCode) && !string.IsNullOrEmpty(ZipCodeTextField.Text))
            {
                this.registeringUser.ZipCode = ZipCodeTextField.Text;
            }

            var membershipManager = new MembershipManager();
            //membershipManager.AddMember(registeringUser);
            membershipManager.UpdateMember(this.registeringUser);



            //set current user stuff
            this.CurrentMember = this.registeringUser;
            this.CurrentUser = membershipManager.GetUser(this.CurrentMember.MemberId);

            
            
            //updating salesforce
            SalesforceManager sfMgr = new SalesforceManager("brettgarnier@outlook.com", 
                                                            "8f9C3Ayq", 
                                                            "hlY0jOIILtogz3sQlLUtmERlu");
            if (sfMgr.LoggedIn)
            {
                try
                {
                    SalesforceActionResult result = sfMgr.CreateWebsiteMemberAsContact(this.CurrentMember, CurrentUser.Email);
                    if (result.Success == false)
                    {                     
                        Response.Write("<!-- Error 401 -->");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<!-- Error 501 -->");
                }
            }
            else
            {
                Response.Write("<!-- Error 601 -->");
            }

            
            // *BG: AIGHT STOP COMMENTING THIS OUT YOU HOUNDS*/

            //send an email through exact target 
			BaseReply reply = ExactTargetService.InvokeWelcomeToUnderstood(new InvokeWelcomeToUnderstoodRequest { ToEmail = CurrentUser.Email, FirstName = CurrentMember.FirstName });

            ////run personalization for this user
            Handlers.RunPersonalizationService rps = new Handlers.RunPersonalizationService();
            rps.UpdateMember(CurrentMember);

            //pulling this out of membership manager for now until we find the best place. 
            //It had been in AddMember berfore but there is no screen name available when we Add a member.
            //create Telligent user:
            if (!string.IsNullOrEmpty(CurrentMember.ScreenName))
            {
                bool communitySuccess = CommunityHelper.CreateUser(CurrentMember.ScreenName, CurrentUser.Email);
                if (communitySuccess == false)
                {
                    // ¡Ay, caramba!

                }
            }
            Response.Redirect(MembershipHelper.GetNextStepURL(5));
        }

        protected void ListItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var check = e.Item.FindControl("interest") as CheckBox;
            var item = e.Item.DataItem as Sitecore.Data.Items.Item;

            if (check != null && item != null)
            {
                check.Attributes.Add("guid", item.ID.ToString());
            }
        }
    }
}