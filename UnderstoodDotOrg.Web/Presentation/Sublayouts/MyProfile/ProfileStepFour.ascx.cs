using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Globalization;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Salesforce;
using UnderstoodDotOrg.Domain.ExactTarget;
using UnderstoodDotOrg.Services.ExactTarget;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepFour : BaseRegistration
    {
        private string mode = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            mode = Request.QueryString[Constants.QueryStrings.Registration.Mode];

            string schoolIssueContainer = Constants.SchoolIssueContainer.ToString();
            string homeLifeContainer = Constants.HomeLifeContainer.ToString();
            string growingUpContainer = Constants.GrowingUpContainer.ToString();
            string socialEmotionalContainer = Constants.SocialEmotionalContainer.ToString();
            string techAppsContainer = Constants.TechAppsContainer.ToString();
            string waysToHelpContainer = Constants.WaysToHelpContainer.ToString();
            string parentRolesContainer = "{E5F45505-9153-4AA3-BFCC-04F3808E8AC5}";
            string parentJourneyContainer = "{40D1F458-746D-4649-A03E-E3729F6C9117}";

            if (!IsPostBack)
            {
                this.registeringUser = CurrentMember;
                ScreenNameTextField.Text = DictionaryConstants.ScreenNameWatermark;
                ZipCodeTextField.Text = DictionaryConstants.ZipCodeWatermark;
                SubmitButton.Text = DictionaryConstants.SubmitButtonText;

                if (mode == Constants.QueryStrings.Registration.ModeEdit)
                {
                    divProgressBar.Visible = false;
                    if (!string.IsNullOrEmpty(registeringUser.ScreenName))
                    {
                        ScreenNameTextField.Text = this.registeringUser.ScreenName;
                    }
                    if (!string.IsNullOrEmpty(registeringUser.ZipCode))
                    {
                        ZipCodeTextField.Text = this.registeringUser.ZipCode;
                    }

                    if (this.registeringUser.Role != null)
                    {
                        if (this.registeringUser.Role == Guid.Parse("{890F06AF-284E-43E1-9647-0EFEEB000526}"))
                        {
                            uxMotherButton.Checked = true;
                        }
                        else
                        {
                            if (this.registeringUser.Role == Guid.Parse("{2BF9D7BE-2E40-432C-ADE7-A25C80B9B9EE}"))
                            {
                                uxFatherButton.Checked = true;
                            }
                            else
                            {
                                if (uxParentList.Items.FindByValue(this.registeringUser.Role.ToString()) != null)
                                {
                                    uxParentList.ClearSelection();
                                    uxParentList.Items.FindByValue(this.registeringUser.Role.ToString()).Selected = true;
                                }
                            }
                        }
                    }

                    if (this.registeringUser.allowConnections)
                    {
                        cbConnections.Checked = true;
                    }

                    if (this.registeringUser.allowNewsletter)
                    {
                        cbNewsLetter.Checked = true;
                    }
                }



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
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            this.registeringUser.Interests.Clear();
            this.registeringUser.Journeys.Clear();

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

            if (cbConnections.Checked)
            {
                this.registeringUser.allowConnections = true;
            }

            if (cbNewsLetter.Checked)
            {
                this.registeringUser.allowNewsletter = true;
            }
            //bg: verify that this is working:
            this.registeringUser.ScreenName = ScreenNameTextField.Text;

            if (string.IsNullOrEmpty(registeringUser.ZipCode) && !string.IsNullOrEmpty(ZipCodeTextField.Text))
            {
                this.registeringUser.ZipCode = ZipCodeTextField.Text;
            }

            var membershipManager = new MembershipManager();

            //set current user/member
            this.CurrentMember = membershipManager.UpdateMember(this.registeringUser);
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
                catch (Exception)
                {
                    Response.Write("<!-- Error 501 -->");
                }
            }
            else
            {
                Response.Write("<!-- Error 601 -->");
            }

            //send an email through exact target.
            BaseReply reply = ExactTargetService.InvokeWelcomeToUnderstood(new InvokeWelcomeToUnderstoodRequest { ToEmail = CurrentUser.Email, FirstName = CurrentMember.FirstName });


            ////run personalization for this user
            Handlers.RunPersonalizationService rps = new Handlers.RunPersonalizationService();
            rps.UpdateMember(CurrentMember);

            //pulling this out of membership manager for now until we find the best place. 
            //It had been in AddMember berfore but there is no screen name available when we Add a member.
            //create Telligent user:
            bool err = false;
            if (!string.IsNullOrEmpty(CurrentMember.ScreenName)) //optional to the user
            {
                try
                {
                    if (mode == Constants.QueryStrings.Registration.ModeEdit)
                    {
                        bool communitySuccess = CommunityHelper.CreateUser(CurrentMember.ScreenName, CurrentUser.Email);
                        if (communitySuccess == false)
                        {
                            // ¡Ay, caramba!
                            // give them a nice "I'm sorry" please try again later message.
                            uxErrorMessage.Text = "<font color=red>I'm sorry, the Community User failed to be created properly. </ font> ";
                            uxErrorMessage.Visible = true;
                            err = true; //dont progress. stop and display an error.
                        }
                    }
                }
                catch (Exception ex)
                {
                    //bg: we need a generic procedure for handling errors so that we can display important data properly without being gross  
                    uxErrorMessage.Text = "<font color=red>I'm sorry, an error has occured while trying to create the Community User. <hr> " +
                        "Message: " + ex.Message + Environment.NewLine +
                        "Source: " + ex.Source + Environment.NewLine + "<hr>" +
                        "Stack Trace: " + ex.StackTrace + Environment.NewLine +
                        "Inner Message: " + ex.InnerException.Message + Environment.NewLine +
                        "Inner Source: " + ex.InnerException.Source + Environment.NewLine +
                        "Inner Stack Trace: " + ex.InnerException.StackTrace +
                        "</font>";
                    uxErrorMessage.Visible = true;
                    err = true;
                }
            }
            if (!err)//no errors. Move the progression forward.
            {
                if (mode == Constants.QueryStrings.Registration.ModeEdit)
                {
                    Response.Redirect(MyAccountItem.GetMyAccountPage().GetUrl());
                }
                Response.Redirect(MembershipHelper.GetNextStepURL(5));
            }
        }

        protected void ListInterestDataBound(object sender, ListViewItemEventArgs e)
        {
            var check = e.Item.FindControl("interest") as CheckBox;
            var item = e.Item.DataItem as Sitecore.Data.Items.Item;

            if (check != null && item != null)
            {
                if (mode == Constants.QueryStrings.Registration.ModeEdit)
                {
                    if ((this.registeringUser != null) && (this.registeringUser.Interests.ToList().Exists(x => x.Key == Guid.Parse(item.ID.ToString()))))
                    {
                        check.Checked = true;
                    }
                }
                check.Attributes.Add("guid", item.ID.ToString());
            }
        }

        protected void ListJourneyDataBound(object sender, ListViewItemEventArgs e)
        {
            var check = e.Item.FindControl("interest") as CheckBox;
            var item = e.Item.DataItem as Sitecore.Data.Items.Item;

            if (check != null && item != null)
            {
                if (mode == Constants.QueryStrings.Registration.ModeEdit)
                {
                    if ((this.registeringUser != null) && (this.registeringUser.Journeys.ToList().Exists(x => x.Key == Guid.Parse(item.ID.ToString()))))
                    {
                        check.Checked = true;
                    }
                }
                check.Attributes.Add("guid", item.ID.ToString());
            }
        }

    }
}