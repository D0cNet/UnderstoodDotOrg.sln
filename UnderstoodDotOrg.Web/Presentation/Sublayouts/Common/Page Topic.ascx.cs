using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ToolsPages.BehaviorToolsPages;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages;
using UnderstoodDotOrg.Domain.Membership;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Common
{
    public partial class Page_Topic : BaseSublayout
    {
        private Item _currentItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            _currentItem = Sitecore.Context.Item;
            BindContent();
            LogViewForPopularity();
        }

        /// <summary>
        /// Log page view for subtopic filter nav
        /// </summary>
        private void LogViewForPopularity()
        {
            if (Sitecore.Context.PageMode.IsPreview)
            {
                return;
            }
            if (_currentItem.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                // Check for subtopic
                Item parent = _currentItem.Parent;
                if (parent != null 
                    && parent.InheritsTemplate(SubtopicLandingPageItem.TemplateId))
                {
                    // Setup user which page view will be logged against
                    var mm = new MembershipManager();
                    Guid viewer = Guid.Empty;
                    if (IsUserLoggedIn)
                    {
                        viewer = CurrentMember.MemberId;
                    }
                    else
                    {
                        // Look up shadow user
                        var shadowUser = mm.GetMemberByScreenName(Constants.UnauthenticatedMember_ScreeName);
                        if (shadowUser != null)
                        {
                            viewer = shadowUser.MemberId;
                        }
                    }

                    try
                    {
                        mm.LogSubtopicPageView(viewer, _currentItem.ID.ToGuid(), parent.ID.ToGuid());
                    }
                    catch (Exception ex)
                    {
                        Sitecore.Diagnostics.Log.Error("Error saving article view log", ex, this);
                    }
                }
            }
        }

        private void BindContent()
        {
            if (_currentItem.InheritsTemplate(BehaviorAdvicePageItem.TemplateId)
                    || _currentItem.TemplateID == Sitecore.Data.ID.Parse(BehaviorToolsResultsPageItem.TemplateId))
            {
                PopulateBehaviorInfo();
            }
            else
            {
                PopulateArticleInfo();
            }
        }

        private void PopulateArticleInfo()
        {
            phAuthorInfo.Visible = false;

            if (_currentItem.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                DefaultArticlePageItem article = _currentItem;

                if (article.AuthorName.Item != null)
                {
                    frAuthorName.Item = article.AuthorName.Item;
                    hlAuthorName.NavigateUrl = article.AuthorName.Item.GetUrl();
                    hlAuthorName.Text = article.AuthorName.Item.Name;
                    phAuthorInfo.Visible = true;
                }
            }

            //UNAO-434 - refactored to recursively go up the tree until it finds something to navigate back to
            this.SetBreadcrumb(Sitecore.Context.Item.Parent);
        }

        private void SetBreadcrumb(BasePageNEWItem item)
        {
            if (!string.IsNullOrEmpty(item.NavigationTitle.Text) )
            {
                frSectionTitle.Item = item;
                hlSectionTitle.NavigateUrl = item.GetUrl();

                return;
            }
            else
            {
                this.SetBreadcrumb(item.InnerItem.Parent);
            }
        }

        private void PopulateBehaviorInfo()
        {
            phBehaviorArticleInfo.Visible = true;
            hlSectionTitle.Visible = false;

            frTitle.FieldName = "Hero Heading";

            Item dataSource = null;

            // TEMP: look up parent item until DataSource is updated
            if (this.DataSource != null && this.DataSource != Sitecore.Context.Item)
            {
                dataSource = this.DataSource;
            }
            else
            {
                Item parent = Sitecore.Context.Item.Parent;
                while (parent != null)
                {
                    if (parent.TemplateID == Sitecore.Data.ID.Parse(BehaviorToolsLandingPageItem.TemplateId))
                    {
                        dataSource = ((BehaviorToolsLandingPageItem)parent).HeroImageDatasource.Item;
                        break;
                    }
                    parent = parent.Parent;
                }
            }

            if (dataSource != null)
            {
                frTitle.Item = frBehaviorSubtitle.Item = dataSource;
            }
        }
    }
}