<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Assessment Quiz.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.Assessment_Quiz" %>


<!-- BEGIN PARTIAL: pagetopic -->


<!-- END PARTIAL: pagetopic -->
<div class="container article knowledge-quiz-page">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: knowledge-quiz-a13a -->
            <div class="knowledge-quiz">
                <div class="question-counter">
                    <asp:Label ID="lblPageCounter" runat="server"></asp:Label>
                    <sc:FieldRenderer ID="frResultHeadline" runat="server" FieldName="Quiz Result Headline" Visible="false"></sc:FieldRenderer>
                    <%--Question 1 of 10--%>
                </div>
                <p class="explanation">
                    <sc:fieldrenderer id="frEndExplanation" runat="server" fieldname="Detail" visible="false"></sc:fieldrenderer></p>
                <asp:Repeater ID="rptPageQuestions" runat="server" OnItemDataBound="rptPageQuestions_ItemDataBound">
                    <HeaderTemplate>

                    </HeaderTemplate>
                    <ItemTemplate>
                        <h3><%--True or False? Kids with dyslexia can never learn what other kids learn.--%>
                            <sc:FieldRenderer ID="frQuestionTitle" runat="server" FieldName="Question" />
                        </h3>
                        <asp:Panel ID="pnlQuestion" runat="server" CssClass="answer-choices">
                            <asp:Panel ID="pnlTrueFalse" runat="server" Visible="false">
                                <button type="button" id="btnTrue" runat="server" class="button answer-choice-true rs_skip" >True</button>
                                <button type="button" id="btnFalse" runat="server" class="button gray answer-choice-false rs_skip" >False</button>
                            </asp:Panel>
                            <asp:Panel ID="pnlRadioQuestion" CssClass="test" runat="server" Visible="false">
                                <%-- OR --%>
                                <%-- Options for list style Question --%>
                                <asp:RadioButtonList ValidationGroup="vlgPageQuestions" ID="rblAnswer" runat="server" RepeatLayout="UnorderedList">
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator id="rflRadioAnswer"
                                    controltovalidate="rblAnswer"
                                    validationgroup="vlgPageQuestions"
                                    runat="server">
                                </asp:RequiredFieldValidator>
                           </asp:Panel>
                            <asp:Panel ID="pnlDropDown" runat="server" Visible="false">
                                <asp:DropDownList ValidationGroup="vlgPageQuestions" ID="ddlQuestion" runat="server"/>
                                <asp:RequiredFieldValidator id="rflDropDownAnswer"
                                    controltovalidate="ddlQuestion"
                                    validationgroup="vlgPageQuestions"
                                    runat="server">
                                </asp:RequiredFieldValidator>
                                <br />
                                <br />
                            </asp:Panel>
                        </asp:Panel>
                    </ItemTemplate>
                    <FooterTemplate>

                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hfKeyValuePairs" runat="server" />
                <script>
                    var Answers = {};
                    var hiddenField = $("[id*='hfKeyValuePairs']");

                    $("ul[id*='rptPageQuestions_rblAnswer']").each(function () {
                        $radioControl = $(this);

                        $radioControl.find("li input").click(function () {

                            Answers[$radioControl.data("id")] = $(this).val();
                            hiddenField.val(JSON.stringify(Answers));
                        })
                    })

                    $("select[id*='rptPageQuestions_ddlQuestion']").change(function () {
                        Answers[$(this).data("id")] = $(this).val();
                        hiddenField.val(JSON.stringify(Answers));
                    })

                    $("[id*='btnTrue'], [id*='btnFalse']").click(function () {
                        Answers[$(this).data("id")] = $(this).html();
                        hiddenField.val(JSON.stringify(Answers));
                    })

                    function checkValidation() {
                        if (Page_ClientValidate("vlgPageQuestions")) {
                            $(".assessment-quiz-next").off("click");
                        }
                    }
                </script>
                <br />
                <br />
                <br />
                <br />
                <div class="next-question">
                    <button type="button" runat="server" id="btnPrevPage" onserverclick="btnPrevPage_Click" onclick="checkValidation();" class="button no gray reload-page assessment-quiz-next" visible="false">Back</button>
                    <button type="button" runat="server" id="btnNextPage" onserverclick="btnNextPage_Click" onclick="checkValidation();" class="button reload-page assessment-quiz-next" >Next</button>
                    <button type="button" runat="server" id="btnShowResults" onserverclick="btnResult_Click" onclick="checkValidation();" class="button assessment-quiz-next" visible="false" >Show Results</button>
                </div>
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
            <sc:Sublayout Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/KeepReading.ascx" runat="server"></sc:Sublayout>
            <!-- END PARTIAL: keep-reading -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->

<sc:Sublayout Path="~/Presentation/Sublayouts/Articles/QuizMiniToolsContainer.ascx" runat="server"></sc:Sublayout>
<!-- .container -->
