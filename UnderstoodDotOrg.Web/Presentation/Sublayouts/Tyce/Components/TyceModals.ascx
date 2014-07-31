<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceModals.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components.TyceModals" %>

<script>
    $(document).ready(function () {
        
        $('select.reponsive-select-mobile').on('change', function() {
        if ($(this).val() == 'grade-after-highschool') {
          $('#tyce-modal-after-hs').modal('show');
          $(window).trigger('resize');
        }
      });
      $('button.tyce-after-highschool').on('click', function(e) {
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


        // $('div.tyce-on-demand-container.stories').easytabs({
        //     tabs: '.tab-controls li'
        // });

        $('.tyce-personalize').find('.button').on('click', function (e) {
            e.preventDefault();
            $("#tyce-modal-select-child").modal('show');
            $(window).trigger('resize');
        });



        // var $tyceModalAfterHighSchool = $('#tyce-modal-after-hs');

        // $('select.reponsive-select-mobile').on('change', function () {
        //     if ($(this).val() == 'grade-after-highschool') { //<-- replace value with guid
        //         $tyceModalAfterHighSchool.modal('show');
        //         $(window).trigger('resize');
        //     }
        // });

        // $('button.tyce-after-highschool').on('click', function () {
        //     $tyceModalAfterHighSchool.modal('show');
        //     $(window).trigger('resize');
        // });

        // $tyceModalAfterHighSchool.find('.button-close').on('click', function () {
        //     $tyceModalAfterHighSchool.modal('hide');
        // });

        // var $tyceModalNoChallenge = $('#tyce-modal-no-challenge');
        // $('#no-challenge').on('click', function () {
        //     $tyceModalNoChallenge.modal('show');
        //     $(window).trigger('resize');
        // });

        // $tyceModalNoChallenge.find('.button-close').on('click', function () {
        //     $tyceModalNoChallenge.modal('hide');
        // });

        //var $tyceModalBegin = $('#tyce-modal-begin');
        //$(".tyce-before-begin-button").on("click", function() {
        //    $tyceModalBegin
        //        .modal('show')
        //        .css('visibility', 'hidden')
        //        .on('shown.bs.modal', function () {
        //            $(window).trigger('resize');
        //            $tyceModalBegin.css('visibility', 'visible');
        //        });
        //});

        //$tyceModalBegin.find('.button-close').on('click', function () {
        //    $tyceModalBegin.modal('hide');
        //});
    });
</script>

<div class="modal fade modal-standard" id="tyce-modal-select-child" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <button type="button" class="close-overlay" data-dismiss="modal" aria-hidden="true">Close</button>
            <div class="modal-body rs_preserve rs_skip">
                <h2>Select your Child</h2>
                <p>Your profile contains <%= IsUserLoggedIn ? CurrentMember.Children.Count : 0 %> children. 
                   <%= PleaseSelectChild %></p>
                <fieldset>
                    <legend class="visuallyhidden">Select your Child</legend>
                    <ul class="input-buttons">
                        <asp:Repeater ID="rptrChildSelectionModal" runat="server">
                            <ItemTemplate>
                                <li>
                                    <input type="radio" name="tyce-child" id="tyce-child-<%# Eval("Id") %>">
                                    <label for="tyce-child-<%# Eval("Id") %>" data-grade-param="<%# Eval("GradeParam") %>"
                                        data-issue-params="<%# Eval("IssueParams") %>" class="tyce-child-select-label">
                                        <%# Eval("Label") %>
                                    </label>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                        <%--<li>
                            <input type="radio" name="tyce-child" id="tyce-child-02">
                            <label for="tyce-child-02">Cara, 8</label>
                        </li>
                        <li>
                            <input type="radio" name="tyce-child" id="tyce-child-03">
                            <label for="tyce-child-03">Stephanie, 11</label>
                        </li>--%>
                    </ul>
                </fieldset>
                <div class="actions rs_preserve rs_skip">
                    <a href="<%= TyceQuestionsPageUrl %>" class="button to-player-link">Ok let's go</a>
                    <a href="<%= TyceQuestionsPageUrl %>" class="button gray to-questions-link">Let Me Customize</a>
                </div>
            </div>
            <!-- /.modal-body -->
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->
<script type="text/javascript">
    $(document).ready(function () {
        var questionsPageUrl = "<%= TyceQuestionsPageUrl %>";
        var playerPageUrl = "<%= TycePlayerPageUrl %>";

        var $tyceModalSelectChild = $("#tyce-modal-select-child");
        var $tyceChildSelectLabel = $tyceModalSelectChild.find(".tyce-child-select-label");
        var $tyceModalActions = $tyceModalSelectChild.find(".modal-body>.actions");
        var $toPlayerLink = $tyceModalActions.children(".to-player-link");
        var $toQuestionsLink = $tyceModalActions.children(".to-questions-link");

        $tyceChildSelectLabel.on("click", function () {
            var $this = $(this);
            var gradeParam = $this.data("grade-param");
            var issueParams = $this.data("issue-params");

            var qs = issueParams;
            qs = gradeParam ? (qs ? qs + "&" + gradeParam : gradeParam) : qs;
            qs = qs ? "?" + qs : qs;

            if (gradeParam && issueParams) {
                $toPlayerLink.attr("href", playerPageUrl + qs);
                $toQuestionsLink.attr("href", questionsPageUrl + qs);
            } else {
                $toPlayerLink.attr("href", questionsPageUrl + qs);
                $toQuestionsLink.attr("href", questionsPageUrl + qs);
            }
        });
    });
</script>

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
