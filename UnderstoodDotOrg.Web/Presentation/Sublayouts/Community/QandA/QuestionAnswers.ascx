<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionAnswers.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA.QuestionAnswers" %>
<%@ Register Src="~/Presentation/Sublayouts/Common/LikeButton.ascx" TagPrefix="uc1" TagName="LikeButton" %>
<div class="col col-24 skiplink-comments">
    <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.AnswersLabel %> (<asp:Label ID=lbAnswerCount runat="server" />)</h2>
    <!-- BEGIN PARTIAL: community/question_sort -->
    <div id="divSortAnswers" class="question-sort clearfix" runat="server">
        <div class="sort-options">
            <div class="dropdown">
                <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                    <span class="current-filter"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostHelpfulLabel %></span>
                    <span class="dropdown-title"><%= UnderstoodDotOrg.Common.DictionaryConstants.SortByLabel %></span>
                </a>
                <ul class="dropdown-menu" role="menu">

                    <li role="presentation" class="filter selected" data-sort-by="helpful"><a role="menuitem"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostHelpfulLabel %></a></li>

                    <li role="presentation" class="filter " data-sort-by="date"><a role="menuitem"><%= UnderstoodDotOrg.Common.DictionaryConstants.MostRecentLabel %></a></li>

                </ul>
            </div>
        </div>
    </div>

    <!-- END PARTIAL: community/question_sort -->
    <div class="answer-list">
        <asp:Repeater ID="AnswerRepeater" runat="server"
            ItemType="UnderstoodDotOrg.Services.Models.Telligent.Answer" OnItemDataBound="AnswerRepeater_ItemDataBound">
            <ItemTemplate>
        <!-- BEGIN PARTIAL: community/answer_card -->
        <div class="card-answer">
            <div class="answer-image">
                <img style="height: 70px; width: 70px;" alt="70x70 Placeholder" src="<%# Item.AuthorAvatar %>" />

                <span class="badge moderator">M</span>

            </div>
            <div class="question-answer-info">
                <div class="description">
                    <%# Item.Body %>
                </div>
                <span class="details"><sc:Text Field="In Text" runat="server" /> <a href="REPLACE" class="topic"><asp:Literal ID="lbGroup" runat="server" /></a> - <sc:Text Field="Answered By Text" runat="server" /> <asp:HyperLink ID="hypUserProfileLink" CssClass="author" runat="server"><%# Item.Author %></asp:HyperLink>, <asp:Literal ID="lbModerator" runat="server" Text="<%# UnderstoodDotOrg.Common.DictionaryConstants.ModeratorLabel %>" /> <span class="bullet">&bull;</span> <%# Item.PublishedDate %></span>
                <div class="buttons">
                    <button id="btnLike" onserverclick="LikeButton_Click" class="helped" runat="server"><i class="icon-comment-like"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.ThisHelpedLabel %></button>
                    <button class="report"><i class="icon-comment-flag"></i><%= UnderstoodDotOrg.Common.DictionaryConstants.ReportAsInappropriateLabel %></button>
                </div>
                <button class="count-helped"><i class="icon-comment-like"></i><%# Item.Likes %><span class="visuallyhidden">likes</span></button>
            </div>
        </div>
        <!-- END PARTIAL: community/answer_card -->
                </ItemTemplate>
            </asp:Repeater>
    </div>

    <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    
   <div class="container show-more rs_skip" id="divShowMore" runat="server">
        <div class="row">
            <div class="col col-24">
                <a class="show-more-link " href="#" data-path="community/qa-answers" data-container="answer-list" data-item="card-answer" data-count="6"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreLabel %><i class="icon-arrow-down-blue"></i></a>
            </div>
        </div>
    </div>
    <div>here</div>
    
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->
</div>