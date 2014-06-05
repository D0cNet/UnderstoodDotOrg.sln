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

            CompleteMyProfileUrl = IsUserLoggedIn ? MyAccountFolderItem.GetMyProfileStepOnePage().GetUrl() : MyAccountFolderItem.GetSignInPage();

            if (UnauthenticatedSessionMember != null)
            {
                ActiveMember = UnauthenticatedSessionMember;
            }

            if (!IsPostBack)
            {
                GetSliderItem(ContextItem);

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
                    ddlGradeGroups.DataBind();
                }

                // TODO: retrieve selected states from session
            }
            else
            {
                // Handle selected state
                if (!String.IsNullOrEmpty(hfGradeChoice.Value))
                {
                    foreach (RepeaterItem ri in rptGrades.Items)
                    {
                        HtmlButton gradeBtn = (HtmlButton)ri.FindControl("gradeBtn");
                        if (gradeBtn.Attributes["data-value"] == hfGradeChoice.Value)
                        {
                            gradeBtn.Attributes["class"] += " active";
                        }
                        else
                        {
                            gradeBtn.Attributes["class"] = gradeBtn.Attributes["class"].Replace("active", "").Trim();
                        }
                    }
                }
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

            Member member = new Member();

            Child child = new Child();

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
                            Key = Guid.Parse(cii.ID.ToString())
                        });
                    }
                }
            }

            child.Grades.Add(new Grade
            {
                Key = Guid.Parse(selectedGrade)
            });

            member.Children.Add(child);
            UnauthenticatedSessionMember = member;

            Response.Redirect(FormHelper.GetRecommendationUrl());
        }
    }
}