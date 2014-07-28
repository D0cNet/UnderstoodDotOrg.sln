﻿using System;
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

namespace UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening
{
    public partial class RecommendedQuestions : BaseSublayout //System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hypAllQuestions.Text = "poop";
            hypAllQuestions.NavigateUrl = "#";

            List<QandADetailsItem> recommendedQuestions;

            recommendedQuestions = SearchHelper.GetRecommendedContent(this.CurrentMember, QandADetailsItem.TemplateId)
                                .Where(a => a.GetItem() != null)
                                .Select(a => new QandADetailsItem(a.GetItem()))
                                .ToList();

            lvQuestionCards.DataSource = recommendedQuestions;
            lvQuestionCards.DataBind();
        }

        protected void lvQuestionCards_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            var hypQuestionTitle = e.Item.FindControl("hypQuestionTitle") as HyperLink;
            var litQuestionCardText = e.Item.FindControl("litQuestionCardText") as Literal;
            var hypAnswerCount = e.Item.FindControl("hypAnswerCount") as HyperLink;
            var hypQuestionLink = e.Item.FindControl("hypQuestionLink") as HyperLink;

            var item = e.Item.DataItem as QandADetailsItem;

            if (hypQuestionTitle != null && litQuestionCardText != null && hypAnswerCount != null && hypQuestionLink != null)
            {
                hypQuestionTitle.Text = item.QuestionTitle;
                hypAnswerCount.Text = "5 " + DictionaryConstants.AnswerFragment;
                hypQuestionLink.Text = DictionaryConstants.AnswerThisQuestionLabel;

                hypQuestionTitle.NavigateUrl = hypQuestionLink.NavigateUrl = hypAnswerCount.NavigateUrl = item.GetUrl();

                litQuestionCardText.Text = item.QuestionBody;
            }
        }
    }
}