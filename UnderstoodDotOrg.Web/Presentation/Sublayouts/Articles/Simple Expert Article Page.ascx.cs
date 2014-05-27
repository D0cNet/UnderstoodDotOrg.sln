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
using UnderstoodDotOrg.Framework.UI;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles
{
    public partial class Simple_Expert_Article_Page : BaseSublayout<SimpleExpertArticleItem>
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            sbAboutAuthor.Visible = Model.DefaultArticlePage.AuthorName.Item != null;
            sbSidebarPromo.Visible = Model.DefaultArticlePage.ShowPromotionalControl.Checked;

            var allQAList = Model.GetSimpleExpertQAList();
            rptExpertQA.DataSource = allQAList;
            rptExpertQA.DataBind();
        }

        protected void rptExpertQA_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.IsItem())
            {
                var QAItem = e.Item.DataItem as SimpleExpertAddQuestionPageItem;

                var frQuestion = e.FindControlAs<FieldRenderer>("frQuestion");
                if (frQuestion != null)
                {
                    frQuestion.Item = QAItem;
                }
                var frAnswer = e.FindControlAs<FieldRenderer>("frAnswer");
                if (frAnswer != null)
                {
                    frAnswer.Item = QAItem;
                }
                var ExpertPerson = QAItem.AnsweredExpertDetails.Item;
                if (ExpertPerson != null)
                {
                    var frExpertImage = e.FindControlAs<Sitecore.Web.UI.WebControls.Image>("frExpertImage");
                    if (frExpertImage != null)
                    {
                        frExpertImage.Item = ExpertPerson;
                    }
                    var frExpertName = e.FindControlAs<FieldRenderer>("frExpertName");
                    if (frExpertName != null)
                    {
                        frExpertName.Item = ExpertPerson;
                    }
                    var frExpertTitle = e.FindControlAs<FieldRenderer>("frExpertTitle");
                    if (frExpertTitle != null)
                    {
                        frExpertTitle.Item = ExpertPerson;
                    }
                }
            }
        }
    }
}