<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FeaturedQuestions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.QandA.FeaturedQuestions" %>
<div class="col col-24 featured-parent-questions skiplink-content" aria-role="main">
    <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.FeaturedParentQuestionsLabel %></h2>

    <div class="parent-questions">
        <asp:Repeater ID="questionsRepeater" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.Question" runat="server" OnItemDataBound="questionsRepeater_ItemDataBound">
            <ItemTemplate>
                <!-- BEGIN PARTIAL: community/parent_question_card -->
                <div class="card-parent-question clearfix repeater-item">
                    <div class="question-image">
                        <img alt="70x70 Placeholder" src="http://placehold.it/70x70" />
                    </div>
                    <div class="question-info">
                        <a href="<%# Item.Url %>" class="title"><%# Item.Title %></a>
                        <span class="details">In <a href="REPLACE" class="topic"><%# Item.Group %></a> - Asked by <asp:HyperLink ID="hypUserProfileLink" CssClass="author" runat="server"><%# Item.Author %></asp:HyperLink> <span class="bullet">&bull;</span> <%# Item.PublishedDate %></span>
                        <a class="button" href="REPLACE"><%= UnderstoodDotOrg.Common.DictionaryConstants.FollowThisQuestionLabel %></a>
                    </div>
                    <div class="question-reply-container">
                        <div class="question-replies"><span class="count-replies"><%# Item.CommentCount %></span> <%= UnderstoodDotOrg.Common.DictionaryConstants.RepliesLabel %></div>
                    </div>
                </div>
                <!-- END PARTIAL: community/parent_question_card -->
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
    <!--Show More-->
    <div class="container show-more rs_skip">
        <div class="row">
            <div class="col col-24">
                <a class="show-more-link " href="#" data-path="community/parent-questions" data-container="parent-questions" data-item="card-parent-question" data-count="6"><%= UnderstoodDotOrg.Common.DictionaryConstants.ShowMoreLabel %><i class="icon-arrow-down-blue"></i></a>
            </div>
        </div>
    </div>
    <!-- .show-more -->
    <!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->

</div>
