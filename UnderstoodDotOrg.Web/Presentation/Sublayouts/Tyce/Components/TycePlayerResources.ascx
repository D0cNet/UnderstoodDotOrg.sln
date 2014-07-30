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
            <div class="modal-body rs_read_this">
                <h2><%= BeforeYouBeginTitle %></h2>
                <%= BeforeYouBeginContent %>
                <div class="actions rs_preserve rs_skip">
                    <a href="#" class="button button-close">Continue</a>
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
            <div class="modal-body rs_read_this">
                <h2><%= YourDoneHeader %></h2>
                <%= YourDoneContent %>
                <div class="actions rs_preserve rs_skip">
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


<script language="JavaScript" type="text/javascript" src="/presentation/includes/js/BrightcoveExperiences.js"></script>
<script type="text/javascript" src="/presentation/includes/js/SmartPlayerAPI.js"></script>
<script type="text/javascript" src="/presentation/includes/js/markup.min.js"></script>
<script type="text/javascript">

    // config for experience
    var experienceConfig = {
        // whether or not this is a personalized experience
        isPersonalized: <%= IsPersonalized.ToString().ToLower() %>,
        // start step of the experience, should always be set at 0
        start: 0,
        // steps for experience
        steps: [
            <% if (IsPersonalized) { %>
            {
                // type: video or sim
                type: 'video',
                // vid: object with default and hardcoded id
                vid: {
                    // id of defaut vid
                    'default': '<%= IntroductionVideo.WithoutSubtitlesVideoId %>',
                    // id of vid with hardcoded subtitles
                    'hardcoded': '<%= IntroductionVideo.WithSubtitlesVideoId %>'
                }
            },
            {
                // simulation type
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
            <% } else if (IsStandaloneSimulation) { %>
            {
                type: 'sim'
            }
            <% } else { %>
            {
                type: 'video',
                vid: {
                    'default': '<%= OnDemandVideo.WithoutSubtitlesVideoId %>',
                    'hardcoded': '<%= OnDemandVideo.WithSubtitlesVideoId %>'
                }
            }
            <% } %>
        ],
        // path to where the next button should take user at the end of the simulation
        next: '<%= NextPagePath %>',
        // config for simulation
        simConfig : {
            // the language of the sim
            // language: 'en' or 'es'
            language: '<%= ContextLanguage.InnerItem["Iso"] %>',
            // the mode of the presentation
            // presentationMode: 'normal' or 'standalone'
            presentationMode: '<%= IsPersonalized ? "normal" : "standalone" %>'
        }
    };

    // on dom ready init the experience
    $(function () {
        TYCE.init(experienceConfig);
    });

</script>
