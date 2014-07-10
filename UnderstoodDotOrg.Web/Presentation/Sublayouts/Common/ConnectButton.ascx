<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ConnectButton" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:Button  ID="btnConnect" CssClass="button" OnClick="btnConnect_Click"  runat="server" />
    </ContentTemplate>
</asp:UpdatePanel> 
 