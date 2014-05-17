<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DecisionToolQuestionPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.DecisionTool.DecisionToolQuestionPage" %>
<!-- END PARTIAL: pagetopic-dl -->
<div class="container dl-quiz-container q-a">
    <div class="row">
        <div class="col col-24 dl-quiz-wrapper">
            <div class="dl-quiz rs_read_this question one offset-1 rs_read_this skiplink-content">
                <h4 class="question-counter">
                    Question <%= CurrentIndicationQuestionIndex + 1 %> of <%= IndicationQuestionsCount %>
                </h4>
                <h3><%= CurrentIndicationQuestion.DisplayText.Rendered %></h3>
                <div id="divAnswerButtons" runat="server" class="answer-choices answer-wrapper">
                    <button type="button" id="btnIndicationAnswer1" runat="server" class="button answer-choice-true rs_skip"></button>
                    <button type="button" id="btnIndicationAnswer2" runat="server" class="button answer-choice-false rs_skip"></button>
                </div>        
                <div id="divAnswerRadios" runat="server" class="assessment-questions answer-wrapper">
                    <div class="assessment-question-wrapper">
                        <fieldset>
                            <asp:Repeater ID="rptrAnswerRadios" runat="server" 
                                ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components.DecisionIndicationAnswerItem">
                                <ItemTemplate>
                                    <div class="radio-wrapper">
                                        <label for="q4r1">
                                            <input type="radio" name="question4" value="" data-answer-index="<%# GetAnswerIndex(Item) %>" 
                                                data-indication-answer-id="a<%# Item.ID.Guid.ToString() %>">
                                            <span><%# Item.DisplayText.Rendered %></span>
                                        </label>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </fieldset>
                    </div>
                </div>
                <!-- .assessment-questions -->
                <asp:Repeater ID="rptrIndicationAnswers" runat="server" 
                    ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.DecisionTool.Components.DecisionIndicationAnswerItem">
                    <ItemTemplate>
                        <span class="a<%# Item.ID.Guid %>" style="display:none;">
                            <p class="correctness-headline">You Answered: <%# Item.DisplayText.Rendered %></p>
                            <p class="explanation"><%# Item.Abstract.Rendered %></p>
                        </span>
                    </ItemTemplate>
                </asp:Repeater>
                <input type="hidden" id="hfAnswerIndex" runat="server" class="hfAnswerIndex" />
                <div class="next-question" style="display:none;">
                    <button type="button" runat="server" onserverclick="SubmitAndProceed_Click" class="button rs_skip">Next Question</button>
                </div>
            </div>
        </div>
    </div>
</div>
