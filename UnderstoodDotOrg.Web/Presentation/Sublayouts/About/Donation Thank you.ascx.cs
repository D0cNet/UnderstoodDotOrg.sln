using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;
//using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.TextOnlyTipsArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.Search;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.About
{
    public partial class Donation_Thank_you : System.Web.UI.UserControl
    {
        DonationThankYouPageItem ObjDonationThx;
        List<DefaultArticlePageItem> FinalRelatedArticles = null;
        object[][] _jaggedArray;

        protected void Page_Load(object sender, EventArgs e)
        {
            ObjDonationThx = new Domain.SitecoreCIG.Poses.Pages.AboutPages.DonationThankYouPageItem(Sitecore.Context.Item);
            if (ObjDonationThx != null)
            {

                //SearchHelper.GetRandomMustReadArticles(4).Where(t => t.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
                FinalRelatedArticles = GetRecommendations(true);
                if (FinalRelatedArticles != null)
                {
                    int _objectat = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        _jaggedArray = new object[i][];
                        _jaggedArray[i] = new object[2];
                        for (int j = 0; j < 2; j++)
                        {
                            _jaggedArray[i][j] = FinalRelatedArticles[_objectat];
                            _objectat++;

                        }
                    }

                    String[] OuterLoop = new String[2];
                    OuterLoop[0] = "one";
                    OuterLoop[1] = "two";
                    rptRecommendation.DataSource = OuterLoop;
                    rptRecommendation.DataBind();
                }
                

            }
        }

        protected void rptRecommendation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                String i = e.Item.DataItem as String;
                if (i == "one")
                {
                    if (FinalRelatedArticles != null)
                    {
                        Repeater rptTwoArticle = e.FindControlAs<Repeater>("rptTwoArticle");
                        if (rptTwoArticle != null)
                        {
                            rptTwoArticle.DataSource = _jaggedArray[0];
                            rptTwoArticle.DataBind();
                        }
                    }
                }
                if (i == "two")
                {
                    if (FinalRelatedArticles != null)
                    {
                        Repeater rptTwoArticle = e.FindControlAs<Repeater>("rptTwoArticle");
                        if (rptTwoArticle != null)
                        {
                            rptTwoArticle.DataSource = _jaggedArray[1];
                            rptTwoArticle.DataBind();
                        }
                    }
                }

            }
        }


        public List<DefaultArticlePageItem> GetRecommendations(bool ShowRandom)
        {
            List<DefaultArticlePageItem> FinalArticles = null;
            if (ShowRandom == true)
            {
                //var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                //using (var context = index.CreateSearchContext())
                //{
                    //IEnumerable<Item> RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
                    //     .Where(i => i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
                    //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;

                    IEnumerable<Item> RandomRelatedLink = SearchHelper.GetRandomMustReadArticles(4).Select(a =>a.GetItem());


                    if (RandomRelatedLink != null)
                    {

                        if (RandomRelatedLink.Count() > 4) RandomRelatedLink.Take(4);
                        FinalArticles = new List<DefaultArticlePageItem>(RandomRelatedLink.Count());
                    }
                    foreach (Item DefItem in RandomRelatedLink)
                    {
                        FinalArticles.Add(DefItem);
                    }
                //}
            }
            return FinalArticles;
        }

        protected void rptTwoArticle_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem _currentArticle = e.Item.DataItem as DefaultArticlePageItem;
                if (_currentArticle != null)
                {
                    HyperLink hlRecommendImage = e.FindControlAs<HyperLink>("hlRecommendImage");
                    if (hlRecommendImage != null)
                    {
                        FieldRenderer frRecommendImage = e.FindControlAs<FieldRenderer>("frRecommendImage");
                        if (frRecommendImage != null)
                        {
                            frRecommendImage.Item = _currentArticle;
                            hlRecommendImage.NavigateUrl = _currentArticle.InnerItem.GetUrl();
                        }
                    }

                    HyperLink hlRecommendTitle = e.FindControlAs<HyperLink>("hlRecommendTitle");
                    if (hlRecommendTitle != null)
                    {
                        FieldRenderer frRecommendTitle = e.FindControlAs<FieldRenderer>("frRecommendTitle");
                        if (frRecommendTitle != null)
                        {
                            frRecommendTitle.Item = _currentArticle;
                            hlRecommendTitle.NavigateUrl = _currentArticle.InnerItem.GetUrl();
                        }
                    }
                }
            }
        }
    }
}