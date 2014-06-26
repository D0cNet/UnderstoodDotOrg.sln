<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TycePlayerResources.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components.TycePlayerResources" %>

<%= JSResources %>

<div id="rotation-overlay">
    <div>
        <img alt="Turn Your Phone" src="Presentation/includes/images/icon.turn.phone.png" />
    </div>
    <div>
        <h2>Please turn your phone to portrait view to interact with your experience</h2>
    </div>
</div>


<div class="modal fade modal-standard modal-begin" id="tyce-modal-begin" tabindex="-1" role="dialog" aria-hidden="true">
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

<div class="modal fade modal-standard modal-end" id="tyce-modal-begin" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <h2>You're Done!</h2>
                <p>You're done!</p>
                <div class="actions">
                    <a href="#" class="button button-close">Go Somewhere</a>
                </div>
            </div>
            <!-- /.modal-body -->
        </div>
        <!-- /.modal-content -->
    </div>
    <!-- /.modal-dialog -->
</div>
<!-- /.modal -->


<script language="JavaScript" type="text/javascript" src="http://admin.brightcove.com/js/BrightcoveExperiences.js"></script>
<script type="text/javascript" src="http://admin.brightcove.com/js/api/SmartPlayerAPI.js"></script>
<script type="text/javascript" src="http://files.brightcove.com/markup.min.js"></script>
<script type="text/javascript">

    // config for experience
    var experienceConfig = {
        isPersonalized: true,
        start: 0,
        steps: [
          {
              type: 'video',
              vid: {
                  'default': '<%= IntroductionVideo.WithoutSubtitlesVideoId %>',
                  'hardcoded': '<%= IntroductionVideo.WithSubtitlesVideoId %>'
              }
          },
          {
              type: 'sim'
          },
          {
              type: 'video',
              vid: {
                  'default': '<%= ExpertSummaryVideo.WithoutSubtitlesVideoId %>',
                  'hardcoded': '<%= ExpertSummaryVideo.WithSubtitlesVideoId %>'
              }
          },
          {
              type: 'video',
              vid: {
                  'default': '<%= ChildStoryVideo.WithoutSubtitlesVideoId %>',
                  'hardcoded': '<%= ChildStoryVideo.WithSubtitlesVideoId %>'
              }
          }
        ],
        next: '<%= NextPagePath %>'
    };

    // on dom ready init the experience
    $(function () {
        TYCE.init(experienceConfig);
    });

</script>
