using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using UnderstoodDotOrg.Common.Extensions;
using System.Linq;

namespace UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages.SimpleExpertArticle
{
    public partial class SimpleExpertArticleItem
    {
        public static  IEnumerable<SimpleExpertAddQuestionPageItem> GetSimpleExpertQAList(SimpleExpertArticleItem ObjExpertArt)
    {
        IEnumerable<SimpleExpertAddQuestionPageItem> AllExpertQAList = ObjExpertArt.AllExpertQA;
        return AllExpertQAList;
            
    }
        private IEnumerable<SimpleExpertAddQuestionPageItem> _allExpertQA;
        private IEnumerable<SimpleExpertAddQuestionPageItem> AllExpertQA
        {
            get
            {
                if (_allExpertQA == null)
                {
                    _allExpertQA = this.InnerItem.GetChildren()
                        .Where(t => t.TemplateID.ToString() == SimpleExpertAddQuestionPageItem.TemplateId.ToString())
                        .Select(x => new SimpleExpertAddQuestionPageItem(x));
                }

                return _allExpertQA;
            }
        }
    }
}