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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components
{
    public partial class TycePlayerResources : BaseSublayout<TycePlayerPageItem>
    {
        private string HomepageUrl { get; set; }
        protected string JSResources { get; set; }
        protected string NextPagePath { get; set; }

        protected ChildLearningIssueItem IssueItem { get; set; }
        protected ChildGradeItem GradeItem { get; set; }

        protected VideoIdPair IntroductionVideo { get; set; }
        protected VideoIdPair ChildStoryVideo { get; set; }
        protected VideoIdPair ExpertSummaryVideo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HomepageUrl = MainsectionItem.GetHomePageItem().GetUrl();
                ProcessQueryString();
                InitializeVideoIdPairs();
                AddResourcesToPage();
            }
            catch
            {
                Response.Redirect(HomepageUrl);
            }
        }

        private void ProcessQueryString()
        {
            var simq = Request.QueryString["simq"];
            var gradeId = Request.QueryString["gradeId"];
            if (!(string.IsNullOrEmpty(simq) || string.IsNullOrEmpty(gradeId)))
            {
                var simIds = simq.Split(',');
                if (!simIds.Any())
                {
                    return;
                }

                var issueId = simIds.First();
                IssueItem = Sitecore.Context.Database.GetItem(issueId);
                GradeItem = Sitecore.Context.Database.GetItem(gradeId);

                if (IssueItem == null || GradeItem == null)
                {
                    Response.Redirect(HomepageUrl);
                }

                if (simIds.Count() > 1)
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
                        Response.Redirect(HomepageUrl);
                    }
                }

                var simHist = Request.QueryString["simhist"];
                if (!string.IsNullOrEmpty(simHist))
                {
                    var histIds = simHist.Split(',');
                    NextPagePath += "&" + string.Join("&", histIds.Select(hid => "simhist=" + hid));
                }

                NextPagePath += "&simhist=" + issueId;
            }
            else
            {
                Response.Redirect(HomepageUrl);
            }
        }

        private void AddResourcesToPage()
        {
            if (IssueItem != null)
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
            }
            else
            {
                Response.Redirect(HomepageUrl);
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

            IntroductionVideo = new VideoIdPair(videoGradeSet.IntroductionWithSubtitles, videoGradeSet.IntroductionWithoutSubtitles);
            ChildStoryVideo = new VideoIdPair(videoGradeSet.ChildStoryWithSubtitles, videoGradeSet.ChildStoryWithoutSubtitles);        
            ExpertSummaryVideo = new VideoIdPair(IssueItem.ExpertSummaryWithSubtitles, IssueItem.ExpertSummaryWithoutSubtitles);
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