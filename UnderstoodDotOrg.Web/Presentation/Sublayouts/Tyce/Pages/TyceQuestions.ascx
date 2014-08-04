<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceQuestions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceQuestions" %>
<div class="container tyce-step-wrap">
    <div class="row">
        <div class="col col-22 offset-1">
            <div class="tyce-step rs_read_this" id="tyce-step-1">
                <header>
                    <h2>
                        <span class="num">1</span>
                        <label for="personalize-grade-mobile" class="tyce-step-question"><%= Model.QuestionOneText.Rendered %></span>
                        <span class="tyce-step-answer" style="display: none;"><%= Model.QuestionOneAnswerText.Rendered %></span>
                        <span class="instructions"><%= Model.QuestionOneInstructions.Rendered %></span>
                    </h2>
                    <div class="info tyce-step-why">
                        <a href="REPLACE" class="rs_preserve"><%= Model.WhyAreWeAskingText.Rendered %></a>
                    </div>
                    <a href="REPLACE" class="button tyce-step-change" style="display: none;">Change</a>
                </header>
                <div class="body">
                    <select id="personalize-grade-mobile" class="responsive-select-mobile" required aria-required="true">
                        <option value="">Select a grade</option>
                        <asp:Repeater ID="rptrGradeOptions" runat="server" 
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components.ChildGradeItem">
                            <ItemTemplate>
                                <option value="<%# Item.ID.Guid.ToString() %>"><%# Item.ChildDemographic.Title.Rendered %></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                    <input type="hidden" name="personalize-grade" class="reponsive-select-full-input" value="">
                    <ul id="personalize-grade-desktop-select" class="reponsive-select-full-options">
                        <asp:Repeater ID="rptrGradeButtons" runat="server" 
                            ItemType="UnderstoodDotOrg.Domain.SitecoreCIG.Poses.Pages.TYCE.Components.ChildGradeItem">
                            <ItemTemplate>
                                <li>
                                    <button type="button" class="grade <%# Item.ChildDemographic.CssClass.Rendered %> grade-question-button" 
                                        data-grade-id="<%# Item.ID.Guid.ToString() %>">
                                        <%# Item.ChildDemographic.Title.Rendered %>
                                    </button>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!-- #tyce-step-1 -->
            <div class="tyce-step rs_read_this" id="tyce-step-2">
                <header>
                    <h2>
                        <span class="num">2</span>
                        <span class="tyce-step-question"><%= Model.QuestionTwoText.Rendered %></span>
                        <span class="tyce-step-answer" style="display: none;"><%= Model.QuestionTwoAnswerText.Rendered %></span>
                        <span class="instructions"><%= Model.QuestionTwoInstructions.Rendered %></span>
                    </h2>
                    <div class="info tyce-step-why">
                        <a href="REPLACE"><%= Model.WhyAreWeAskingText.Rendered %></a>
                    </div>
                    <a href="REPLACE" class="button tyce-step-change" style="display: none;">Change</a>
                </header>
                <div class="body">
                    <fieldset>
                        <ul class="input-buttons">
                            <asp:Repeater ID="rptrChildIssues" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <input type="checkbox" id="tyce-issue-<%# Eval("Id") %>" data-issue-id="<%# Eval("Id") %>" 
                                            class="tyce-issue"<%# PresetIssues.Contains((Guid)Eval("Id")) ? "checked=\"checked\"" : string.Empty %>>
                                        <label for="tyce-issue-<%# Eval("Id") %>"><%# Eval("Title") %></label>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </fieldset>
                    <div class="action">
                        <button type="button" class="button complete-answer" style="display: none;">Continue</button>
                        <a href="REPLACE" id="no-challenge"><%= Model.DontSeeChildHereText.Rendered %></a>
                    </div>
                </div>
                <div class="body" style="display:none;">
                    <ul class="tyce-issues">
                        <asp:Repeater ID="rptrIssueSummaries" runat="server">
                            <ItemTemplate>
                                <li class="issue" data-issue-id="<%# Eval("Id") %>" style="display: none;">
                                    <h3><%# Eval("Title") %></h3>
                                    <%# Eval("Abstract") %>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <button type="button" class="button submit-answers-button tyce-before-begin-button" style="display:none;" runat="server"
                        onserverclick="btnStartSimulation_Click"><%= Model.GetStartedButtonText.Rendered %></button>
                </div>
            </div>
            <!-- #tyce-step-2 -->
            <input type="hidden" id="hfGradeId" runat="server" class="hfGradeId" />
            <input type="hidden" id="hfIssueIds" runat="server" class="hfIssueIds" />
        </div>
    </div>
</div>
<!-- .tyce-step-wrap -->
<% if (PresetGrade.HasValue) { %>
<script type="text/javascript">
    $(window).load(function () {
        $("#personalize-grade-desktop-select .grade-question-button").filter(function () {
            return $(this).data("grade-id") == "<%= PresetGrade.Value.ToString() %>";
        }).trigger("click");
    });
</script>
<% } %>