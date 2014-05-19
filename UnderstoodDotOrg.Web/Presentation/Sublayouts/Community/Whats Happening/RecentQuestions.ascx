<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentQuestions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Whats_Happening.RecentQuestions" %>
<div class="recent-questions">
    <div class="row">
        <div class="col col-24 recent-questions-wrapper">
            <h2>Recent Questions</h2>
            <div class="carousel-arrow-wrapper">
                <!-- BEGIN PARTIAL: community/carousel_arrows -->
                <div class="arrows questions next-prev-menu">

                    <a class="view-all" href="REPLACE">See all questions</a>

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
                                        <a href="<%#CurrentItemUrl + Item.QueryString %>"><%# Item.Title %></a>
                                    </div>
                                    <!-- end .question-card-title -->
                                    <div class="question-card-text">
                                        <%# Item.Body %>
                                    </div>
                                    <!-- end .question-card-text -->
                                </div>
                                <ul class="question-card-links">
                                    <li><a href="REPLACE"><%# Item.CommentCount %> answers</a></li>
                                    <li><a href="REPLACE">Answer this Question</a></li>
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