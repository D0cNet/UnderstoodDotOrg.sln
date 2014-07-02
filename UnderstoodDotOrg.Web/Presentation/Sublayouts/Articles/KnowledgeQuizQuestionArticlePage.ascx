<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KnowledgeQuizQuestionArticlePage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.KnowledgeQuizQuestionrArticlePage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: pagetopic -->


<!-- END PARTIAL: pagetopic -->
<div class="container article knowledge-quiz-page">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: knowledge-quiz-a13a -->
            <div class="knowledge-quiz">
                <div id="divQuestionsRight" class="results-indicators" runat="server" visible="false">
                    <asp:Repeater ID="rptCorrectAnswers" runat="server" OnItemDataBound="rptCorrectAnswers_ItemDataBound">
                        <HeaderTemplate>

                        </HeaderTemplate>
                        <ItemTemplate>
                            <span id="spanResult" runat="server"></span>
                        </ItemTemplate>
                        <FooterTemplate>

                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <p class="correctness-headline"><asp:Literal ID="litTextResults" runat="server"></asp:Literal></p>
                <p class="explanation"><sc:FieldRenderer ID="frEndExplanation" runat="server" FieldName="Explanation"></sc:FieldRenderer></p>
                <div class="question-counter" id="question-count">
                    <asp:Label ID="lblQuestionCounter" runat="server"></asp:Label>
                    <%--Question 1 of 10--%>
                </div>
                <h3><%--True or False? Kids with dyslexia can never learn what other kids learn.--%>
                    <sc:FieldRenderer ID="frQuestionTitle" runat="server" FieldName="Question" />
                </h3>
                <asp:Panel ID="pnlQuestion" runat="server" CssClass="answer-choices">
                    <asp:Panel ID="pnlTrueFalse" runat="server" Visible="false">
                        <button type="button" id="btnTrue" runat="server" class="button gray answer-choice-true rs_skip" onserverclick="btnTrue_Click">True</button>
                        <button type="button" id="btnFalse" runat="server" class="button gray answer-choice-false rs_skip" onserverclick="btnFalse_Click">False</button>
                    </asp:Panel>
                    <asp:Panel ID="pnlRadioQuestion" CssClass="test" runat="server" Visible="false">
                        <%-- OR --%>
                        <%-- Options for list style Question --%>
                        <asp:RadioButtonList ID="rblAnswer" AutoPostBack="true" runat="server" OnSelectedIndexChanged="rblAnswer_SelectedIndexChanged" RepeatLayout="UnorderedList">
                        </asp:RadioButtonList>
                   </asp:Panel>
                </asp:Panel>

                <asp:Panel ID="pnlResult" runat="server" Visible="false">
                    <p class="correctness-headline">
                        <span id="spanCurrentAnswerResult" runat="server" class="correct-incorrect correct"></span>
                        <asp:Label ID="lblCorrect" runat="server" Text="Correct"></asp:Label>
                        <asp:Label ID="lblIncorrect" runat="server" Text="Incorrect"></asp:Label>
                    </p>
                    <p class="explanation">
                        <sc:FieldRenderer ID="frExplanation" runat="server" FieldName="Answer Explanation" />
                    </p>
                    <div class="next-question">
                        <button type="button" runat="server" id="btnResult" onserverclick="btnResult_Click" class="button" >Show Result</button>
                        <button type="button" runat="server" id="btnNextQuestion" onserverclick="btnNextQuestion_Click" class="button" >Next Question</button>
                    </div>
                </asp:Panel>
                <div class="next-question">
                    <button type="button" runat="server" id="btnTakeQuizAgain" onserverclick="btnTakeQuizAgain_Click" class="button" visible="false" >Take Quiz Again</button>
                </div>
            </div>
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1">
            
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulCountOnlySideColumn.ascx" runat="server"></sc:Sublayout>

            <!-- BEGIN PARTIAL: find-helpful -->
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpfulSideBar.ascx" runat="server"></sc:Sublayout>
            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->
            <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" runat="server"></sc:Sublayout>
            <!-- END PARTIAL: keep-reading -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->
<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/QuizTryMoreQuizzes.ascx" runat="server"></sc:Sublayout>

<sc:Sublayout Path="~/Presentation/Sublayouts/Section/SectionTools.ascx" runat="server"></sc:Sublayout>
<!-- .container -->
<!-- END PARTIAL: tools -->
<script>
    $(function () {
        if(<%= JumpToAnswer.ToString().ToLower() %>)
            location.href = "#question-count";
    })
</script>
