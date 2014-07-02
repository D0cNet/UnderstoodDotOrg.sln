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
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Action_Style_List_Page : BaseSublayout<ActionStyleListPageItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Model.DefaultArticlePage.AuthorName.Item != null)
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
            if (Model.DefaultArticlePage.ShowPromotionalControl.Checked == true)
            {
                sbSidebarPromo.Visible = true;
            }
            else
            {
                sbSidebarPromo.Visible = false;
            }

            var allChildSlides = ActionStyleListPageItem.GetAllAction(Model);
            rptAction.DataSource = allChildSlides;
            rptAction.DataBind();
        }

        protected void rptAction_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                ActionPageItem _currentItem = e.Item.DataItem as ActionPageItem;

                Label lblActionCount = e.FindControlAs<Label>("lblActionCount");
                if (lblActionCount != null)
                {
                    lblActionCount.Text = (e.Item.ItemIndex+1).ToString();
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