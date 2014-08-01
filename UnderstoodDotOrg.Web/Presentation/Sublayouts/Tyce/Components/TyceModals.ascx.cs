using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components;
using UnderstoodDotOrg.Common.Comparers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TyceModals : BaseSublayout<TyceBasePageItem>
    {

        public string PleaseSelectChild = "";
        public string OtherChallengesHeader = "";
        public string OtherChallengesContent = "";
        public string AfterHighSchoolHeader = "";
        public string AfterHighSchoolContent = "";

        private TyceQuestionsPageItem _tyceQuestionsPage;
        private TycePlayerPageItem _tycePlayerPage;
        private TyceNextStepsPageItem _tyceNextStepsPage;
        private TyceOverviewPageItem _tyceOverviewPage;

        protected TyceQuestionsPageItem TyceQuestionsPage
        {
            get
            {
                return (_tyceQuestionsPage = _tyceQuestionsPage ?? Model.GetQuestionsPage());
            }
        }
        protected TycePlayerPageItem TycePlayerPage
        {
            get
            {
                return (_tycePlayerPage = _tycePlayerPage ?? Model.GetPlayerPage());
            }
        }
        protected TyceOverviewPageItem TyceOverviewPage
        {
            get
            {
                return (_tyceOverviewPage = _tyceOverviewPage ?? Model.GetOverviewPage());
            }
        }
        protected TyceNextStepsPageItem TyceNextStepsPage
        {
            get
            {
                return (_tyceNextStepsPage = _tyceNextStepsPage ?? Model.GetNextStepsPage());
            }
        }

        private string _tyceQuestionsPageUrl;
        private string _tycePlayerPageUrl;
        private string _tyceNextStepsPageUrl;
        private string _tyceOverviewPageUrl;

        protected string TyceQuestionsPageUrl
        {
            get
            {
                return (_tyceQuestionsPageUrl = _tyceQuestionsPageUrl ?? TyceQuestionsPage.GetUrl());
            }
        }
        protected string TycePlayerPageUrl
        {
            get
            {
                return (_tycePlayerPageUrl = _tycePlayerPageUrl ?? TycePlayerPage.GetUrl());
            }
        }
        protected string TyceOverviewPageUrl
        {
            get
            {
                return (_tyceOverviewPageUrl = _tyceOverviewPageUrl ?? TyceOverviewPage.GetUrl());
            }
        }
        protected string TyceNextStepsPageUrl
        {
            get
            {
                return (_tyceNextStepsPageUrl = _tyceNextStepsPageUrl ?? TyceNextStepsPage.GetUrl());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulatePersonalizationModal();
        }

        private void PopulatePersonalizationModal()
        {
            if (IsUserLoggedIn)
            {
                var childrenModels = CurrentMember.Children
                    .Select(c => 
                    {
                        var gradeItem = c.Grades.Any() ? ChildGradeItem.GetTyceGradeFromTaxonomy(c.Grades.First().Key) : null;
                        var gradeParam = gradeItem != null ? "gradeId=" + gradeItem.ID.Guid.ToString() : string.Empty;
                        var issueParams = c.Issues.Any() ? 
                                string.Join("&", c.Issues                                
                                    .SelectMany(issue => ChildLearningIssueItem.GetTyceIssuesFromTaxonomy(issue.Key))
                                    .Where(tyceIssue => tyceIssue != null)
                                    .Distinct(new CustomItemComparer<ChildLearningIssueItem>())
                                    .Select(tyceIssue => "simq=" + tyceIssue.ID.Guid.ToString())) :
                                string.Empty;

                        return new
                        {
                            Id = c.ChildId,
                            Label = gradeItem != null ? 
                                c.Nickname.TrimEnd() + ", " + gradeItem.ChildDemographic.NavigationTitle.Rendered :
                                c.Nickname,
                            GradeParam = gradeParam,
                            IssueParams = issueParams
                        };
                    });

                rptrChildSelectionModal.DataSource = childrenModels;
                rptrChildSelectionModal.DataBind();
            }

            if (Sitecore.Context.Item.IsOfType(TyceOverviewPageItem.TemplateId))
            {
                TyceOverviewPageItem context = (TyceOverviewPageItem)Sitecore.Context.Item;

                int childCount = 0;
                if (this.CurrentMember != null && this.CurrentMember.Children != null && this.CurrentMember.Children.Count > 0)
                {
                    childCount = this.CurrentMember.Children.Count;
                }

                PleaseSelectChild = context.PleaseSelectChildModalText.Rendered.Replace("[#]", childCount.ToString());
            }

            if (Sitecore.Context.Item.IsOfType(TyceQuestionsPageItem.TemplateId))
            {
                TyceQuestionsPageItem context = (TyceQuestionsPageItem)Sitecore.Context.Item;
                OtherChallengesHeader = context.OtherChallengesModalHeaderText;
                OtherChallengesContent = context.OtherChallengesModalContent;
                AfterHighSchoolHeader = context.AfterHighSchoolModalHeaderText;
                AfterHighSchoolContent = context.AfterHighSchoolModalContent;
            }
        }
    }
}