using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.Slideshow;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.LandingPages;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class SlideshowArticle : BaseSublayout
    {
        SlideshowArticlePageItem ObjSlideshowArticle;
        IEnumerable<SlidesPageItem> AllChildSlides;
        int _totalSlide;
        int _currentSlideNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjSlideshowArticle = new SlideshowArticlePageItem(Sitecore.Context.Item);
            if (ObjSlideshowArticle != null)
            {
                //Set Slide Counter value and binda data accordinly
                 RptDataBind();
            }
        }

        public  void RptDataBind()
        {
            AllChildSlides = SlideshowArticlePageItem.GetAllSlides(ObjSlideshowArticle);
            if (AllChildSlides != null)
            {
                _totalSlide = AllChildSlides.Count();
                _currentSlideNo = 0;
                rptSlides.DataSource = AllChildSlides;
                rptSlides.DataBind();
                rptSlideButton.DataSource = AllChildSlides;
                rptSlideButton.DataBind();   
            }
        }
     
        protected void rptSlides_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                
                SlidesPageItem _currentSlide = e.Item.DataItem as SlidesPageItem;
                if (_currentSlide != null)
                {
                    _currentSlideNo++;
                    Panel pnlSlide = e.FindControlAs<Panel>("pnlSlide");
                    PlaceHolder phImageSlide=e.FindControlAs<PlaceHolder>("phImageSlide");
                    Label lblTotalSlide = e.FindControlAs<Label>("lblTotalSlide");
                    if (lblTotalSlide != null)
                    {
                        lblTotalSlide.Text = _totalSlide.ToString();
                    }
                    Label lblCurrentSlide = e.FindControlAs<Label>("lblCurrentSlide");
                    if (lblCurrentSlide != null)
                    {
                        lblCurrentSlide.Text = _currentSlideNo.ToString();
                    }
                    if (pnlSlide != null)
                    { //Set the css class based on slide type
                        pnlSlide.CssClass += " " + _currentSlide.SlideFormat.Raw + " rs_read_this";
                        //Label lblTotalSlide = e.FindControlAs<Label>("lblTotalSlide");
                        //if (lblTotalSlide != null)
                        //{
                        //    lblTotalSlide.Text = _totalSlide.ToString();
                        //}
                        phImageSlide.Visible = true;
                    }
                    //show slide values
                    FieldRenderer frSlideTitle = e.FindControlAs<FieldRenderer>("frSlideTitle");
                    if (frSlideTitle != null)
                    {
                        frSlideTitle.Item = _currentSlide;
                    }
                    FieldRenderer frSlideInto = e.FindControlAs<FieldRenderer>("frSlideInto");
                    if (frSlideInto != null)
                    {
                        frSlideInto.Item = _currentSlide;
                    }
                    FieldRenderer frSlideImage = e.FindControlAs<FieldRenderer>("frSlideImage");
                    if (frSlideImage != null)
                    {
                        frSlideImage.Item = _currentSlide;
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

                var randomSlides = SearchHelper.GetLastSlide(DataSource.ID, subtopic, topic, SlideshowArticlePageItem.TemplateId);

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

        protected void rptSlideButton_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}