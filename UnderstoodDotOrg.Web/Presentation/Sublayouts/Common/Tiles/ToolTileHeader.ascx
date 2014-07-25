<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolTileHeader.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.Tiles.ToolTileHeader" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="header">
    <h3>
        <sc:FieldRenderer ID="frTileTitle" FieldName="Tile Title" runat="server" />
    </h3>
    <p>
        <sc:FieldRenderer ID="frTileDescription" FieldName="Tile Description" runat="server" />
    </p>
</div>