<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommunityContainer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Community.CommunityContainer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div id="community-page" class="<%= AdditionalCssClass %> <%= ArchiveCssClass %>">
    <sc:Placeholder ID="phContainer" Key="middle" runat="server" />
</div>
