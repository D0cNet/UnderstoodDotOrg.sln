<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentQuestions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.RecentQuestions" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="recent-questions">
    <div class="row">
        <div class="col col-24 recent-questions-wrapper">
            <h2><%= UnderstoodDotOrg.Common.DictionaryConstants.RecentQuestionsLabel %></h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows questions next-prev-menu">

                    <asp:HyperLink CssClass="view-all" ID="lnkSeeAll" runat="server"><%= UnderstoodDotOrg.Common.DictionaryConstants.SeeAllQuestionsLabel %></asp:HyperLink>

                    <div class="rsArrow rsArrowLeft">
                        <button class="rsArrowIcn"></button>
                    </div>
                    <div class="rsArrow rsArrowRight">
                        <button class="rsArrowIcn"></button>
                    </div>
                </div>
                <!-- end .arrows -->
                <!-- END PARTIAL: community/carousel_arrows -->
            </div>
            <div class="row question-cards">
                <asp:Repeater ID="RecentQuestionsRepeater" ItemType="UnderstoodDotOrg.Domain.TelligentCommunity.Question" runat="server">
                    <ItemTemplate>
                        <!-- BEGIN PARTIAL: community/question_card -->
                        <div class="col col-12 question-card">
                            <div class="question-card-info group">
                                <div class="question-card-title-and-text">
                                    <div class="question-card-title">
                                        <a href="<%# Item.Url %>"><%# Item.Title %></a>
                                    </div>
                                    <!-- end .question-card-title -->
                                    <div class="question-card-text">
                                        <%# Item.Body %>
                                    </div>
                                    <!-- end .question-card-text -->
                                </div>
                                <ul class="question-card-links">
                                    <li><a href="<%# Item.Url %>"><%# Item.CommentCount %> <%= UnderstoodDotOrg.Common.DictionaryConstants.AnswersLabel %></a></li>
                                    <li><a href="<%# Item.Url %>"><%= UnderstoodDotOrg.Common.DictionaryConstants.AnswerQuestionLabel %></a></li>
                                </ul>
                                <!-- end .question-card-links -->
                            </div>
                            <!-- end .question-card-info -->
                        </div>
                        <!-- end .question-card -->
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <!-- end .question-cards -->
        </div>
        <!-- end .col.col-24.container -->
    </div>
    <!-- end .row -->
</div>
<!-- end .recent-questions -->