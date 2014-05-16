<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BehaviorToolsAdviceVideoPage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolsAdviceVideoPage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
  <div class="row row-equal-heights">
    <!-- article -->
    <div class="col col-15 offset-1">
      <sc:Sublayout ID="slTopNavigation" runat="server" Path="~/Presentation/Sublayouts/Tools/BehaviorTools/BehaviorToolsArticleTopNavigation.ascx" />

      <!-- BEGIN PARTIAL: in-this-video -->
<div class="expert-advice-wrapper">
  <div class="expert-video">
    <h2><sc:FieldRenderer runat="server" FieldName="Tip Title" /></h2>
      <div class="player-container">
        <div class="player">
            <sc:FieldRenderer runat="server" FieldName="Video Embed" />
        </div>
      </div>
  </div> <!-- end expert-video -->
  <div class="in-this-video">
    <h2>In this video</h2>
    <sc:FieldRenderer runat="server" FieldName="Video Description" />
  </div> <!-- end in-this-video -->
</div> <!-- end expert-advice-wrapper -->

<!-- END PARTIAL: in-this-video -->
    </div>

    <div class="col col-1 sidebar-spacer"></div>

    <!-- right bar -->
    <div class="col col-5 offset-1">
        <sc:Sublayout ID="slSocialCounter" runat="server" Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/SocialCounter.ascx" />

        <sc:Sublayout ID="slHelpfulVote" runat="server" Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/HelpfulVote.ascx" Parameters="AdditionalCSSClass=sidebar" />

        <sc:Sublayout ID="slKeepReading" runat="server" Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/KeepReading.ascx" />

    </div>
  </div><!-- .row -->
</div><!-- .container -->


<div class="container">
  <div class="row row-equal-heights">
    <div class="col col-15 offset-1">
      <sc:Sublayout ID="slHelpfulVoteWide" runat="server" Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/HelpfulVote.ascx" Parameters="AdditionalCSSClass=content" />
    </div>

    <!-- spacer column -->
    <div class="col col-1 sidebar-spacer"></div>

    <!-- right bar -->
    <div class="col col-5 offset-1">
      <sc:Sublayout ID="slTipCarousel" runat="server" Path="~/Presentation/Sublayouts/Tools/BehaviorTools/Widgets/TipCarousel.ascx" />
    </div>
  </div><!-- .row -->
</div>