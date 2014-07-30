<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VideoArticle.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Articles.VideoArticle" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<sc:Sublayout ID="Sublayout1" Path="~/Presentation/Sublayouts/Articles/Shared/FoundHelpfulAndCommentCounts.ascx" runat="server"></sc:Sublayout>

<div class="container article">
  <div class="row">
    <div class="col col-24 skiplink-content" aria-role="main" aria-role="main">
        <div class="player-container">
            <div class="player">
                <sc:FieldRenderer ID="frVideo" runat="server" FieldName="Video Embed" />
            </div>
        </div>
    </div>
  </div>
</div>

<div class="container">
  <div class="row">
    <div class="col col-18 offset-3">
      <!-- BEGIN PARTIAL: transcript-control -->
        <div id="divTranscript" runat="server" class="transcript-container Video">
          <div class="read-more mobile-close">
            <a href="#"><%= UnderstoodDotOrg.Common.DictionaryConstants.Articles_CloseTranscriptButtonText %><i class="icon-arrow-up-blue"></i></a>
          </div>
          <div class="transcript-wrap clearfix rs_read_this">
            <div>
                <sc:FieldRenderer ID="frTranscript" runat="server" FieldName="Transcript" />
            </div>   
          </div>             
          <div class="read-more read-more-bottom"></div>
        </div>
<!-- END PARTIAL: transcript-control -->
    </div>
  </div>
</div><!-- .container -->
<!-- .container -->

<div class="container">
    <div class="row">
        <div class="col col-15 offset-1">
            <div class="rs_about_author rs_read_this">
                <!-- BEGIN PARTIAL: reviewed-by -->
                <sc:Sublayout ID="SBReviewedBy" runat="server" Path="~/Presentation/Sublayouts/Articles/Shared/ReviewerInfo.ascx" />
                <!-- END PARTIAL: reviewed-by -->

                <!-- BEGIN PARTIAL: find-helpful -->
                <sc:Sublayout Path="~/Presentation/Sublayouts/Articles/Shared/DidYouFindThisHelpful.ascx" runat="server"></sc:Sublayout>
                <!-- END PARTIAL: find-helpful -->
            </div>
        </div>
    </div>
    <!-- .row -->
</div>
<!-- .container -->
