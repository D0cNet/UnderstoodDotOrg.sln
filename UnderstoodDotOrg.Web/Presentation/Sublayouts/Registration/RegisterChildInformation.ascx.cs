using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
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