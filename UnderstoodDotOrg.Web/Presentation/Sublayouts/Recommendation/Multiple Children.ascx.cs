using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Recommendation;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common.Helpers;
using UnderstoodDotOrg.Domain.Search;
using System.Text;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Child;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Parent;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.MyAccount;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    public partial class Multiple_Children : BaseSublayout<MultipleChildrenItem>
    {
        private bool useSearch = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            BindChildren();
        }

        private void BindChildren()
        {
            // Temp proxy - use CurrentMember for final implementation
            if (CurrentMember != null)
            {
                var children = CurrentMember.Children;
                if (children.Any())
                {
                    rptChildBasicInfo.DataSource = children;
                    rptChildBasicInfo.DataBind();
                }
            }
            else if (UnauthenticatedSessionMember != null)
            {
                this.useSearch = true;

                var children = UnauthenticatedSessionMember.Children;
                if (children.Any())
                {
                    rptChildBasicInfo.DataSource = children;
                    rptChildBasicInfo.DataBind();
                }
            }
        }

        protected void rptChildBasicInfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Child child = (Child)e.Item.DataItem;

                HyperLink hlReplaceMatchingIssues = e.FindControlAs<HyperLink>("hlReplaceMatchingIssues");
                hlReplaceMatchingIssues.NavigateUrl = MyProfileStepTwoItem.GetChildEditLink(e.Item.ItemIndex);

                Literal litChildGrade = e.FindControlAs<Literal>("litChildGrade");
                if (child.Grades != null && child.Grades.Any())
                {
                    litChildGrade.Text = child.Grades.First().Value;
                }

                Literal litChildGender = e.FindControlAs<Literal>("litChildGender");
                if (child.Gender != null)
                {
                    litChildGender.Text = TextHelper.ToTitleCase(child.Gender);
                }

                Repeater rptChildRelatedArticles = e.FindControlAs<Repeater>("rptChildRelatedArticles");

                List<DefaultArticlePageItem> articles;
                if (this.useSearch)
                {
                    articles = SearchHelper.GetArticles(UnauthenticatedSessionMember, child, DateTime.Now)
                                    .Where(a => a.GetItem() != null)
                                    .Select(a => new DefaultArticlePageItem(a.GetItem()))
                                    .ToList();     
                }
                else
                {
                    articles = UnderstoodDotOrg.Domain.Personalization.PersonalizationHelper.GetChildPersonalizedContents(child);    
                }

                if (articles.Any())
                {
                    rptChildRelatedArticles.DataSource = articles;
                    rptChildRelatedArticles.DataBind();
                }
            }
        }

        protected void rptChildRelatedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem item = (DefaultArticlePageItem)e.Item.DataItem;
                {
                    HyperLink hlArticleImage = e.FindControlAs<HyperLink>("hlArticleImage");
                    HyperLink hlArticleTitle = e.FindControlAs<HyperLink>("hlArticleTitle");

                    hlArticleImage.NavigateUrl = hlArticleTitle.NavigateUrl = item.InnerItem.GetUrl();

                    Image imgThumbnail = e.FindControlAs<Image>("imgThumbnail");
                    imgThumbnail.ImageUrl = item.GetArticleThumbnailUrl(150, 85);

                    // DEBUG - START
                    Literal litDebugTag = e.FindControlAs<Literal>("litDebugTag");

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("");
                    sb.AppendLine("Sitecore web db tagging:");
                    sb.AppendLine("Grades:");

                    foreach (var grade in item.ChildGrades.ListItems)
                    {
                        GradeLevelItem gli = grade;
                        sb.AppendLine(HttpUtility.HtmlDecode(gli.Name.Raw));
                    }

                    sb.AppendLine("");

                    sb.AppendLine("Issues:");

                    foreach (var issue in item.ChildIssues.ListItems)
                    {
                        ChildIssueItem cii = issue;
                        sb.AppendLine(HttpUtility.HtmlDecode(cii.IssueName.Raw));
                    }

                    sb.AppendLine("");

                    sb.AppendLine("Child Diagnoses:");

                    foreach (var diagnosis in item.ChildDiagnoses.ListItems)
                    {
                        ChildDiagnosisItem cdi = diagnosis;
                        sb.AppendLine(HttpUtility.HtmlDecode(cdi.DiagnosisName.Raw));
                    }

                    sb.AppendLine("");

                    sb.AppendLine("Interests:");

                    foreach (var interest in item.ApplicableInterests.ListItems)
                    {
                        ParentInterestItem pii = interest;
                        sb.AppendLine(HttpUtility.HtmlDecode(pii.InterestName.Raw));
                    }

                    sb.AppendLine("");

                    sb.AppendLine("Evaluations:");

                    foreach (var itemEval in item.OtherApplicableEvaluations.ListItems)
                    {
                        sb.AppendLine(itemEval.Name);
                    }

                    sb.AppendLine("");

                    sb.AppendLine("Diagnosed:");

                    foreach (var diag in item.DiagnosedCondition.ListItems)
                    {
                        sb.AppendLine(diag.Name);
                    }

                    sb.AppendLine("");

                    bool excluded = item.OverrideType.ListItems
                        .Where(x => x.ID == Sitecore.Data.ID.Parse(Constants.ArticleTags.ExcludeFromPersonalization))
                        .FirstOrDefault() != null;

                    sb.AppendLine(String.Format("Exclude from Personalization: {0}", excluded.ToString().ToLower()));

                    bool mustRead = item.ImportanceLevel.ListItems
                        .Where(x => x.ID == Sitecore.Data.ID.Parse(Constants.ArticleTags.MustRead))
                        .FirstOrDefault() != null;

                    sb.AppendLine(String.Format("Must read: {0}", mustRead.ToString().ToLower()));
                    
                    sb.AppendLine(String.Format("Timely: {0}", IsTimely(item.DateStart.DateTime, item.DateEnd.DateTime).ToString()));

                    sb.AppendLine("");



                    Article article = SearchHelper.GetArticle(item.ID);
                    if (article != null)
                    {
                        sb.AppendLine("Solr index:");
                        sb.AppendLine("Grades:");

                        foreach (var grade in article.ChildGrades)
                        {
                            GradeLevelItem gli = Sitecore.Context.Database.GetItem(grade.Guid);
                            if (gli != null)
                            {
                                sb.AppendLine(HttpUtility.HtmlDecode(gli.Name.Raw));
                            }
                        }

                        sb.AppendLine("");

                        sb.AppendLine("Issues:");

                        foreach (var issue in article.ChildIssues)
                        {
                            ChildIssueItem cii = Sitecore.Context.Database.GetItem(issue.Guid);
                            if (cii != null)
                            {
                                sb.AppendLine(HttpUtility.HtmlDecode(cii.IssueName.Raw));
                            }
                        }

                        sb.AppendLine("");

                        sb.AppendLine("Child Diagnoses:");

                        foreach (var diagnosis in article.ChildDiagnoses)
                        {
                            ChildDiagnosisItem cdi = Sitecore.Context.Database.GetItem(diagnosis.Guid);
                            if (cdi != null)
                            {
                                sb.AppendLine(HttpUtility.HtmlDecode(cdi.DiagnosisName.Raw));
                            }
                        }

                        sb.AppendLine("");

                        sb.AppendLine("Interests:");

                        foreach (var interest in article.ParentInterests)
                        {
                            ParentInterestItem pii = Sitecore.Context.Database.GetItem(interest.Guid);
                            if (pii != null)
                            {
                                sb.AppendLine(HttpUtility.HtmlDecode(pii.InterestName.Raw));
                            }
                        }

                        sb.AppendLine("");

                        sb.AppendLine("Evaluations:");

                        foreach (var itemEval in article.ApplicableEvaluations)
                        {
                            Item i = Sitecore.Context.Database.GetItem(itemEval);
                            if (i != null)
                            {
                                sb.AppendLine(i.Name);
                            }
                        }

                        sb.AppendLine("");

                        sb.AppendLine("Diagnosed:");

                        foreach (var diag in article.DiagnosedConditions)
                        {
                            Item i = Sitecore.Context.Database.GetItem(diag);
                            if (i != null)
                            {
                                sb.AppendLine(i.Name);
                            }
                        }

                        sb.AppendLine("");

                        bool excludedTag = article.OverrideTypes.Contains(Sitecore.Data.ID.Parse(Constants.ArticleTags.ExcludeFromPersonalization));

                        sb.AppendLine(String.Format("Exclude from Personalization: {0}", excludedTag.ToString().ToLower()));

                        bool mustReadTag = article.ImportanceLevels.Contains(Sitecore.Data.ID.Parse(Constants.ArticleTags.MustRead));
                        sb.AppendLine(String.Format("Must read: {0}", mustReadTag.ToString().ToLower()));

                        sb.AppendLine(String.Format("Timely: {0}", IsTimely(article.TimelyStart, article.TimelyEnd)));
                    }

                    litDebugTag.Text = String.Format("<!--{0}-->", sb.ToString());
                    // DEBUG - END
                }
            }
        }

        private bool IsTimely(DateTime start, DateTime end)
        {
            DateTime now = DateTime.Now;
            return (start != DateTime.MinValue && end == DateTime.MinValue
                    && start <= now)
                    || (start == DateTime.MinValue && end != DateTime.MinValue
                        && end >= now)
                    || (start != DateTime.MinValue && end != DateTime.MinValue
                        && start <= now && end >= now);
        }

        protected void btnRunPersonalied_Click(object sender, EventArgs e)
        {
            runPersonalization();
        }

        private void runPersonalization()
        {
            //http://understood.org.local/handlers/runpersonalizationservice.ashx?memberid={BFF9BFC7-32F4-43BC-828B-98A7385E17A6}
            // AS IT WAS FOROLD IN PROPHECY
            //Constants.HANDLER_TIMELY_DATE_QUERY_STRING//
            ////run personalization for this user
            Handlers.RunPersonalizationService rps = new Handlers.RunPersonalizationService();

            if (uxCal.SelectedDate != null)
            {
                rps.ImpersonateSearchDate = uxCal.SelectedDate;
            }
            rps.UpdateMember(CurrentMember);
        }
    }
}