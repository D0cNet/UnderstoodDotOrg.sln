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
                        <sc:FieldRenderer ID="frQuizIntro" runat="server" FieldName="Body Content" />

                    </p>

                    <div class="assessment-questions">
                        <div class="assessment-question-wrapper">
                            <asp:Repeater ID="rptQuestion" runat="server" OnItemDataBound="rptQuestion_ItemDataBound" OnItemCommand="rptQuestion_ItemCommand">
                                <ItemTemplate>
                                    <p class="assessment-question">
                                        <%--My child's favorite activity is:--%>
                                        <sc:FieldRenderer ID="frQuestion" runat="server" FieldName="Question Title" />
                                    </p>
                                    <asp:PlaceHolder ID="phBoolean" runat="server" Visible="false">
                                        <%--<button type="button" class="answer-choice-true">True</button>
                    <button type="button" class="answer-choice-false">False</button>--%>

                                        <asp:LinkButton ID="lbTrue" runat="server" Text="True" CommandName="True" Width="50"></asp:LinkButton>
                                        
                                        <asp:LinkButton ID="lbFalse" runat="server" Text="False" CommandName="False" Width="50"></asp:LinkButton>
                                        
                                        
                                        <%--<asp:Button ID="btnTrue" runat="server"  Text="True"  CssClass="answer-choice-true" />
                                        <asp:Button ID="btnFalse" runat="server" Text="False" CssClass="answer-choice-false"  />--%>
                                    </asp:PlaceHolder>
                                    <asp:PlaceHolder ID="phOption" runat="server" Visible="false">
                                        <asp:RadioButtonList ID="rblAnswer" runat="server" OnSelectedIndexChanged="rblAnswer_SelectedIndexChanged">
                                        </asp:RadioButtonList>
                                        <div class="radio-wrapper">

                                            <%-- <label>
                                                  <input />
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
                                    <hr />
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
        <div class="col col-5 offset-1 skiplink-sidebar rs_read_this">

            <%-- <sc:Placeholder ID="Placeholder1" Key="Quiz-Sidebar" runat="server" />--%>

            <div class="count-helpful">
                <a href="#count-helpful-sidebar"><span>34</span>Found this helpful</a>
            </div>
            <!-- END PARTIAL: helpful-count -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful sidebar" id="count-helpful-sidebar rs_read_this">
                <h4>Did you find this helpful?</h4>
                <ul>
                    <li>
                        <button class="button yes rs_skip">Yes</button>
                    </li>
                    <li>
                        <button class="button no gray rs_skip">No</button>
                    </li>
                </ul>
                <div class="clearfix"></div>

            </div>

            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->
            <div class="keep-reading">
                <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Articles/QuizKeepReadingControl.ascx" />
                <%-- <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>--%>
            </div>
            <!-- END PARTIAL: keep-reading -->


        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->
<sc:Placeholder ID="Placeholder2" Key="Mini-Tools-Container" runat="server" />

<!-- .container -->
<!-- END PARTIAL: tools -->
