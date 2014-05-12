using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class TextOnlyTipsArticle : System.Web.UI.UserControl
    {
        TextOnlyTipsArticlePageItem ObjTextTipsArticle;
        IEnumerable<TextTipPageItem> AllChildSlides;
        int _CurrentTipNo, _totalTipsCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Set Slide Counter value and binda data accordinly
            ObjTextTipsArticle = new TextOnlyTipsArticlePageItem(Sitecore.Context.Item);
            if (ObjTextTipsArticle != null)
            {
                RptDataBind();
            }

        }
        public void RptDataBind()
        {
            AllChildSlides = TextOnlyTipsArticlePageItem.GetAllSlides(ObjTextTipsArticle);
            if (AllChildSlides != null)
            {
                // _totalSlide = AllChildSlides.Count();
                _CurrentTipNo = 0;
                _totalTipsCount = AllChildSlides.Count();
                rptAllTips.DataSource = AllChildSlides;
                rptAllTips.DataBind();

                uxSliderButtonGroup.DataSource = AllChildSlides;
                uxSliderButtonGroup.DataBind();

            }

        }
        public static IEnumerable<Item> GetRandom2TipsArticles(TextOnlyTipsArticlePageItem _CurrnetTipsArtcle)
        {
            IEnumerable<Item> _RandomTipsArticle;
            var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
            using (var context = index.CreateSearchContext())
            {
                _RandomTipsArticle =(IEnumerable<Item>) context.GetQueryable<SearchResultItem>()
                     .Where(i => i.ItemId != _CurrnetTipsArtcle.ID);
                
                if (_RandomTipsArticle != null)
                {
                    if (_RandomTipsArticle.Count() > 2) _RandomTipsArticle = _RandomTipsArticle.Take(2);
                }
            }
            return _RandomTipsArticle;
        }

        protected void rptAllTips_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                TextTipPageItem _currentTip = e.Item.DataItem as TextTipPageItem;
                if (_currentTip != null)
                {
                    Panel pnlTips = e.FindControlAs<Panel>("pnlTips");
                    PlaceHolder phEnd = e.FindControlAs<PlaceHolder>("phEnd");
                    PlaceHolder phSlide = e.FindControlAs<PlaceHolder>("phSlide");
                    _CurrentTipNo++;
                    if (pnlTips != null)
                    {
                        //check for tip type(end slide) open phend
                        if (_currentTip.ShowasEndSlide.Checked == true)
                        {
                            // open end slide ph
                            //set end slide css
                            pnlTips.CssClass += " end";
                            if (phEnd != null)
                            {
                                phEnd.Visible = true;
                                phSlide.Visible = false;
                                //IEnumerable<TextOnlyTipsArticlePageItem> RandomTipsArticle =(IEnumerable<TextOnlyTipsArticlePageItem>) GetRandom2TipsArticles(ObjTextTipsArticle);
                                //if (RandomTipsArticle != null)
                                //{
                                    
                                //    HyperLink hlRandomArticle1 = e.FindControlAs<HyperLink>("hlRandomArticle1");
                                //    if (hlRandomArticle1 != null && RandomTipsArticle.ElementAt(0)!=null )
                                //    {
                                //        FieldRenderer frRandomTipArticleTitle1 = e.FindControlAs<FieldRenderer>("frRandomTipArticleTitle1");
                                //        if (frRandomTipArticleTitle1 != null)
                                //        {
                                //            frRandomTipArticleTitle1.Item = RandomTipsArticle.ElementAt(0);
                                //        }
                                //        FieldRenderer frRandomTipsArticleIntro1 = e.FindControlAs<FieldRenderer>("frRandomTipsArticleIntro1");
                                //        if (frRandomTipsArticleIntro1 != null)
                                //        {
                                //            frRandomTipsArticleIntro1.Item = RandomTipsArticle.ElementAt(0);
                                //        }
                                //        hlRandomArticle1.NavigateUrl = RandomTipsArticle.ElementAt(0).InnerItem.GetUrl().ToString();
                                //    }
                                //     HyperLink hlRandomArticle2 = e.FindControlAs<HyperLink>("hlRandomArticle2");
                                //     if (hlRandomArticle2 != null && RandomTipsArticle.ElementAt(1)!=null)
                                //     {
                                //         FieldRenderer frRandomTipArticleTitle2 = e.FindControlAs<FieldRenderer>("frRandomTipArticleTitle2");
                                //         if (frRandomTipArticleTitle2 != null)
                                //         {
                                //             frRandomTipArticleTitle2.Item = RandomTipsArticle.ElementAt(1);
                                //         }
                                //         FieldRenderer frRandomTipsArticleIntro2 = e.FindControlAs<FieldRenderer>("frRandomTipsArticleIntro2");
                                //         if (frRandomTipsArticleIntro2 != null)
                                //         {
                                //             frRandomTipsArticleIntro2.Item = RandomTipsArticle.ElementAt(1);
                                //         }
                                //         hlRandomArticle2.NavigateUrl = RandomTipsArticle.ElementAt(1).InnerItem.GetUrl().ToString();
                                //     }
                                //}
                            }

                        }
                        else
                        {
                            // set Slide based color css class
                            pnlTips.CssClass += " text-slide " + _currentTip.Backgroundcolor.Raw + "-background";
                            if (phSlide != null)
                            {
                                phEnd.Visible = false;
                                phSlide.Visible = true;
                                FieldRenderer frTipTitle = e.FindControlAs<FieldRenderer>("frTipTitle");
                                if (frTipTitle != null)
                                {
                                    frTipTitle.Item = _currentTip;
                                }
                                FieldRenderer frTipText = e.FindControlAs<FieldRenderer>("frTipText");
                                if (frTipText != null)
                                {
                                    frTipText.Item = _currentTip;
                                }
                                Label lblCurrentTip = e.FindControlAs<Label>("lblCurrentTip");
                                if (lblCurrentTip != null)
                                {
                                    lblCurrentTip.Text=_CurrentTipNo.ToString();
                                }
                                Label lblTotalTips = e.FindControlAs<Label>("lblTotalTips");
                                if (lblTotalTips != null)
                                {
                                    lblTotalTips.Text = _totalTipsCount.ToString();
                                }
                            }

                        }
                        //else open ph slide and set css accordingly
                    }
                }
            }
        }
    }
}