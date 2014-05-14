<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceQuestions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceQuestions" %>
<div class="container tyce-step-wrap">
    <div class="row">
        <div class="col col-22 offset-1">
            <div class="tyce-step" id="tyce-step-1">
                <header>
                    <h2>
                        <span class="num">1</span>
                        <%= PageItem.QuestionOneText.Rendered %>
                    </h2>
                    <div class="info">
                        <a href="REPLACE">Why are we asking this?</a>
                    </div>
                </header>
                <div class="body">
                    <label for="personalize-grade-mobile" class="visuallyhidden">
                        <%= PageItem.QuestionOneText.Rendered %>:</label>
                    <%--<asp:DropDownList ID="ddlPersonalizeGradeMobile" runat="server" CssClass="personalize-grade-mobile responsive-select-mobile" required
                        aria-required="true">
                    </asp:DropDownList>--%>
                    <select id="personalize-grade-mobile" class="responsive-select-mobile" required aria-required="true">
                        <asp:Repeater ID="rptrGradeOptions" runat="server">
                            <ItemTemplate>
                                <option value="<%# Eval("Id") %>"><%# Eval("Title") %></option>
                            </ItemTemplate>
                        </asp:Repeater>
                    </select>
                    <input type="hidden" name="personalize-grade" class="reponsive-select-full-input" value="">
                    <ul id="personalize-grade-desktop-select" class="reponsive-select-full-options">
                        <asp:Repeater ID="rptrGradeButtons" runat="server">
                            <ItemTemplate>
                                <li>
                                    <button type="button" class="grade <%# Eval("CssClass") %>" data-grade-id="<%# Eval("Id") %>"><%# Eval("Title") %></button></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <!-- #tyce-step-1 -->
            <div class="tyce-step" id="tyce-step-2">
                <header>
                    <h2>
                        <span class="num">2</span>
                        <%= PageItem.QuestionTwoText.Rendered %>
                        <span class="instructions"><%= PageItem.QuestionTwoInstructions.Rendered %></span></h2>

                    <div class="info">
                        <a href="REPLACE">Why are we asking this?</a></div>
                </header>
                <div class="body">
                    <fieldset>
                        <legend class="visuallyhidden">
                        <%= PageItem.QuestionTwoText.Rendered %></legend>
                        <ul class="input-buttons">
                            <asp:Repeater ID="rptrChildIssues" runat="server">
                                <ItemTemplate>
                                    <li>
                                        <input type="checkbox" name="tyce-issue-<%# Eval("Id") %>">
                                        <label for="tyce-issue-<%# Eval("Id") %>">Reading</label>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </fieldset>
                    <div class="action">
                        <button class="button">Continue</button>
                        <a href="REPLACE" id="no-challenge">Don't see your child's challenge listed here?</a>
                    </div>
                </div>
            </div>
            <!-- #tyce-step-2 -->
        </div>
    </div>
</div>
<!-- .tyce-step-wrap -->
