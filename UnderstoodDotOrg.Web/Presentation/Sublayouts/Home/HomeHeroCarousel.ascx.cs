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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home {
    public partial class HomeHeroCarousel : BaseSublayout {
        Member ActiveMember = new Member();
        public static IEnumerable<Item> GetAllIssues() {
            var children = Sitecore.Context.Database.GetItem(Constants.IssueContainer.ToString())
                .GetChildren().FilterByContextLanguageVersion();

            return from c in children
                   let i = new ChildIssueItem(c)
                   select c;
        }


        /// <summary>
        /// Returns a list of child grades defined in child taxonomy
        /// </summary>
        /// <returns>Collection of child grades where value is the respective Sitecore Guid</returns>
        public static IEnumerable<Item> GetGrades() {
            var children = Sitecore.Context.Database.GetItem(Constants.GradeContainer.ToString())
                            .GetChildren().FilterByContextLanguageVersion();
            return from c in children
                   let i = new GradeLevelItem(c)
                   select c;
        }

        protected void Page_Load(object sender, EventArgs e) {
            HomePageItem ContextItem = Sitecore.Context.Item;

            if (UnauthenticatedSessionMember != null) {
                ActiveMember = UnauthenticatedSessionMember;
            }
            else if (CurrentMember != null) {
                ActiveMember = CurrentMember;
            }

            if (!IsPostBack) {
                if (ContextItem != null) {
                    GetSliderItem(ContextItem);

                    var childIssues = GetAllIssues().Select(i => (ChildIssueItem)i);
                    
                    if (childIssues != null && childIssues.Any()) {
                        rptChildIssues.Visible = true;
                        rptChildIssues.DataSource = childIssues;
                        rptChildIssues.DataBind();
                    }
                    else {
                        rptChildIssues.Visible = false;
                    }

                    var grades = GetGrades().Select(i => (GradeLevelItem)i);
                    
                    if (grades != null && grades.Any()) {
                        rptGrades.Visible = true;
                        rptGrades.DataSource = grades;
                        rptGrades.DataBind();
                    }
                    else {
                        rptGrades.Visible = false;
                    }

                    BindGradesDDL();
                }
            }
            //if (CurrentMember != null && CurrentMember.Children != null && CurrentMember.Children.Any()) {
            //    btnSubmit.Enabled = true;
            //}
            //else {
            //    btnSubmit.Enabled = false;
            //}
        }

        private void GetSliderItem(HomePageItem ContextItem) {
            PageResourceFolderItem pageResourceFolder = ContextItem.GetPageResourceFolderItem();
            if (pageResourceFolder != null) {
                HomeSliderFolderItem homeSliderFolderItem = pageResourceFolder.GetHomeSliderFolderItem();
                if (homeSliderFolderItem != null) {
                    if (!homeSliderFolderItem.RandomizeSlides.Rendered.IsNullOrEmpty()) {
                        hfRandomizeSlider.Value = "true";
                    }
                    else {
                        hfRandomizeSlider.Value = "false";
                    }
                    var sliderItems = homeSliderFolderItem.GetHomeSliderItems();
                    if (sliderItems != null && sliderItems.Any()) {
                        rptHomeSlider.DataSource = sliderItems;
                        rptHomeSlider.DataBind();
                    }
                }

            }
        }

        public void BindGradesDDL() {

            var grades = GetFilters(GradeLevelItem.TemplateId).Select(i => (GradeLevelItem)i);
            if (grades.Any()) {
                ddlGradeGroups.Items.Clear();
                ddlGradeGroups.Items.Add(new ListItem(DictionaryConstants.SelectGradeLabel, "0"));

                foreach (GradeLevelItem gradeItem in grades) {
                    if (!string.IsNullOrEmpty(gradeItem.Name.Raw)) {
                        ddlGradeGroups.Items.Add(new ListItem(gradeItem.Name.Raw, gradeItem.ID.ToString()));
                    }
                }

                ddlGradeGroups.DataBind();

                if (ActiveMember != null && ActiveMember.Children != null && ActiveMember.Children.Any()) {
                    foreach (Child child in ActiveMember.Children) {
                        if (child.Grades != null && child.Grades.Any()) {
                            foreach (Grade grade in child.Grades) {
                                if (grade != null && ddlGradeGroups.Items.FindByValue(string.Concat("{", grade.Key.ToString().ToUpper(), "}")) != null) {
                                    ddlGradeGroups.Items.FindByValue(string.Concat("{", grade.Key.ToString().ToUpper(), "}")).Selected = true;
                                }
                            }
                        }
                    }
                }
            }

        }

        protected void rptHomeSlider_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                HomeSliderItem item = e.Item.DataItem as HomeSliderItem;
                if (item != null) {
                    FieldRenderer frSliderText = e.FindControlAs<FieldRenderer>("frSliderText");
                    Panel pnlSliderImage = e.FindControlAs<Panel>("pnlSliderImage");
                    Panel pnlSliderText = e.FindControlAs<Panel>("pnlSliderText");

                    if (frSliderText != null) {
                        frSliderText.Item = item;
                    }

                    if (pnlSliderImage != null && item.HeroImage.MediaItem != null) {
                        pnlSliderImage.Style.Add("background-image", string.Format("url('{0}')", item.HeroImage.MediaUrl));
                        pnlSliderImage.Attributes.Add("onclick", string.Format("location.href='{0}'", item.Link.Url));
                    }

                    if (pnlSliderText != null) {
                        pnlSliderText.Attributes.Add("class", string.Format("text {0}", item.TextCss.Rendered));
                    }
                }
            }
        }

        protected void rptChildIssues_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                ChildIssueItem childIssueItem = e.Item.DataItem as ChildIssueItem;
                if (childIssueItem != null) {
                    HtmlInputCheckBox issueInput = e.FindControlAs<HtmlInputCheckBox>("issueInput");
                    HtmlGenericControl lblCheckbox = e.FindControlAs<HtmlGenericControl>("lblCheckbox");
                    HiddenField hdnKeyValuePair = e.FindControlAs<HiddenField>("hdnKeyValuePair");
                    HiddenField hdnChecked = e.FindControlAs<HiddenField>("hdnChecked");

                    if (issueInput != null) {
                        issueInput.Name = "guideme-issue-" + childIssueItem.IssueName.Raw;
                        issueInput.Attributes.Add("data-value", childIssueItem.ID + "|" + childIssueItem.IssueName.Raw);
                        if (ActiveMember != null && ActiveMember.Children != null && ActiveMember.Children.Any()) {
                            foreach (Child child in ActiveMember.Children) {
                                if (child.Issues != null && child.Issues.Any()) {
                                    foreach (Issue issue in child.Issues) {
                                        if (issue.Key.ToString().ToLower().Replace("{", "").Replace("}", "") == childIssueItem.ID.ToString().ToLower().Replace("{", "").Replace("}", "")) {
                                            hdnKeyValuePair.Value = childIssueItem.ID + "|" + childIssueItem.IssueName.Raw;
                                            hdnChecked.Value = "true";
                                            issueInput.Attributes.Add("checked", "checked");
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (lblCheckbox != null) {
                        lblCheckbox.Attributes.Add("for", "guideme-issue-" + childIssueItem.IssueName.Raw);
                        lblCheckbox.InnerText = childIssueItem.IssueName.Raw;
                    }
                }
            }
        }

        protected void rptGrades_ItemDataBound(object sender, RepeaterItemEventArgs e) {
            if (e.IsItem()) {
                GradeLevelItem gradeItem = e.Item.DataItem as GradeLevelItem;
                if (gradeItem != null) {
                    HtmlButton gradeBtn = e.FindControlAs<HtmlButton>("gradeBtn");

                    if (gradeBtn != null) {
                        gradeBtn.InnerText = gradeItem.Name.Raw;
                        gradeBtn.Attributes.Add("data-value", gradeItem.ID.ToString());
                        gradeBtn.ID = "grade-" + gradeItem.Name.Raw.Replace(" ", "-").Replace("/", "-");
                        if (ActiveMember != null && ActiveMember.Children != null && ActiveMember.Children.Any()) {
                            foreach (Child child in ActiveMember.Children) {
                                if (child.Grades != null && child.Grades.Any()) {
                                    foreach (Grade grade in child.Grades) {
                                        if (grade.Key.ToString().ToLower().Replace("{", "").Replace("}", "") == gradeItem.ID.ToString().ToLower().Replace("{", "").Replace("}", "")) {
                                            gradeBtn.Attributes.Add("class", "grade active");
                                            gradeBtn.Attributes.Add("checked", "checked");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_OnClick(object sender, EventArgs e) {

            if (btnSubmit != null) {

                if (CurrentMember == null) {
                    Member member = new Member();

                    string[] checkedIds = hdnGetAllCheckedIssues.Value.Split(',');
                    string activeGradeId = hdnGetAllCheckedGrades.Value;

                    if (checkedIds != null && checkedIds.Any() || activeGradeId != null && !activeGradeId.IsNullOrEmpty()) {
                        Child child = new Child();

                        child.ChildId = new Guid();

                        if (checkedIds != null && checkedIds.Any()) {
                            foreach (string checkId in checkedIds) {

                                ChildIssueItem issueItem = Sitecore.Context.Database.GetItem(checkId.Split('|')[0]);
                                if (issueItem != null) {

                                    Issue _issue = new Issue();
                                    _issue.Key = System.Guid.Parse(issueItem.ID.ToString());
                                    _issue.Value = issueItem.IssueName.Raw;
                                    child.Issues.Add(_issue);
                                }
                            }
                        }

                        if (activeGradeId != null && !activeGradeId.IsNullOrEmpty()) {

                            GradeLevelItem gradeItem = Sitecore.Context.Database.GetItem(activeGradeId);
                            if (gradeItem != null) {

                                Grade _grade = new Grade();
                                _grade.Key = System.Guid.Parse(gradeItem.ID.ToString());
                                _grade.Value = gradeItem.Name.Raw;
                                child.Grades.Add(_grade);
                            }
                        }

                        member.Children.Add(child);
                        Session[Constants.sessionUnauthenticatedMemberKey] = member;

                    }
                }

                else {

                    if (CurrentMember.Children != null && CurrentMember.Children.Any()) {
                        string[] checkedIds = hdnGetAllCheckedIssues.Value.Split(',');
                        string activeGradeId = hdnGetAllCheckedGrades.Value;

                        if (checkedIds != null && checkedIds.Any() || activeGradeId != null && !activeGradeId.IsNullOrEmpty()) {

                            Child child = CurrentMember.Children.FirstOrDefault();

                            if (checkedIds != null && checkedIds.Any()) {
                                child.Issues.Clear();
                                foreach (string checkId in checkedIds) {

                                    ChildIssueItem issueItem = Sitecore.Context.Database.GetItem(checkId.Split('|')[0]);
                                    if (issueItem != null) {

                                        Issue _issue = new Issue();
                                        _issue.Key = System.Guid.Parse(issueItem.ID.ToString());
                                        _issue.Value = issueItem.IssueName.Raw;
                                        child.Issues.Add(_issue);
                                    }
                                }
                            }


                            if (activeGradeId != null && !activeGradeId.IsNullOrEmpty()) {
                                child.Grades.Clear();

                                GradeLevelItem gradeItem = Sitecore.Context.Database.GetItem(activeGradeId);
                                if (gradeItem != null) {

                                    Grade _grade = new Grade();
                                    _grade.Key = System.Guid.Parse(gradeItem.ID.ToString());
                                    _grade.Value = gradeItem.Name.Raw;
                                    child.Grades.Add(_grade);
                                }
                            }


                        }
                    }
                }

                Response.Redirect(FormHelper.GetRecommendationUrl());
            }
        }

        /// Gets the search result based on keyword
        /// </summary>
        /// <returns></returns>
        public List<Item> GetFilters(string templateId) {
            List<Item> searchResultItems = new List<Item>();
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            using (var context = index.CreateSearchContext()) {
                searchResultItems = context.GetQueryable<SearchResultItem>()
                    .Where(i => i.TemplateId == Sitecore.Data.ID.Parse(templateId) && i.Path.Contains("/sitecore/content"))
                    .Select(i => i.GetItem()).ToList();
            }
            return searchResultItems;
        }
    }
}