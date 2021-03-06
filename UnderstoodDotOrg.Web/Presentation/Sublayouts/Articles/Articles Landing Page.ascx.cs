﻿using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Articles_Landing_Page : BaseSublayout
    {
        public List<Item> TempList = new List<Item>();
        public int ListTotal;

        protected void Page_Load(object sender, EventArgs e)
        {
            LandingPageResourceArticlePageItem context = Sitecore.Context.Item;
            ListTotal = context.SelectArticles.ListItems.Count;

            rptFeaturedArticles.DataSource = context.SelectArticles.ListItems;
            rptFeaturedArticles.DataBind();
        }

        protected void rptFeaturedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item dataItem = e.Item.DataItem as Item;
                Repeater rptRow = e.FindControlAs<Repeater>("rptRow");

                if (TempList.Count < 2 )
                {
                    TempList.Add(dataItem);
                    if (TempList.Count == 2)
                    {
                        rptRow.DataSource = TempList;
                        rptRow.DataBind();
                        TempList.Clear();
                    }
                    else if (e.Item.ItemIndex + 1 == ListTotal)
                    {
                        rptRow.DataSource = TempList;
                        rptRow.DataBind();
                    }
                }
            }
        }

        protected void rptRow_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                Item dataItem = e.Item.DataItem as Item;

                if(dataItem.InheritsTemplate(DefaultArticlePageItem.TemplateId))
                {
                    DefaultArticlePageItem article = (DefaultArticlePageItem)dataItem;

                    System.Web.UI.WebControls.Image imgThumbnail = e.FindControlAs<System.Web.UI.WebControls.Image>("imgThumbnail");
                    HyperLink hypArticleLink = e.FindControlAs<HyperLink>("hypArticleLink");
                    HyperLink hypThumbnail = e.FindControlAs<HyperLink>("hypThumbnail");

                    if (imgThumbnail != null)
                        imgThumbnail.ImageUrl = article.GetArticleThumbnailUrl(230, 129);

                    if (hypArticleLink != null)
                    {
                        hypArticleLink.NavigateUrl = hypThumbnail.NavigateUrl = article.GetUrl();
                        hypArticleLink.Text = article.ContentPage.PageTitle;
                    }
                }
            }
        }
    }
}