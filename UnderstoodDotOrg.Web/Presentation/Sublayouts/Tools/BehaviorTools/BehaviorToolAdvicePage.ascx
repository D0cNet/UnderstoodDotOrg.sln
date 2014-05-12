<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="BehaviorToolAdvicePage.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.BehaviorToolAdvicePage" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<div class="container article">
  <div class="row row-equal-heights">
    <!-- article -->
    <div class="col col-15 offset-1">
      <a href="REPLACE" class="back-to-previous left-of-first-next-prev-menu"><i class="icon-arrow-left-blue"></i> Back to task-to-task transitions</a>

      <!-- BEGIN PARTIAL: first-next-prev-menu -->
<div class="first-next-prev-menu arrows-gray">
  <span class="next-prev-text">Next Tip</span>
  <div class="rsArrow rsArrowLeft"><div class="rsArrowIcn"></div></div>
  <div class="rsArrow rsArrowRight"><div class="rsArrowIcn"></div></div>
</div><!-- end .first-next-prev-menu -->
<!-- END PARTIAL: first-next-prev-menu -->

      <!-- BEGIN PARTIAL: behavior-tip-detail -->
<div class="behavior-tip-detail">
  <header>
    <h2><sc:FieldRenderer ID="frTitle" runat="server" FieldName="Tip Title" /></h2>
  </header>
  <section class="tip-detail-content">
    <h3 class="first-sub-header">What you can do</h3>
    <sc:FieldRenderer ID="frWhatYouCanDo" runat="server" FieldName="What You Can Do" />
  </section> <!-- end tip-detail-content -->
  <section class="tip-detail-content">
    <h3>What you can say</h3>
    <sc:FieldRenderer ID="frWhatYouCanSay" runat="server" FieldName="What You Can Say" />
  </section> <!-- end tip-detail-content -->
  <section class="tip-detail-content no-border">
    <h3>Why this will help</h3>
    <sc:FieldRenderer ID="frWhyThisWillHelp" runat="server" FieldName="Why This Will Help" />
  </section> <!-- end tip-detail-content -->
</div> <!-- end behavior-tip-detail -->

<!-- END PARTIAL: behavior-tip-detail -->
    </div>

    <!-- spacer column -->
    <div class="col col-1 sidebar-spacer"></div>

    <!-- right bar -->
    <div class="col col-5 offset-1">
      <!-- BEGIN PARTIAL: helpful-count -->
<div class="count-helpful">
  <a href="REPLACE"><span>34</span>Found this helpful</a>
</div>
<!-- END PARTIAL: helpful-count -->
      <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span>19</span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->
      <!-- BEGIN PARTIAL: find-helpful -->
<div class="find-this-helpful sidebar">
   
  <h4>Did you find this helpful?</h4>
  <ul>
    <li>
      <button class="helpful-yes">Yes</button>
    </li>
    <li>
      <button class="helpful-no">No</button>
    </li>
  </ul>
  <div class="clearfix"></div>
   
</div>
<!-- END PARTIAL: find-helpful -->
      <!-- BEGIN PARTIAL: keep-reading -->
<div class="keep-reading">
  <h3>Keep Reading</h3>
  <ul>
    <li><a href="REPLACE">10 Tips to Help Kids Get Organized</a></li>
    <li><a href="REPLACE">How to Build a Homework Plan</a></li>
    <li class="last-child"><a href="REPLACE">Make Space for Learning: The Perfect Study Nook</a></li>
  </ul>
</div>
<!-- END PARTIAL: keep-reading -->
    </div>
  </div><!-- .row -->
</div><!-- .container -->

<div class="container">
  <div class="row row-equal-heights">
    <div class="col col-15 offset-1">
      <!-- BEGIN PARTIAL: find-helpful -->
<div class="find-this-helpful content">
   
  <h4>Did you find this helpful?</h4>
  <ul>
    <li>
      <button class="helpful-yes">Yes</button>
    </li>
    <li>
      <button class="helpful-no">No</button>
    </li>
  </ul>
  <div class="clearfix"></div>
   
</div>
<!-- END PARTIAL: find-helpful -->
    </div>

    <!-- spacer column -->
    <div class="col col-1 sidebar-spacer"></div>

    <!-- right bar -->
    <div class="col col-5 offset-1">
      <!-- BEGIN PARTIAL: second-next-prev-menu -->
<div class="second-next-prev-menu arrows-gray">
  <span class="next-prev-text">Next Tip</span>
  <div class="second-next-prev-menu-slider">
    <p class="next-prev-title">Start by demonstrating, then shift to supervising</p>
    <p class="next-prev-title">Start by demonstrating, then shift to supervising</p>
    <p class="next-prev-title">Start by demonstrating, then shift to supervising</p>
  </div>
</div><!-- end .second-next-prev-menu -->
<!-- END PARTIAL: second-next-prev-menu -->
    </div>
  </div><!-- .row -->
</div>