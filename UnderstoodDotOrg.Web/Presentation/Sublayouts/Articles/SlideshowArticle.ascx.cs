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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class SlideshowArticle : System.Web.UI.UserControl
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
                    PlaceHolder phEnd = e.FindControlAs<PlaceHolder>("phEnd");
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
                    }
                    if(_currentSlide.SlideFormat.Raw.Contains("end"))
                    {
                        phEnd.Visible = true;
                        phImageSlide.Visible = false;
                        //show values for end slide
                    }
                    else
                    {
                        phEnd.Visible = false;
                        phImageSlide.Visible = true;
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
                   
            }
        }

        protected void rptSlideButton_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}