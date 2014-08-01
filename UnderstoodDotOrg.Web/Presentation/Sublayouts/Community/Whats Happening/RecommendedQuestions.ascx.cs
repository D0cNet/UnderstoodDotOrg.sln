using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnderstoodDotOrg.Domain.Search;
using UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.CommunityTemplates.QandA;
using UnderstoodDotOrg.Framework.UI;
using UnderstoodDotOrg.Common.Extensions;
using UnderstoodDotOrg.Common;
using Sitecore.Links;
using UnderstoodDotOrg.Services.CommunityServices;
using UnderstoodDotOrg.Services.Models.Telligent;

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class RecommendedQuestions : BaseSublayout //System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hypAllQuestions.Text = DictionaryConstants.SeeAllQuestionsLabel;
            hypAllQuestions.NavigateUrl = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(Constants.Pages.AllQuestions));
            
            if (this.CurrentMember != null)
            {
                lvQuestionCards.DataSource = SearchHelper.GetRecommendedContent(this.CurrentMember,Question.TemplateID)// QandADetailsItem.TemplateId)
                                .Where(a => a.GetItem() != null)
                                .Select(a => Questions.QuestionFactory(a.GetItem())) //Items can exist in sitecore, but not telligent, therefore there will be missing items from this call
                                .Where(a=> a!=null)
                                 .Take(6)
                                .ToList();
                lvQuestionCards.DataBind();
            }
        }

        protected void lvQuestionCards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var hypQuestionTitle = e.Item.FindControl("hypQuestionTitle") as HyperLink;
            var litQuestionCardText = e.Item.FindControl("litQuestionCardText") as Literal;
            var hypAnswerCount = e.Item.FindControl("hypAnswerCount") as HyperLink;
            var hypQuestionLink = e.Item.FindControl("hypQuestionLink") as HyperLink;

            var item = e.Item.DataItem as Question;//QandADetailsItem;

            if (hypQuestionTitle != null && litQuestionCardText != null && hypAnswerCount != null && hypQuestionLink != null)
            {
                hypQuestionTitle.Text = item.Title;
                hypAnswerCount.Text =item.CommentCount + DictionaryConstants.AnswerFragment;
                hypQuestionLink.Text = DictionaryConstants.AnswerThisQuestionLabel;

                hypQuestionTitle.NavigateUrl = hypQuestionLink.NavigateUrl = hypAnswerCount.NavigateUrl = item.Url;

                litQuestionCardText.Text = item.Body;
            }
        }
    }
}