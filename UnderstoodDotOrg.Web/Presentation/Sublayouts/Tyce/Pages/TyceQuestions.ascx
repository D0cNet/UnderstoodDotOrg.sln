<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceQuestions.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Pages.TyceQuestions" %>
<div class="container tyce-step-wrap">
    <div class="row">
        <div class="col col-22 offset-1">
            <div class="tyce-step rs_read_this" id="tyce-step-1">
                <header>
                    <h2>
                        <span class="num">1</span>
                        <span class="tyce-step-question"><%= Model.QuestionOneText.Rendered %></span>
                        <span class="tyce-step-answer" style="display: none;"><%= Model.QuestionOneAnswerText.Rendered %></span>
                        <span class="instructions"><%= Model.QuestionOneInstructions.Rendered %></span>
                    </h2>
                    <div class="info tyce-step-why">
                        <a href="REPLACE" class="rs_preserve"><%= Model.WhyAreWeAskingText.Rendered %></a>
                    </div>
                    <a href="REPLACE" class="button tyce-step-change" style="display: none;">Change</a>
                </header>
                <div class="body">
                    <label for="personalize-grade-mobile" class="visuallyhidden">
                        <%= Model.QuestionOneText.Rendered %>:</label>
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
                        <legend class="visuallyhidden">
                            <%= Model.QuestionTwoText.Rendered %></legend>
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

<div class="modal fade modal-standard" id="tyce-modal-after-hs" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body rs_read_this">
        <h2>After High School</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non viverra turpis. Curabitur tristique porta purus nec tincidunt. Donec augue turpis, lobortis suscipit sagittis a, sodales a tellus. Sed neque tortor, consequat et ligula ac, venenatis facilisis neque. In porttitor congue magna, ut elementum massa semper.</p>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non viverra turpis. Curabitur tristique porta purus nec tincidunt. Donec augue turpis.</p>
        <div class="actions rs_preserve rs_skip">
          <a href="#" class="button button-close">OK</a>
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

<div class="modal fade modal-standard" id="tyce-modal-why-ask-step-1" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body rs_read_this">
        <h2>Why are we asking this?</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
        <div class="actions rs_preserve rs_skip">
          <a href="#" class="button button-close">OK</a>
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

<div class="modal fade modal-standard" id="tyce-modal-no-challenge" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <h2>Other Challenges</h2>
        <p>At this time, we have experiences for five common learning and attention issues. If you're looking for a specific issue you don't see here, we encourage you to explore our <a href="REPLACE">Learning &amp; Attention</a> Issues section - we have a wide array of content that explores the full spectrum of learning issues.</p>
        <p>Also - make sure you check back soon. We're always adding more content. <a href="REPLACE">If you have any suggestions</a> for this tool, <a href="REPLACE">contact us and share your thoughts</a>.</p>
        <div class="actions rs_preserve rs_skip">
          <a href="#" class="button button-close">OK</a>
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

<div class="modal fade modal-standard" id="tyce-modal-why-ask-step-2" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body rs_read_this">
        <h2>Why are we asking this?</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>
        <div class="actions rs_preserve rs_skip">
          <a href="#" class="button button-close">OK</a>
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->


<script>
$(document).ready(function() {
  $('select.reponsive-select-mobile').on('change', function() {
    if ($(this).val() == 'grade-after-highschool') {
      $('#tyce-modal-after-hs').modal('show');
      $(window).trigger('resize');
    }
  });
  $('button.tyce-after-hs').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-after-hs').modal('show');
    $(window).trigger('resize');
  });

  $('#tyce-modal-after-hs').find('.button-close').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-after-hs').modal('hide');
  });
  $('#tyce-step-1 .tyce-step-why a').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-why-ask-step-1').modal('show');
    $(window).trigger('resize');
  });

  $('#tyce-modal-why-ask-step-1').find('.button-close').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-why-ask-step-1').modal('hide');
  });

    $('#no-challenge').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-no-challenge').modal('show');
    $(window).trigger('resize');
  });

  $('#tyce-modal-no-challenge').find('.button-close').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-no-challenge').modal('hide');
  });

  $('#tyce-step-2 .tyce-step-why a').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-why-ask-step-2').modal('show');
    $(window).trigger('resize');
  });

  $('#tyce-modal-why-ask-step-2').find('.button-close').on('click', function(e) {
    e.preventDefault();
    $('#tyce-modal-why-ask-step-2').modal('hide');
  });

});
</script>