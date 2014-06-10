<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Parents Group Recommended.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.Parents_Group_Recommended" %>
<div class="container">
    <div class="row">
          <div class="container rs_read_this parent-groups-recommended-rs-wrapper">
            <header class="groups-heading">
              <!-- BEGIN PARTIAL: community/breadcrumb_menu -->
<!--breadcrumb menu-->
<a href="REPLACE" ID="ref_ParentGroup" runat="server" class="back-to-previous rs_skip">
  <i class="icon-arrow-left-blue"></i>
    <asp:Literal Text="" ID="litBackLink" runat="server" /> 
</a>
<!-- END PARTIAL: community/breadcrumb_menu -->
              <h2>
                  <asp:Literal Text="" ID="litRecommendHeader" runat="server" /></h2>
              <!-- BEGIN PARTIAL: community/groups_private_heading -->
<!--groups private partial-->
<div class="col groups-private">
  <p class="col">
      <asp:Literal Text="" ID="litGroupPrivacy" runat="server" /></p>
  <i class="icon"></i>
</div>
<!-- END PARTIAL: community/groups_private_heading -->
            </header>
            <div class="col col-24 message-box">
              <p>
                  <asp:Literal Text="" ID="litViewProfileLink1" runat="server" /> </p>
            </div>
          </div>
    </div>

    <div class="group-summary-container">
      <!-- BEGIN PARTIAL: community/group_summary -->
        <asp:PlaceHolder ID="groupList"  runat="server" /> 

    <!-- END PARTIAL: community/group_summary -->
    </div>


    <!-- Show More -->
    <!-- BEGIN PARTIAL: community/show_more -->
<!--Show More-->
<div class="container show-more rs_skip">
  <div class="row">
    <div class="col col-24">
      <a class="show-more-link " href="#" data-path="community/group-summary" data-container="group-summary-container" data-item="row" data-count="3">Show More<i class="icon-arrow-down-blue"></i></a>
    </div>
  </div>
</div><!-- .show-more -->
<!-- END PARTIAL: community/show_more -->
    <!-- .show-more -->

  <%--<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator ">
  <!-- Key -->
  <div class="row">
    <div class="col col-23 offset-1">
      <div class="children-key" aria-hidden="true">
        <ul>
          <li><i class="child-a"></i>for Michael</li>
          <li><i class="child-b"></i>for Elizabeth</li>
          <li><i class="child-c"></i>for Ethan</li>
          <li><i class="child-d"></i>for Jeremy</li>
          <li><i class="child-e"></i>for Franklin</li>
        </ul>
      </div><!-- .children-key --> 
    </div><!-- .col --> 
  </div><!-- .row --> 
</div><!-- .child-content-indicator --> 
<!-- END PARTIAL: children-key -->--%>
    <sc:Sublayout runat="server" Path="~/Presentation/Sublayouts/Recommendation/Recommendation Icons.ascx" />
  </div>
