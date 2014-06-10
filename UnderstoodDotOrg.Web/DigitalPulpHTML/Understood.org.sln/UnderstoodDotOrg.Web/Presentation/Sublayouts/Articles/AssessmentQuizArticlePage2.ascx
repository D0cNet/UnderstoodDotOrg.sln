<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssessmentQuizArticlePage2.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.AssessmentQuizArticlePage2" %>
<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->

<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: assessment-quiz-2 -->
            <div class="container assessment-quiz">
                <div class="assessment-quiz-form">

                    <div class="assessment-quiz-pager">Page 2 of 2</div>
                    <p class="assessment-quiz-intro">
                        <%--doloremque aut molestiae facere quo repellat commodi soluta iure distinctio natus dicta accusantium nesciunt amet sit autem et ipsa voluptatibus minima magnam ut error possimus--%>
                        <sc:fieldrenderer id="frQuizIntro" runat="server" fieldname="Body Content" />

                    </p>

                    <div class="assessment-questions">
                        <div class="assessment-question-wrapper">
                           <asp:Repeater ID="rptQuestion" runat="server" OnItemDataBound="rptQuestion_ItemDataBound">
                                <ItemTemplate>
                                    <p class="assessment-question">
                                        <%--My child's favorite activity is:--%>
                                        <sc:FieldRenderer ID="frQuestion" runat="server" FieldName="Question Title" />
                                    </p>
                                    <asp:PlaceHolder ID="phOption" runat="server" Visible="false">
                                        <asp:RadioButtonList ID="rblAnswer" runat="server" OnSelectedIndexChanged="rblAnswer_SelectedIndexChanged">
                                        </asp:RadioButtonList>

                                        <div class="radio-wrapper">
                                            <label>
                                                <%--  <input />
                                                <input type="radio" name="question" value="answer">
                                                        <span>Doing crafts or art projects
                                                            <sc:FieldRenderer ID="frOptAnswer" runat="server" FieldName="Answer" />
                                                        </span>
                                            </label>--%>
                                        </div>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phDropdown" runat="server" Visible="false">
                                        <asp:DropDownList ID="ddlAnswer" runat="server" OnSelectedIndexChanged="ddlAnswer_SelectedIndexChanged">
                                        </asp:DropDownList>

                                    </asp:PlaceHolder>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%-- <div class="assessment-question-wrapper">
                            <p class="assessment-question">My child's favorite activity is:</p>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question1" value="answer1">
                                    <span>Getting lost in a good book</span>
                                </label>
                            </div>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question1" value="answer2">
                                    <span>Doing crafts or art projects</span>
                                </label>
                            </div>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question1" value="answer3">
                                    <span>Trying to solve mysteries, riddles, or crossword puzzles</span>
                                </label>
                            </div>
                        </div>

                        <div class="assessment-question-wrapper">
                            <p class="assessment-question">My child's favorite activity is:</p>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question2" value="answer1">
                                    <span>Doing crafts or art projects</span>
                                </label>
                            </div>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question2" value="answer2">
                                    <span>Trying to solve mysteries, riddles, or crossword puzzles</span>
                                </label>
                            </div>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question2" value="answer3">
                                    <span>Writing a journal or blogging</span>
                                </label>
                            </div>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question2" value="answer4">
                                    <span>Reflecting on your life and your future</span>
                                </label>
                            </div>
                        </div>

                        <div class="assessment-question-wrapper">
                            <p class="assessment-question">My child's favorite activity is:</p>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question1" value="answer1">
                                    <span>Getting lost in a good book</span>
                                </label>
                            </div>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question1" value="answer2">
                                    <span>Doing crafts or art projects</span>
                                </label>
                            </div>
                            <div class="radio-wrapper">
                                <label>
                                    <input type="radio" name="question1" value="answer3">
                                    <span>Trying to solve mysteries, riddles, or crossword puzzles</span>
                                </label>
                            </div>
                        </div>--%>
                    </div>
                    <!-- .assessment-questions -->
                    <div class="assessment-actions">
                        <%--<input class="quiz-back-button quiz-back" type="button" value="Back">
                        <input class="submit-button quiz-next" type="submit" value="Submit">--%>
                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="quiz-back-button quiz-back" />
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="submit-button quiz-next" />
                    </div>

                </div>
                <!-- .assessment-quiz-form -->
            </div>
            <!-- .assessment-quiz -->

            <!-- END PARTIAL: assessment-quiz-2 -->
        </div>
        <div class="col col-1 sidebar-spacer"></div>
        <!-- right bar -->
        <div class="col col-5 offset-1">
            <sc:placeholder id="Placeholder1" key="Quiz-Sidebar" runat="server" />
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->
<sc:placeholder id="Placeholder2" key="Mini-Tools-Container" runat="server" />

<!-- .container -->
<!-- END PARTIAL: tools -->
