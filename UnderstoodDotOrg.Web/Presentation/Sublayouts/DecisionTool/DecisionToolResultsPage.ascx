﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DecisionToolResultsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool.DecisionToolResultsPage" %>

<div class="dl-quiz-container container results">
    <div class="row">
        <div class="col col-23 offset-1 dl-quiz-wrapper rs_read_this">
            <div class="dl-quiz skiplink-content">
                <h2><%= QuestionPage.ContentPage.PageTitle %></h2>
                <h3>You Answered:</h3>
                <asp:Repeater ID="rptrAnswers" runat="server">
                    <ItemTemplate>
                        <p class="correctness-headline<%# Container.ItemIndex < (Answers.Count - 1) ? " ready" : string.Empty %>">
                            <%# Eval("IndicatorCount") %> <%# Eval("AnswerText") %>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="explanation-wrapper">
                    <%= IndicatedAnswerAbstract %>
                </div>
                <br />
                <div class="next-question">
                    <button type="button" runat="server" onserverclick="StartOver_Click" class="button rs_skip">Start Over</button>
                </div>
            </div>
        </div>
    </div>
    <div class="container flush dl-content">
        <section class="dl-list-results">
            <div class="result-section row">
                <div class="col col-24">
                    <header>
                        <h2 class="rs_read_this">Other Decisions to Explore...</h2>
                    </header>
                </div>
                <div class="results-outer-wrapper">
                    <div class="results-wrapper">
                        <asp:Repeater ID="rptrQuestions" runat="server" 
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Pages.DecisionQuestionPageItem">
                            <ItemTemplate>
                                <!-- BEGIN PARTIAL: decision-lite/dl-list-item -->
                                <div class="search-result rs_read_this" aria-role="main">
                                    <button class="result-body rs_preserve">
                                        <div class="result-topic"><%# Item.ContentPage.PageTitle.Rendered %></div>
                                        <div class="result-hover">
                                            <div class="hover-link-wrapper">
                                                <a href="<%# Item.GetStartUrl() %>" class="topic-question"><%# Item.ContentPage.PageTitle.Rendered %></a>
                                            </div>
                                        </div>
                                    </button>
                                    <span class="children-key">
                                        <ul>
                                            <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                        </ul>
                                    </span>
                                </div>
                                <!-- END PARTIAL: decision-lite/dl-list-item -->
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!-- .results-wrapper -->
                </div>
                <!-- .results-outer-wrapper -->
            </div>
        </section>
    </div>
    <!-- .container -->
</div>
