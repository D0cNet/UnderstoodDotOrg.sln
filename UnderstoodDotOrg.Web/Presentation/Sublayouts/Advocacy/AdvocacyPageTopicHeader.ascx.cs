using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.Advocacy;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.SitecoreCIG;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Advocacy
{
    public partial class AdvocacyPageTopicHeader : BaseSublayout<AdvocacyBasePageItem>
    {
        protected BasePageNEWItem PreviousPageItem { get; set; }

        private bool? _isArticlePage;
        protected bool IsArticlePage
        {
            get
            {
                return (_isArticlePage = _isArticlePage ?? 
                    Sitecore.Context.Item.IsOfType(AdvocacyArticlePageItem.TemplateId)).Value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //hlBackToPreviousPage.NavigateUrl = Sitecore.Context.Item.Parent.GetUrl();
            //litBackToPreviousPage.Text = "Back";
            PreviousPageItem = Sitecore.Context.Item.Parent.InheritsTemplate(BasePageNEWItem.TemplateId) ? Sitecore.Context.Item.Parent : MainsectionItem.GetHomeItem().InnerItem;
        }
    }
}