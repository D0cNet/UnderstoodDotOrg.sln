using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Registration
{
    public partial class RegisterChildInformation : BaseSublayout<RegisterChildInformationItem> //System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bind texts and placeholders
            lblChildNickname.Text = Model.Childnicknameplaceholder.Rendered;
            txtChildNickname.Attributes["placeholder"] = Server.HtmlDecode(Model.Childnicknameplaceholder.Text);
            btnSubmit.Text = Model.SeeMyRecommendationsText.Rendered;
            hypCompleteProfile.Text = Model.CompleteMyFullProfileText.Rendered;
            hypCompleteProfile.NavigateUrl = MyProfileStepOneItem.GetCompleteMyProfileStepOne().GetUrl();

            //validators
            valGender.ErrorMessage = DictionaryConstants.TellGenderofChildText;
            Page.ClientScript.RegisterExpandoAttribute(valGender.ClientID, "groupName", uxBoy.GroupName);

            valNickname.ErrorMessage = DictionaryConstants.GiveChildNicknameText;
            valGrade.ErrorMessage = DictionaryConstants.GiveChildGradeText;

            if (!IsPostBack)
            {
                //bind issue list
                rptIssues.DataSource = ChildIssueItem.GetIssues();
                rptIssues.DataBind();

                //bind grade list
                var grades = GradeLevelItem.GetGrades().Select(x => new ListItem(x.Name, x.ID.ToString()));
                ddlGrades.DataSource = grades;
                ddlGrades.DataTextField = "Text";
                ddlGrades.DataValueField = "Value";
                ddlGrades.DataBind();

                ddlGrades.Items.Insert(0, new ListItem() { Text = Model.Gradedefaultselection.Rendered, Value = string.Empty, Selected = true });
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //do stuff
            if (this.CurrentMember != null)
            {
                var child = new UnderstoodDotOrg.Domain.Membership.Child();

                //required values that we can default
                child.EvaluationStatus = new Guid(Constants.ChildEvaluation.StatusEvaluationNo);

                child.Nickname = TextHelper.RemoveHTML(txtChildNickname.Text);
                child.Gender = uxBoy.Checked ? "boy" : "girl";
                child.Grades.Add(new Grade() { Key = Guid.Parse(ddlGrades.SelectedValue) });

                foreach (var item in rptIssues.Items)
                {
                    var checkbox = item.FindControl("uxIssueCheckbox") as CheckBox;
                    var hidden = item.FindControl("uxIssueHidden") as HiddenField;

                    if (checkbox.Checked)
                    {
                        //singleChild.Issues.Add(new Issue() { Key = Guid.Parse(checkbox.Attributes["value"]) });
                        child.Issues.Add(new Issue() { Key = Guid.Parse(hidden.Value) });
                    }
                }

                MembershipManager membershipManager = new MembershipManager();

                child = membershipManager.AddChild(child, this.CurrentMember.MemberId);
                
                Handlers.RunPersonalizationService rps = new Handlers.RunPersonalizationService();
                rps.UpdateChild(child.ChildId);

                //should we update the current member?
            }

            this.ReturnRedirect();

            //oh, you're still here...
            Response.Redirect(MyAccountItem.GetMyAccountPage().GetUrl());
        }

        protected void rptIssues_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var checkbox = e.Item.FindControl("uxIssueCheckbox") as CheckBox;
            var hidden = e.Item.FindControl("uxIssueHidden") as HiddenField;
            var item = ((ChildIssueItem)e.Item.DataItem);

            if (checkbox != null && hidden != null)
            {
                hidden.Value = item.ID.ToString();
            }
        }
    }
}