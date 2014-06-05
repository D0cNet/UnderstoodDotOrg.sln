<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PromoTile.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles.PromoTile" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="rs_read_this">
    <div class="header">
        <sc:FieldRenderer ID="frTileTitle" FieldName="Tile Title" EnclosingTag="h3" runat="server"></sc:FieldRenderer>
        <sc:FieldRenderer ID="frTileDescription" FieldName="Tile Description" EnclosingTag="p" runat="server"></sc:FieldRenderer>
    </div>
    <asp:Panel ID="pnlImage" CssClass="image" Visible="false" runat="server">
        <sc:FieldRenderer ID="frTileImage" FieldName="Tile Image" Parameters="mw=190&mh=106" runat="server"></sc:FieldRenderer>
    </asp:Panel>
    <div class="footer">
        <sc:FieldRenderer ID="frTileLink1" FieldName="Tile Link 1" runat="server"></sc:FieldRenderer>
        <sc:FieldRenderer ID="frTileLink2" FieldName="Tile Link 2" runat="server"></sc:FieldRenderer>
    </div>
</div>