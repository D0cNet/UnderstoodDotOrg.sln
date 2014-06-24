using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using System.Web.UI.HtmlControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.Understood.Helper;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Recommendation;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home
{

    public partial class HomeHeroCarousel : BaseSublayout
    {
        Member ActiveMember = new Member();
        protected string CompleteMyProfileUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            HomePageItem ContextItem = Sitecore.Context.Item;

            CompleteMyProfileUrl = IsUserLoggedIn 
                ? MyAccountFolderItem.GetMyProfileStepOnePage().GetUrl() 
                : MyAccountFolderItem.GetSignInPage();

            if (UnauthenticatedSessionMember != null)
            {
                ActiveMember = UnauthenticatedSessionMember;
            }

            //Load Text
            litHelpmsg.Text = DictionaryConstants.HowCanHelp;
            litStruggle.Text = DictionaryConstants.ChildStruggles;
            litStruggle2.Text = DictionaryConstants.ChildStruggles;
            litStruggle3.Text = DictionaryConstants.ChildStruggles;
            litSelectAll.Text = DictionaryConstants.SelectAll;
            litChildEnrolled.Text = DictionaryConstants.ChildEnrolled;
            litChildEnrolled2.Text = DictionaryConstants.ChildEnrolled;
            litComplete1.Text = DictionaryConstants.CompleteMyProfile;
            btnSubmit.Text = DictionaryConstants.SeeMyRecommendationsButtonText;

            if (!IsPostBack)
            {
                GetSliderItem(ContextItem);

                InitGuideMe();
            }
            else
            {
                // Non-standard controls used for grades, values stored in hidden field via JS
                if (!String.IsNullOrEmpty(hfGradeChoice.Value))
                {
                    SetSelectedGrade(hfGradeChoice.Value);
                }
            }
        }

        private void InitGuideMe()
        {
            var childIssues = FormHelper.GetIssues();
            rptChildIssues.Visible = true;
            rptChildIssues.DataSource = childIssues;
            rptChildIssues.DataBind();

            var grades = FormHelper.GetGrades();
            rptGrades.Visible = true;
            rptGrades.DataSource = grades;
            rptGrades.DataBind();

            var gradesList = FormHelper.GetGrades(DictionaryConstants.SelectGradeLabel);
            if (gradesList.Any())
            {
                ddlGradeGroups.DataSource = gradesList;
                ddlGradeGroups.DataTextField = "Text";
                ddlGradeGroups.DataValueField = "Value";
                ddlGradeGroups.DataBind();
            }

            // Pre-select unauthenticated user's choices
            if (ActiveMember.Children.Any())
            {
                Child child = ActiveMember.Children.First();
                foreach (RepeaterItem ri in rptChildIssues.Items)
                {
                    CheckBox cbIssue = (CheckBox)ri.FindControl("cbIssue");
                    HiddenField hfIssue = (HiddenField)ri.FindControl("hfIssue");
                    var match = child.Issues.Where(i => i.Key == Guid.Parse(hfIssue.Value)).FirstOrDefault();
                    if (match != null)
                    {
                        cbIssue.Checked = true;
                    }
                }

                if (child.Grades.Any())
                {
                    SetSelectedGrade(child.Grades.First().Key.ToString());
                }
            }
        }

        private void SetSelectedGrade(string grade)
        {
            // Repeater
            foreach (RepeaterItem ri in rptGrades.Items)
            {
                HtmlButton gradeBtn = (HtmlButton)ri.FindControl("gradeBtn");
                string shortId = Sitecore.Data.ID.Parse(grade).ToShortID().ToString();

                if (gradeBtn.Attributes["data-value"] == shortId)
                {
                    gradeBtn.Attributes["class"] += " active";
                }
                else
                {
                    gradeBtn.Attributes["class"] = gradeBtn.Attributes["class"].Replace("active", "").Trim();
                }
            }

            var item = ddlGradeGroups.Items.FindByValue(Guid.Parse(grade).ToString());
            if (item != null)
            {
                item.Selected = true;
            }
        }

        private void GetSliderItem(HomePageItem ContextItem)
        {
            PageResourceFolderItem pageResourceFolder = ContextItem.GetPageResourceFolderItem();
            if (pageResourceFolder != null)
            {
                HomeSliderFolderItem homeSliderFolderItem = pageResourceFolder.GetHomeSliderFolderItem();
                if (homeSliderFolderItem != null)
                {
                    if (!homeSliderFolderItem.RandomizeSlides.Rendered.IsNullOrEmpty())
                    {
                        hfRandomizeSlider.Value = "true";
                    }
                    else
                    {
                        hfRandomizeSlider.Value = "false";
                    }
                    var sliderItems = homeSliderFolderItem.GetHomeSliderItems();
                    if (sliderItems != null && sliderItems.Any())
                    {
                        rptHomeSlider.DataSource = sliderItems;
                        rptHomeSlider.DataBind();
                    }
                }

            }
        }

        protected void rptHomeSlider_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                HomeSliderItem item = e.Item.DataItem as HomeSliderItem;
                if (item != null)
                {
                    FieldRenderer frSliderText = e.FindControlAs<FieldRenderer>("frSliderText");
                    Panel pnlSliderImage = e.FindControlAs<Panel>("pnlSliderImage");
                    Panel pnlSliderText = e.FindControlAs<Panel>("pnlSliderText");

                    if (frSliderText != null)
                    {
                        frSliderText.Item = item;
                    }

                    if (pnlSliderImage != null && item.HeroImage.MediaItem != null)
                    {
                        pnlSliderImage.Style.Add("background-image", string.Format("url('{0}')", item.HeroImage.MediaUrl));
                        pnlSliderImage.Attributes.Add("onclick", string.Format("location.href='{0}'", item.Link.Url));
                    }

                    if (pnlSliderText != null)
                    {
                        pnlSliderText.Attributes.Add("class", string.Format("text {0}", item.TextCss.Rendered));
                    }
                }
            }
        }

        protected void rptChildIssues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ChildIssueItem childIssueItem = e.Item.DataItem as ChildIssueItem;

                HiddenField hfIssue = e.FindControlAs<HiddenField>("hfIssue");
                Label lblIssue = e.FindControlAs<Label>("lblIssue");
                hfIssue.Value = childIssueItem.ID.ToShortID().ToString();
                lblIssue.Text = childIssueItem.IssueName.Rendered;
            }
        }

        protected void rptGrades_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                GradeLevelItem gradeItem = e.Item.DataItem as GradeLevelItem;

                HtmlButton gradeBtn = e.FindControlAs<HtmlButton>("gradeBtn");
                gradeBtn.Attributes.Add("data-value", gradeItem.ID.ToShortID().ToString());
                gradeBtn.InnerText = gradeItem.Name.Rendered;
            }
        }

        /// <summary>
        /// Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_OnClick(object sender, EventArgs e)
        {
            // First check hidden field
            string selectedGrade = hfGradeChoice.Value;

            if (String.IsNullOrEmpty(selectedGrade))
            {
                selectedGrade = ddlGradeGroups.SelectedValue;
            }

            if (String.IsNullOrEmpty(selectedGrade))
            {
                return;
            }

            // TODO: verify if it's ok to clear out unauthenticated user
            Member member = new Member();

            Child child = new Child();
            // TODO: replace child name
            child.Nickname = "Your Child";

            child.ChildId = Guid.NewGuid();

            foreach (RepeaterItem ri in rptChildIssues.Items)
            {
                CheckBox cbIssue = (CheckBox)ri.FindControl("cbIssue");
                HiddenField hfIssue = (HiddenField)ri.FindControl("hfIssue");
                if (cbIssue.Checked)
                {
                    ChildIssueItem cii = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(hfIssue.Value));
                    if (cii != null)
                    {
                        child.Issues.Add(new Issue
                        {
                            Key = Guid.Parse(cii.ID.ToString()),
                            Value = cii.IssueName.Rendered
                        });
                    }
                }
            }

            GradeLevelItem gradeItem = Sitecore.Context.Database.GetItem(Sitecore.Data.ID.Parse(selectedGrade));
            if (gradeItem != null)
            {
                child.Grades.Add(new Grade
                {
                    Key = Guid.Parse(selectedGrade),
                    Value = gradeItem.Name
                });
            }

            member.Children.Add(child);
            UnauthenticatedSessionMember = member;

            // TODO: return unauthenticated users to different results page
            Response.Redirect(FormHelper.GetRecommendationUrl());
        }
    }
}