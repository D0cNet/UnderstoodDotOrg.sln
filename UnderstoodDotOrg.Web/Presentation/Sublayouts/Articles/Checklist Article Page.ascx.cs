using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.ChecklistArticle;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Checklist_Article_Page : System.Web.UI.UserControl
    {
        ChecklistArticlePageItem ObjChecklistArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjChecklistArticle = new ChecklistArticlePageItem(Sitecore.Context.Item);
            if( ObjChecklistArticle!= null)
            {
                // Create the checklist from base object
                if (ObjChecklistArticle.InnerItem.GetChildren() != null)
                {
                    TreeView ChecklistTree = ChecklistArticlePageItem.GetChecklistTree(ObjChecklistArticle);
                    if (ChecklistTree != null)
                    {
                        tvCheckBoxTree.DataSource = ChecklistTree.DataSource;
                        tvCheckBoxTree.DataBind();
                    }
                }
            }
        }

      
    }
}