<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuestionAnswers.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA.QuestionAnswers" %>
<div class="col col-24 skiplink-comments">
    <h2>Answers (<asp:Label ID=lbAnswerCount runat="server" />)</h2>
    <!-- BEGIN PARTIAL: community/question_sort -->
    <div class="question-sort clearfix">
        <div class="sort-options">
            <div class="dropdown">
                <a class="dropdown-toggle" role="button" data-toggle="dropdown" href="#">
                    <span class="current-filter">Most helpful</span>
                    <span class="dropdown-title">Sort By</span>
                </a>
                <ul class="dropdown-menu" role="menu">

                    <li role="presentation" class="filter selected" data-sort-by="helpful"><a role="menuitem">Most helpful</a></li>

                    <li role="presentation" class="filter " data-sort-by="date"><a role="menuitem">Most recent</a></li>

                </ul>
            </div>
        </div>
    </div>

    <!-- END PARTIAL: community/question_sort -->
    <div class="answer-list">
        <asp:Repeater ID="AnswerRepeater" runat="server"
            ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.Answer" OnItemDataBound="AnswerRepeater_ItemDataBound">
            <ItemTemplate>
        <!-- BEGIN PARTIAL: community/answer_card -->
        <div class="card-answer">
            <div class="answer-image">
                <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />

                <span class="badge moderator">M</span>

            </div>
            <div class="question-answer-info">
                <div class="description">
                    <%# Item.Body %>
                </div>
                <span class="details">In <a href="REPLACE" class="topic">aut molestias</a> - Answered by <asp:HyperLink ID="hypUserProfileLink" CssClass="author" runat="server"><%# Item.Author %></asp:HyperLink>, Moderator <span class="bullet">&bull;</span> <%# Item.PublishedDate %></span>
                <div class="buttons">
                    <button class="helped"><i class="icon-comment-like"></i>This Helped</button>
                    <button class="report"><i class="icon-comment-flag"></i>Report as inappropriate</button>
                </div>
                <button class="count-helped"><i class="icon-comment-like"></i>8<span class="visuallyhidden">likes</span></button>
            </div>
        </div>
        <!-- END PARTIAL: community/answer_card -->
                </ItemTemplate>
            </asp:Repeater>
    </div>

    <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    <div class="container show-more">
        <div class="row">
            <div class="col col-24">
                <a class="show-more-link " href="#" data-path="community/qa-answers" data-container="answer-list" data-item="card-answer" data-count="6">Show More<i class="icon-arrow-down-blue"></i></a>
            </div>
        </div>
    </div>
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->

</div>
