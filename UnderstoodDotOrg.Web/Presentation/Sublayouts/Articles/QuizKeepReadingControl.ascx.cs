﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.ContentSearch;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class QuizKeepReadingControl : BaseSublayout<DefaultArticlePageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DefaultArticlePageItem context = (DefaultArticlePageItem)Sitecore.Context.Item;

            if (context.KeepReadingContent.ListItems.Count != 0)
            {
                rptKeepReading.DataSource = context.KeepReadingContent.ListItems.Where(i => i.InheritsTemplate(DefaultArticlePageItem.TemplateId)).Take(3);
                rptKeepReading.DataBind();
            }
            else
            {
                List<Item> relatedLinks = context.InnerItem.Parent.Children
                    .Where(i => i.InheritsFromType(DefaultArticlePageItem.TemplateId))
                    .Shuffle().Where(i => i.ID != context.ID).Take(3).ToList();
                rptKeepReading.DataSource = relatedLinks;
                rptKeepReading.DataBind();
                if (relatedLinks == null || !(relatedLinks.Count > 0))
                    this.Visible = false;
            }
        }

        protected void rptKeepReading_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item RelatedLink = e.Item.DataItem as Item;
                if (RelatedLink != null)
                {
                    FieldRenderer frPageTitle = e.FindControlAs<FieldRenderer>("frPageTitle");
                    HyperLink hlPageTitle = e.FindControlAs<HyperLink>("hlPageTitle");
                    if (frPageTitle != null)
                    {
                        frPageTitle.Item = RelatedLink;
                        hlPageTitle.NavigateUrl = RelatedLink.GetUrl();
                        hlPageTitle.Visible = true;
                    }
                }
            }
        }
    }
}