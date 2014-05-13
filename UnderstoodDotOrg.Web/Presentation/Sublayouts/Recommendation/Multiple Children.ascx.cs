﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Recommendation;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Common.Helpers;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation
{
    public partial class Multiple_Children : BaseSublayout
    {
        MultipleChildrenItem ObjMultipleChildren;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjMultipleChildren = new MultipleChildrenItem(Sitecore.Context.Item);

            BindControls();
        }

        private void BindControls()
        {
            BindChildren();
        }

        private void BindChildren()
        {
            // Temp proxy - use CurrentMember for final implementation
            var mmp = new MembershipManager();
            var member = mmp.GetMember(Guid.Parse("{2FC0FD53-CD17-4A9F-9D24-AD2B17852ECB}"));
            if (member != null)
            {
                var children = member.Children;
                if (children.Any())
                {
                    rptChildBasicInfo.DataSource = member.Children;
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
                litChildGrade.Text = child.Grades.First().Value;

                Literal litChildGender = e.FindControlAs<Literal>("litChildGender");
                litChildGender.Text = TextHelper.ToTitleCase(child.Gender);

                Repeater rptChildRelatedArticles = e.FindControlAs<Repeater>("rptChildRelatedArticles");
                if (rptChildRelatedArticles != null)
                {
                    List<DefaultArticlePageItem> articles = UnderstoodDotOrg.Domain.Personalization.PersonalizationHelper.GetChildPersonalizedContents(child);
                    if (articles.Any())
                    {
                        rptChildRelatedArticles.DataSource = articles;
                        rptChildRelatedArticles.DataBind();
                    }
                }
            }
        }

        protected void rptChildRelatedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.IsItem())
            {
                DefaultArticlePageItem item = (DefaultArticlePageItem)e.Item.DataItem;
                {
                    HyperLink hlArticleImage = e.FindControlAs<HyperLink>("hlArticleImage");
                    HyperLink hlArticleTitle = e.FindControlAs<HyperLink>("hlArticleTitle");

                    hlArticleImage.NavigateUrl = hlArticleTitle.NavigateUrl = item.InnerItem.GetUrl();
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