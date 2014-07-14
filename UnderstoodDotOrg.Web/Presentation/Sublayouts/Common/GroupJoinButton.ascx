<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupJoinButton.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.Sublayouts.Common.GroupJoinButton" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Button  ID="btnJoin" CssClass="button rs_skip" OnClientClick="document.body.style.cursor='wait';return true;" 
             OnClick="btnJoin_Click"  runat="server" />
    </ContentTemplate>
</asp:UpdatePanel> 
 