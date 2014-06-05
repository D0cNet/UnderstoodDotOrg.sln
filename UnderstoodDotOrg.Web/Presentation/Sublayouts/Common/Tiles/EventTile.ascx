<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventTile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles.EventTile" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="rs_read_this">
    <div class="header">
        <sc:FieldRenderer ID="frHeading" FieldName="Event Heading" EnclosingTag="h3" runat="server"></sc:FieldRenderer>
        <p><asp:Literal ID="ltlSubHeading" runat="server"></asp:Literal></p>
    </div>
    <div class="image">
        <sc:FieldRenderer ID="frEventImage" FieldName="Event Image" Parameters="mw=190&mh=106" runat="server"></sc:FieldRenderer>
    </div>
    <div class="footer">
        <asp:Hyperlink ID="hlLearnMore" runat="server"></asp:Hyperlink>
    </div>
</div>