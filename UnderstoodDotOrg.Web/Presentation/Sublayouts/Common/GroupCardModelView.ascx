<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupCardModelView.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.GroupCardModelView" %>
<div class="row skiplink-feature">
  <header class="groups-heading">
    <div class="col col-24 rs_read_this">
      <div class="col col-18 title">
        <h2><asp:Literal ID="litTitle" runat="server"></asp:Literal></h2>
      </div>
      <!-- BEGIN PARTIAL: community/groups_private_heading -->
<!--groups private partial-->
<div class="col groups-private">
  <p class="col">Only members can see the conversations</p>
  <i class="icon"></i>
</div>
<!-- END PARTIAL: community/groups_private_heading -->
    </div>
  </header><!-- end .main-header -->
</div>
<div class="row">
  <div class="col col-24 featured-group group-summary clearfix rs_read_this">
    <div class="topic col col-17">
      <div class="feature-image col col-4">
          <asp:Image ImageUrl="#" ID="imgModeratorImage" runat="server" /></div>
      <div class="description col col-17"><p>
          <asp:Literal Text="" ID="litDesc" runat="server" /></p>
        <p><span class="leader">
            <asp:Literal Text="" ID="litModeratorScreenName" runat="server" /></span>, <asp:Literal Text="" ID="litModeratorTitle" runat="server" /></p>
      </div>
    </div>
    <div class="statistics col col-5">
      <div class="meta">
        <p class="members">
            <asp:Literal Text="" ID="litNumMembers" runat="server" /> Members</p>
        <p class="discussions"><asp:Literal Text="" ID="litNumThreads" runat="server" /> Discussions</p>
      </div>
      <div class="mobile-search-box">
      <h3>Find a conversation</h3>
        <!-- BEGIN PARTIAL: community/groups_search_form -->
<!--groups search form-->
    <fieldset class="group-search-form mobile-group-search-form">
      <label for="group-search-text" class="visuallyhidden" aria-hidden="true">Search</label>
      <input type="text" class="group-search" id="group-search-text" name="group-search" placeholder="Search">
      <input class="group-search-button" type="submit" value="Go">
    </fieldset>
<!-- END PARTIAL: community/groups_search_form -->
      </div>
    </div><!-- end .statistics -->
  </div> <!-- end .featured-group and .group-summary -->
</div>