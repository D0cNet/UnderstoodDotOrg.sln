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
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.ActionStyleListArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Action_Style_List_Page : System.Web.UI.UserControl
    {
        ActionStyleListPageItem ObjActionListArticle;
        IEnumerable<ActionPageItem> AllChildSlides;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjActionListArticle = new ActionStyleListPageItem(Sitecore.Context.Item);
            if (ObjActionListArticle != null)
            {
                if (ObjActionListArticle.DefaultArticlePage.AuthorName.Item != null)
                {
                    //Show Author details
                    frAuthorName.Item = ObjActionListArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorBio.Item = ObjActionListArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorImage.Item = ObjActionListArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorImage.FieldName = "Author Image";
                    hlAuthorImage.NavigateUrl = ObjActionListArticle.DefaultArticlePage.AuthorName.Item.Paths.ContentPath;
                }
                if (ObjActionListArticle.DefaultArticlePage.Reviewedby.Item != null)//Reviwer Name
                {
                    lnkReviewedBy.Item = ObjActionListArticle.DefaultArticlePage.Reviewedby.Item;
                    lnkReviewedBy.Field = "Revierwer Name";
                    HyplnkReviewedBy.Text = lnkReviewedBy.Text;
                }
                if (ObjActionListArticle.DefaultArticlePage.ReviewedDate.DateTime != null)// Reviewed date 
                {
                    dtReviewdDate.Field = "Reviewed Date";
                    dtReviewdDate.Format = "dd MMM yy";
                }
                AllChildSlides = ActionStyleListPageItem.GetAllAction(ObjActionListArticle);
                if (AllChildSlides != null)
                {
                   // _totalSlide = AllChildSlides.Count();
                    rptAction.DataSource = AllChildSlides;
                    rptAction.DataBind();

                }
          
            }
        }

        protected void rptAction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ActionPageItem _currentItem = e.Item.DataItem as ActionPageItem;
                if (_currentItem != null)
                {
                    FieldRenderer frActionNo = e.FindControlAs<FieldRenderer>("frActionNo");
                    if (frActionNo != null)
                    {
                        frActionNo.Item = _currentItem;
                    }
                    FieldRenderer frActionTitle = e.FindControlAs<FieldRenderer>("frActionTitle");
                    if (frActionTitle != null)
                    {
                        frActionTitle.Item = _currentItem;
                    }
                    FieldRenderer frActionIntro = e.FindControlAs<FieldRenderer>("frActionIntro");
                    if (frActionIntro != null)
                    {
                        frActionIntro.Item = _currentItem;
                    }
                }
            }
        }
    }
}