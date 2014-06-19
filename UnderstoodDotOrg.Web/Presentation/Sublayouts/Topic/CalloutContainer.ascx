<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalloutContainer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Topic.CalloutContainer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN ELEMENT: Split Modules -->
<div class="container split-modules">
  <div class="row">
    <div class="col col-12">

      <sc:Sublayout ID="slUpcomingEvent" Path="~/Presentation/Sublayouts/Common/Widgets/UpcomingEvent.ascx" runat="server" />

    </div>
    <div class="col col-12">

      <!-- BEGIN PARTIAL: get-better-recommendations -->
<div class="get-better-recommendations-container">
  <div class="skiplink-toolbar  rs_read_this get-better-recommendations split">
    <div class="get-recommendations">
      <h4>Get Better Recommendations <button class="popover-link rs_preserve"><i class="icon-question-mark tooltip rs_skip">more information</i></button></h4>
      <div class="popover-container rs_skip">
        <p><strong>Why are we asking this?</strong> Lorem ipsum tincidunt ut laoreet dolore magna aliqua quis nostrud exerci tation ullamcorper consequat. Duis autem vel eum iriure consequat, vel illum.</p>
      </div>
      <h3>Has your child been formally evaluated for learning &amp; attention issues?</h3>
      <ul>
        <li><a href="REPLACE" class="button">Yes</a></li><li><a href="REPLACE" class="button">No</a></li><li><a href="REPLACE" class="button">In Progress</a></li><li class="complete-profile"><a href="REPLACE" class="rs_skip">Complete my full profile</a></li>
      </ul>
    </div><!-- .get-recommendations -->
    <div class="thank-you rs_skip">
      <h4>Thank You!</h4>
      <p>You've completed <span class="total-completed">3</span> out of <span class="total-questions">100</span> questions.</p>
      <a href="REPLACE" class="button">Complete my full profile</a>
    </div><!-- .thank-you -->
  </div><!-- .get-better-recommendations -->
</div><!-- .get-better-recommendations-container --> 
<!-- END PARTIAL: get-better-recommendations -->

    </div>
  </div>
</div>

<!-- END ELEMENT: Split Modules -->