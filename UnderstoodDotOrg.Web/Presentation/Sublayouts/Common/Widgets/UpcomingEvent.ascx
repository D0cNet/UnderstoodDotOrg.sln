<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UpcomingEvent.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Widgets.UpcomingEvent" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!-- BEGIN PARTIAL: featured-event -->
<div class="featured-event rs_read_this">
  <h4><sc:FieldRenderer ID="frWidgetTitle" runat="server" FieldName="Widget Title" /></h4>
  <h3><a href="<%= EventUrl %>"><%= EventTitle %></a></h3>
  <p><strong><%= EventDate %></strong><br><%= EventTime %><br><%= Expert %></p>
</div><!-- .featured-event -->
<!-- END PARTIAL: featured-event -->