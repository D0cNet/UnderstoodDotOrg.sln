using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle;
using Sitecore.Data.Items;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using UnderstoodDotOrg.Common.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Shared.BaseTemplate.Article;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Simple_Expert_Article_Page : System.Web.UI.UserControl
    {
        SimpleExpertArticleItem ObjSimpleExpertArticle;
        protected void Page_Load(object sender, EventArgs e)
        {
            ObjSimpleExpertArticle = new SimpleExpertArticleItem(Sitecore.Context.Item);
            if (ObjSimpleExpertArticle != null)
            {
                if (ObjSimpleExpertArticle.DefaultArticlePage.AuthorName.Item != null)
                {
                    //Show Author details
                    frAuthorName.Item = ObjSimpleExpertArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorBio.Item = ObjSimpleExpertArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorImage.Item = ObjSimpleExpertArticle.DefaultArticlePage.AuthorName.Item;
                    frAuthorImage.FieldName = "Author Image";
                    hlAuthorImage.NavigateUrl = ObjSimpleExpertArticle.DefaultArticlePage.AuthorName.Item.Paths.ContentPath;
                }
                IEnumerable<SimpleExpertAddQuestionPageItem> AllQAList = SimpleExpertArticleItem.GetSimpleExpertQAList(ObjSimpleExpertArticle);
                if (AllQAList != null)
                {
                    rptExpertQA.DataSource = AllQAList;
                    rptExpertQA.DataBind();
                }
            }
        }

        protected void rptExpertQA_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                SimpleExpertAddQuestionPageItem QAItem = e.Item.DataItem as SimpleExpertAddQuestionPageItem;
                if (QAItem != null)
                {
                    FieldRenderer frQuestion = e.FindControlAs<FieldRenderer>("frQuestion");
                    if (frQuestion != null)
                    {
                        frQuestion.Item = QAItem;
                    }
                    FieldRenderer frAnswer = e.FindControlAs<FieldRenderer>("frAnswer");
                    if (frAnswer != null)
                    {
                        frAnswer.Item = QAItem;
                    }
                    ExpertPersonItem ExpertPerson = QAItem.AnsweredExpertDetails.Item;
                    if (ExpertPerson != null)
                    {
                        FieldRenderer frExpertImage = e.FindControlAs<FieldRenderer>("frExpertImage");
                        if (frExpertImage != null)
                        {
                            frExpertImage.Item = ExpertPerson;
                        }
                        FieldRenderer frExpertName = e.FindControlAs<FieldRenderer>("frExpertName");
                        if (frExpertName != null)
                        {
                            frExpertName.Item = ExpertPerson;
                        }
                        FieldRenderer frExpertTitle = e.FindControlAs<FieldRenderer>("frExpertTitle");
                        if (frExpertTitle != null)
                        {
                            frExpertTitle.Item = ExpertPerson;
                        }
                    }
                }
            }
        }
    }
}