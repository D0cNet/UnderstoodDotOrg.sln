using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy
{
    public partial class TakeActionPage : System.Web.UI.UserControl
    {
        TakeActionPageItem ObjTakeActionPage;
        IEnumerable<CampaignItem> FinalRelatedCampaigns = null;
        IEnumerable<DefaultArticlePageItem> FinalRelatedArticles = null;
        AdvocacyMainFolderItem ObjAdvocacyMainFolder;
        PartnerInfoItem ObjPartnerInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjTakeActionPage = new TakeActionPageItem(Sitecore.Context.Item);
            if (ObjTakeActionPage != null)
            {
                if (ObjTakeActionPage.InnerItem.Parent.Parent.TemplateID.ToString() == AdvocacyMainFolderItem.TemplateId)
                {
                    ObjAdvocacyMainFolder = (AdvocacyMainFolderItem)ObjTakeActionPage.InnerItem.Parent.Parent;
                    if (ObjAdvocacyMainFolder != null && ObjAdvocacyMainFolder.AdvocacyfromPartner.Item!=null )
                    {
                        ObjPartnerInfo=ObjAdvocacyMainFolder.AdvocacyfromPartner.Item;
                        frPartnerLogo.Item=ObjPartnerInfo;
                        hlPartnerLogo.NavigateUrl = ObjPartnerInfo.InnerItem.GetUrl();
                    }

                }

                FinalRelatedCampaigns = GetCampaignLinks(ObjTakeActionPage);
                if (FinalRelatedCampaigns != null)
                {
                    rptCampaigns.DataSource = FinalRelatedCampaigns;
                    rptCampaigns.DataBind();

                }
                FinalRelatedArticles = GetFeaturedArticleLinks(ObjTakeActionPage);
                if (FinalRelatedArticles != null)
                {
                    rptFeaturedArticles.DataSource = FinalRelatedArticles;
                    rptFeaturedArticles.DataBind();
                }
                if (ObjTakeActionPage.PromotionalContent.Item != null)
                {
                    frPromoImage.Item = ObjTakeActionPage.PromotionalContent.Item;
                    hlPromo.NavigateUrl = ObjTakeActionPage.PromotionalContent.Item.GetUrl();
                    hlPromo.Visible = true;
                }

            }

        }

        public IEnumerable<CampaignItem> GetCampaignLinks(TakeActionPageItem ObjTakeAction)
        {
            // Item SiteRoot=Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath, Sitecore.Data.Managers.LanguageManager.GetLanguage("en"));
            IEnumerable<Item> AllArticles = ObjTakeAction.CompaignstoShow.ListItems.Where(t => t.InheritsTemplate(CampaignItem.TemplateId));
            List<CampaignItem> FinalArticles = null;
            if (AllArticles != null)
            {
                if (AllArticles.Count() > 6) AllArticles.Take(6);
                FinalArticles = new List<CampaignItem>(AllArticles.Count());
                foreach (CampaignItem DefItem in AllArticles)
                {
                    FinalArticles.Add(DefItem);
                }
            }
            else
            {
                //Select Random max 6 articles to show
                var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                using (var context = index.CreateSearchContext())
                {
                    IEnumerable<Item> RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
                         .Where(i => i.GetItem().InheritsTemplate(CampaignItem.TemplateId));
                    //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
                    if (RandomRelatedLink != null)
                    {
                        if (RandomRelatedLink.Count() > 6) RandomRelatedLink.Take(6);
                        FinalArticles = new List<CampaignItem>(RandomRelatedLink.Count());
                    }
                    foreach (CampaignItem DefItem in RandomRelatedLink)
                    {
                        FinalArticles.Add(DefItem);
                    }
                }
            }

            return FinalArticles;
        }
        public IEnumerable<DefaultArticlePageItem> GetFeaturedArticleLinks(TakeActionPageItem ObjTakeAction)
        {
            // Item SiteRoot=Sitecore.Context.Database.GetItem(Sitecore.Context.Site.RootPath, Sitecore.Data.Managers.LanguageManager.GetLanguage("en"));
            IEnumerable<Item> AllArticles = ObjTakeAction.ArticlestoShow.ListItems.Where(t => t.InheritsTemplate(DefaultArticlePageItem.TemplateId));
            List<DefaultArticlePageItem> FinalArticles = null;
            if (AllArticles != null)
            {
                if (AllArticles.Count() > 6) AllArticles.Take(6);
                FinalArticles = new List<DefaultArticlePageItem>(AllArticles.Count());
                foreach (DefaultArticlePageItem DefItem in AllArticles)
                {
                    FinalArticles.Add(DefItem);
                }
            }
            else
            {
                //Select Random max 6 articles to show
                var index = ContentSearchManager.GetIndex(UnderstoodDotOrg.Common.Constants.CURRENT_INDEX_NAME);
                using (var context = index.CreateSearchContext())
                {
                    IEnumerable<Item> RandomRelatedLink = (System.Collections.Generic.IEnumerable<Item>)context.GetQueryable<SearchResultItem>()
                         .Where(i => i.GetItem().InheritsTemplate(DefaultArticlePageItem.TemplateId));
                    //ActualRelatedLinks = (System.Collections.Generic.IEnumerable<Item>)RandomRelatedLink;
                    if (RandomRelatedLink != null)
                    {
                        if (RandomRelatedLink.Count() > 6) RandomRelatedLink.Take(6);
                        FinalArticles = new List<DefaultArticlePageItem>(RandomRelatedLink.Count());
                    }
                    foreach (DefaultArticlePageItem DefItem in RandomRelatedLink)
                    {
                        FinalArticles.Add(DefItem);
                    }
                }
            }

            return FinalArticles;
        }


        protected void rptCampaigns_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                CampaignItem CurrentCamp = e.Item.DataItem as CampaignItem;
                if (CurrentCamp != null)
                {
                    HyperLink hlCampaignImage = e.FindControlAs<HyperLink>("hlCampaignImage");
                    if (hlCampaignImage != null)
                    {
                        FieldRenderer frCampaignImage = e.FindControlAs<FieldRenderer>("frCampaignImage");
                        if (frCampaignImage != null)
                        {
                            frCampaignImage.Item = CurrentCamp;
                        }
                        hlCampaignImage.NavigateUrl = CurrentCamp.InnerItem.GetUrl();
                        hlCampaignImage.Visible = true;

                    }

                    HyperLink hlCampaignTitle = e.FindControlAs<HyperLink>("hlCampaignTitle");
                    if (hlCampaignTitle != null)
                    {
                        FieldRenderer frCampaignTitle = e.FindControlAs<FieldRenderer>("frCampaignTitle");
                        if (frCampaignTitle != null)
                        {
                            frCampaignTitle.Item = CurrentCamp;
                            hlCampaignTitle.Text = CurrentCamp.ContentPage.PageTitle;
                            hlCampaignTitle.Visible = true;
                            hlCampaignTitle.NavigateUrl = string.Concat(Request.Url.Host.ToString(), "/", CurrentCamp.DestinationURL);
                        }
                    }
                    FieldRenderer frCampaignBodyContent = e.FindControlAs<FieldRenderer>("frCampaignBodyContent");
                    if (frCampaignBodyContent != null)
                    {
                        frCampaignBodyContent.Item = CurrentCamp;
                    }
                    Button btnActNow = e.FindControlAs<Button>("btnActNow");
                    if (btnActNow != null)
                    {
                        btnActNow.Text = CurrentCamp.LinkButtonText.Text;
                        // btnActNow.OnClientClick += new EventHandler(btnActNow_Click);
                        btnActNow.PostBackUrl = string.Concat(Request.Url.Host.ToString(), "/", CurrentCamp.DestinationURL);
                    }

                }
            }
        }

        protected void btnActNow_Click(object sender, EventArgs e)
        {


        }

        protected void rptFeaturedArticles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                DefaultArticlePageItem RelatedLink = e.Item.DataItem as DefaultArticlePageItem;
                if (RelatedLink != null)
                {
                    HyperLink hlArticleImage = e.FindControlAs<HyperLink>("hlArticleImage");
                    if (hlArticleImage != null)
                    {
                        FieldRenderer frArticleImage = e.FindControlAs<FieldRenderer>("frArticleImage");
                        if (frArticleImage != null)
                        {
                            frArticleImage.Item = RelatedLink.InnerItem;
                        }
                        hlArticleImage.NavigateUrl = RelatedLink.InnerItem.GetUrl();
                        hlArticleImage.Visible = true;
                    }
                    FieldRenderer frArticleTitle = e.FindControlAs<FieldRenderer>("frArticleTitle");
                    HyperLink hlArticleTitle = e.FindControlAs<HyperLink>("hlArticleTitle");
                    if (frArticleTitle != null)
                    {
                        frArticleTitle.Item = RelatedLink.ContentPage.InnerItem;
                        hlArticleTitle.NavigateUrl = RelatedLink.InnerItem.GetUrl(); //string.Concat(Request.Url.Host.ToString(), "/", frArticleTitle.Item.Paths.ContentPath);

                    }

                }

            }
        }


    }
}