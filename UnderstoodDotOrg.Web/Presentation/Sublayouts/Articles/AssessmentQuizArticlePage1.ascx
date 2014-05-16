<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssessmentQuizArticlePage1.ascx.cs"
    Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.AssessmentQuizArticlePage1" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!-- BEGIN PARTIAL: assessment-quiz-error -->
<%--<div class="assessment-quiz-modal modal fade">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <p class="title">Oops.</p>
                <p>Please provide an answer for all questions before proceeding to the next page.</p>
                <p class="button-container group"><a href="#" class="button">Return to Quiz</a></p>
            </div>
            <!-- .modal-body -->
        </div>
        <!-- .modal-content -->
    </div>
    <!-- .modal-dialog -->
</div> --%>
<!-- .assessment-quiz-modal -->
<!-- END PARTIAL: assessment-quiz-error -->
<!-- BEGIN PARTIAL: pagetopic -->
<!-- Page Title -->
<%--<div class="container page-topic">
  <div class="row">
    <div class="col col-14 offset-1">
      
        <a href="REPLACE" class="back-to-previous"><i class="icon-arrow-left-blue"></i>Game & Skill Builders</a>
      
      <h1>What's Your Child's Learning Style</h1>
      
        <p class="page-subtitle">Lorem ipsum dolor sit amet, consectetur adipiscing elit nulla egestas</p>
      
    </div>
    
    <div class="col col-9">
      <!-- BEGIN PARTIAL: share-save -->
<div class="share-save-container">
  <div class="share-save-social-icon">
  	<div class="toggle">
	    <a href="REPLACE" class="socicon icon-facebook">Facebook</a><br />
	    <a href="REPLACE" class="socicon icon-twitter">Twitter</a><br />
	    <a href="REPLACE" class="socicon icon-googleplus">Google&#43;</a><br />
	    <a href="REPLACE" class="socicon icon-pinterest">Pinterest</a><br />
	</div>
  </div>
  <div class="share-save-icon">
    <h3>Share &amp; Save</h3>
    <!-- leave no white space for layout consistency -->
    <a href="REPLACE" class="icon icon-share">Share</a><span class="tools"><a href="REPLACE" class="icon icon-email">Email</a><a href="REPLACE" class="icon icon-save">Save</a><a href="REPLACE" class="icon icon-print">Print</a><a href="REPLACE" class="icon icon-remind">Remind</a><a href="REPLACE" class="icon icon-rss">RSS</a></span>
  </div>
</div>

<!-- END PARTIAL: share-save -->
    </div>
    
  </div>
</div><!-- .container -->  --%>
<!-- END PARTIAL: pagetopic -->
<div class="container article">
    <div class="row row-equal-heights">
        <!-- article -->
        <div class="col col-15 offset-1">
            <!-- BEGIN PARTIAL: assessment-quiz-1 -->
            <div class="container assessment-quiz">
                <div class="assessment-quiz-form">
                    <div class="assessment-quiz-pager">
                        Page 1 of 2
                    </div>
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

                                        <asp:LinkButton ID="lbTrue" runat="server" Text="True" Width="50" CommandName="True"></asp:LinkButton>
                                        <asp:LinkButton ID="lbFalse" runat="server" Text="False" Width="50" CommandName="False"></asp:LinkButton>

                                    </asp:PlaceHolder>
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
                                    <hr />
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--<asp:Literal ID="opresult" runat="server"></asp:Literal>
                            <asp:Literal ID="ddlresult" runat="server"></asp:Literal>--%>
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
        <select name="question3">
          <option value="">Select Activity</option>
          <option>Doing crafts or art projects</option>
          <option>Trying to solve mysteries, riddles, or crossword puzzles</option>
          <option>Writing a journal or blogging</option>
          <option>Reflecting on your life and your future</option>
        </select>
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
      </div> --%>
                    </div>
                    <!-- .assessment-questions -->
                    <div class="assessment-actions">
                        <%--s<input class="submit-button assessment-quiz-next" type="submit" value="Next" />--%>
                        <asp:Button CssClass="submit-button assessment-quiz-next" ID="btnNext" runat="server" OnClick="btnNext_Click" Text="Next" />
                    </div>
                </div>
                <!-- .assessment-quiz-form -->
            </div>
            <!-- .assessment-quiz -->
            <!-- END PARTIAL: assessment-quiz-1 -->
        </div>
        <div class="col col-1 sidebar-spacer">
        </div>
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
<%--<div class="container mini-tools-wrap" style="background-image: url(http://understood.org.local/Presentation/includes/img/bg-subtopic-minitools.jpg)">
    <div class="row">
        <div class="col col-8">
           
        </div>
        <!-- .col -->
    </div>
    <!-- .row -->
</div>--%>
<!-- .container -->
<!-- END PARTIAL: tools -->
