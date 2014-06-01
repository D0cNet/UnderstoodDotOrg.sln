<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Recommendation_Icons.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Recommendation.Recommendation_Icons" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: children-key -->
<div class="container child-content-indicator recos">
  <!-- Key -->
  <div class="row">
    <div class="col col-23 offset-1">
      <div class="children-key" aria-hidden="true">
        <ul>
            <asp:ListView runat="server" ID="lvChildren" ItemType="UnderstoodDotOrg.Domain.Membership.Child">
                <ItemTemplate>
                    <li><i class="child-<%# getLetter(Container.DisplayIndex) %>"></i>for <%# Item.Nickname %></li>
                </ItemTemplate>
            </asp:ListView>
          <%--<li><i class="child-a"></i>for Michael</li>
          <li><i class="child-b"></i>for Elizabeth</li>
          <li><i class="child-c"></i>for Ethan</li>
          <li><i class="child-d"></i>for Jeremy</li>
          <li><i class="child-e"></i>for Franklin</li>--%>
        </ul>
      </div><!-- .children-key --> 
    </div><!-- .col --> 
  </div><!-- .row --> 
</div><!-- .child-content-indicator --> 
<!-- END PARTIAL: children-key -->