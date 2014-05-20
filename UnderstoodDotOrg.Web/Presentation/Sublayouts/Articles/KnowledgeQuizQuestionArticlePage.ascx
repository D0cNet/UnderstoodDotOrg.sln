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
                <div class="question-counter">
                    <asp:Label ID="lblQuestionCounter" runat="server"></asp:Label>
                    <%--Question 1 of 10--%>
                </div>
                <h3><%--True or False? Kids with dyslexia can never learn what other kids learn.--%>
                    <sc:FieldRenderer ID="frQuestionTitle" runat="server" FieldName="Question" />
                </h3>
                <asp:Panel ID="pnlQuestion" runat="server" CssClass="answer-choices">
                    <%-- Two buttons for Boolean Question --%>
                    <h4 class="question-counter">
                    Question 1 of 10
                    </h4>
                    <h3>True or False? Kids with dyslexia can never learn what other kids learn.</h3>
                    <div class="answer-choices">
                    <button type="button" class="button answer-choice-true rs_skip">True</button>
                    <button type="button" class="button gray answer-choice-false rs_skip">False</button>
                    </div>
                    <asp:Panel ID="pnlTrueFalse" runat="server" CssClass="answer-choices" Visible="false">
                        <asp:PlaceHolder ID="phBoolean" runat="server">
                            <%--<button type="button" class="answer-choice-true">True</button>
                    <button type="button" class="answer-choice-false">False</button>--%>
                            <asp:Button ID="btnTrue" runat="server" Text="True" CssClass="button answer-choice-true rs_skip" OnClick="btnTrue_Click" />
                            <asp:Button ID="btnFalse" runat="server" Text="False" CssClass="button gray answer-choice-false rs_skip" OnClick="btnFalse_Click" />
                        </asp:PlaceHolder>
                    </asp:Panel>
                    <asp:Panel ID="pnlRadioQuestion" runat="server" Visible="false">
                        <%-- OR --%>
                        <%-- Options for list style Question --%>
                        <asp:PlaceHolder ID="phOption" runat="server">
                            <asp:RadioButtonList ID="rblAnswer" AutoPostBack="true" runat="server" OnSelectedIndexChanged="rblAnswer_SelectedIndexChanged">
                            </asp:RadioButtonList>
                        </asp:PlaceHolder>
                        <asp:PlaceHolder ID="phDropdown" runat="server">
                            <asp:DropDownList ID="ddlAnswer" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlAnswer_SelectedIndexChanged">
                            </asp:DropDownList>
                        </asp:PlaceHolder>
                   </asp:Panel>
                </asp:Panel>

                <asp:Panel ID="pnlResult" runat="server" Visible="false">
                    <p class="correctness-headline">
                        <span class="correct-incorrect correct"></span>
                        <asp:Label ID="lblCorrect" runat="server" Text="Correct"></asp:Label>
                        <asp:Label ID="lblIncorrect" runat="server" Text="Incorrect"></asp:Label>
                    </p>
                    <p class="explanation">
                        <sc:FieldRenderer ID="frTrueAnsDetail" runat="server" FieldName="True Answer" />
                        <sc:FieldRenderer ID="frFalseAnsDetail" runat="server" FieldName="False Answer" />

                    </p>
                    <div class="next-question">
                        <asp:Button runat="server" ID="btnResult" Text="Show Result" OnClick="btnResult_Click" />
                        <asp:Button runat="server" ID="btnNextQuestion" Text="Next Question" OnClick="btnNextQuestion_Click" />
                    </div>
                </asp:Panel>
            </div>
            <div class="knowledge-quiz">
              <h4 class="question-counter">
                Question 4 of 10
              </h4>
              <fieldset>
                <legend>Which of the following symptoms might signal dyslexia?</legend>
                <div class="answer-choices">
                  <ul>
                    <li><label for="r1"><input type="radio" "id="r1" name="example"> <span>Doing crafts or art projects</span></label></li>
                    <li><label for="r2"><input type="radio" "id="r2" name="example"> <span>Trying to solve mysteries, riddles, or crossword puzzles</span></label></li>
                    <li><label for="r3"><input type="radio" "id="r3" name="example"> <span>Writing a journal or blogging</span></label></li>
                    <li><label for="r4"><input type="radio" "id="r4" name="example"> <span>Reflecting on your life and your future</span></label></li>
                  </ul>
                </div>
              <fieldset>
            </fieldset></fieldset></div>
        </div>

        <div class="col col-1 sidebar-spacer"></div>

        <!-- right bar -->
        <div class="col col-5 offset-1">
            <!-- BEGIN PARTIAL: helpful-count -->
            <div class="count-helpful">
                <a href="REPLACE"><span>34</span>Found this helpful</a>
            </div>
            <!-- END PARTIAL: helpful-count -->
            <!-- BEGIN PARTIAL: find-helpful -->
            <div class="find-this-helpful sidebar">

                <h4>Did you find this helpful?</h4>
                <ul>
                    <li>
                        <button class="helpful-yes">Yes</button>
                    </li>
                    <li>
                        <button class="helpful-no">No</button>
                    </li>
                </ul>
                <div class="clearfix"></div>

            </div>
            <!-- END PARTIAL: find-helpful -->
            <!-- BEGIN PARTIAL: keep-reading -->
            <div class="keep-reading">
                <h3>Keep Reading</h3>
                <ul>
                    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
                    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
                    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
                </ul>
            </div>
            <!-- END PARTIAL: keep-reading -->
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->

<!-- BEGIN PARTIAL: tools -->
<!-- Tools -->

<div runat="server" visible="false" class="container mini-tools-wrap" style="background-image: url(http://understood.org.local/Presentation/includes/img/bg-subtopic-minitools.jpg)">

    <div class="row">

        <div class="col col-8">

            <!-- BEGIN PARTIAL: tool-technology -->
            <section class="mini-tool" id="mini-tool-apps">

                <header>
                    <h3>Apps &amp; Technology</h3>
                    <p>Find technology to help your child.</p>
                </header>

                <div class="form select-container">

                    <fieldset>

                        <label for="tool-tech-issue" class="visuallyhidden">Select behavior issue</label>
                        <select name="tool-tech-issue" id="tool-tech-issue" aria-required="true">
                            <option value="">Select behavior issue</option>
                            <option>Attention & hyperactivity issues</option>
                            <option>Reading issues</option>
                            <option>Writing issues</option>
                            <option>Math issues</option>
                            <option>Trouble with motor skills</option>
                            <option>Trouble with spoken and written language</option>
                            <option>Trouble understanding visual information</option>
                        </select>

                        <label for="tool-tech-grade" class="visuallyhidden">Select grade</label>
                        <select name="tool-tech-grade" id="tool-tech-grade" aria-required="true">
                            <option value="">Select grade</option>
                            <option>Grade 1</option>
                            <option>Grade 2</option>
                            <option>Grade 3</option>
                            <option>Grade 4</option>
                        </select>

                        <label for="tool-tech-alltech" class="visuallyhidden">All Technology</label>
                        <select name="tool-tech-alltech" id="tool-tech-alltech" aria-required="true">
                            <option value="">All technology</option>
                            <option>Apps</option>
                            <option>Games</option>
                            <option>Websites</option>
                        </select>

                        <label for="tool-tech-platforms" class="visuallyhidden">All Platforms &amp; Devices</label>
                        <select name="tool-tech-platforms" id="tool-tech-platforms" aria-required="true">
                            <option value="">All platforms &amp; devices</option>
                            <option>iPhone</option>
                            <option>iPod Touch</option>
                            <option>iPad</option>
                        </select>

                    </fieldset>

                    <div class="submit-button-wrap">
                        <input class="submit-button" type="submit" value="Submit">
                    </div>

                </div>
                <!-- .form -->

                <footer class="powered-by">
                    <h5>powered by</h5>
                    <div class="logo">
                        <img class="logo-img" alt="Common Sense" src="http://understood.org.local/Presentation/includes/img/logo.partner.commonsense.png" />
                    </div>
                </footer>

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-technology -->

        </div>
        <!-- .col -->

        <div class="col col-8">

            <!-- BEGIN PARTIAL: tool-experts -->
            <section class="mini-tool" id="mini-tool-experts">

                <header>
                    <h3>Advice from Behavior Experts</h3>
                    <p>Find practical strategies for handling common behavior challenges.</p>
                </header>

                <div class="form select-container">

                    <fieldset>

                        <label for="tool-advice-issue" class="visuallyhidden">Select behavior issue</label>
                        <select name="tool-advice-issue" id="tool-advice-issue" aria-required="true">
                            <option value="">Select challenge</option>
                            <option>Attention & hyperactivity issues</option>
                            <option>Reading issues</option>
                            <option>Writing issues</option>
                            <option>Math issues</option>
                            <option>Trouble with motor skills</option>
                            <option>Trouble with spoken and written language</option>
                            <option>Trouble understanding visual information</option>
                        </select>

                        <label for="tool-advice-grade" class="visuallyhidden">Select grade</label>
                        <select name="tool-advice-grade" id="tool-advice-grade" aria-required="true">
                            <option value="">Select grade</option>
                            <option>Grade 1</option>
                            <option>Grade 2</option>
                            <option>Grade 3</option>
                            <option>Grade 4</option>
                        </select>

                    </fieldset>

                    <div class="submit-button-wrap">
                        <input class="submit-button" type="submit" value="Submit">
                    </div>

                </div>
                <!-- .form -->

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-experts -->

        </div>
        <!-- .col -->

        <div class="col col-8">

            <!-- BEGIN PARTIAL: tool-school-ratings -->
            <section class="mini-tool" id="mini-tool-ratings">

                <header>
                    <h3>School Ratings</h3>
                    <p>Find a new school or rate your child's</p>
                </header>


                <div class="tabs">
                    <!-- NO WHITE SPACE BETWEEN As to PRESERVE LAYOUT -->
                    <a href="#by-location">By Location</a><a href="#by-name">By Name</a>
                </div>

                <ul class="tab-content-wrap">



                    <li class="tab-content" id="by-location">

                        <div class="form">

                            <fieldset>

                                <label for="tool-ratings-zip" class="visuallyhidden"></label>
                                <input type="text" name="tool-ratings-zip" id="tool-ratings-zip" placeholder="Enter zip code or city &amp; state">
                            </fieldset>

                            <div class="submit-button-wrap">
                                <input class="submit-button" type="submit" value="Submit">
                            </div>

                        </div>
                        <!-- .form -->

                    </li>
                    <!-- .by-location -->


                    <li class="tab-content" id="by-name">

                        <div class="form select-container">

                            <fieldset>

                                <label for="tool-ratings-school" class="visuallyhidden"></label>
                                <input type="text" name="tool-ratings-school" id="tool-ratings-school" placeholder="Enter school name">

                                <label for="tool-ratings-state" class="visuallyhidden">Select a state</label>
                                <select name="tool-ratings-state" id="tool-ratings-state" aria-required="false">
                                    <option value="">Select a state</option>
                                    <option>Alabama</option>
                                    <option>Arizona</option>
                                    <option>Arkansas</option>
                                </select>

                            </fieldset>

                            <div class="submit-button-wrap">
                                <input class="submit-button" type="submit" value="Submit">
                            </div>

                        </div>
                        <!-- .form -->

                    </li>
                    <!-- .by-name -->


                </ul>
                <!-- .tab-content-wrap -->

                <footer class="powered-by">
                    <h5>powered by</h5>
                    <div class="logo">
                        <img class="logo-img" alt="Great Schools" src="http://understood.org.local/Presentation/includes/img/logo.partner.greatschools.png" />
                    </div>
                </footer>

            </section>
            <!-- .module -->
            <!-- END PARTIAL: tool-school-ratings -->

        </div>
        <!-- .col -->

    </div>
    <!-- .row -->

</div>
<!-- .container -->
<!-- END PARTIAL: tools -->
