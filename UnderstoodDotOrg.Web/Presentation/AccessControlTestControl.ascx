<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccessControlTestControl.ascx.cs" Inherits="UnderstoodDotOrg.Web.Presentation.AccessControlTest1" %>

<div>
    User Logged In?
    <asp:Literal ID="uxLoggedInState" runat="server"></asp:Literal>
</div>
<div>
    User Screen name:
    <asp:Literal ID="uxScreenName" runat="server"></asp:Literal>
</div>
<div>
    International User Status:
    <asp:Literal ID="uxInternationalUser" runat="server"></asp:Literal>
</div>
<div>
    Terms & Conditions: 
    <asp:Literal ID="uxTandC" runat="server"></asp:Literal>
</div>

<div>
    <asp:Button ID="btnLoggedIn" runat="server" OnClick="btnLoggedIn_Click" Text="Check Logged In" />
    <asp:Button ID="btnCommunity" runat="server" OnClick="btnCommunity_Click" Text="Check Community" />
    <asp:Button ID="btnInternational" runat="server" OnClick="btnInternational_Click" Text="Check International" />
    <asp:Button ID="btnTermsAndConditions" runat="server" OnClick="btnTermsAndConditions_Click" Text="Check T&Cs" />
</div>
