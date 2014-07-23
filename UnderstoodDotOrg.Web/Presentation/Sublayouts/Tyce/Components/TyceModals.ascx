<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TyceModals.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components.TyceModals" %>

<script>
    $(document).ready(function () {
        $('div.tyce-on-demand-container.stories').easytabs({
            tabs: '.tab-controls li'
        });

        $('.tyce-personalize').find('.button').on('click', function () {
            $("#tyce-modal-select-child").modal('show');
            $(window).trigger('resize');
        });

        var $tyceModalAfterHighSchool = $('#tyce-modal-after-hs');

        $('select.reponsive-select-mobile').on('change', function () {
            if ($(this).val() == 'grade-after-highschool') { //<-- replace value with guid
                $tyceModalAfterHighSchool.modal('show');
                $(window).trigger('resize');
            }
        });

        $('button.tyce-after-highschool').on('click', function () {
            $tyceModalAfterHighSchool.modal('show');
            $(window).trigger('resize');
        });

        $tyceModalAfterHighSchool.find('.button-close').on('click', function () {
            $tyceModalAfterHighSchool.modal('hide');
        });

        var $tyceModalNoChallenge = $('#tyce-modal-no-challenge');
        $('#no-challenge').on('click', function () {
            $tyceModalNoChallenge.modal('show');
            $(window).trigger('resize');
        });

        $tyceModalNoChallenge.find('.button-close').on('click', function () {
            $tyceModalNoChallenge.modal('hide');
        });

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
      <div class="modal-body rs_read_this">
        <h2><%= OtherChallengesHeader %></h2>
        <%= OtherChallengesContent %>
          <a href="REPLACE" class="button button-close">OK</a>
        <div class="actions rs_preserve rs_skip">
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

<div class="modal fade modal-standard" id="tyce-modal-after-hs" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body rs_read_this">
        <h2><%= AfterHighSchoolHeader %></h2>
        <%= AfterHighSchoolContent %>
          <a href="REPLACE" class="button button-close">OK</a>
        <div class="actions rs_preserve rs_skip">
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
