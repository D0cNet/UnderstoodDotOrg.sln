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
            <div class="modal-body">
                <h2>Select your Child</h2>
                <p>Your profile contains three children. Please select the child you'd like to base this experience on.</p>
                <fieldset>
                    <legend class="visuallyhidden">Select your Child</legend>
                    <ul class="input-buttons">
                        <li>
                            <input type="radio" name="tyce-child" id="tyce-child-01">
                            <label for="tyce-child-01">David, 7</label>
                        </li>
                        <li>
                            <input type="radio" name="tyce-child" id="tyce-child-02">
                            <label for="tyce-child-02">Cara, 8</label>
                        </li>
                        <li>
                            <input type="radio" name="tyce-child" id="tyce-child-03">
                            <label for="tyce-child-03">Stephanie, 11</label>
                        </li>
                    </ul>
                </fieldset>
                <div class="actions">
                    <asp:LinkButton ID="lbLetsGo" runat="server" CssClass="button">Ok let's go</asp:LinkButton>
                    <a href="REPLACE" class="button gray">Let Me Customize</a>
                </div>
            </div>
            <!-- /.modal-body -->
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->

<div class="modal fade modal-standard" id="tyce-modal-begin" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <h2>Before You Begin&hellip;</h2>
                <p>The interactive experiences you’re going to see are designed to be as relevant as possible – but as you know, every child is unique.</p>
                <p>We would never assume that your child's nature or challenges and environment could be captured by a web site, but we believe that these interactives can give you some new perspectives and insights</p>
                <div class="actions">
                    <a href="REPLACE" class="button button-close">Continue</a>
                </div>
            </div>
            <!-- /.modal-body -->
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->

<div class="modal fade modal-standard" id="tyce-modal-no-challenge" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <h2>Other Challenges</h2>
        <p>At this time, we have experiences for five common learning and attention issues. If you're looking for a specific issue you don't see here, we encourage you to explore our <a href="REPLACE">Learning &amp; Attention</a> Issues section - we have a wide array of content that explores the full spectrum of learning issues.</p>
        <p>Also - make sure you check back soon. We're always adding more content. <a href="REPLACE">If you have any suggestions</a> for this tool, <a href="REPLACE">contact us and share your thoughts</a>.</p>
        <div class="actions">
          <a href="REPLACE" class="button button-close">OK</a>
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->

<div class="modal fade modal-standard" id="tyce-modal-after-hs" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-body">
        <h2>After High School</h2>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non viverra turpis. Curabitur tristique porta purus nec tincidunt. Donec augue turpis, lobortis suscipit sagittis a, sodales a tellus. Sed neque tortor, consequat et ligula ac, venenatis facilisis neque. In porttitor congue magna, ut elementum massa semper.</p>
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non viverra turpis. Curabitur tristique porta purus nec tincidunt. Donec augue turpis.</p>
        <div class="actions">
          <a href="REPLACE" class="button button-close">OK</a>
        </div>
      </div><!-- /.modal-body -->
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
