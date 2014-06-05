using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.General;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class TextOnlyTipsArticle : BaseSublayout
    {
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataSource != null && DataSource.IsOfType(TextOnlyTipsArticlePageItem.TemplateId))
            {
                BindData((TextOnlyTipsArticlePageItem)DataSource);
            }
        }

        private void BindData(TextOnlyTipsArticlePageItem page)
        {
            var slides = page.GetSlides();

            if (slides.Any())
            {
                count = slides.Count();

                rptSlides.DataSource = slides;
                rptSlides.ItemDataBound += rptSlides_ItemDataBound;
                rptSlides.DataBind();
                rptSlides.Visible = true;

                rptSlideButtons.DataSource = slides;
                rptSlideButtons.ItemDataBound += rptSlideButtons_ItemDataBound;
                rptSlideButtons.DataBind();
                rptSlideButtons.Visible = true;
            }
        }

        void rptSlideButtons_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                Literal ltlPrev = e.FindControlAs<Literal>("ltlPrev");
                ltlPrev.Text = DictionaryConstants.PrevTipButtonText;
            }
            
            if (e.IsItem())
            {
                string buttonNumber = (e.Item.ItemIndex + 1).ToString();
                HtmlButton hgcButton = e.FindControlAs<HtmlButton>("hgcButton");
                
                hgcButton.InnerText = buttonNumber;
                hgcButton.Attributes["data-target"] = buttonNumber;
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Literal ltlNext = e.FindControlAs<Literal>("ltlNext");
                Literal ltlLast = e.FindControlAs<Literal>("ltlLast");
                
                ltlNext.Text = DictionaryConstants.NextTipButtonText;
                ltlLast.Text = DictionaryConstants.LastTipButtonText;
            }
        }

        void rptSlides_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                TextTipPageItem dataItem = e.Item.DataItem as TextTipPageItem;
                Panel pnlSlide = e.FindControlAs<Panel>("pnlSlide");
                Literal ltlSlideNumber = e.FindControlAs<Literal>("ltlSlideNumber");
                Literal ltlSlideCount = e.FindControlAs<Literal>("ltlSlideCount");
                Label lblCircle = e.FindControlAs<Label>("lblCircle");
                FieldRenderer frTipTitle = e.FindControlAs<FieldRenderer>("frTipTitle");
                FieldRenderer frTipText = e.FindControlAs<FieldRenderer>("frTipText");

                ltlSlideNumber.Text = (e.Item.ItemIndex + 1).ToString();
                ltlSlideCount.Text = count.ToString();
                frTipTitle.Item = dataItem;
                frTipText.Item = dataItem;

                if (dataItem.Backgroundcolor.Item != null)
                {
                    if (dataItem.Backgroundcolor.Item.IsOfType(MetadataItem.TemplateId))
                    {
                        MetadataItem color = dataItem.Backgroundcolor.Item;

                        if (!string.IsNullOrEmpty(color.ContentTitle.Raw))
                        {
                            pnlSlide.CssClass += " " + color.ContentTitle.Raw;
                        }
                    }
                }

                if (dataItem.Circlecolor.Item != null)
                {
                    if (dataItem.Circlecolor.Item.IsOfType(MetadataItem.TemplateId))
                    {
                        MetadataItem color = dataItem.Circlecolor.Item;

                        if (!string.IsNullOrEmpty(color.ContentTitle.Raw))
                        {
                            lblCircle.CssClass = color.ContentTitle.Raw;
                        }
                    }
                }
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                var parent = DataSource.Parent;
                List<Item> parents = new List<Item>();

                while (parent != null)
                {
                    parents.Add(parent);
                    parent = parent.Parent;
                }


                Item subtopic = null;
                Item topic = null;

                foreach (var p in parents)
                {
                    if (p.IsOfType(SubtopicLandingPageItem.TemplateId))
                    {
                        subtopic = p;
                    }
                    else if (p.IsOfType(TopicLandingPageItem.TemplateId))
                    {
                        topic = p;
                    }
                }

                var randomSlides = SearchHelper.GetLastSlide(DataSource.ID, subtopic, topic, TextOnlyTipsArticlePageItem.TemplateId);

                FieldRenderer frPageSummary1 = e.FindControlAs<FieldRenderer>("frPageSummary1");
                FieldRenderer frPageSummary2 = e.FindControlAs<FieldRenderer>("frPageSummary2");
                HyperLink hypLink1 = e.FindControlAs<HyperLink>("hypLink1");
                HyperLink hypLink2 = e.FindControlAs<HyperLink>("hypLink2");
                Literal ltlSlideshowRestartLabel = e.FindControlAs<Literal>("ltlSlideshowRestartLabel");
                Literal ltlSlideshowRestartAlternateLabel = e.FindControlAs<Literal>("ltlSlideshowRestartAlternateLabel");

                if (randomSlides.Count >= 2)
                {
                    var slide = randomSlides[1];
                    hypLink2.NavigateUrl = slide.GetUrl();
                    hypLink2.Text = slide.Name;
                    frPageSummary2.Item = slide;
                    Panel pnlThumbnail2 = e.FindControlAs<Panel>("pnlThumbnail2");
                    string url = slide.GetArticleThumbnailUrl(380, 220);
                    string style = string.Format("background-image: url('{0}')", url);
                    pnlThumbnail2.Attributes.Add("style", style);
                    e.FindControlAs<System.Web.UI.WebControls.PlaceHolder>("phSlideshow2").Visible = true;
                }

                if (randomSlides.Count >= 1)
                {
                    var slide = randomSlides[0];
                    hypLink1.NavigateUrl = slide.GetUrl();
                    hypLink1.Text = slide.Name;
                    frPageSummary1.Item = slide;
                    Panel pnlThumbnail1 = e.FindControlAs<Panel>("pnlThumbnail2");
                    string url = slide.GetArticleThumbnailUrl(380, 220);
                    string style = string.Format("background-image: url('{0}')", url);
                    pnlThumbnail1.Attributes.Add("style", style);
                    e.FindControlAs<System.Web.UI.WebControls.PlaceHolder>("phSlideshow1").Visible = true;
                }

                ltlSlideshowRestartLabel.Text = DictionaryConstants.SlideshowRestartLabel;
                //ltlSlideshowRestartAlternateLabel.Text = DictionaryConstants.SlideshowRestartAlternateLabel;
            }
        }
    }

    public class CustomResultItem : SearchResultItem
    {
        public string AllTemplates
        {
            get;
            set;
        }
    }
}