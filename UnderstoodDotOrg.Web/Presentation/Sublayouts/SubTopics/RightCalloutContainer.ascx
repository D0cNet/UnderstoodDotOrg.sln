<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RightCalloutContainer.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.SubTopics.RightCalloutContainer" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="col col-7 sidebar">

    <asp:Repeater ID="rptWidgets" runat="server">
        <ItemTemplate>
            <asp:PlaceHolder ID="phToolWrapperStart" runat="server" Visible="false">
                <section class="mini-tool rs_read_this">
            </asp:PlaceHolder>
            <sc:sublayout id="slWidget" runat="server" />
            <asp:PlaceHolder ID="phToolWrapperEnd" runat="server" Visible="false"></section></asp:PlaceHolder>
        </ItemTemplate>
    </asp:Repeater>

</div>
