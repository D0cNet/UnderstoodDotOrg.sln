<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoResources.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.ExpertLive.VideoResources" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="player-container">
    <div class="player">
        <asp:Literal runat="server" ID="ltBrightCovePlayer"></asp:Literal>
    </div>
</div>
<div class="col col-18 offset-3">
    <!-- BEGIN PARTIAL: transcript-control -->
    <div class="transcript-container Video">
        <div class="read-more mobile-close">
            <a href="REMOVE">
                <asp:Literal runat="server" ID="ltVideoDetailShow"></asp:Literal><i class="icon-arrow-up-blue"></i></a>
        </div>
        <div class="transcript-wrap clearfix rs_read_this">
            <sc:fieldrenderer id="frVideoTranscript" runat="server" fieldname="Video Transcript" />

        </div>
        <div class="read-more read-more-bottom"></div>
    </div>
    <!-- END PARTIAL: transcript-control -->
</div>
<script type="text/javascript">
    runMobileCompatibilityScript('birghtcovePlayerObject');
</script>
<script type="text/javascript">brightcove.createExperiences();</script>
<script type="text/javascript">
    var player;
    var modVP;

    function myTemplateLoaded(experienceID) {
        player = brightcove.api.getExperience(experienceID);
        modVP = player.getModule(brightcove.api.modules.APIModules.VIDEO_PLAYER);
    }

    $('.video_resource_container .video_rotator .slideshow ul li:first').addClass('active-vd');

    $('.video_resource_container .video_rotator .slideshow ul li input').click(function () {
        $('.video_resource_container .video_rotator .slideshow ul li').removeClass('active-vd');
        $(this).parent().addClass('active-vd');
    });

    function onTemplateReady(evt) {
    }

    function onMediaComplete(videoid, title, desc) {
        $('.video_title').empty();
        $('.video_title').html(title);
        $('.video_para').empty();
        $('.video_para').html(desc);
        modVP.loadVideoByID(videoid);
    }
    </script>

