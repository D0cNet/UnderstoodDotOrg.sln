<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SocialCounter.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Tools.BehaviorTools.Widgets.SocialCounter" %>
  <!-- BEGIN PARTIAL: helpful-count -->
<div class="count-helpful">
  <a href="REPLACE"><span><asp:Literal ID="litHelpfulCount" runat="server" /></span>Found this helpful</a>
</div>
<!-- END PARTIAL: helpful-count -->
  <!-- BEGIN PARTIAL: comments-count -->
<div class="count-comments">
  <a href="REPLACE"><span><asp:Literal ID="litCommentsCount" runat="server" /></span>Comments</a>
</div>
<!-- END PARTIAL: comments-count -->