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
        int _currentActionNo;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjActionListArticle = new ActionStyleListPageItem(Sitecore.Context.Item);
            if (ObjActionListArticle != null)
            {
                if (ObjActionListArticle.DefaultArticlePage.AuthorName.Item != null)
                {
                    sbAboutAuthor.Visible = true;
                    ////Show Author details
                    //frAuthorName.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    //frAuthorBio.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    //frAuthorImage.Item = ObjBasicArticle.DefaultArticlePage.AuthorName.Item;
                    //frAuthorImage.FieldName = "Author Image";
                    //hlAuthorImage.NavigateUrl = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.Paths.ContentPath;
                    //hlAuthorMorePost.NavigateUrl = ObjBasicArticle.DefaultArticlePage.AuthorName.Item.Paths.FullPath;
                }
                if (ObjActionListArticle.ShowPromotionalControl.Checked == true)
                {
                    sbSidebarPromo.Visible = true;
                }
                else
                {
                    sbSidebarPromo.Visible = false;
                }
                if (ObjActionListArticle.DefaultArticlePage.Reviewedby.Item != null && ObjActionListArticle.DefaultArticlePage.ReviewedDate.DateTime != null)//Reviwer Name
                    SBReviewedBy.Visible = true;
                else
                    SBReviewedBy.Visible = false;

                AllChildSlides = ActionStyleListPageItem.GetAllAction(ObjActionListArticle);
                if (AllChildSlides != null)
                {
                   // _totalSlide = AllChildSlides.Count();
                    _currentActionNo = 0;
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
                    _currentActionNo++;
                    Label lblActionCount = e.FindControlAs<Label>("lblActionCount");
                    if (lblActionCount != null)
                    {
                        lblActionCount.Text = _currentActionNo.ToString();
                    }
                    //FieldRenderer frActionNo = e.FindControlAs<FieldRenderer>("frActionNo");
                    //if (frActionNo != null)
                    //{
                    //    frActionNo.Item = _currentItem;
                    //}
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