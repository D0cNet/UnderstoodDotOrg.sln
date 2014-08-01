using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.CSS;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.JS;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Pages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Brightcove;
using CustomItemGenerator.Fields.ListTypes;
using Sitecore.Data.Managers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TycePlayerResources : BaseSublayout<TycePlayerPageItem>
    {
        public string YourDoneHeader = "";
        public string YourDoneContent = "";
        public string YourDoneLinkText = "";
        public string BeforeYouBeginTitle = "";
        public string BeforeYouBeginContent = "";

        private string HomepageUrl { get; set; }
        protected string JSResources { get; set; }
        protected string NextPagePath { get; set; }

        protected ChildLearningIssueItem IssueItem { get; set; }
        protected ChildGradeItem GradeItem { get; set; }

        protected VideoIdPair IntroductionVideo { get; set; }
        protected VideoIdPair ChildStoryVideo { get; set; }
        protected VideoIdPair ExpertSummaryVideo { get; set; }

        protected VideoIdPair OnDemandVideo { get; set; }

        protected bool IsPersonalized { get; set; }
        protected bool IsStandaloneSimulation { get; set; }
        protected bool IsStandaloneVideo { get; set; }

        private LanguageItem _contextLanguage;
        protected LanguageItem ContextLanguage
        {
            get
            {
                if (_contextLanguage == null)
                {
                    var langId = LanguageManager.GetLanguageItemId(Sitecore.Context.Language, Sitecore.Context.Database);
                    if (langId != (Sitecore.Data.ID)null)
                    {
                        _contextLanguage = Sitecore.Context.Database.GetItemAs<LanguageItem>(langId);
                    }
                }
                return _contextLanguage;
            }
        }

        protected string getBrightcoveExperienceURL()
        {
            if (CurrentMember != null && CurrentMember.MemberId != null || Request.IsSecureConnection)
            {
                return "//sadmin.brightcove.com/js/BrightcoveExperiences.js";
            }
            else return "//admin.brightcove.com/js/BrightcoveExperiences.js";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HomepageUrl = MainsectionItem.GetHomePageItem().GetUrl();
                ProcessQueryString();
                if (!IsStandaloneSimulation)
                {
                    InitializeVideoIdPairs();
                }
                AddResourcesToPage();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message + "<br/>" + ex.StackTrace);
                Response.End();
                //Response.Redirect(HomepageUrl);
            }
        }

        private void ProcessQueryString()
        {
            var standalone = Request.QueryString["standalone"];
            IsPersonalized = string.IsNullOrEmpty(standalone) || standalone.ToLower() != bool.TrueString.ToLower();

            var simq = Request.QueryString["simq"];
            var gradeId = Request.QueryString["gradeId"];
            
            var hasSimq = !string.IsNullOrEmpty(simq);
            var hasGradeId = !string.IsNullOrEmpty(gradeId);

            IsStandaloneSimulation = !IsPersonalized && !hasGradeId;
            IsStandaloneVideo = !IsStandaloneSimulation && !IsPersonalized;

            if (hasSimq && ((IsPersonalized && hasGradeId) || IsStandaloneSimulation || IsStandaloneVideo))
            {
                var simIds = simq.Split(',');
                if (!simIds.Any())
                {
                    return;
                }

                var issueId = simIds.First();
                IssueItem = Sitecore.Context.Database.GetItem(issueId);
                GradeItem = hasGradeId ? Sitecore.Context.Database.GetItem(gradeId) : null;

                if (IssueItem == null || (hasGradeId && GradeItem == null))
                {
                    Response.Redirect("111");
                    Response.End();
                    //Response.Redirect(HomepageUrl);
                }

                if (!IsPersonalized)
                {
                    var 
                    NextPagePath = Model.TyceBasePage.GetOverviewPage().GetUrl();
                }
                else if (simIds.Count() > 1)
                {
                    NextPagePath = Request.Url.GetLeftPart(UriPartial.Path) + "?";
                    var nextSimIds = simIds.Skip(1);

                    NextPagePath += string.Join("&", nextSimIds.Select(sid => "simq=" + sid));
                }
                else
                {
                    var nextStepsPage = Model.InnerItem.Parent.Children
                        .FirstOrDefault(i => i.IsOfType(TyceNextStepsPageItem.TemplateId));
                    if (nextStepsPage != null)
                    {
                        NextPagePath = nextStepsPage.GetUrl() + "?";
                    }
                    else
                    {
                        Response.Write("138");
                        Response.End();
                        //Response.Redirect(HomepageUrl);
                    }
                }

                var simHist = Request.QueryString["simhist"];
                if (!string.IsNullOrEmpty(simHist))
                {
                    var histIds = simHist.Split(',');
                    NextPagePath += "&" + string.Join("&", histIds.Select(hid => "simhist=" + hid));
                }

                NextPagePath += "&simhist=" + issueId + "&gradeId=" + gradeId;
            }
            else
            {
                Response.Write("155");
                Response.End();
                //Response.Redirect(HomepageUrl);
            }
        }

        private void AddResourcesToPage()
        {
            JSResources = string.Empty;
            IssueItem.SimulationJS.ListItems
                .Where(i => i != null)
                .Select(i => (JSItem)i).ToList()
                .ForEach(jsItem =>
                    JSResources += "<script type='text/javascript' src='" + jsItem.JSFilepath + jsItem.JSFilename + "'></script>");

            IssueItem.SimulationCSS.ListItems
                .Where(i => i != null)
                .Select(i => (CSSItem)i).ToList()
                .ForEach(cssItem => Page.Header.Controls.Add(
                    new Literal()
                    {
                        Text = "<link rel='stylesheet' href='" + cssItem.CSSFilepath + cssItem.CSSFilename + "' />"
                    }));

            if (Sitecore.Context.Item.IsOfType(TycePlayerPageItem.TemplateId))
            {
                TycePlayerPageItem context = (TycePlayerPageItem)Sitecore.Context.Item;
                YourDoneHeader = context.YourDoneModalHeaderText;
                YourDoneContent = context.YourDoneModalContent;
                YourDoneLinkText = context.YourDoneModalLinkText;
                BeforeYouBeginTitle = context.BeforeYouBeginTitle;
                BeforeYouBeginContent = context.BeforeYouBeginContent;
            }
        }

        protected void InitializeVideoIdPairs()
        {
            var videoGradeSet = IssueItem.InnerItem.Children
                .Where(i => i.IsOfType(TyceVideoGradeSetsItem.TemplateId))
                .Select(i => (TyceVideoGradeSetsItem)i)
                .Where(vgs =>
                    vgs.GradeGroup.Item != null &&
                    vgs.GradeGroup.Item.IsOfType(TYCEGradeGroupItem.TemplateId))
                .First(vgs =>
                    ((TYCEGradeGroupItem)vgs.GradeGroup.Item).Grades.ListItems
                        .Select(i => i.ID)
                        .Contains(GradeItem.ID));

            if (IsPersonalized)
            {
                InitializePersonalizedVideoIdPairs(videoGradeSet);
            }
            else
            {
                InitializeStandaloneVideoIdPairs(videoGradeSet);
            }
        }

        protected void InitializeStandaloneVideoIdPairs(TyceVideoGradeSetsItem videoGradeSet)
        {
            OnDemandVideo = new VideoIdPair(videoGradeSet.OnDemandWithSubtitles, videoGradeSet.OnDemandWithoutSubtitles);
        }

        protected void InitializePersonalizedVideoIdPairs(TyceVideoGradeSetsItem videoGradeSet)
        {
            IntroductionVideo = new VideoIdPair(videoGradeSet.IntroductionWithSubtitles, videoGradeSet.IntroductionWithoutSubtitles);
            ChildStoryVideo = new VideoIdPair(videoGradeSet.ChildStoryWithSubtitles, videoGradeSet.ChildStoryWithoutSubtitles);        
            //ExpertSummaryVideo = new VideoIdPair(IssueItem.ExpertSummaryWithSubtitles, IssueItem.ExpertSummaryWithoutSubtitles);
        }

        protected class VideoIdPair
        {
            public string WithSubtitlesVideoId { get; set; }
            public string WithoutSubtitlesVideoId { get; set; }

            public VideoIdPair() {}

            public VideoIdPair(CustomMultiListField withSubtitlesField, CustomMultiListField withoutSubtitlesField)
            {
                SetVideoIds(withSubtitlesField, withoutSubtitlesField);
            }

            public void SetVideoIds(CustomMultiListField withSubtitlesField, CustomMultiListField withoutSubtitlesField)
            {
                WithSubtitlesVideoId = GetBrightcoveVideoId(withSubtitlesField);
                WithoutSubtitlesVideoId = GetBrightcoveVideoId(withoutSubtitlesField);
            }

            public string GetBrightcoveVideoId(CustomMultiListField field)
            {
                return field.ListItems
                    .First(i => i != null && i.IsOfType(BrightcoveVideoItem.TemplateId))["ID"];
            }
        }
    }
}