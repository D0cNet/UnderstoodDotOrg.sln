<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DecisionToolResultsPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool.DecisionToolResultsPage" %>

<div class="dl-quiz-container container results">
    <div class="row">
        <div class="col col-23 offset-1 dl-quiz-wrapper rs_read_this">
            <div class="dl-quiz skiplink-content">
                <h2><%= Question.ContentPage.PageTitle %></h2>
                <h3>You Answered:</h3>
                <%--<p class="correctness-headline ready">6 Ready</p>
                <p class="correctness-headline">4 Not Ready</p>--%>
                <asp:Repeater ID="rptrAnswers" runat="server">
                    <ItemTemplate>
                        <p class="correctness-headline<%# Container.ItemIndex < (Answers.Count - 1) ? " ready" : string.Empty %>">
                            <%# Eval("IndicatorCount") %> <%# Eval("AnswerText") %>
                        </p>
                    </ItemTemplate>
                </asp:Repeater>
                <p class="explanation">Culpa architecto at sit errorSapiente fugiat quod velit omnis sit quia est sed sintSit repudiandae labore molestias qui culpa adipisci sapiente aut id estDolorum in et velit saepe voluptates ad inventore voluptate expedita veniam error omnis
                    <a href="REPLACE">Text link goes here</a>
                    Eius tempora sunt est autIpsum enim dignissimos est cum perspiciatisDicta eum et optio ex necessitatibus autem quidem animi natusOptio minus qui blanditiis ex perspiciatis harum quibusdam inventore rerum sunt omnis</p>
                <div class="next-question">
                    <button type="button" class="button rs_skip">Start Over</button>
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
                        <!-- BEGIN PARTIAL: decision-lite/dl-list-item -->
                        <div class="search-result rs_read_this item-one" aria-role="main">
                            <button class="result-body rs_preserve">
                                <div class="result-topic">Should I consider alternatives to my public school?</div>
                                <div class="result-hover">
                                    <div class="hover-link-wrapper">
                                        <a href="REPLACE" class="topic-question">Should my child repeat a grade?</a>
                                    </div>
                                </div>
                            </button>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                        <!-- END PARTIAL: decision-lite/dl-list-item -->
                        <!-- BEGIN PARTIAL: decision-lite/dl-list-item -->
                        <div class="search-result rs_read_this item-two" aria-role="main">
                            <button class="result-body rs_preserve">
                                <div class="result-topic">Am I ready to have my child evaluated?</div>
                                <div class="result-hover">
                                    <div class="hover-link-wrapper">
                                        <a href="REPLACE" class="topic-question">Should my child repeat a grade?</a>
                                    </div>
                                </div>
                            </button>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-d' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                        <!-- END PARTIAL: decision-lite/dl-list-item -->
                        <!-- BEGIN PARTIAL: decision-lite/dl-list-item -->
                        <div class="search-result rs_read_this item-three" aria-role="main">
                            <button class="result-body rs_preserve">
                                <div class="result-topic">Am I ready to have my child evaluated?</div>
                                <div class="result-hover">
                                    <div class="hover-link-wrapper">
                                        <a href="REPLACE" class="topic-question">Should my child repeat a grade?</a>
                                    </div>
                                </div>
                            </button>
                            <span class="children-key">
                                <ul>
                                    <li><i class='child-a' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-b' title='CHILD NAME HERE'></i></li>
                                    <li><i class='child-e' title='CHILD NAME HERE'></i></li>
                                </ul>
                            </span>
                        </div>
                        <!-- END PARTIAL: decision-lite/dl-list-item -->
                    </div>
                    <!-- .results-wrapper -->
                </div>
                <!-- .results-outer-wrapper -->
            </div>
        </section>
    </div>
    <!-- .container -->
</div>
