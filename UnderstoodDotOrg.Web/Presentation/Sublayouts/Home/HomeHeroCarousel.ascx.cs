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
namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Home {
    public partial class HomeHeroCarousel : BaseSublayout {
        string query = string.Empty;
        protected void Page_Load(object sender, EventArgs e) {
            HomePageItem ContextItem = Sitecore.Context.Item;
            if (ContextItem != null) {
                GetSliderItem(ContextItem);

                var childIssues = GetFilters(ChildIssueItem.TemplateId).Select(i => (ChildIssueItem)i);
                if (childIssues != null && childIssues.Any()) {
                    rptChildIssues.Visible = true;
                    rptChildIssues.DataSource = childIssues;
                    rptChildIssues.DataBind();
                }
                else {
                    rptChildIssues.Visible = false;
                }

                var grades = GetFilters(GradeLevelItem.TemplateId).Select(i => (GradeLevelItem)i);
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
                ddlGradeGroups.Items.Add(new ListItem(DictionaryConstants.SelectGradeLabel, "0"));

                foreach (GradeLevelItem gradeItem in grades) {
                    if (!string.IsNullOrEmpty(gradeItem.Name.Raw)) {
                        ddlGradeGroups.Items.Add(new ListItem(gradeItem.Name.Raw, gradeItem.ID.ToString()));
                    }
                }
                ddlGradeGroups.DataBind();
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
                        if (CurrentMember != null && CurrentMember.Children != null && CurrentMember.Children.Any()) {
                            foreach (Child child in CurrentMember.Children) {
                                if (child.Issues != null && child.Issues.Any()) {
                                    foreach (Issue issue in child.Issues) {
                                        if (issue.Key.Equals(childIssueItem.ID.ToString().ToLower())) {
                                            hdnKeyValuePair.Value = childIssueItem.ID + "|" + childIssueItem.IssueName.Raw;
                                            hdnChecked.Value = "checked";
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
                        gradeBtn.ID = "grade-" + gradeItem.Name.Raw.Replace(" ", "-").Replace("/", "-");
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
                    CurrentMember = new Member();

                    string[] checkedIds = hdnGetAllChecked.Value.Split(',');
                    if (checkedIds != null && checkedIds.Any()) {
                        Child child = new Child();
                        foreach (string checkId in checkedIds) {

                            ChildIssueItem issueItem = Sitecore.Context.Database.GetItem(checkId.Split('|')[0]);
                            if (issueItem != null) {

                                Issue _issue = new Issue();
                                _issue.Key = System.Guid.Parse(issueItem.ID.ToString());
                                _issue.Value = issueItem.IssueName.Raw;
                                child.Issues.Add(_issue);
                            }

                            //Grade x1 = new Grade();
                            //x1.Key = "";
                            //x1.Value = "";
                            //child.Grades.Add(x1);

                            CurrentMember.Children.Add(child);
                        }
                    }
                }

                //Item resourceLanding = MainsectionItem.GetHomePageItem();
                //if (resourceLanding != null) {

                //    string itemUrl = resourceLanding.GetUrl();
                //    //Response.Redirect(itemUrl + "?" + DictionaryConstants.SelectChallenge + "=" + queryText);

                //}
            }
        }

        /// Gets the search result based on keyword
        /// </summary>
        /// <returns></returns>
        public List<Item> GetFilters(string templateId) {
            List<Item> searchResultItems = new List<Item>();
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            using (var context = index.CreateSearchContext()) {
                searchResultItems = context.GetQueryable<SearchResultItem>().
                   Where(i => i.TemplateId == Sitecore.Data.ID.Parse(templateId) && i.Path.Contains("/sitecore/content")).Select(i => (Item)i.GetItem()).ToList();
            }
            return searchResultItems;
        }
    }
}