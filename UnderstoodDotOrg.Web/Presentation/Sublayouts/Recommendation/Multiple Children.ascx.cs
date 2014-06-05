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
                                    .Select(a => new DefaultArticlePageItem(a.GetItem()))
                                    .Where(a => a.InnerItem != null)
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
                }
            }
        }

        protected void rptChildIssuesList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                //ChildIssue ObjChildIssue = e.Item.DataItem as ChildIssue;
                {
                    HyperLink hlReplaceMatchingIssues = e.FindControlAs<HyperLink>("hlReplaceMatchingIssues");
                    if (hlReplaceMatchingIssues != null)
                    {
                        //hlReplaceMatchingIssues.NavigateUrl= Navigate to page where Usrer can edit childs related Info;
                    }
                }
            }
        }


    }
}