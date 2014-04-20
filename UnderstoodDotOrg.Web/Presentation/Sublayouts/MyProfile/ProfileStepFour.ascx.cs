using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Globalization;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.MyProfile
{
    public partial class ProfileStepFour : BaseRegistration
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ScreenNameTextField.Text = DictionaryConstants.ScreenNameWatermark;
            ZipCodeTextField.Text = DictionaryConstants.ZipCodeWatermark;
            SubmitButton.Text = DictionaryConstants.SubmitButtonText;

            string schoolIssueContainer = "{596757D6-B2DB-4819-AA25-95DC9BB2FD0E}";
            string homeLifeContainer = "{18D5FA6B-32EC-476B-9194-3B18F7572D10}";
            string growingUpContainer = "{E9194DCB-1A67-4CFF-A8A4-B799639AFADC}";
            string socialEmotionalContainer = "{E8DF800B-1002-4EF6-AB46-825E70D968F5}";
            string techAppsContainer = "{4836BBBB-3C01-4BBB-BC78-0DF1D36E32B6}";
            string waysToHelpContainer = "{E4276D4E-71D7-4E5F-B9A2-B7DF3CA2990C}";
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
    }
}