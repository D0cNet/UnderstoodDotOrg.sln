<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Account.Common.ConnectButton" %>
<asp:Button ID="btnAnonConnect" CssClass="button" runat="server" />
<asp:UpdatePanel ID="pnlLoggedIn" runat="server">
    <ContentTemplate>
        <asp:Button  ID="btnConnect" CssClass="button" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel> 