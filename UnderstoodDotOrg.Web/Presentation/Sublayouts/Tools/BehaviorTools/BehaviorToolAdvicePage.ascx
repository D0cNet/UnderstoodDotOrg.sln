<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="BehaviorToolAdvicePage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolAdvicePage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
  <div class="row row-equal-heights">
    <!-- article -->
    <div class="col col-15 offset-1">
      <sc:Sublayout ID="slTopNavigation" runat="server" Path="~/Presentation/Sublayouts/Tools/BehaviorTools/BehaviorToolsArticleTopNavigation.ascx" />

      <!-- BEGIN PARTIAL: behavior-tip-detail -->
<div class="behavior-tip-detail">
  <header>
    <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Tip Title" /></h2>
  </header>
  <section class="tip-detail-content">
    <h3 class="first-sub-header"><%= UnderstoodDotOrg.Common.DictionaryConstants.WhatYouCanDoLabel %></h3>
    <sc:FieldRenderer ID="frWhatYouCanDo" runat="server" FieldName="What You Can Do" />
  </section> <!-- end tip-detail-content -->
  <section class="tip-detail-content">
    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.WhatYouCanSayLabel %></h3>
    <sc:FieldRenderer ID="frWhatYouCanSay" runat="server" FieldName="What You Can Say" />
  </section> <!-- end tip-detail-content -->
  <section class="tip-detail-content no-border">
    <h3><%= UnderstoodDotOrg.Common.DictionaryConstants.WhyThisWillHelpLabel %></h3>
    <sc:FieldRenderer ID="frWhyThisWillHelp" runat="server" FieldName="Why This Will Help" />
  </section> <!-- end tip-detail-content -->
</div> <!-- end behavior-tip-detail -->

<!-- END PARTIAL: behavior-tip-detail -->
    </div>

    <!-- spacer column -->
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