using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.AboutPages;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Web.UI.WebControls;
using Sitecore.Data.Items;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Folders;


namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy
{
    public partial class Advocacy_Article_Page : System.Web.UI.UserControl
    {
        AdvocacyArticlePageItem ObjAdvocacyArticle;
        IEnumerable<ArticleCalloutItem> _allArticleCallouts;
        AdvocacyMainFolderItem ObjAdvocacyMainFolder;
        PartnerInfoItem ObjPartnerInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjAdvocacyArticle = new AdvocacyArticlePageItem(Sitecore.Context.Item);
            if (ObjAdvocacyArticle != null)
            {
                frBodyContent.Item =frThumbnailImage.Item= ObjAdvocacyArticle;
                if (ObjAdvocacyArticle.InnerItem.Parent.Parent.TemplateID.ToString() == AdvocacyMainFolderItem.TemplateId)
                {
                    ObjAdvocacyMainFolder = (AdvocacyMainFolderItem)ObjAdvocacyArticle.InnerItem.Parent.Parent;
                    if (ObjAdvocacyMainFolder != null && ObjAdvocacyMainFolder.AdvocacyfromPartner.Item != null)
                    {
                        ObjPartnerInfo = ObjAdvocacyMainFolder.AdvocacyfromPartner.Item;
                        frPartnerLogo.Item = ObjPartnerInfo;
                        hlPartnerLogo.NavigateUrl = ObjPartnerInfo.InnerItem.GetUrl();
                    }

                }
                // Get Callout Content
                _allArticleCallouts = AdvocacyArticlePageItem.GetAllArticleCallouts(ObjAdvocacyArticle);
                if (_allArticleCallouts != null)
                {
                    rptArticleCallouts.DataSource = _allArticleCallouts;
                    rptArticleCallouts.DataBind();
                }
                if (string.IsNullOrEmpty(ObjAdvocacyArticle.DisplayTextforLink1.Text) == false)
                {
                    btnLink1.Text = ObjAdvocacyArticle.DisplayTextforLink1.Text;
                    if (string.IsNullOrEmpty(ObjAdvocacyArticle.NavigationURLforLink1.Text) == false)
                    {
                        btnLink1.PostBackUrl = ObjAdvocacyArticle.NavigationURLforLink1;
                    }

                }
                if (string.IsNullOrEmpty(ObjAdvocacyArticle.DisplayTextforLink2.Text) == false)
                {
                    btnLink2.Text = ObjAdvocacyArticle.DisplayTextforLink2.Text;
                    if (string.IsNullOrEmpty(ObjAdvocacyArticle.NavigationURLforLink2.Text) == false)
                    {
                        btnLink2.PostBackUrl = ObjAdvocacyArticle.NavigationURLforLink2;
                    }

                }
                if (string.IsNullOrEmpty(ObjAdvocacyArticle.DisplayTextforLink3.Text) == false)
                {
                    btnLink3.Text = ObjAdvocacyArticle.DisplayTextforLink3.Text;
                    if (string.IsNullOrEmpty(ObjAdvocacyArticle.NavigationURLforLink3.Text) == false)
                    {
                        btnLink3.PostBackUrl = ObjAdvocacyArticle.NavigationURLforLink3;
                    }

                }
            }
        }

        protected void rptArticleCallouts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ArticleCalloutItem _currentArticleCallout = e.Item.DataItem as ArticleCalloutItem;
                if (_currentArticleCallout != null)
                {
                    FieldRenderer frCalloutTitle = e.FindControlAs<FieldRenderer>("frCalloutTitle");
                    if (frCalloutTitle != null)
                    {
                        frCalloutTitle.Item = _currentArticleCallout;
                    }
                    FieldRenderer frCalloutDescription = e.FindControlAs<FieldRenderer>("frCalloutDescription");
                    if (frCalloutDescription != null)
                    {
                        frCalloutDescription.Item = _currentArticleCallout;
                    }
                }
            }
        }

        protected void btnLink1_Click(object sender, EventArgs e)
        {
              
               
        }

        protected void btnLink2_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnLink3_Click(object sender, EventArgs e)
        {
            
        }
    }
}