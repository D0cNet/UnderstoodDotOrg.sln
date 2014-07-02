using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Common;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Base.BasePageItems;
using UnderstoodDotOrg.Domain.TelligentCommunity;
using UnderstoodDotOrg.Domain.Understood.Activity;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.ArticlePages;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Shared
{
    public partial class FoundHelpfulCountOnly : BaseSublayout
    {
        private Item model;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.model = Sitecore.Context.Item;

            BindContent();
            PopulateCount();
        }

        private void BindContent()
        {
            if (this.model.TemplateID == Sitecore.Data.ID.Parse(InfographicArticlePageItem.TemplateId))
            {
                frIntroText.FieldName = ((InfographicArticlePageItem)this.model).IntroText.Field.InnerField.Name;
            }
            else if (this.model.InheritsTemplate(DefaultArticlePageItem.TemplateId))
            {
                frIntroText.FieldName = ((DefaultArticlePageItem)this.model).ContentPage.BodyContent.Field.InnerField.Name;
            }
        }

        private void PopulateCount()
        {
            ActivityLog tempLog = new ActivityLog();
            
            int helpfulCount = tempLog.GetActivityCountByValue(Guid.Parse(this.model.ID.ToString()), Constants.UserActivity_Values.FoundHelpful_True);

            lblHelpfulCount.Text = lblHelpfulCountMobile.Text = helpfulCount.ToString();

            ltlFoundThisHelpful.Text = ltlFoundThisHelpfulMobile.Text = DictionaryConstants.FoundThisHelpful;
        }
    }
}