<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TycePlayerResources.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tyce.Components.TycePlayerResources" %>

<%= JSResources %>

<div id="rotation-overlay">
    <div>
        <sc:FieldRenderer ID="frRotationImage" runat="server" FieldName="Mobile Rotation Image"></sc:FieldRenderer>
    </div>
    <div>
        <h2><sc:FieldRenderer ID="frRotationText" runat="server" FieldName="Mobile Rotation Text"></sc:FieldRenderer></h2>
    </div>
</div>


<div class="modal fade modal-standard modal-begin" id="tyce-modal-begin" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-body">
                <h2><%= BeforeYouBeginTitle %></h2>
                <%= BeforeYouBeginContent %>
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
                <h2><%= YourDoneHeader %></h2>
                <%= YourDoneContent %>
                <div class="actions">
                    <a href="#" class="button button-close"><%= YourDoneLinkText %></a>
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

    $("#gameboard").addClass("<%= IssueItem.SimulationCssClass.Raw %>");

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
