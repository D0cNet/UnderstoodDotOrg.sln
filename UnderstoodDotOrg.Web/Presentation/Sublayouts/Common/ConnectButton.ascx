<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConnectButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.ConnectButton" %>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:PlaceHolder ID="viewConnect" runat="server" Visible="true">
            <asp:Button ID="btnConnect" CssClass="button" OnClick="btnConnect_Click" runat="server" />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="viewAccept" runat="server" Visible="false">
            <%-- future place to put accept/decline button --%>
        </asp:PlaceHolder>
    </ContentTemplate>
</asp:UpdatePanel>
